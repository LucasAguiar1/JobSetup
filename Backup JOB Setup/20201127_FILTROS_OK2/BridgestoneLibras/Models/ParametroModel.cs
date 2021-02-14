using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class ParametroModel
    {
        [Display(Name = "ID")]
        public string ID { get; set; }      // ID pergunta
        [Display(Name = "Nome")]
        public string Nome { get; set; }    // Name do campo
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }       //Descrição da pergunta
        [Display(Name = "Valor")]
        public string Valor { get; set; }              // valor da resposta
        [Display(Name = "Size")]
        public string Size { get; set; }                // tamnho do campo
        [Display(Name = "Cabecalho")]
        public string Cabecalho { get; set; }           // SEM USO

        public string Obrigatorio { get; set; }           // SEM USO
        public int Tipo { get; set; }           //  1=numerico 2=texto 3=checkbox(condição) 4=alternativa

        #region [ MAPPER ]

        /// <summary>
        /// Atualiza a model com os dados da MV.
        /// </summary>
        public void Mapper(ref TB_PARAMETROS dbItem)
        {
            dbItem.ID = ID;
            dbItem.Descricao = Descricao;
            dbItem.Valor = Valor;
            dbItem.Size = Size;
            dbItem.Cabecalho = Cabecalho;
            dbItem.Tipo = Tipo;
        }

        /// <summary>
        /// Retornas lista de MV a partir da lista.
        /// </summary>
        public static List<ParametroModel> Mapper(List<TB_PARAMETROS> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<ParametroModel>();
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
                return lstRet.OrderBy(item => item.Descricao).ToList();
            }
        }

        /// <summary>
        /// Retorna MV da model.
        /// </summary>
        public static ParametroModel Mapper(TB_PARAMETROS dbItem, TB_PARAMETROS dbItemProx = null)
        {
            return new ParametroModel()
            {
                ID = dbItem.ID,
                Descricao = dbItem.Descricao,
                Valor = dbItem.Valor,
                Size = dbItem.Size,
                Cabecalho = dbItem.Cabecalho,
                Nome = dbItem.Nome,
                Tipo = dbItem.Tipo
               

            };
        }

        #endregion

    }
}
