using BridgestoneLibras.Data;
using BridgestoneLibras.Models;
using BridgestoneLibras.ModelsEntity;
using LHH.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BridgestoneLibras.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DepartamentoController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;
        Document Document = new Document();

        List<Status> listaStatus = new List<Status>();

        //the framework handles this
        public DepartamentoController(ApplicationDbSpecContext db,
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

        public ActionResult Cadastrar([FromBody]  TB_DEPARTAMENTO departamento)
        {
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            departamento.tipo = "C";
            departamento.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            departamento = repDepartamento.Cadatrar(departamento);

            return Json(departamento);
        }

        public ActionResult Alterar([FromBody]  TB_DEPARTAMENTO departamento)
        {

            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            departamento.tipo = "A";
            departamento.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            departamento = repDepartamento.Alterar(departamento);

            return Json(departamento);
        }

        public ActionResult Consulta()
        {
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            List<TB_DEPARTAMENTO> listDepartamentos = new List<TB_DEPARTAMENTO>();

            if (CheckSession())
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                listDepartamentos = repDepartamento.Consultar(dp);
            }

            return Json(listDepartamentos);
        }

        public ActionResult Pesquisar([FromBody]  TB_DEPARTAMENTO myData)
        {
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            List<TB_DEPARTAMENTO> listDepartamentos = new List<TB_DEPARTAMENTO>();
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            listDepartamentos = repDepartamento.Consultar(dp).ToList();
            bool consulta = false;

            if (myData.id != 0 && (myData.nome == null || myData.nome == "")  && myData.status == 0)
            {
                listDepartamentos = listDepartamentos.Where(x => x.codigo == myData.id.ToString()).ToList();
                consulta = true;
            }
            if (myData.id != 0 && myData.nome != null  && myData.status == 0)
            {
                listDepartamentos = listDepartamentos.Where(x => x.codigo == myData.id.ToString() && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
                consulta = true;
            }

            if (myData.id != 0 && myData.nome != null  && myData.status != 0)
            {
                listDepartamentos = listDepartamentos.Where(x => x.codigo == myData.id.ToString() && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.status == myData.status).ToList();
                consulta = true;
            }

            if (!consulta)
            {
                listDepartamentos = new List<TB_DEPARTAMENTO>();   
            }
            return Json(listDepartamentos);
        }

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }
    }
}