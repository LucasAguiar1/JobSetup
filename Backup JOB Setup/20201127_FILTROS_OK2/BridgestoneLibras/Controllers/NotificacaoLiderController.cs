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

namespace LHH.Controllers
{
    public class NotificacaoLiderController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        List<NotificacaoLiderModel> lNotificacoes = new List<NotificacaoLiderModel>();
        List<TB_USUARIO> ListaUsuario = new List<TB_USUARIO>();

        //the framework handles this
        public NotificacaoLiderController(ApplicationDbSpecContext db,
            ILogger<OperadorController> log,
            IConfiguration iconfiguration)
        {
            _db = db;
            _log = log;
            _iconfiguration = iconfiguration;
        }

        // GET: NotificacaoLiderController
        public ActionResult Index(int cd_rl )
        {
            NotificacaoLiderRepository repository = new NotificacaoLiderRepository(_db);
            TB_NOTIFICACAOLIDER modelo = new TB_NOTIFICACAOLIDER();

            modelo.UsuarioOperador.rl_usuario = cd_rl;

            List<TB_NOTIFICACAOLIDER> tbNotificacao = repository.Consultar(modelo);
            var lNotificacao = NotificacaoLiderModel.Mapper(tbNotificacao, true);

            //Mostrar somente os OPERADORES do mesmo departamento que o LIDER que está acessando a tela para visualizar as notificações.
            ListaUsuario = repository.ConsultarListaUsuarios("OPERADOR", Convert.ToInt32(HttpContext.Session.GetString("departamento")) );
            ViewBag.ListaUsuarioOperador = AreaListarUsuarios(ListaUsuario, "Selecionar", null);

            return View(lNotificacao);
        }

        private List<SelectListItem> AreaListarUsuarios(List<TB_USUARIO> lModelo, string opcaoInicial, int? cd_rl)
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            if (!string.IsNullOrEmpty(opcaoInicial))
            {
                lista.Add(new SelectListItem //adiciona uma opção que convida a escolher uma das possíveis opções
                {
                    Text = opcaoInicial,
                    Value = "0"
                });
            }

            foreach (var Linha in lModelo)
            {
                if (cd_rl == Linha.rl_usuario)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = Linha.rl_usuario.ToString(),
                        Text = Linha.nm_usuario.Trim(),
                        Selected = true
                    });
                }
                else
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = Linha.rl_usuario.ToString(),
                        Text = Linha.nm_usuario.Trim()
                    });
                }


            }

            return lista;
        }


        // GET: NotificacaoLiderController/Create
        public ActionResult Create(int idNotificacao)
        {
            //try
            //{
            //    TB_NOTIFICACAOLIDER modelo = new TB_NOTIFICACAOLIDER();
            //    NotificacaoLiderRepository repository = new NotificacaoLiderRepository(_db);

            //    //Editar
            //    if (idNotificacao != 0)
            //    {                    
            //        modelo.id_notificacao = idNotificacao;
            //        List<TB_NOTIFICACAOLIDER> tb = repository.Consultar(modelo);

            //        lNotificacoes = NotificacaoLiderModel.Mapper(tb, true);
            //    }

            //    return View(lNotificacoes);
            //}
            //catch
            //{
            return View();
            //}
        }

        // POST: NotificacaoLiderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotificacaoLiderModel collection)
        {
            try
            {



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // ATUALIZAÇÃO DE LEITURA DO LIDER.
        public void AtualizaDataLeituraLider([FromBody] NotificacaoLiderModel dado)  // ou usar a POCO
        {
            try
            {
                TB_NOTIFICACAOLIDER modelo = new TB_NOTIFICACAOLIDER();
                modelo.id_notificacao = dado.id_notificacao;
                modelo.UsuarioLiderLeitura.rl_usuario = Convert.ToInt32(HttpContext.Session.GetString("id_usuario")); // Pegando id_usuario da SESSION

                NotificacaoLiderRepository repository = new NotificacaoLiderRepository(_db);

                //Editar
                if (modelo.id_notificacao != 0)
                {
                    repository.AtualizaDataLeituraLider(modelo);
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void EnviaNotificacaoLider([FromBody] NotificacaoLiderModel dado)
        {
            try
            {
                NotificacaoLiderRepository repository = new NotificacaoLiderRepository(_db);

                if (dado.id_notificacao != 0)
                {
                    TB_NOTIFICACAOLIDER modelo = new TB_NOTIFICACAOLIDER();
                    modelo.id_notificacao = dado.id_notificacao;
                    modelo.ds_lider_notificacao = dado.ds_lider_notificacao;
                    modelo.UsuarioLiderNotificacao.rl_usuario = Convert.ToInt32(HttpContext.Session.GetString("id_usuario"));

                    repository.GravarNotificacaoLider(modelo);

                    TempData["Msg"] = "Notificação Atualizada:'" + dado.id_notificacao + "' com sucesso.";
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Houve um erro inesperado. Entrar em contato com TI. Erro: " + ex.Message.ToString();
            }
        }
    }
}


