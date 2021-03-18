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
using System.Linq;

namespace LHH.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
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
        public ActionResult Cadastrar([FromBody]  TB_MAQUINAPARTE myData)
        {

            MaquinaParteRepository repMaquinaParte = new MaquinaParteRepository(_db);
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repMaquinaParte.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_MAQUINAPARTE myData)
        {

            MaquinaParteRepository repMaquinaParte = new MaquinaParteRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
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
        public ActionResult Pesquisar([FromBody]  TB_MAQUINAPARTE myData)
        {
            List<TB_MAQUINAPARTE> listMaquinaParte = new List<TB_MAQUINAPARTE>();
            MaquinaParteRepository repMaquinaParte = new MaquinaParteRepository(_db);
            TB_MAQUINAPARTE dp = new TB_MAQUINAPARTE();
            listMaquinaParte = repMaquinaParte.Consultar(dp).ToList();
            bool consulta = false;

            if (myData.id_departamento != 0 && myData.id_maquina == 0 && (myData.nome == null || myData.nome == "") && myData.status == 0)
            {
                listMaquinaParte = listMaquinaParte.Where(x => x.id_departamento == myData.id_departamento).ToList();
                consulta = true;
            }
            if (myData.id_departamento != 0 && myData.id_maquina != 0 && myData.nome == null && myData.status == 0)
            {
                listMaquinaParte = listMaquinaParte.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina).ToList();
                consulta = true;
            }
            if (myData.id_departamento != 0 && myData.id_maquina != 0 && myData.nome != null  && myData.status == 0)
            {
                listMaquinaParte = listMaquinaParte.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
                consulta = true;
            }
            if (myData.id_departamento != 0 && myData.id_maquina != 0 && (myData.nome != null || myData.nome != "") && myData.status != 0)
            {
                listMaquinaParte = listMaquinaParte.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.status == myData.status).ToList();
                consulta = true;
            }
           
            if (!consulta)
            {
                listMaquinaParte = new List<TB_MAQUINAPARTE>();
            }
            return Json(listMaquinaParte);
        }

        public ActionResult Departamento()
        {
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);

            List<TB_DEPARTAMENTO> listDeparts = new List<TB_DEPARTAMENTO>();

            if (CheckSession())
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                listDeparts = repDepartamento.Consultar(dp).Where(x => x.status == 1).ToList();
            }

            return Json(repDepartamento.Combo(listDeparts, "Selecione"));
        }

        public ActionResult Maquinas(int idDepartamento)
        {
            TB_MAQUINA maquina = new TB_MAQUINA();
            maquina.id_departamento = idDepartamento; 
            MaquinaRepository repMaquina = new MaquinaRepository(_db);

            var list = repMaquina.Consultar(maquina).Where(x => x.status == 1).ToList();

            return Json(repMaquina.Combo(list, "Selecione"));
        }

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }

    }

}