using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class ModeloModel
    {
        public int id_Modelo { get; set; }
        public int id_maquina { get; set; }
        public string nm_modelo { get; set; }

        public void Mapper(ref TB_MODELO dbItem)
        {
            dbItem.id_Modelo = id_Modelo;
            dbItem.id_maquina = id_maquina;
            dbItem.nm_modelo = nm_modelo;
        }

        public static List<ModeloModel> Mapper(List<TB_MODELO> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<ModeloModel>();
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
                return lstRet.OrderBy(item => item.nm_modelo).ToList();
            }
        }

        private static ModeloModel Mapper(TB_MODELO tb_modelo, object p)
        {
            ModeloModel s = new ModeloModel();

            s.id_Modelo = tb_modelo.id_Modelo;
            s.id_maquina = tb_modelo.id_maquina;
            s.nm_modelo = tb_modelo.nm_modelo;
            
            return s;
        }
    }
}
