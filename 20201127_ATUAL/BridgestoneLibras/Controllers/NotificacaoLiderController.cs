using BridgestoneLibras.Controllers;
using BridgestoneLibras.Data;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LHH.Controllers
{
    public class NotificacaoLiderController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        

        //the framework handles this
        public NotificacaoLiderController(ApplicationDbSpecContext db,
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
            List<SelectListItem> combo = new List<SelectListItem>();
            int departamento = Convert.ToInt32( HttpContext.Session.GetString("departamento"));
            if (HttpContext.Session.GetString("permissoes") != "CADASTRAPERGUNTA")
            {

                combo = repDepartamento.Combo(repDepartamento.Consultar(dp).Where(x => x.codigo == departamento.ToString()).ToList(), "Selecione").ToList();
            }
            else
            {
                combo = repDepartamento.Combo(repDepartamento.Consultar(dp), "Selecione").ToList();
            }
            

            return Json(combo);
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

        public ActionResult ConsultarNotificacao(int id_formulario, string respondidas)
        {
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);

            TB_NOTIFICACAO t = new TB_NOTIFICACAO();

            t.respondidas = respondidas == "" ? 0 : Convert.ToInt32(respondidas);
           
            t.id_formulario = id_formulario;
            t.id_lider = HttpContext.Session.GetString("login");
            var dados = notificacaoRepos.Consultar(t);

            if (dados.Count > 0)
            {
                dados.FirstOrDefault().permissao = HttpContext.Session.GetString("permissoes").ToString().ToUpper();
            }

            return Json(dados);
        }

        public ActionResult CarregaGrid()
        {
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);

            TB_NOTIFICACAO t = new TB_NOTIFICACAO();

            //t.respondidas = 0;
            //t.id_formulario = 0;
            //t.id_lider =HttpContext.Session.GetString("login");
            //t.id_departamento = Convert.ToInt32(HttpContext.Session.GetString("departamento"));
            ////t.permissao = "CADASTRAPERGUNTA";//HttpContext.Session.GetString("permissoes").ToString().ToUpper();
            //var dados = notificacaoRepos.Consultar(t);
            
            //if (dados.Count > 0)
            //{
            //    dados.FirstOrDefault().permissao = HttpContext.Session.GetString("permissoes").ToString().ToUpper();
            //}

            return Json(ConsultaGrid());
        }

        public List<TB_NOTIFICACAO> ConsultaGrid()
        {
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);

            TB_NOTIFICACAO t = new TB_NOTIFICACAO();

            t.respondidas = 0;
            t.id_formulario = 0;
            t.id_lider = HttpContext.Session.GetString("login");
            t.id_departamento = Convert.ToInt32(HttpContext.Session.GetString("departamento"));
            //t.permissao = "CADASTRAPERGUNTA";//HttpContext.Session.GetString("permissoes").ToString().ToUpper();
            var dados = notificacaoRepos.Consultar(t);

            if (dados.Count > 0)
            {
                dados.FirstOrDefault().permissao = HttpContext.Session.GetString("permissoes").ToString().ToUpper();
            }

            return dados;
        }


        public ActionResult Atualizar([FromBody] TB_NOTIFICACAO myData)
        {
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);
            TB_NOTIFICACAO t = new TB_NOTIFICACAO();
            try
            {

                var aaaa = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
                myData.id_liderObs = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
                myData.nomeLider = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");

                //t.id_liderObs     = myData.id_liderObs        ;
                //t.id              = myData.id                 ;
                //t.nomeLider       = myData.nomeLider          ;
                //t.observacaoLider = myData.observacaoLider;




                myData = notificacaoRepos.Atualizar(myData);
            }
            catch (Exception ex)
            {


                throw ex;
            }
            
            

            return Json(myData);
        }

        public ActionResult LeituraNotificacao(int idregistro)
        {
            TB_NOTIFICACAO myData = new TB_NOTIFICACAO();
            myData.id = idregistro;
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);
            myData.id_lider = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData.nomeLider = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");

            //verifica se ja foi atualizado, caso ja tenha  sido atualizado não faz nada.

            var retorno = ConsultaGrid().Where(x => x.id == idregistro).ToList();

            if(retorno.FirstOrDefault().dataLeitura == ""  )
            {
                myData = notificacaoRepos.AtualizarLeitura(myData);
            }

            //HttpContext.Session.SetString("id_usuario", Convert.ToString(usuarioModel.rl_usuario));
            //HttpContext.Session.SetString("login", usuario);
            //HttpContext.Session.SetString("usuario", usuarioModel.nm_usuario.Trim());

            return Json("");
        }
    }
}


