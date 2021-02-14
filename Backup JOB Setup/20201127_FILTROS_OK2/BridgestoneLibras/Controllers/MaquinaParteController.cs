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
using System;
using System.Collections.Generic;

namespace LHH.Controllers
{
    public class MaquinaParteController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        public MaquinaParteController(ApplicationDbSpecContext db,
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
        public ActionResult Cadastrar([FromBody]  TB_MAQUINAPARTE myData)
        {

            MaquinaParteRepository repMaquinaParte = new MaquinaParteRepository(_db);
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repMaquinaParte.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_MAQUINAPARTE myData)
        {

            MaquinaParteRepository repMaquinaParte = new MaquinaParteRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repMaquinaParte.Alterar(myData);

            return Json(myData);
        }

        public ActionResult ConsultaGrid()
        {
            List<TB_MAQUINAPARTE> listMaquinaParte = new List<TB_MAQUINAPARTE>();
            TB_MAQUINAPARTE m = new TB_MAQUINAPARTE();
            MaquinaParteRepository repMaquinaParte = new MaquinaParteRepository(_db);

            var maquinasParte = repMaquinaParte.Consultar(m);

            return Json(maquinasParte);
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

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }

    }

}