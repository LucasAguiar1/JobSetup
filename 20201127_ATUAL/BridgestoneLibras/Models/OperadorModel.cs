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
    public class OperadorModel
    {

        public string id { get; set; }
        public string valor { get; set; }
        public void Mapper(ref OPERADOR dbItem)
        {
            dbItem.id = id;
            dbItem.valor = valor;
        }

        public static List<OperadorModel> Mapper(List<OPERADOR> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<OperadorModel>();
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

            return lstRet;


        }

        private static OperadorModel Mapper(OPERADOR operador, object p)
        {
            OperadorModel tModel = new OperadorModel();

            tModel.id = operador.id;
            tModel.valor = operador.valor;
            
           
            return tModel;

        }
    }
}