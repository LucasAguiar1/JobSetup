using BridgestoneLibras.Data;
using BridgestoneLibras.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BridgestoneLibras.Controllers
{
    public class OperadorController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        //the framework handles this
        public OperadorController(ApplicationDbContext db,
            ILogger<OperadorController> log,
            IConfiguration iconfiguration)
        {
            _db = db;
            _log = log;
            _iconfiguration = iconfiguration;
        }

        
        private bool ControleAcessoPeriodo()
        {
            bool retorno = false;
            int index = 0;

            Int32 situacao = Convert.ToInt32(HttpContext.Session.GetInt32("stPeriodo"));
            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("C_FCH");
                if (index <= 0) { return false; }

                if (situacao == 3)
                {
                    ViewBag.AcaoControleReabre = "hidden";
                    ViewBag.AcaoControleReabreD = "hidden";

                    index = permissoes.IndexOf("E_FCH");
                    if (index <= 0)
                    {
                        ViewBag.AcaoControleEditar = "hidden";
                    }
                    else
                    {
                        ViewBag.AcaoControleEditarD = "hidden";
                    }

                    index = permissoes.IndexOf("P_FCH");
                    if (index <= 0)
                    {
                        ViewBag.AcaoControleProcessa = "hidden";
                    }
                    else
                    {
                        ViewBag.AcaoControleProcessaD = "hidden";
                    }
                }
                else
                {
                    ViewBag.AcaoControleEditar = "hidden";
                    ViewBag.AcaoControleProcessa = "hidden";
                    ViewBag.AcaoControleProcessaD = "hidden";

                    index = permissoes.IndexOf("E_FCH");
                    if (index <= 0)
                    {
                        ViewBag.AcaoControleReabre = "hidden";
                    }
                    else
                    {
                        ViewBag.AcaoControleReabreD = "hidden";
                    }
                }

                retorno = true;
            }

            return retorno;
        }



        [HttpPost]
        public string PeriodoReabrir()
        {
            string mensagem = string.Empty;

            try
            {
                if (!ControleAcessoPeriodo()) { RedirectToAction(_iconfiguration.GetSection("InitialPage").Value); }

                string usuario = HttpContext.Session.GetString("login");
                Int32 periodo = Convert.ToInt32(HttpContext.Session.GetInt32("periodoId"));

                PeriodoRepository repPeriodo = new PeriodoRepository(_db);
                mensagem = repPeriodo.PeriodoReabrir(periodo, usuario);

                if (mensagem.Length == 0)
                    HttpContext.Session.SetInt32("stPeriodo", 3);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        [HttpPost]
        public string PeriodoProcessar()
        {
            string mensagem = string.Empty;

            try
            {
                if (!ControleAcessoPeriodo()) { RedirectToAction(_iconfiguration.GetSection("InitialPage").Value); }

                string usuario = HttpContext.Session.GetString("login");
                Int32 periodo = Convert.ToInt32(HttpContext.Session.GetInt32("periodoId"));

                PeriodoRepository repPeriodo = new PeriodoRepository(_db);

                mensagem = repPeriodo.PeriodoFechamento(periodo, usuario);

                if (mensagem.Length == 0)
                    HttpContext.Session.SetInt32("stPeriodo", 5);
            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            return mensagem;
        }

        [HttpPost]
        public JsonResult PeriodoValidar()
        {
            string mensagem = string.Empty;
            int mensagens = 0;

            if (!ControleAcessoPeriodo()) { RedirectToAction(_iconfiguration.GetSection("InitialPage").Value); }

            Int32 periodo = Convert.ToInt32(HttpContext.Session.GetInt32("periodoId"));
            PeriodoRepository repPeriodo = new PeriodoRepository(_db);

            return Json(repPeriodo.PeriodoValidar(periodo, ref mensagens));
        }

        #region "Parametros"

        //public ActionResult Parametros()
        //{
        //    if (!ControleAcessoParametro()) { return RedirectToAction(_iconfiguration.GetSection("InitialPage").Value); }

        //    ParametroRepository repParametro = new ParametroRepository(_db);
        //    List<TB_PARAMETROS> lParametro = repParametro.Consultar();
        //    return View(ParametroModel.Mapper(lParametro, true));
        //}

        //[HttpPost]
        //public string ParametroAlterar([FromBody] ParametroModel jsonRecursoView)
        //{
        //    string mensagem = string.Empty;

        //    try
        //    {
        //        if (!ControleAcessoParametro()) { RedirectToAction(_iconfiguration.GetSection("InitialPage").Value); }

        //        string usuario = HttpContext.Session.GetString("login");
        //        int parametro = jsonRecursoView.ID;
        //        string valor = jsonRecursoView.Valor.ToString();

        //        ParametroRepository repParametro = new ParametroRepository(_db);
        //        repParametro.Alterar(parametro, valor, usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.LogError(ex.Message);
        //        mensagem = "Erro interno! Contacte o administrador do Sistema!";
        //    }

        //    return mensagem;
        //}

        private bool ControleAcessoParametro()
        {
            bool retorno = false;
            int index = 0;

            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("C_PRM");
                if (index <= 0) { return false; }

                index = permissoes.IndexOf("E_PRM");
                if (index <= 0)
                {
                    ViewBag.AcaoControleDetalhe = "hidden";
                }
                else
                {
                    ViewBag.AcaoControleDetalheD = "hidden";
                }

                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region "CentroCusto"




        private void FiltroSet(int area, int tipo, string codigo, string nome)
        {
            HttpContext.Session.SetInt32("filtroCCArea", area);
            HttpContext.Session.SetInt32("filtroCCTipo", tipo);
            HttpContext.Session.SetString("filtroCCCodigo", codigo);
            HttpContext.Session.SetString("filtroCCNome", nome);

            ViewBagSet(area, tipo, codigo, nome);
        }

        private void FiltroGet(ref int area, ref int tipo, ref string codigo, ref string nome)
        {
            if (HttpContext.Session.GetString("filtroCCArea") != null)
            {
                area = (Int32)HttpContext.Session.GetInt32("filtroCCArea");
                tipo = (Int32)HttpContext.Session.GetInt32("filtroCCTipo");
                codigo = HttpContext.Session.GetString("filtroCCCodigo");
                nome = HttpContext.Session.GetString("filtroCCNome");

                ViewBagSet(area, tipo, codigo, nome);
            }
        }

        private void ViewBagSet(int area, int tipo, string codigo, string nome)
        {
            ViewBag.BuscaArea = area;
            ViewBag.BuscaTipo = tipo;
            ViewBag.BuscaCodigo = codigo;
            ViewBag.BuscaNome = nome;
        }





        private bool ControleAcessoCentroCusto()
        {
            bool retorno = false;
            int index = 0;

            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("C_CC");
                if (index <= 0) { return false; }

                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region "CentroCusto Detalhe"








        private bool ControleAcessoCentroCustoDetalhe()
        {
            bool retorno = false;
            int index = 0;

            Int32 situacao = Convert.ToInt32(HttpContext.Session.GetInt32("stPeriodo"));
            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("D_CTT");
                if (index <= 0) { return false; }

                index = permissoes.IndexOf("E_CTT");
                if ((index <= 0) || (situacao != 3))
                {
                    ViewBag.AcaoControleExclui = "hidden";
                    ViewBag.AcaoControle = "hidden";
                }
                else
                {
                    ViewBag.AcaoControleExcluiD = "hidden";
                }

                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region "Peso Armazenado"





        private List<SelectListItem> DataListar()
        {
            string inicio = HttpContext.Session.GetString("periodoInicio");
            string fim = HttpContext.Session.GetString("periodoFim");

            int controle = Int32.Parse(inicio.Substring(0, 2));
            int limite = Int32.Parse(fim.Substring(0, 2));
            string mes = inicio.Substring(2, inicio.Length - 2);

            List<SelectListItem> lista = new List<SelectListItem>();

            lista.Add(new SelectListItem
            {
                Text = "Selecionar",
                Value = "0"
            });

            while (controle <= limite)
            {
                if (controle < 10)
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = controle.ToString(),
                        Text = "0" + controle.ToString() + mes
                    });
                }
                else
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = controle.ToString(),
                        Text = controle.ToString() + mes
                    });
                }

                controle += 1;
            }

            return lista;
        }

        private void PesoArmazenadoFiltroSet(int categoria, int dia)
        {
            HttpContext.Session.SetInt32("filtroPesoCategoria", categoria);
            HttpContext.Session.SetInt32("filtroPesoDia", dia);

            PesoArmazenadoViewBagSet(categoria, dia);
        }

        private void PesoArmazenadoFiltroGet(ref int categoria, ref int dia)
        {
            if (HttpContext.Session.GetString("filtroPesoCategoria") != null)
            {
                categoria = (Int32)HttpContext.Session.GetInt32("filtroPesoCategoria");
                dia = (Int32)HttpContext.Session.GetInt32("filtroPesoDia");

                PesoArmazenadoViewBagSet(categoria, dia);
            }
        }

        private void PesoArmazenadoViewBagSet(int categoria, int dia)
        {
            ViewBag.BuscaCategoria = categoria;
            ViewBag.BuscaDia = dia;
        }

        private bool ControleAcessoPesoArmazenado()
        {
            bool retorno = false;
            int index = 0;

            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("C_PSA");
                if (index <= 0) { return false; }

                retorno = true;
            }

            return retorno;
        }

        #endregion


        private void FuncaoFiltroSet(int classificacao, int ppmh, int pcmh, string codigo, string nome)
        {
            HttpContext.Session.SetInt32("filtroFuncaoClassificacao", classificacao);
            HttpContext.Session.SetInt32("filtroFuncaoPpmh", ppmh);
            HttpContext.Session.SetInt32("filtroFuncaoPcmh", pcmh);
            HttpContext.Session.SetString("filtroFuncaoCodigo", codigo);
            HttpContext.Session.SetString("filtroFuncaoNome", nome);

            FuncaoViewBagSet(classificacao, ppmh, pcmh, codigo, nome);
        }

        private void FuncaoFiltroGet(ref int classificacao, ref int ppmh, ref int pcmh, ref string codigo, ref string nome)
        {
            if (HttpContext.Session.GetString("filtroFuncaoClassificacao") != null)
            {
                classificacao = (Int32)HttpContext.Session.GetInt32("filtroFuncaoClassificacao");
                ppmh = (Int32)HttpContext.Session.GetInt32("filtroFuncaoPpmh");
                pcmh = (Int32)HttpContext.Session.GetInt32("filtroFuncaoPcmh");
                codigo = HttpContext.Session.GetString("filtroFuncaoCodigo");
                nome = HttpContext.Session.GetString("filtroFuncaoNome");

                FuncaoViewBagSet(classificacao, ppmh, pcmh, codigo, nome);
            }
        }

        private void FuncaoViewBagSet(int classificacao, int ppmh, int pcmh, string codigo, string nome)
        {
            ViewBag.BuscaClassificacao = classificacao;
            ViewBag.BuscaPpmh = ppmh;
            ViewBag.BuscaPcmh = pcmh;
            ViewBag.BuscaCodigo = codigo;
            ViewBag.BuscaNome = nome;
        }


        private bool ControleAcessoFuncao()
        {
            bool retorno = false;
            int index = 0;

            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("C_FNC");
                if (index <= 0) { return false; }
                retorno = true;

                index = permissoes.IndexOf("E_FNC");
                if (index <= 0)
                {
                    ViewBag.AcaoControleEdita = "hidden";
                }
                else
                {
                    ViewBag.AcaoControleEditaD = "hidden";
                }
            }

            return retorno;
        }




        private bool ControleAcessoFuncaoDetalhe()
        {
            bool retorno = false;
            int index = 0;

            string permissoes = HttpContext.Session.GetString("permissoes");

            if (!string.IsNullOrEmpty(permissoes))
            {
                index = permissoes.IndexOf("C_FNC");
                if (index <= 0) { return false; }

                index = permissoes.IndexOf("E_FNC");
                if (index <= 0)
                {
                    ViewBag.AcaoControleEdita = "hidden";
                }
                else
                {
                    ViewBag.AcaoControleEditaD = "hidden";
                }

                retorno = true;
            }

            return retorno;
        }


    }
}
