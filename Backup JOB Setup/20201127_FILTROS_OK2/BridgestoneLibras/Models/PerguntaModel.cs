using BridgestoneLibras.ModelsEntity;
using System.Collections.Generic;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class PerguntaModel
    {
        public PerguntaModel()
        {
            Formulario = new TB_FORMULARIO();
            lAlternativaPergunta = new List<AlternativaPerguntaModel>();
            RespostasPerguntaModel = new RespostasPerguntaModel();
        }

        public int id_pergunta { get; set; }
        public int id_status { get; set; }
        public string ds_pergunta { get; set; }
        public int id_tipo_resposta { get; set; }
        public int id_obrigatorio { get; set; }
        public int id_verifica_tess { get; set; }
        public int id_pergunta_pai { get; set; }
        public int ordem_apresentacao { get; set; }

        public RespostasPerguntaModel RespostasPerguntaModel { get; set; }
        public TB_FORMULARIO Formulario { get; set; }
        public List<AlternativaPerguntaModel> lAlternativaPergunta { get; set; }


        public static List<PerguntaModel> Mapper(List<TB_PERGUNTA> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<PerguntaModel>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (i == lista.Count - 1)
                {
                    lstRet.Add(Mapper(lista[i], null));
                }
                else
                {
                    lstRet.Add(Mapper(lista[i], lista[i + 1]));
                }
            }

            //Ordernar na procedure
            if (isExecutadoPorProc)
            {
                return lstRet;
            }
            else
            {
                return lstRet.OrderBy(item => item.id_pergunta).ToList();
            }


        }

        private static PerguntaModel Mapper(TB_PERGUNTA tbPergunta, object obj)
        {
            PerguntaModel p = new PerguntaModel();

           // p.id_pergunta = tbPergunta.id_pergunta;
           //// p.Formulario.id_formulario = tbPergunta.Formulario.id_formulario;
           // p.id_status = tbPergunta.id_status;
           // p.ds_pergunta = tbPergunta.ds_pergunta;
           // p.id_tipo_resposta = tbPergunta.id_tipo_resposta;
           // p.id_obrigatorio = tbPergunta.id_obrigatorio;
           // p.id_verifica_tess = tbPergunta.id_verifica_tess;
           // p.id_pergunta_pai = tbPergunta.id_pergunta_pai;
           // p.ordem_apresentacao = tbPergunta.ordem_apresentacao;


            //p.RespostasPerguntaModel.id_respostas = tbPergunta.respostaPergunta.id_respostas.ToString();
            //p.RespostasPerguntaModel.ds_resposta = tbPergunta.respostaPergunta.ds_resposta;

            //foreach (var item in tbPergunta.lAlternativaPergunta)
            //{
            //    AlternativaPerguntaModel modelAlternativa = new AlternativaPerguntaModel();

            //    modelAlternativa.id_alternativa_pergunta = item.id_alternativa_pergunta;
            //    modelAlternativa.ds_alternativa = item.ds_alternativa;
            //    modelAlternativa.id_status = item.id_status;
            //    modelAlternativa.id_pergunta = item.id_pergunta;

            //    p.lAlternativaPergunta.Add(modelAlternativa);
            //}


            return p;
        }
    }
}
