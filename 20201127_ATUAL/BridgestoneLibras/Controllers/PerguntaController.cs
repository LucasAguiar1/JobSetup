﻿using BridgestoneLibras.Controllers;
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
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
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

        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("permissoes") == null)
            {
                return true;
            }
            return false;
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
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repPergunta.Cadastrar(myData);

            return Json(myData);
        }

        public void CaracterSpecial(ref TB_PERGUNTA pergunta)
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

            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repPergunta.Alterar(myData);

            return Json(myData);
        }

        public ActionResult Departamentos()
        {
            TB_DEPARTAMENTO departamentos = new TB_DEPARTAMENTO();

            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            List<TB_DEPARTAMENTO> listDepartamentos = new List<TB_DEPARTAMENTO>();

            if (CheckSession())
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                listDepartamentos = repDepartamento.Consultar(departamentos).Where(x => x.status == 1).ToList();
            }

            return Json(repDepartamento.Combo(listDepartamentos, "Selecione"));
        }

        public ActionResult Maquinas(int idDepartamento)
        {
            TB_MAQUINA maquina = new TB_MAQUINA();
            maquina.id_departamento = idDepartamento;
            MaquinaRepository repMaquina = new MaquinaRepository(_db);

            return Json(repMaquina.Combo(repMaquina.Consultar(maquina).Where(x => x.status == 1).ToList(), "Selecione"));
        }

        public ActionResult MaquinaParte(int idMaquina)
        {
            TB_MAQUINAPARTE parte = new TB_MAQUINAPARTE();
            parte.id_maquina = idMaquina;
            MaquinaParteRepository repMaquina = new MaquinaParteRepository(_db);

            if (idMaquina == 0)
            {
                List<TB_MAQUINAPARTE> list = new List<TB_MAQUINAPARTE>();
                return Json(repMaquina.Combo(list, "Selecione"));
            }

            return Json(repMaquina.Combo(repMaquina.Consultar(parte).Where(x => x.status == 1).ToList(), "Selecione"));
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
            List<TB_FORMULARIO> list = new List<TB_FORMULARIO>();
            if (idParteMaquina == 0)
            {
                return Json(RepForm.Combo(list, "Selecione"));
            }
            return Json(RepForm.Combo(RepForm.Consultar(f).Where(x => x.status == 1).ToList(), "Selecione"));
        }

        public ActionResult TiposRespostas(TB_TIPORESPOSTA tb_status)
        {
            TipoRespostaRepository RepTipo = new TipoRespostaRepository(_db);
            return Json(RepTipo.Combo(RepTipo.Consultar(tb_status), "Selecione"));
        }

        public ActionResult ConsultaGrid(int id_formulario)
        {
            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            PerguntaRepository repPergunta = new PerguntaRepository(_db);
            pergunta.id_formulario = id_formulario;
            var listPergunta = repPergunta.Consultar(pergunta);
            return Json(listPergunta);
        }


        public ActionResult Pesquisar([FromBody]  TB_PERGUNTA myData)
        {
            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            PerguntaRepository repPergunta = new PerguntaRepository(_db);
            pergunta.id_formulario = myData.id_formulario;
            var listPergunta = repPergunta.Consultar(pergunta);
            bool consulta = false;

            if (myData.id_tess != 0 && myData.id_obrigatorio == 0 && myData.nome == null && myData.id_tipoResposta == 0 && myData.status == 0)
            {
                listPergunta = listPergunta.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.id_formulario == myData.id_formulario && x.id_tess == myData.id_tess).ToList();
                consulta = true;
            }

            if (myData.id_tess != 0 && myData.id_obrigatorio != 0 && myData.nome == null && myData.id_tipoResposta == 0 && myData.status == 0)
            {
                listPergunta = listPergunta.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.id_formulario == myData.id_formulario && x.id_tess == myData.id_tess && x.id_obrigatorio == myData.id_obrigatorio).ToList();
                consulta = true;
            }

            if (myData.id_tess != 0 && myData.id_obrigatorio != 0 && myData.nome != null && myData.id_tipoResposta == 0 && myData.status == 0)
            {
                listPergunta = listPergunta.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.id_formulario == myData.id_formulario && x.id_tess == myData.id_tess && x.id_obrigatorio == myData.id_obrigatorio && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
                consulta = true;
            }

            if (myData.id_tess != 0 && myData.id_obrigatorio != 0 && myData.nome != null && myData.id_tipoResposta != 0 && myData.status == 0)
            {
                listPergunta = listPergunta.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.id_formulario == myData.id_formulario && x.id_tess == myData.id_tess && x.id_obrigatorio == myData.id_obrigatorio && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.id_tipoResposta == myData.id_tipoResposta).ToList();
                consulta = true;
            }

            if (myData.id_tess != 0 && myData.id_obrigatorio != 0 && myData.nome != null && myData.id_tipoResposta != 0 && myData.status != 0)
            {
                listPergunta = listPergunta.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.id_formulario == myData.id_formulario && x.id_tess == myData.id_tess && x.id_obrigatorio == myData.id_obrigatorio && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.id_tipoResposta == myData.id_tipoResposta && x.status == myData.status).ToList();
                consulta = true;
            }
            
            if (!consulta)
            {
                listPergunta = new List<TB_PERGUNTA>();
            }
            return Json(listPergunta);
        }

        public ActionResult PerguntaPai(int id_pai, int idformulario)
        {

            TB_PERGUNTA pergunta = new TB_PERGUNTA();
            pergunta.id_formulario = idformulario;
            PerguntaRepository repPergunta = new PerguntaRepository(_db);

            var listPergunta = repPergunta.Consulta_perguntaSemPai(pergunta).ToList();

            listPergunta = listPergunta.Where(x => x.id != id_pai).ToList();

            listPergunta = listPergunta.Where(x => x.id_tipoResposta != 2).ToList();

            return Json(repPergunta.Combo(listPergunta, "Selecione"));
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
                if (string.IsNullOrEmpty(alternativas))
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
            pergunta.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            PerguntaRepository repPergunta = new PerguntaRepository(_db);

            var ret = repPergunta.AtualizarAlternativa(pergunta);


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

            return Json(repDescricao.Combo(repDescricao.Consultar(descricao), "Selecione"));
        }

        //Filho

        public ActionResult CadastrarFilho([FromBody]  TB_FILHO myData)
        {

            int idFilho = myData.id_filho;

            FilhoRepository repFilho = new FilhoRepository(_db);

            var existeFilho = repFilho.Consultar(myData).Where(x => x.id_filho == idFilho).ToList();


            if (existeFilho.Count > 0)
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


        public ActionResult EnviarEmail()
        {

            EmailRepository email = new EmailRepository(_db);


            EmailRepository.EnviarMensagemContato("lucasguimaraesaguiar@gmail.com",
                                                   "Notificação do Líder.",
                                                  "Notificação do Formulário: idFomulario 1 <br />" +
                                                  "Mensagem do Operador: Operador Notificacao  <br />" +
                                                  "Data de envio: " + DateTime.Now.ToString());


            return Json("Email");
        }
    }
}
