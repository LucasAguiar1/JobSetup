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

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
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
            myData.idUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
            myData = repDescricao.Alterar(myData);

            return Json(myData);
        }

        public ActionResult TiposRespostas(TB_TIPORESPOSTA tb_status)
        {
            TipoRespostaRepository RepTipo = new TipoRespostaRepository(_db);


            return Json(RepTipo.Combo(RepTipo.Consultar(tb_status).Where(x => x.tipoResposta == "Alternativa").ToList(), "Selecione"));
        }
    }
}