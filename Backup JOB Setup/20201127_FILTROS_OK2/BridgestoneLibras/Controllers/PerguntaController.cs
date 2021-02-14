using BridgestoneLibras.Controllers;
using BridgestoneLibras.Data;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.Data.Repository;
using LHH.Library.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LHH.Controllers
{
    public class PerguntaController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;


        public PerguntaController(ApplicationDbSpecContext db,
           ILogger<OperadorController> log,
           IConfiguration iconfiguration)
        {
            _db = db;
            _log = log;
            _iconfiguration = iconfiguration;
        }

        

        // GET: Pergunta
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Cadastrar([FromBody]  TB_PERGUNTA myData)
        {

            PerguntaRepository repPergunta = new PerguntaRepository(_db);
            CaracterSpecial(ref myData);
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repPergunta.Cadastrar(myData);

            return Json(myData);
        }

        public void CaracterSpecial (ref TB_PERGUNTA pergunta)
        {

            pergunta.nome = pergunta.nome.Replace("&quot;", "''");
            pergunta.nome = pergunta.nome.Replace("&lt;", "<");
            pergunta.nome = pergunta.nome.Replace("&gt;", ">");
            pergunta.nome = pergunta.nome.Replace("&amp;", "&");
            

        }

        public ActionResult Alterar([FromBody]   TB_PERGUNTA myData)
        {

            PerguntaRepository repPergunta = new PerguntaRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repPergunta.Alterar(myData);

            return Json(myData);
        }

        public ActionResult Departamentos()
        {
            TB_DEPARTAMENTO departamentos = new TB_DEPARTAMENTO();

            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);

            return Json(repDepartamento.Combo(repDepartamento.Consultar(departamentos), "Selecione"));
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

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }

        public ActionResult Formularios(int idParteMaquina)
        {
            TB_FORMULARIO f = new TB_FORMULARIO();
            f.id_parteMaquina = idParteMaquina; 
            FormularioRepository RepForm = new FormularioRepository(_db);
            return Json(RepForm.Combo(RepForm.Consultar(f), "Selecione"));
        }

        public ActionResult TiposRespostas(TB_TIPORESPOSTA tb_status)
        {
            TipoRespostaRepository RepTipo = new TipoRespostaRepository(_db);
            return Json(RepTipo.Combo(RepTipo.Consultar(tb_status), "Selecione"));
        }

        public ActionResult ConsultaGrid()
        {
            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            PerguntaRepository repPergunta = new PerguntaRepository(_db);

            var listPergunta = repPergunta.Consultar(pergunta);
            return Json(listPergunta);
        }
        public ActionResult PerguntaPai(int id_pai, int idformulario)
        {
            
            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            pergunta.id_formulario = idformulario; 
            PerguntaRepository repPergunta = new PerguntaRepository(_db);

            var listPergunta = repPergunta.Consulta_perguntaSemPai(pergunta).ToList();

            listPergunta = listPergunta.Where(x => x.id != id_pai).ToList();

            listPergunta = listPergunta.Where(x => x.resposta != "Condição").ToList();

            return Json( repPergunta.Combo(listPergunta, "Selecione"));
        }

        public ActionResult ConsultaGridAlternativas(int id_pai)
        {
            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            pergunta.id = id_pai;
            PerguntaRepository repPergunta = new PerguntaRepository(_db);

            //Consulta Tabela Perguntas
            var listPergunta = repPergunta.Consultar(pergunta);

            var idsAlternativa = listPergunta.FirstOrDefault().idsAlternativa.Split("-");

            //Consulta tabela Alternativas
            var tipoRepostas = TipoRespostas(listPergunta);

            
            List<TB_DescricaoMultiplaEscolha> lDescricao = new List<TB_DescricaoMultiplaEscolha>();

            for (int i = 0; i < idsAlternativa.Length; i++)
            {
                if (!idsAlternativa[i].Equals(string.Empty))
                {
                    var itemDes = tipoRepostas.Where(x => x.id == Convert.ToInt32(idsAlternativa[i])).ToList();

                    foreach (var item in itemDes)
                    {
                        lDescricao.Add(item);
                    }
                }
            }

            return Json(lDescricao);
        }
        
        public ActionResult ExcluirAlternativa(int idPai, string idAlternativa, string idAlternativas)
        {
            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            string alternativas = string.Empty;

            var ids = idAlternativas.Split("-");

            for (int i = 0; i < ids.Length; i++)
            {
                if( string.IsNullOrEmpty(alternativas))
                {
                    if (ids[i] != idAlternativa)
                    {
                        alternativas = ids[i];
                    }
                        
                }
                else
                {
                    if (ids[i] != idAlternativa)
                    {
                        alternativas += "-" + ids[i];
                    }
                }
            }

            pergunta.id = idPai;
            pergunta.idsAlternativa = alternativas;
            pergunta.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            PerguntaRepository repPergunta = new PerguntaRepository(_db);

             var ret  = repPergunta.AtualizarAlternativa(pergunta);

            
            return Json(ret);
        }




        public List<TB_DescricaoMultiplaEscolha> TipoRespostas(List<TB_PERGUNTA> listPergunta)
        {
            List<TB_DescricaoMultiplaEscolha> lDescricao = new List<TB_DescricaoMultiplaEscolha>();

            DescricaoMultiplaEscolhaRepository repDescricao = new DescricaoMultiplaEscolhaRepository(_db);


            TB_DescricaoMultiplaEscolha tDescricao = new TB_DescricaoMultiplaEscolha
            {
                id = listPergunta.FirstOrDefault().id_tipoResposta
            };

            lDescricao = repDescricao.Consultar(tDescricao);


            return lDescricao; 

        }


        public ActionResult DescricaoAlterantivas()
        {
            DescricaoMultiplaEscolhaRepository repDescricao = new DescricaoMultiplaEscolhaRepository(_db);

            TB_DescricaoMultiplaEscolha descricao = new TB_DescricaoMultiplaEscolha();

            return Json( repDescricao.Combo(repDescricao.Consultar(descricao),"Selecione"));
        }

        //Filho


        public ActionResult CadastrarFilho([FromBody]  TB_FILHO myData)
        {

            int idFilho = myData.id_filho; 

            FilhoRepository repFilho = new FilhoRepository(_db);

            var existeFilho   = repFilho.Consultar(myData).Where(x=>x.id_filho == idFilho).ToList(); 
            
            
            if(existeFilho.Count > 0)
            {
                myData.msn = "Essa pergunta já está associada, não é possível associar a mesma  pergunta mais de uma vez.";
                return Json(myData);
            }
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repFilho.Cadastrar(myData);

            return Json(myData);
        }


        public ActionResult ConsultaGridFilho(int id_pai)
        {
            TB_FILHO filho = new TB_FILHO();
            filho.id_perguntaPai = id_pai;
            FilhoRepository repFilho = new FilhoRepository(_db);

            var listPergunta = repFilho.Consultar(filho);
            return Json(listPergunta);
        }


        public ActionResult ExcluirFilho(int idFilho)
        {
            TB_FILHO filho = new TB_FILHO();
            filho.id = idFilho;
            FilhoRepository repFilho = new FilhoRepository(_db);

            var listPergunta = repFilho.Excluir(filho);
            return Json(listPergunta);
        }

    }
}
