using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class listraCoresModel
    {
        public string codPlanta { get; set; }
        public string codCor { get; set; }
        public string codCorLocal { get; set; }
        public string dscCorLocal { get; set; }
        public string dscCorEnglish { get; set; }

        public listraCoresModel()
        {
        }

        public void Mapper(ref TB_LISTRA_CORES dbItem)
        {
            dbItem.codPlanta = codPlanta;
            dbItem.codCor = codCor;
            dbItem.codCorLocal = codCorLocal;
            dbItem.dscCorLocal = dscCorLocal;
            dbItem.dscCorEnglish = dscCorEnglish ;
        }

        public static List<listraCoresModel> Mapper(List<TB_LISTRA_CORES> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<listraCoresModel>();
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
                return lstRet.OrderBy(item => item.codCor).ToList();
            }


        }

        private static listraCoresModel Mapper(TB_LISTRA_CORES tblCor, object p)
        {
            listraCoresModel s = new listraCoresModel();

            s.codPlanta = tblCor.codPlanta;
            s.codCor = tblCor.codCor;
            s.codCorLocal = tblCor.codCorLocal;
            s.dscCorLocal = tblCor.dscCorLocal;
            s.dscCorEnglish = tblCor.dscCorEnglish;
            return s;
        }

     
    }
}
