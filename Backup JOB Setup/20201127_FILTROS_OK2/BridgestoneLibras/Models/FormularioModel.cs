using BridgestoneLibras.ModelsEntity;
using System.Collections.Generic;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class FormularioModel
    {
        public int id_formulario { get; set; }
        public string ds_nome { get; set; }
        public int id_status { get; set; }

        public TB_MAQUINAPARTE MaquinaParte { get; set; }
        public List<PerguntaModel> lPerguntaModel { get; set; }
        public MaquinaModel Maquina { get; set; }


        public FormularioModel()
        {
            MaquinaParte = new TB_MAQUINAPARTE();
            lPerguntaModel = new List<PerguntaModel>();
            Maquina = new MaquinaModel();
        }
        public void Mapper(ref TB_FORMULARIO dbItem)
        {
           // dbItem.id_formulario = id_formulario;
           // dbItem.id_status = id_status;
           // dbItem.ds_nome = ds_nome;
           //// dbItem.MaquinaParte.id_maquina = MaquinaParte.id_maquina_parte;
            //dbItem.Maquina.id_maquina = Maquina.id_maquina;
            //dbItem.Maquina.nm_maquina = Maquina.nm_maquina;


            foreach (var item in lPerguntaModel)
            {
                TB_PERGUNTA pergunta = new TB_PERGUNTA();

                //pergunta.id_pergunta = item.id_pergunta;
                //pergunta.id_status = item.id_status;
                //pergunta.ds_pergunta = item.ds_pergunta;
                //pergunta.id_tipo_resposta = item.id_tipo_resposta;
                //pergunta.id_obrigatorio = item.id_obrigatorio;
                //pergunta.id_verifica_tess = item.id_verifica_tess;
                //pergunta.id_pergunta_pai = item.id_pergunta_pai;
                //pergunta.ordem_apresentacao = item.ordem_apresentacao;

              //  dbItem.ListaPergunta.Add(pergunta);
            }
        }

        public static List<FormularioModel> Mapper(List<TB_FORMULARIO> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<FormularioModel>();
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
                return lstRet.OrderBy(item => item.ds_nome).ToList();
            }


        }

        private static FormularioModel Mapper(TB_FORMULARIO tb_formulario, object p)
        {
            FormularioModel f = new FormularioModel();

            //f.id_formulario = tb_formulario.id_formulario;
            //f.id_status = tb_formulario.id_status;
            //f.ds_nome = tb_formulario.ds_nome;
            //f.MaquinaParte.id_maquina_parte = tb_formulario.MaquinaParte.id_maquina_parte;
            //f.MaquinaParte.ds_maquina_parte = tb_formulario.MaquinaParte.ds_maquina_parte;

            //f.Maquina.id_maquina = tb_formulario.Maquina.id_maquina;
            //f.Maquina.nm_maquina = tb_formulario.Maquina.nm_maquina;

            //foreach (var itemPergunta in tb_formulario.ListaPergunta)
            //{
            //    PerguntaModel model = new PerguntaModel();

            //    model.id_pergunta = itemPergunta.id_pergunta;
            //    model.id_status = itemPergunta.id_status;
            //    model.ds_pergunta = itemPergunta.ds_pergunta;
            //    model.id_tipo_resposta = itemPergunta.id_tipo_resposta;
            //    model.id_obrigatorio = itemPergunta.id_obrigatorio;
            //    model.id_verifica_tess = itemPergunta.id_verifica_tess;
            //    model.id_pergunta_pai = itemPergunta.id_pergunta_pai;
            //    model.ordem_apresentacao = itemPergunta.ordem_apresentacao;

            //    f.lPerguntaModel.Add(model);
            //}


            return f;
        }
    }
}
