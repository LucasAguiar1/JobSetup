using System;
using System.Collections.Generic;
using System.Globalization;
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

        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("permissoes") == null)
            {
                return true;
            }
            return false;
        }

        public ActionResult ConsultaGrid()
        {
            List<TB_DEPARTAMENTO> listDepartamento = new List<TB_DEPARTAMENTO>();

            MaquinaRepository repMaquina = new MaquinaRepository(_db);

            var maquinas = repMaquina.Consultar();

            return Json(maquinas);
        }

        public ActionResult Maquinas(int idDepartamento)
        {
            List<TB_DEPARTAMENTO> listDepartamento = new List<TB_DEPARTAMENTO>();

            MaquinaRepository repMaquina = new MaquinaRepository(_db);
            TB_MAQUINA maquina = new TB_MAQUINA();
            maquina.id_departamento = idDepartamento;

            return Json(repMaquina.Combo(repMaquina.Consulta(maquina), "Selecione"));
        }

        public ActionResult Index()
        {  
            return View();
        }

        public ActionResult MaquinaPCS(String pcs)
        {
            TB_MAQUINAPCS maquinaPCS = new TB_MAQUINAPCS();
            maquinaPCS.vc_Descripcion = pcs; 
            MaquinaPCSRepository repPCS = new MaquinaPCSRepository(_db);

            return Json(repPCS.Consultar(maquinaPCS));
            
        }
        public ActionResult Departamento()
        {
            TB_DEPARTAMENTO dp = new TB_DEPARTAMENTO();
            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);
            List<TB_DEPARTAMENTO> listDeps = new List<TB_DEPARTAMENTO>(); 

            if (CheckSession())
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                listDeps = repDepartamento.Consultar(dp).Where(x => x.status == 1).ToList();
            }

                
            return Json(repDepartamento.Combo(listDeps, "Selecione"));
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
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repMaquina.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_MAQUINA myData)
        {

            MaquinaRepository repMaquina = new MaquinaRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repMaquina.Alterar(myData);

            return Json(myData);
        }

        public ActionResult Pesquisar([FromBody]  TB_MAQUINA myData)
        {
            MaquinaRepository repMaquina = new MaquinaRepository(_db);
            List<TB_MAQUINA> listDeps = new List<TB_MAQUINA>();

            listDeps = repMaquina.Consultar().ToList();

            bool consulta = false;

            if (myData.id_departamento != 0 && (myData.nome == null || myData.nome == "") && myData.vc_Descripcion == null && myData.status == 0)
            {
                listDeps = listDeps.Where(x => x.id_departamento == myData.id_departamento).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0 && myData.nome != null && myData.vc_Descripcion == null && myData.status == 0)
            {
                listDeps = listDeps.Where(x => x.id_departamento == myData.id_departamento && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0 && myData.nome != null && myData.vc_Descripcion != null && myData.status == 0)
            {
                listDeps = listDeps.Where(x => x.id_departamento == myData.id_departamento && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.vc_Descripcion.ToUpper().Contains(myData.vc_Descripcion.ToUpper().Trim())).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0 && myData.nome != null && myData.vc_Descripcion != null && myData.status != 0)
            {
                listDeps = listDeps.Where(x => x.id_departamento == myData.id_departamento && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.vc_Descripcion.ToUpper().Contains(myData.vc_Descripcion.ToUpper().Trim()) && myData.status != 0).ToList();
                consulta = true;
            }
            if (!consulta)
            {
                listDeps = new List<TB_MAQUINA>();
            }
            return Json(listDeps);
        }
    }
}