using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System;

namespace BridgestoneLibras.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        IConfiguration _iconfiguration;

        //the framework handles this
        public HomeController(ApplicationDbContext db, IConfiguration iconfiguration)
        {
            _db = db;
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = HttpContext.Session.GetString("permissoes");
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.Clear();            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            string usuario = string.Empty;
            string nome = string.Empty;
            string senha = string.Empty;
            string permissoes = string.Empty;
            string AD1 = string.Empty;
            string AD2 = string.Empty;
            bool ativoAD = false;
            bool valido = false;
            bool validoAD = false;

            int departamento = 0;

            SegurancaRepository segRep = new SegurancaRepository(_db);
            UsuarioModel usuarioModel = new UsuarioModel();
            // esta action trata o post (login)
            if (ModelState.IsValid)
            {
                AD1 = _iconfiguration.GetSection("AD").GetSection("First").Value;
                AD2 = _iconfiguration.GetSection("AD").GetSection("Second").Value;

                usuario = login.Usuario;
                senha = login.Senha;
                //return RedirectToAction("Index", "Departamento");
                usuarioModel = segRep.ValidaUsuario(usuario, senha, ativoAD, AD1, AD2, ref permissoes, ref validoAD, ref nome, ref departamento);


                if (usuarioModel.lUsuarioFuncao.Count > 0)
                {
                    HttpContext.Session.SetString("login", usuario);

                    HttpContext.Session.SetString("usuario", nome.Trim());
                    HttpContext.Session.SetString("permissoes", permissoes);
                    HttpContext.Session.SetString("departamento", departamento.ToString());


                    if (permissoes.Equals("LIDER"))
                    {
                        return RedirectToAction("Index", "NotificacaoLider");
                    }
                    else if (permissoes.Equals("CADASTRARPERGUNTA"))
                    {

                        return RedirectToAction("Index", "Departamento");
                    }
                    else if (permissoes.Equals("OPERADOR"))
                    {

                        return RedirectToAction("Index", "JobSetup");
                    }
                    //PeriodoRepository repPeriodo = new PeriodoRepository(_db);
                    //List<TB_PERIODOS> lPeriodos = repPeriodo.PeriodoConsulta();

                    //var oSerialised = JsonConvert.SerializeObject(lPeriodos);
                    //HttpContext.Session.SetString("periodos", oSerialised);

                    //HttpContext.Session.SetInt32("periodoId", lPeriodos[0].id_periodo);
                    //HttpContext.Session.SetInt32("stPeriodo", lPeriodos[0].id_situacao);
                    //HttpContext.Session.SetString("periodoInicio", lPeriodos[0].dt_inicio.ToString("dd/MM/yyyy"));
                    //HttpContext.Session.SetString("periodoFim", lPeriodos[0].dt_fim.ToString("dd/MM/yyyy"));

                    //  return RedirectToAction("../Recurso/Recurso");
                    //if (HttpContext.Session.GetString("permissoes").Contains("SPECON_APPROVE_PARAMETERS") || HttpContext.Session.GetString("permissoes").Contains("SPECON_CHANGE_PARAMETERS"))
                    //{

                    //if (permissoes == "LIDER")
                    //{
                    //    return RedirectToAction("Index", "NotificacaoLider");
                    //}
                    //else
                    //{
                    return RedirectToAction("Index", "Departamento");
                    //}

                    //}
                    //else
                    //{

                    //    return RedirectToAction("Index", "Departamento");
                    //}


                    //if (usuarioModel.valido == 1)
                    //{
                    //    usuarioModel.ds_login = usuario;
                    //    // PRECISA IR NO BD PARA VER OS DADOS DO USUARIO E ADD NA SESSION COMO ABAIXO.
                    //    HttpContext.Session.SetString("id_usuario", Convert.ToString(usuarioModel.rl_usuario));
                    //    HttpContext.Session.SetString("login", usuario);
                    //    HttpContext.Session.SetString("usuario", usuarioModel.nm_usuario.Trim());
                    //    HttpContext.Session.SetString("departamento", Convert.ToString(usuarioModel.id_departamento));
                    //    HttpContext.Session.SetString("permissoes", JsonConvert.SerializeObject(usuarioModel.lUsuarioFuncao));

                    //    return RedirectToAction("Index", "Departamento");
                    //}
                }
                else
                {
                    if (validoAD)
                    {
                        ViewData["Message"] = "Usuário sem acesso ao Sistema LHH. Contacte o administrador para solicitar o acesso!";
                    }
                    else
                    {
                        ViewData["Message"] = "Usuário ou senha inválidos!";
                    }

                    return View();
                }

            }
            else
            {
                HttpContext.Session.Clear();
                return View();
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpPost]
        //public void TrocarPeriodo(int id)
        //{
        //    try
        //    {
        //        string periodos = HttpContext.Session.GetString("periodos");
        //        List<TB_PERIODOS> lPeriodos = JsonConvert.DeserializeObject<List<TB_PERIODOS>>(periodos);

        //        for (int i = 0; i < lPeriodos.Count; i++)
        //        {
        //            if (id == lPeriodos[i].id_periodo)
        //            {
        //                HttpContext.Session.SetInt32("periodoId", lPeriodos[i].id_periodo);
        //                HttpContext.Session.SetInt32("stPeriodo", lPeriodos[i].id_situacao);
        //                HttpContext.Session.SetString("periodoInicio", lPeriodos[i].dt_inicio.ToString("dd/MM/yyyy"));
        //                HttpContext.Session.SetString("periodoFim", lPeriodos[i].dt_fim.ToString("dd/MM/yyyy"));
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
    }
}
