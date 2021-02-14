using BridgestoneLibras.Data;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

namespace BridgestoneLibras.Controllers
{
    public class RespostasController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;
        Document Document = new Document();

        List<Status> listaStatus = new List<Status>();

        //the framework handles this
        public RespostasController(ApplicationDbSpecContext db,
            ILogger<OperadorController> log,
            IConfiguration iconfiguration)
        {
            _db = db;
            _log = log;
            _iconfiguration = iconfiguration;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Departamento()
        {
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);

            return Json(repDepartamento.Combo(repDepartamento.Consultar(dp), "Selecione"));
        }

        public ActionResult Maquinas(int idDepartamento)
        {
            TB_MAQUINA maquina = new TB_MAQUINA();
            maquina.id_departamento = idDepartamento;
            MaquinaRepository repMaquina = new MaquinaRepository(_db);

            return Json(repMaquina.Combo(repMaquina.Consultar(maquina), "Selecione"));
        }

        public ActionResult MaquinaParte(int idMaquina)
        {
            TB_MAQUINAPARTE parte = new TB_MAQUINAPARTE();
            parte.id_maquina = idMaquina;
            MaquinaParteRepository repMaquina = new MaquinaParteRepository(_db);

            return Json(repMaquina.Combo(repMaquina.Consultar(parte), "Selecione"));
        }

        public ActionResult Formularios(int idParteMaquina)
        {
            TB_FORMULARIO f = new TB_FORMULARIO();
            f.id_parteMaquina = idParteMaquina;
            FormularioRepository RepForm = new FormularioRepository(_db);
            return Json(RepForm.Combo(RepForm.Consultar(f), "Selecione"));
        }

        public ActionResult StatusFormularios()
        {
            TB_STATUS_FORMULARIO f = new TB_STATUS_FORMULARIO();

            StatusFormularioRepository RepForm = new StatusFormularioRepository(_db);
            return Json(RepForm.Combo(RepForm.Consultar(f), "Selecione"));
        }

        public ActionResult Consulta([FromBody] TB_RESPOSTA mydata)
        {
            RespostaRepository respostaRepository = new RespostaRepository(_db);
            List<TB_RESPOSTA> listRespostas = new List<TB_RESPOSTA>();
            var dados = respostaRepository.ConsultarRelatorio(mydata);


            //De para informacao tipo 1 e 2 

            DescricaoMultiplaEscolhaRepository desc = new DescricaoMultiplaEscolhaRepository(_db);
            foreach (var item in dados)
            {

                if (item.id_tipoResposta == 1)
                {
                    TB_DescricaoMultiplaEscolha t = new TB_DescricaoMultiplaEscolha();

                    t.id = item.id_tipoResposta;
                    var list = desc.Consultar(t).Where(x=> x.id ==  Convert.ToInt32( item.valor)).FirstOrDefault().nome;

                    item.DescMutiplaEscolha = list;

                }
            }

            //Agrupa pelo idPreenchimento
            var quantidadesFormulariosRespondidos = (from a in dados
                                                     where a.id_formulario == mydata.id_formulario
                                                     group a by a.idPreenchimento into g
                                                     select new { g.Key, Count = g.Count() });

            ArrayList montaArray = new ArrayList();

            foreach (var item in quantidadesFormulariosRespondidos)
            {
                montaArray.Add(dados.Where(x => x.idPreenchimento == item.Key).ToList());
            }

            
            return Json(montaArray);
        }

        public ActionResult Consulta_perguntaFilhoRelatorio(int idPreenchimento, int id_formulario, int idPai)
        {
            FilhoRepository filhoRep = new FilhoRepository(_db);
            TB_FILHO filho = new TB_FILHO
            {
                idPreenchimento = idPreenchimento,
                id_formulario = id_formulario,
                idPai = idPai
            };

            var dados = filhoRep.Consulta_perguntaFilhoRelatorio(filho);

            DescricaoMultiplaEscolhaRepository desc = new DescricaoMultiplaEscolhaRepository(_db);
            foreach (var item in dados)
            {

                if (item.id_tipoResposta == 1)
                {
                    TB_DescricaoMultiplaEscolha t = new TB_DescricaoMultiplaEscolha();
                    
                    t.id = item.id_tipoResposta;
                    var list = desc.Consultar(t).Where(x => x.id == Convert.ToInt32(item.valor)).FirstOrDefault().nome;


                    item.DescMutiplaEscolha = desc.Consultar(t).FirstOrDefault().nome;
                }
            }


            return Json(dados);
        }

    }
}