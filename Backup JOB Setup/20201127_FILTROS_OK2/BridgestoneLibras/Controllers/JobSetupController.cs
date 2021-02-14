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
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace BridgestoneLibras.Controllers
{

    [Serializable]
    public class Summary
    {
        public string fieldname { get; set; }
        public string summarytype { get; set; }
        public string caption { get; set; }
        public int isDeleted { get; set; }
    }
    public class JobSetupController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;
        Document Document = new Document();

        List<Status> listaStatus = new List<Status>();

        //the framework handles this
        public JobSetupController(ApplicationDbSpecContext db,
            ILogger<OperadorController> log,
            IConfiguration iconfiguration)
        {
            _db = db;
            _log = log;
            _iconfiguration = iconfiguration;
        }
        //Lucas
        public ActionResult Index()
        {


            return View();
        }

        //public ActionResult Cadastrar([FromBody]  TB_DEPARTAMENTO departamento)
        //{
        //    DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
        //    departamento.tipo = "C";
        //    departamento.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
        //    departamento = repDepartamento.Cadatrar(departamento);

        //    return Json(departamento);
        //}

        //public ActionResult Alterar([FromBody]  TB_DEPARTAMENTO departamento)
        //{

        //    DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
        //    departamento.tipo = "A";
        //    departamento.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
        //    departamento = repDepartamento.Cadatrar(departamento);

        //    return Json(departamento);
        //}

        //public ActionResult Departamento(TB_DEPARTAMENTO departamento)
        //{
        //    DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
        //    List<TB_DEPARTAMENTO> tbDep = repDepartamento.Consultar(departamento);
        //    var lDepartamento = DepartamentoModel.Mapper(tbDep, true);

        //    return View(lDepartamento);
        //}

        public ActionResult Departamentos()
        {
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            List<TB_DEPARTAMENTO> tbSetor = repDepartamento.Consultar(dp);

            return Json(repDepartamento.Consultar(dp));
        }

        public ActionResult Maquinas(int idDepartamento)
        {
            TB_MAQUINA m = new TB_MAQUINA();
            m.id_departamento = idDepartamento;
            MaquinaRepository RepMaquinas = new MaquinaRepository(_db);

            return Json(RepMaquinas.Consultar(m));
        }
        public ActionResult MaquinasParte(int idMaquina)
        {
            TB_MAQUINAPARTE m = new TB_MAQUINAPARTE();
            m.id_maquina = idMaquina;
            MaquinaParteRepository RepMaquinaParte = new MaquinaParteRepository(_db);

            return Json(RepMaquinaParte.Consultar(m));
        }

        public ActionResult Formularios(int idMaquinaParte)
        {
            TB_FORMULARIO m = new TB_FORMULARIO();
            m.id = idMaquinaParte;
            FormularioRepository RepFormulario = new FormularioRepository(_db);

            return Json(RepFormulario.Consultar(m));
        }


        //[FromBody] 
        [HttpPost]
        public void RespostaPergunta(List<Summary> list)
        {

        }


        public ActionResult Perguntas(int idFormulario)
        {
            TB_PERGUNTA pergunra = new TB_PERGUNTA();
            pergunra.id_formulario = idFormulario;
            FormularioRepository PerguntasPorFormulario = new FormularioRepository(_db);
          
            var perguntas = PerguntasPorFormulario.ConsultaPerguntasPorFormulario(pergunra);

            //Alternativas
            foreach (var item in perguntas)
            {

                if (item.id_tipoResposta.Equals(5))
                {                    

                    item.listDescricaoMultiplaEscolha = Alternativas(item.idsAlternativa); 
                }
                //Condição
                if (item.id_tipoResposta.Equals(6))
                {

                    item.listFilhos = Condicao(item.id);

                    foreach (var f in item.listFilhos)
                    {
                        if (f.id_tipoResposta.Equals(5))
                        {
                            f.listDescricaoMultiplaEscolha = Alternativas(f.idsAlternativa);
                        }
                    }
                }
            }

            

            //List<TB_PERGUNTA> lisPerguntas = new List<TB_PERGUNTA>();

            var copyListPerguntas = perguntas;

            foreach (var item in copyListPerguntas)
            {
                foreach (var f in item.listFilhos)
                {
                    perguntas = perguntas.Where(x => x.id != f.id_filho).ToList();
                }
            }

            AdiconaSelecione(ref perguntas);
            return Json(perguntas);
        }

        public List<TB_PERGUNTA> AdiconaSelecione(ref List<TB_PERGUNTA> listPergunta)
        {

            foreach (var item in listPergunta)
            {
                if(item.listDescricaoMultiplaEscolha.Count > 0)
                {
                    TB_DescricaoMultiplaEscolha d = new TB_DescricaoMultiplaEscolha();
                    d.id = 0;
                    d.nome = "Selecione";
                    item.listDescricaoMultiplaEscolha.Insert(0,  d);
                }
                if (item.listFilhos.Count > 0)
                {
                    foreach (var filho in item.listFilhos)
                    {
                        TB_DescricaoMultiplaEscolha d = new TB_DescricaoMultiplaEscolha();
                        d.id = 0;
                        d.nome = "Selecione";
                        filho.listDescricaoMultiplaEscolha.Insert(0, d);
                    }
                }

            }
            return listPergunta; 
        }

        public List<TB_DescricaoMultiplaEscolha>  Alternativas(string idsAlternativa)
        {
            List<TB_DescricaoMultiplaEscolha> list = new List<TB_DescricaoMultiplaEscolha>();
            DescricaoMultiplaEscolhaRepository desc = new DescricaoMultiplaEscolhaRepository(_db);

            var ids = idsAlternativa.Split('-');

            for (int i = 0; i < ids.Length; i++)
            {
                TB_DescricaoMultiplaEscolha d = new TB_DescricaoMultiplaEscolha();
                d.id = Convert.ToInt32(ids[i]);
                list.Add( desc.ConsultarPorPergunta(d).FirstOrDefault());
            }
            return list;
        }

        public List<TB_FILHO> Condicao(int id)
        {
            FilhoRepository Repfilho = new FilhoRepository(_db);
            TB_FILHO filho = new TB_FILHO
            {
                id_perguntaPai = id
            };

            return Repfilho.Consultar(filho); 
        }

        public List<TB_FILHO> txt(int id)
        {
            FilhoRepository Repfilho = new FilhoRepository(_db);
            TB_FILHO filho = new TB_FILHO
            {
                id_perguntaPai = id
            };

            return Repfilho.Consultar(filho);
        }
    }
}