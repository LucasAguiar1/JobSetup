using BridgestoneLibras.Controllers;
using BridgestoneLibras.Data;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;

namespace LHH.Controllers
{
    public class FormularioController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        public FormularioController(ApplicationDbSpecContext db,
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

        public ActionResult ConsultaGrid()
        {
            List<TB_FORMULARIO> listMaquinaParte = new List<TB_FORMULARIO>();
            FormularioRepository repFormulario = new FormularioRepository(_db);

            var maquinasParte = repFormulario.Consultar();
            return Json(maquinasParte);
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

        public ActionResult Cadastrar([FromBody]  TB_FORMULARIO myData)
        {

            FormularioRepository repFormulario = new FormularioRepository(_db);
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repFormulario.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_FORMULARIO myData)
        {

            FormularioRepository repFormulario = new FormularioRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repFormulario.Alterar(myData);

            return Json(myData);
        }

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }
    }
}