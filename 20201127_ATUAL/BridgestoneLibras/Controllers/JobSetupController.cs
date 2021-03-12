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
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using Remotion.Linq.Clauses.ResultOperators;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace BridgestoneLibras.Controllers
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class JobSetupController : Controller
    {
        private readonly ApplicationDbSpecContext _db;
        private readonly ILogger<OperadorController> _log;
        IConfiguration _iconfiguration;
        Document Document = new Document();

        List<Status> listaStatus = new List<Status>();

        static string vc_identificador_lote1 = "0"; //para pega o lote
        static int idPreenchimento = 0; 

        //the framework handles this
        public JobSetupController(ApplicationDbSpecContext db,
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


        public ActionResult Departamentos()
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
                listDepartamentos = repDepartamento.Consultar(dp).Where(x => x.status == 1).ToList();
            }

            return Json(listDepartamentos);

        }

        public ActionResult Maquinas(int idDepartamento)
        {
            TB_MAQUINA m = new TB_MAQUINA();
            m.id_departamento = idDepartamento;
            MaquinaRepository RepMaquinas = new MaquinaRepository(_db);

            return Json(RepMaquinas.Consultar(m).Where(x => x.status == 1).ToList());
        }
        public ActionResult MaquinasParte(int idMaquina)
        {
            TB_MAQUINAPARTE m = new TB_MAQUINAPARTE();
            m.id_maquina = idMaquina;
            MaquinaParteRepository RepMaquinaParte = new MaquinaParteRepository(_db);

            return Json(RepMaquinaParte.Consultar(m).Where(x => x.status == 1).ToList());
        }

        public ActionResult Formularios(int idMaquinaParte)
        {
            TB_FORMULARIO m = new TB_FORMULARIO();
            m.id = idMaquinaParte;
            FormularioRepository RepFormulario = new FormularioRepository(_db);

            return Json(RepFormulario.OrdemPriodidade(m).Where(x => x.status == 1).ToList());
        }


        [HttpPost]
        public ActionResult RespostaPergunta([FromBody]List<TB_RespPai> tb_resPai)
        {
            return Json(Cadastrar(tb_resPai, "A"));
        }

        public List<TB_RespPai> Cadastrar(List<TB_RespPai> tb_resPai, string status)
        {
            RespostaRepository respostaRep = new RespostaRepository(_db);
            RespostaFilhoRepository respostaFilhoRep = new RespostaFilhoRepository(_db);

            TB_PREENCHIMENTO p = new TB_PREENCHIMENTO();

            if (!VerificaStatus(tb_resPai))
            {
                p.idPreenchimento = GeraCodigoPreenchimento(tb_resPai.FirstOrDefault().id_formulario);
                idPreenchimento = p.idPreenchimento;

                foreach (var itemPai in tb_resPai)
                {
                    itemPai.nomeUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
                    itemPai.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
                    itemPai.status = status;
                    itemPai.idPreenchimento = p.idPreenchimento;

                    if (itemPai.id_tipoResposta == 1)
                    {
                        PerguntaRepository PergRepositoy = new PerguntaRepository(_db);
                        TB_PERGUNTA perg = new TB_PERGUNTA();
                        perg.id = itemPai.id;
                        itemPai.idsAlternativas = PergRepositoy.Consultar(perg).FirstOrDefault().idsAlternativa;
                    }

                    if (respostaRep.Cadastrar(itemPai))
                    {
                        int cont = 0;
                        if (tb_resPai.FirstOrDefault().idRetorno != 0)
                        {
                            if (itemPai.Filho.Count > 0)
                            {

                                PerguntaRepository PergRepositoy = new PerguntaRepository(_db);
                                TB_PERGUNTA perg = new TB_PERGUNTA();

                                perg.id = itemPai.Filho.ElementAt(cont).id;
                                itemPai.idsAlternativas = PergRepositoy.Consultar(perg).FirstOrDefault().idsAlternativa;
                                cont++;


                                respostaFilhoRep.Cadastrar(itemPai.Filho, itemPai);
                            }
                        }
                    }
                }

                
            }
            else
            {
                foreach (var itemPai in tb_resPai)
                {
                    itemPai.nomeUsuario = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario");
                    itemPai.idUsuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login");
                    itemPai.status = status;

                    if (respostaRep.Alterar(itemPai))
                    {
                        if (itemPai.Filho.Count > 0)
                        {
                            respostaFilhoRep.Alterar(itemPai.Filho, itemPai);
                        }
                    }
                }
            }
            //Cadatrar o lote na  tabela junto com o o id do preenchimneto. 
            IdentificadorLoteRepository identificador = new IdentificadorLoteRepository(_db);

            p.idPreenchimento = idPreenchimento; 
            
            if (CadastrarIdentificadoLoteXidPreenchimento(p).Count.Equals(0)){
                TB_IDENTIFICADORLOTE iden = new TB_IDENTIFICADORLOTE();
                iden.idPreenchimento = idPreenchimento;
                iden.identificadoLote = vc_identificador_lote1;
                CadastrarIdentificadoLote(iden);
                
            }
            //Limpa as duas variaveis staticas. 
            idPreenchimento = 0;
            vc_identificador_lote1 = "0";
            


            return tb_resPai;
        }

        public void CadastrarIdentificadoLote(TB_IDENTIFICADORLOTE identificarLote)
        {

            IdentificadorLoteRepository identificador = new IdentificadorLoteRepository(_db);

            identificador.Cadastrar(identificarLote);
        }

        public List<TB_IDENTIFICADORLOTE> CadastrarIdentificadoLoteXidPreenchimento(TB_PREENCHIMENTO preenchimento)
        {

            IdentificadorLoteRepository identificador = new IdentificadorLoteRepository(_db);

            TB_IDENTIFICADORLOTE iden = new TB_IDENTIFICADORLOTE();
            iden.idPreenchimento = preenchimento.idPreenchimento;
            iden.identificadoLote = vc_identificador_lote1;

            return identificador.ConsultarIndentificador(iden);
        }

        [HttpPost]
        public ActionResult FinalizarRespostaPergunta([FromBody]List<TB_RespPai> tb_resPai)
        {
            return Json(Cadastrar(tb_resPai, "F"));
        }

        public bool VerificaStatus(List<TB_RespPai> tb_resPai)
        {
            //Verifica se ja foi respondida alguma pergunta, caso tenha sido respondia o return é falso , assim será executada a opção de update.

            foreach (var item in tb_resPai)
            {
                if (item.chave != 0)
                {
                    return true;
                }

                if (item.Filho.Count > 0)
                {
                    foreach (var f in item.Filho)
                    {
                        if (f.chave != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int GeraCodigoPreenchimento(int idFormulario)
        {

            PreenchimentoRepository preenchimentoRep = new PreenchimentoRepository(_db);
            TB_PREENCHIMENTO p = new TB_PREENCHIMENTO
            {
                id_formulario = idFormulario
            };
            return preenchimentoRep.Cadastrar(p).idPreenchimento;

        }

        public ActionResult Perguntas(int idFormulario)
        {
            RespostaRepository respostaRep = new RespostaRepository(_db);

            TB_RespPai tbPai = new TB_RespPai();
            tbPai.id_formulario = idFormulario;

            //Popula Objeto com as respostas com o status A.
            var respostaPai = respostaRep.Consultar(tbPai).Where(X => X.status == "A").ToList();

            if (respostaPai.Count > 0)
            {
                return Json(PerguntasAtivasInativas(idFormulario));
            }
            else
            {
                return Json(PerguntasAtivas(idFormulario));
            }
        }


        public TB_IDENTIFICADORLOTE IdentificadorLote(int id_maquinaPCS)
        {
            IdentificadorLoteRepository RepositoryInd = new IdentificadorLoteRepository(_db);
            TB_IDENTIFICADORLOTE tindentificador = new TB_IDENTIFICADORLOTE();
            tindentificador.id_maquina = id_maquinaPCS;
            return RepositoryInd.Consultar(tindentificador);
        }

        public void IdentificadorLote(ref List<TB_PERGUNTA> perguntas)
        {
            if (perguntas.First().identificadorLote == "")
            {
                var identificador = IdentificadorLote(Convert.ToInt32(perguntas.FirstOrDefault().i_Pk_Maquina));
                if (identificador.vc_identificador_lote1 != null)
                {
                    perguntas.First().identificadorLote = identificador.vc_identificador_lote1;
                         vc_identificador_lote1 = identificador.vc_identificador_lote1;
                    idPreenchimento = identificador.idPreenchimento;
                }
                else
                {
                    perguntas.First().identificadorLote = "0";
                    vc_identificador_lote1 = "0";
                    idPreenchimento = 0; 
                }
            }
            else
            {
                vc_identificador_lote1 = perguntas.First().identificadorLote;
                idPreenchimento = perguntas.First().idpreenchimento;
            }
        }

        public List<TB_PERGUNTA> VerificaPerguntaCondicao(ref List<TB_PERGUNTA> perguntas)
        {
            //Retira condição com pergunta com o status 2 (inativa)
            List<TB_PERGUNTA> PerguntasCondicao = new List<TB_PERGUNTA>();

            foreach (var item in perguntas)
            {
                if (item.id_tipoResposta == 2 && item.listFilhos.Count == 0)
                {
                    PerguntasCondicao.Add(item);
                }

            }

            foreach (var item in PerguntasCondicao)
            {
                perguntas.Remove(item);
            }


            return perguntas;
        }
        public List<TB_PERGUNTA> populaObj(ref List<TB_PERGUNTA> perguntas)
        {
            RespostaRepository respostaRep = new RespostaRepository(_db);
            RespostaFilhoRepository respostaFilhoRep = new RespostaFilhoRepository(_db);

            TB_RespPai tbPai = new TB_RespPai();
            tbPai.id_formulario = perguntas.FirstOrDefault().id_formulario;

            //Popula Objeto com as respostas com o status A.
            var respostaPai = respostaRep.Consultar(tbPai).Where(X => X.status == "A").ToList();

            var idPreenchimento = 0;
            //Alternativas
            if (respostaPai.Count > 0)
            {

                idPreenchimento = respostaPai.FirstOrDefault().idPreenchimento;

                foreach (var item in perguntas)
                {
                    if (item.id_tipoResposta.Equals(3))
                    {
                        if (respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).ToList().Count > 0)
                        {
                            item.valor = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().valor.ToString();
                            item.chave = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().chave;
                        }
                    }

                    if (item.id_tipoResposta.Equals(4))
                    {
                        if (respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).ToList().Count > 0)
                        {
                            item.valor = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().valor.ToString();
                            item.chave = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().chave;
                        }
                    }

                    if (item.id_tipoResposta.Equals(1))
                    {
                        if (respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).ToList().Count > 0)
                        {
                            //item.listDescricaoMultiplaEscolha = Alternativas(item.idsAlternativa);
                            item.valor = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().valor.ToString();
                            item.chave = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().chave;

                            TB_RespPai pergPai = new TB_RespPai();
                            pergPai.id_formulario = perguntas.FirstOrDefault().id_formulario;
                            var ids = ObterDescricaoMultiplaEscolhaNivelPai(pergPai, item);

                            item.idsAlternativa = ids.idsAlternativa;
                            item.listDescricaoMultiplaEscolha = Alternativas(ids.idsAlternativa).ToList();

                        }
                    }
                    //Condição
                    if (item.id_tipoResposta.Equals(2))
                    {
                        item.listFilhos = Condicao(item.id);

                        if (respostaPai.Where(x => x.idPreenchimento == idPreenchimento && x.id == Convert.ToInt32(item.id)).ToList().Count > 0)
                        {
                            item.valor = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().valor.ToString();
                            item.chave = respostaPai.Where(x => x.id == Convert.ToInt32(item.id)).FirstOrDefault().chave;
                        }

                        var repostaFilho = respostaFilhoRep.Consultar(item);

                        foreach (var f in item.listFilhos)
                        {
                            if (repostaFilho.Count > 0)
                            {
                                repostaFilho = repostaFilho.Where(x => x.idPreenchimento == idPreenchimento).ToList();

                                if (repostaFilho.Where(x => x.id == f.id_filho).ToList().Count > 0)
                                {
                                    if (repostaFilho.Where(x => x.id == f.id_filho).FirstOrDefault().valor != null)
                                    {
                                        f.valor = repostaFilho.Where(x => x.id == f.id_filho).FirstOrDefault().valor.ToString();
                                        f.chave = repostaFilho.Where(x => x.id == f.id_filho).FirstOrDefault().chave;
                                    }
                                }
                            }
                            if (f.id_tipoResposta.Equals(1))
                            {
                                //Consulta os ids que estão na tabela resposta Pai, pois na tabela de perguntas as alternativas podem ser retiradas.
                                TB_PERGUNTA perg = new TB_PERGUNTA();
                                perg.id_formulario = perguntas.FirstOrDefault().id_formulario;
                                perg.id = f.id_perguntaPai;

                                var ids = ObterDescricaoMultiplaEscolhaNivelFilho(perg, f);
                                f.idsAlternativa = ids.idsAlternativa;
                                f.listDescricaoMultiplaEscolha = Alternativas(ids.idsAlternativa).ToList();
                            }
                        }
                    }
                }
            }

            //Aqui retira as  perguntas que foram adicionadas após o inicio das respostas pelo operador.

            if (perguntas.Where(x => x.chave != 0).ToList().Count > 0)
            {
                perguntas = perguntas.Where(x => x.chave != 0).ToList();
            }
            return perguntas;
        }

        public List<TB_PERGUNTA> PerguntasAtivas(int idFormulario)
        {
            TB_PERGUNTA p = new TB_PERGUNTA();
            p.id_formulario = idFormulario;
            FormularioRepository PerguntasPorFormulario = new FormularioRepository(_db);

            var perguntas = PerguntasPorFormulario.ConsultaPerguntasPorFormulario(p).Where(x => x.status == 1).ToList();

            if (perguntas.Count > 0)
            {
                IdentificadorLote(ref perguntas);
            }
            //Alternativas
            try
            {
                foreach (var item in perguntas)
                {

                    if (item.id_tipoResposta.Equals(1))
                    {
                        if (item.idsAlternativa != "")
                        {
                            item.listDescricaoMultiplaEscolha = Alternativas(item.idsAlternativa).Where(x => x.status == 1).ToList();
                        }
                    }
                    //Condição
                    if (item.id_tipoResposta.Equals(2))
                    {
                        item.listFilhos = Condicao(item.id).Where(x => x.status == 1).ToList();

                        foreach (var f in item.listFilhos)
                        {
                            if (f.id_tipoResposta.Equals(1))
                            {
                                if (f.idsAlternativa != "")
                                {
                                    f.listDescricaoMultiplaEscolha = Alternativas(f.idsAlternativa).Where(x => x.status == 1).ToList();
                                }
                            }
                        }
                    }
                }


                var copyListPerguntas = perguntas;

                foreach (var item in copyListPerguntas)
                {
                    foreach (var f in item.listFilhos)
                    {
                        perguntas = perguntas.Where(x => x.id != f.id_filho).ToList();
                    }
                }


                //Nesse metodo verifico se a pergunta do tipo condição existe uma pergunta, caso não tenha retiro a pergunta condição do objeto
                perguntas = VerificaPerguntaCondicao(ref perguntas);

                if (perguntas.Count > 0)
                {
                    perguntas = populaObj(ref perguntas);
                    AdiconaSelecione(ref perguntas);
                }

                return perguntas;
            }
            catch (Exception EX)
            {

                throw EX;
            }
            

        }

        public List<TB_PERGUNTA> PerguntasAtivasInativas(int idFormulario)
        {
            //populo objeto e nao verifico Status de Ativo ou invativo das perguntas, caso ja  tenha  iniciado a responder  o formulario.

            TB_PERGUNTA p = new TB_PERGUNTA();
            p.id_formulario = idFormulario;
            FormularioRepository PerguntasPorFormulario = new FormularioRepository(_db);

            var perguntas = PerguntasPorFormulario.ConsultaPerguntasPorFormulario(p).ToList();

            if (perguntas.Count > 0)
            {
                IdentificadorLote(ref perguntas);
            }


            //Alternativas
            foreach (var item in perguntas)
            {

                if (item.id_tipoResposta.Equals(1))
                {
                    //Consulta os ids que estão na tabela resposta Pai, pois na tabela de perguntas as alternativas podem ser retiradas.
                    TB_RespPai pergPai = new TB_RespPai();
                    pergPai.id_formulario = idFormulario;

                    var retPerguntaMultiplaEscolha = ObterDescricaoMultiplaEscolhaNivelPai(pergPai, item);

                    item.listDescricaoMultiplaEscolha = retPerguntaMultiplaEscolha.listDescricaoMultiplaEscolha;
                    item.idsAlternativa = retPerguntaMultiplaEscolha.idsAlternativa;
                }
                //Condição
                if (item.id_tipoResposta.Equals(2))
                {
                    item.listFilhos = Condicao(item.id).ToList();

                    foreach (var f in item.listFilhos)
                    {
                        if (f.id_tipoResposta.Equals(1))
                        {
                            //Consulta os ids que estão na tabela resposta Pai, pois na tabela de perguntas as alternativas podem ser retiradas.
                            TB_PERGUNTA perg = new TB_PERGUNTA();
                            perg.id_formulario = idFormulario;
                            perg.id = f.id_perguntaPai;

                            var ids = ObterDescricaoMultiplaEscolhaNivelFilho(perg, f);

                            f.idsAlternativa = ids.idsAlternativa;
                            f.listDescricaoMultiplaEscolha = Alternativas(ids.idsAlternativa).ToList();
                        }
                    }
                }
            }


            var copyListPerguntas = perguntas;

            foreach (var item in copyListPerguntas)
            {
                foreach (var f in item.listFilhos)
                {
                    perguntas = perguntas.Where(x => x.id != f.id_filho).ToList();
                }
            }


            //Nesse metodo verifico se a pergunta do tipo condição existe uma pergunta, caso não tenha retiro a pergunta condição do objeto

            if (perguntas.Count > 0)
            {
                perguntas = populaObj(ref perguntas);
                AdiconaSelecione(ref perguntas);
            }

            return perguntas;

        }

        public List<TB_PERGUNTA> AdiconaSelecione(ref List<TB_PERGUNTA> listPergunta)
        {

            foreach (var item in listPergunta)
            {
                if (item.listDescricaoMultiplaEscolha.Count > 0)
                {
                    TB_DescricaoMultiplaEscolha d = new TB_DescricaoMultiplaEscolha();
                    d.id = 0;
                    d.nome = "Selecione";
                    item.listDescricaoMultiplaEscolha.Insert(0, d);
                }
                if (item.listFilhos.Count > 0)
                {
                    foreach (var filho in item.listFilhos)
                    {
                        TB_DescricaoMultiplaEscolha d = new TB_DescricaoMultiplaEscolha();
                        d.id = 0;
                        d.nome = "Selecione";
                        filho.listDescricaoMultiplaEscolha.Insert(0, d);
                    }
                }

            }
            return listPergunta;
        }

        public List<TB_DescricaoMultiplaEscolha> Alternativas(string idsAlternativa)
        {
            List<TB_DescricaoMultiplaEscolha> list = new List<TB_DescricaoMultiplaEscolha>();
            DescricaoMultiplaEscolhaRepository desc = new DescricaoMultiplaEscolhaRepository(_db);

            var ids = idsAlternativa.Split('-');

            for (int i = 0; i < ids.Length; i++)
            {
                TB_DescricaoMultiplaEscolha d = new TB_DescricaoMultiplaEscolha();
                d.id = Convert.ToInt32(ids[i]);
                list.Add(desc.ConsultarPorPergunta(d).FirstOrDefault());
            }
            return list;
        }

        public TB_PERGUNTA ObterDescricaoMultiplaEscolhaNivelPai(TB_RespPai pergPai, TB_PERGUNTA item)
        {
            RespostaRepository respRepository = new RespostaRepository(_db);

            if (respRepository.Consultar(pergPai).Where(x => x.id == item.id && x.Filho.Count == 0).ToList().Count > 0)
            {
                item.idsAlternativa = respRepository.Consultar(pergPai).Where(x => x.id == item.id && x.Filho.Count == 0).FirstOrDefault().idsAlternativas;
                item.listDescricaoMultiplaEscolha = Alternativas(item.idsAlternativa).ToList();
            }
            return item;

        }

        public TB_FILHO ObterDescricaoMultiplaEscolhaNivelFilho(TB_PERGUNTA pergPai, TB_FILHO f)
        {

            //Consulta os ids que estão na tabela resposta Pai, pois na tabela de perguntas as alternativas podem ser retiradas.
            RespostaFilhoRepository repsFilho = new RespostaFilhoRepository(_db);
            TB_PERGUNTA perg = new TB_PERGUNTA();
            perg.id_formulario = pergPai.id_formulario;
            perg.id = f.id_perguntaPai;

            var ids = repsFilho.Consultar(perg).ToList();

            if (ids.Count > 0)
            {
                f.idsAlternativa = ids.FirstOrDefault().idsAlternativa;
                f.listDescricaoMultiplaEscolha = Alternativas(f.idsAlternativa).ToList();
            }

            return f;
        }


        public List<TB_FILHO> Condicao(int id)
        {
            FilhoRepository Repfilho = new FilhoRepository(_db);
            TB_FILHO filho = new TB_FILHO
            {
                id_perguntaPai = id
            };

            return Repfilho.Consultar(filho);
        }

        public List<TB_FILHO> txt(int id)
        {
            FilhoRepository Repfilho = new FilhoRepository(_db);
            TB_FILHO filho = new TB_FILHO
            {
                id_perguntaPai = id
            };

            return Repfilho.Consultar(filho);
        }



        public ActionResult Notificacao([FromBody] TB_NOTIFICACAO myData)
        {
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);

            myData.id_nomeOperador = HttpContext.Session.GetString("usuario") == "" ? "" : HttpContext.Session.GetString("usuario").Trim();
            myData.id_usuario = HttpContext.Session.GetString("login") == "" ? "" : HttpContext.Session.GetString("login").Trim();

            myData = notificacaoRepos.Cadastrar(myData);

            return Json(myData);
        }



        public ActionResult ConsultarListaUsuarios(int idDepartamento)
        {
            NotificacaoRepository notificacaoRepos = new NotificacaoRepository(_db);
            
            DepartamentoRepository dep = new DepartamentoRepository(_db);
            TB_DEPARTAMENTO departamento = new TB_DEPARTAMENTO();

            var departamentos = dep.Consultar(departamento);

            return Json(notificacaoRepos.Combo(notificacaoRepos.ConsultarListaUsuarios(departamentos.Where(x => x.id == idDepartamento).FirstOrDefault().codigo), "Selecione"));
        }
    }
}