using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class MaquinaModel
    {
        public int id_maquina { get; set; }
        public int id_departamento { get; set; }
        public int id_status { get; set; }
        public string nm_maquina { get; set; }

        public TB_DEPARTAMENTO departamento { get; set; }
        
        public MaquinaModel()
        {
            departamento = new TB_DEPARTAMENTO();
        }

        public void Mapper(ref TB_MAQUINA dbItem)
        {
            //dbItem.id_maquina = id_maquina;
            //dbItem.id_departamento = id_departamento;
            //dbItem.id_status = id_status;
            //dbItem.nm_maquina = nm_maquina;

            TB_DEPARTAMENTO departa = new TB_DEPARTAMENTO();

            //dbItem.departamento.id_depto = id_departamento;
           // dbItem.departamento = departa;

        }

        public static List<MaquinaModel> Mapper(List<TB_MAQUINA> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<MaquinaModel>();
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
                return lstRet.OrderBy(item => item.nm_maquina).ToList();
            }
        }

        private static MaquinaModel Mapper(TB_MAQUINA tbMaquina, object p)
        {
            MaquinaModel s = new MaquinaModel();
            //s.id_departamento = tbMaquina.id_departamento;
            //s.id_maquina = tbMaquina.id_maquina;
            //s.id_status = tbMaquina.id_status;
            //s.nm_maquina = tbMaquina.nm_maquina;

            TB_DEPARTAMENTO dep = new TB_DEPARTAMENTO();

            //dep.id_depto = tbMaquina.departamento.id_depto;
            //dep.depto = tbMaquina.departamento.depto;
            s.departamento = dep;

            return s;
        }
    }
}
