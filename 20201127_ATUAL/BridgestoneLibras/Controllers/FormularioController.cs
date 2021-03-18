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
using System.Linq;

namespace LHH.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
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

        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("permissoes") == null)
            {
                return true;
            }
            return false;
        }

        public ActionResult Pesquisar([FromBody]  TB_FORMULARIO myData)
        {
            List<TB_FORMULARIO> listFomrulario = new List<TB_FORMULARIO>();
            FormularioRepository repFormulario = new FormularioRepository(_db);
            bool consulta = false;

            listFomrulario = repFormulario.Consultar();

            if(myData.id_departamento != 0  && myData.id_maquina != 0 && myData.id_parteMaquina != 0 && myData.nome != null && myData.status != 0)
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim()) && x.status == myData.status ).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0 && myData.id_maquina != 0 && myData.id_parteMaquina != 0 && myData.nome != null && myData.status == 0)
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina && x.id_parteMaquina == myData.id_parteMaquina && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0 && myData.id_maquina != 0 && myData.id_parteMaquina != 0 && myData.nome == null && myData.status == 0)
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina).ToList();
                consulta = true;
            }


            if (myData.id_departamento != 0 && myData.id_maquina != 0 && myData.id_parteMaquina == 0 && myData.nome == null )
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento && x.id_maquina == myData.id_maquina ).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0 && myData.id_maquina == 0 && myData.id_parteMaquina == 0 && myData.nome == null)
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento).ToList();
                consulta = true;
            }

            if (myData.id_departamento != 0  && myData.nome != null && myData.id_maquina == 0 && myData.id_parteMaquina == 0)
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento && x.nome.ToUpper().Contains(myData.nome.ToUpper().Trim())).ToList();
                consulta = true;
                //listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento ).ToList();
            }

            if (myData.id_departamento != 0  && myData.status != 0)
            {
                listFomrulario = listFomrulario.Where(x => x.id_departamento == myData.id_departamento && x.status == myData.status).ToList();
                consulta = true;
            }


            if (!consulta)
            {
                listFomrulario = new List<TB_FORMULARIO>();
            }

            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();

            foreach (var item in listFomrulario)
            {
                ordemFormulario.id_Formulario = item.id;
                item.FormularioFilho = FormOrdemRepos.Consultar(ordemFormulario).ToList().Count();
            }

            return Json(listFomrulario);
        }

        public ActionResult ConsultaGrid()
        {
            List<TB_FORMULARIO> listMaquinaParte = new List<TB_FORMULARIO>();
            FormularioRepository repFormulario = new FormularioRepository(_db);

            
            var list = repFormulario.Consultar();

            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();

            foreach (var item in list)
            {
                ordemFormulario.id_Formulario = item.id;
                item.FormularioFilho = FormOrdemRepos.Consultar(ordemFormulario).ToList().Count();
            }

            return Json(list);
        }

        public ActionResult Departamentos()
        {
            TB_DEPARTAMENTO departamentos = new TB_DEPARTAMENTO();
            List<TB_DEPARTAMENTO> listDeparts = new List<TB_DEPARTAMENTO>();

            DepartamentoRepository repDepartamento = new DepartamentoRepository(_db);

            if (CheckSession())
            {
                RedirectToAction("Login", "Home");
            }
            else
            {
                listDeparts = repDepartamento.Consultar(departamentos).Where(x => x.status == 1).ToList();
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

        public ActionResult MaquinaParte(int idMaquina)
        {
            TB_MAQUINAPARTE parte = new TB_MAQUINAPARTE();
            parte.id_maquina = idMaquina;
            MaquinaParteRepository repMaquina = new MaquinaParteRepository(_db);

            var list = repMaquina.Consultar(parte).Where(x => x.status == 1).ToList();

            return Json(repMaquina.Combo(list, "Selecione"));
        }

        public ActionResult Cadastrar([FromBody]  TB_FORMULARIO myData)
        {

            FormularioRepository repFormulario = new FormularioRepository(_db);
            myData.tipo = "C";
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repFormulario.Cadastrar(myData);

            return Json(myData);
        }

        public ActionResult Alterar([FromBody]   TB_FORMULARIO myData)
        {

            FormularioRepository repFormulario = new FormularioRepository(_db);
            myData.tipo = "A";
            myData.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            myData = repFormulario.Alterar(myData);

            return Json(myData);
        }

        public ActionResult Status(TB_STATUS tb_status)
        {
            StatusRepository RepStatus = new StatusRepository(_db);
            return Json(RepStatus.Combo(RepStatus.Consultar(tb_status), "Selecione"));
        }
        public ActionResult ConsultaGridOrdemFormulario(int id_formulario, int id_parteMaquina)
        {

            FormularioRepository repFormulario = new FormularioRepository(_db);

            var dadosGrid = repFormulario.Consultar().Where(x => x.id != id_formulario && x.id_parteMaquina == id_parteMaquina).ToList();

           // var dadosGrid = repFormulario.Consultar().Where(x => x.id_parteMaquina == id_parteMaquina).ToList();
            //dadosGrid = repFormulario.Consultar().Where(x => x.id != id_formulario).ToList();


            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();
            ordemFormulario.id_Formulario = id_formulario;

            var listOrmdeForm = FormOrdemRepos.Consultar(ordemFormulario).ToList();

            List<TB_ORDEM_FORMULARIO> lFormulario = new List<TB_ORDEM_FORMULARIO>();

            foreach (var item in dadosGrid)
            {
                TB_ORDEM_FORMULARIO orForulario = new TB_ORDEM_FORMULARIO();
                if (listOrmdeForm.Where(x => x.id_formulario_Filho == item.id && x.id_departamento == item.id_departamento).ToList().Count > 0)
                {

                    orForulario.id_departamento = item.id_departamento;
                    orForulario.id_maquina = item.id_maquina;
                    orForulario.id_parteMaquina = item.id_parteMaquina;
                    orForulario.departamento = item.departamento;
                    orForulario.maquina = item.maquina;
                    orForulario.nome = item.nome;
                    orForulario.orderm_Formulario = listOrmdeForm.Where(x => x.id_formulario_Filho == item.id && x.id_departamento == item.id_departamento).FirstOrDefault().orderm_Formulario;
                    orForulario.id = listOrmdeForm.Where(x => x.id_formulario_Filho == item.id && x.id_departamento == item.id_departamento).FirstOrDefault().id;
                    orForulario.parteMaquina = item.parteMaquina;
                    orForulario.id_Formulario = item.id;
                }
                else
                {
                    orForulario.id_departamento = item.id_departamento;
                    orForulario.id_maquina = item.id_maquina;
                    orForulario.id_parteMaquina = item.id_parteMaquina;
                    orForulario.departamento = item.departamento;
                    orForulario.maquina = item.maquina;
                    orForulario.nome = item.nome;
                    orForulario.orderm_Formulario = 0;
                    orForulario.id = 0;
                    orForulario.parteMaquina = item.parteMaquina;
                    orForulario.id_Formulario = item.id;
                }

                lFormulario.Add(orForulario);


            }

            return Json(lFormulario);
        }
        [HttpPost]
        public ActionResult SalvarOrdemFormulario(int id_formulario, int id_formulario_Filho, int id_departamento, int ordem)
        {
            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemForm = new TB_ORDEM_FORMULARIO
            {

                id_Formulario = id_formulario,
                id_formulario_Filho = id_formulario_Filho,
                id_departamento = id_departamento,
                orderm_Formulario = ordem,
                tipo = "C"

            };

            ordemForm.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();


            ordemFormulario = FormOrdemRepos.Cadastrar(ordemForm);

            return Json(ordemFormulario);
        }


        public bool Consulta(TB_ORDEM_FORMULARIO ordemForm)
        {
            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();
            var exists = FormOrdemRepos.Consultar(ordemForm).ToList();
            if (exists.Count > 0)
            {
                if (exists.Where(x => x.id_Formulario == ordemForm.id_Formulario && x.id_departamento == ordemForm.id_departamento && x.id_parteMaquina == ordemForm.id_parteMaquina && x.id_maquina == ordemForm.id_maquina && x.orderm_Formulario == ordemForm.orderm_Formulario).ToList().Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                //if (exists.Where(x => x.id_Formulario == ordemForm.id_Formulario && x.id_formulario_Filho == ordemForm.id_formulario_Filho && x.id_departamento == ordemForm.id_departamento && x.orderm_Formulario == ordemForm.orderm_Formulario).ToList().Count > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            return false;

        }

        [HttpPost]
        public ActionResult AlterarOrdemFormulario(int id_formulario, int id_formulario_Filho, int id_departamento, int ordem, int idRegistro)
        {
            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemForm = new TB_ORDEM_FORMULARIO
            {

                id_Formulario = id_formulario,
                id_formulario_Filho = id_formulario_Filho,
                id_departamento = id_departamento,
                orderm_Formulario = ordem,
                tipo = "A",
                id = idRegistro

            };
            ordemForm.idUsuarioAlt = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");

            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();
            if (Consulta(ordemForm))
            {
                ordemFormulario.msn = "Não é possível atualizar mais de uma  ordem para mais de um formulário.";
            }
            else
            {
                ordemFormulario = FormOrdemRepos.Alterar(ordemForm);
            }

            return Json(ordemFormulario);
        }

        [HttpPost]
        public ActionResult ExcluirOrdemFormulario(int id_formulario, int id_formulario_Filho, int id_departamento)
        {
            Formulario_OrdemRepository FormOrdemRepos = new Formulario_OrdemRepository(_db);
            TB_ORDEM_FORMULARIO ordemForm = new TB_ORDEM_FORMULARIO
            {
                id_Formulario = id_formulario,
                id_formulario_Filho = id_formulario_Filho,
                id_departamento = id_departamento
            };

            TB_ORDEM_FORMULARIO ordemFormulario = new TB_ORDEM_FORMULARIO();

            ordemFormulario = FormOrdemRepos.Excluir(ordemForm);
            return Json(ordemFormulario);
        }
    }
}