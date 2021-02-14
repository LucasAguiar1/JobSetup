using System;
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
    public class MaquinaController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;

        List<Status> listaStatus = new List<Status>();
        List<TB_DEPARTAMENTO> listaDepartamento = new List<TB_DEPARTAMENTO>();

        public MaquinaController(ApplicationDbSpecContext db,
            ILogger<OperadorController> log,
            IConfiguration iconfiguration)
        {
            _db = db;
            _log = log;
            _iconfiguration = iconfiguration;
        }
        public ActionResult ConsultaGrid()
        {
            List<TB_DEPARTAMENTO> listDepartamento = new List<TB_DEPARTAMENTO>();

            MaquinaRepository repMaquina = new MaquinaRepository(_db);

            var maquinas = repMaquina.Consultar();

            return Json(maquinas);
        }
        public ActionResult Index()
        {  
            return View();
        }
        public ActionResult Departamento()
        {
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);

            return Json(repDepartamento.Combo( repDepartamento.Consultar(dp),"Selecione"));
        }

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }


        public ActionResult Cadastrar([FromBody]  TB_MAQUINA myData)
        {

            MaquinaRepository repMaquina = new MaquinaRepository(_db);
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repMaquina.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_MAQUINA myData)
        {

            MaquinaRepository repMaquina = new MaquinaRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repMaquina.Alterar(myData);

            return Json(myData);
        }
    }
}