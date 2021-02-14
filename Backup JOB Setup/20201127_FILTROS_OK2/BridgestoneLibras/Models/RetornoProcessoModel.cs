using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class RetornoProcessoModel
    {

        public string Capa { get; set; }
        public string Base { get; set; }
        public string Codigo { get; set; }        
        public void Mapper(ref TB_RETORNOPROCESSO dbItem)
        {
            dbItem.Capa = Capa;
            dbItem.Base = Base;
            dbItem.Codigo = Codigo;
        }

        public static List<RetornoProcessoModel> Mapper(List<TB_RETORNOPROCESSO> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<RetornoProcessoModel>();
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

            ////Ordernar na procedure
            //if (isExecutadoPorProc)
            //{
            //    return lstRet;
            //}
            //else
            //{
            //    return lstRet.OrderBy(item => item.Descricao).ToList();
            //}
            return lstRet;


        }

        private static RetornoProcessoModel Mapper(TB_RETORNOPROCESSO tb_retornoProcesso, object p)
        {
            RetornoProcessoModel tModel = new RetornoProcessoModel();

            tModel.Base = tb_retornoProcesso.Base;
            tModel.Capa = tb_retornoProcesso.Capa;
            tModel.Codigo = tb_retornoProcesso.Codigo;
           
            return tModel;

        }
    }
}