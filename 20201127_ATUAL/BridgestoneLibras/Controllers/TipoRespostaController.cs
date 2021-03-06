﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
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

namespace LHH.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class TipoRespostaController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        List<Status> listaStatus = new List<Status>();
        List<TB_DEPARTAMENTO> listaDepartamento = new List<TB_DEPARTAMENTO>();

        public TipoRespostaController(ApplicationDbSpecContext db,
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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ConsultaGrid()
        {
            TB_DescricaoMultiplaEscolha descricao = new TB_DescricaoMultiplaEscolha();

            DescricaoMultiplaEscolhaRepository repDescricao = new DescricaoMultiplaEscolhaRepository(_db);

            return Json(repDescricao.Consultar(descricao));
        }

        public ActionResult Pesquisar([FromBody]  TB_DescricaoMultiplaEscolha myData)
        {
            List<TB_DescricaoMultiplaEscolha> listDescMulEscolha = new List<TB_DescricaoMultiplaEscolha>();
            DescricaoMultiplaEscolhaRepository repDescricao = new DescricaoMultiplaEscolhaRepository(_db);
            TB_DescricaoMultiplaEscolha dp = new TB_DescricaoMultiplaEscolha();
            listDescMulEscolha = repDescricao.Consultar(dp).ToList();

            listDescMulEscolha = listDescMulEscolha.Where(x => x.id_TipoResposta == myData.id_TipoResposta && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
            
            return Json(listDescMulEscolha);
        }

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione").Where(x => x.Value == "1").ToList());
        }

        public ActionResult Cadastrar([FromBody]  TB_DescricaoMultiplaEscolha myData)
        {

            DescricaoMultiplaEscolhaRepository repDescricao = new DescricaoMultiplaEscolhaRepository(_db);

            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repDescricao.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_DescricaoMultiplaEscolha myData)
        {
            DescricaoMultiplaEscolhaRepository repDescricao = new DescricaoMultiplaEscolhaRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repDescricao.Alterar(myData);

            return Json(myData);
        }

        public ActionResult TiposRespostas(TB_TIPORESPOSTA tb_status)
        {
            TipoRespostaRepository RepTipo = new TipoRespostaRepository(_db);
            List<TB_TIPORESPOSTA> listTipoResposta = new List<TB_TIPORESPOSTA>();
            if (CheckSession())
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                listTipoResposta = RepTipo.Consultar(tb_status).Where(x => x.id == 1).ToList();
            }


            return Json(RepTipo.Combo(listTipoResposta, "Selecione").Where(x=> x.Value == "1"));

        }
    }
}