using BridgestoneLibras.ModelsEntity;
using System.Collections.Generic;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class MaquinaParteModel
    {

        public int id_maquina_parte { get; set; }
        public int id_maquina { get; set; }
        public string ds_maquina_parte { get; set; }
        public int id_status { get; set; }        
        public TB_MAQUINA lMaquina { get; set; }

        public void Mapper(ref TB_MAQUINAPARTE dbItem)
        {
           // dbItem.id_maquina_parte = id_maquina_parte;
           // dbItem.id_maquina = id_maquina;
           // dbItem.ds_maquina_parte = ds_maquina_parte;
           // dbItem.id_status = id_status;

           // TB_MAQUINA maquina = new TB_MAQUINA();
           //// maquina.id_maquina = id_maquina;
           // dbItem.tbMaquina = maquina;

            //maquina.departamento.codigo_departamento = dbItem.tbMaquina.departamento.codigo_departamento;
            //maquina.departamento.depto = dbItem.tbMaquina.departamento.depto;

        }

        public static List<MaquinaParteModel> Mapper(List<TB_MAQUINAPARTE> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<MaquinaParteModel>();
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
                return lstRet.OrderBy(item => item.id_maquina_parte).ToList();
            }


        }

        private static MaquinaParteModel Mapper(TB_MAQUINAPARTE tbMaquinaParte, object p)
        {
            MaquinaParteModel m = new MaquinaParteModel();
            //m.id_maquina_parte = tbMaquinaParte.id_maquina_parte;
            //m.id_maquina = tbMaquinaParte.id_maquina;
            //m.id_status = tbMaquinaParte.id_status;
            //m.ds_maquina_parte = tbMaquinaParte.ds_maquina_parte;

            TB_MAQUINA maquina = new TB_MAQUINA();
            //maquina.id_maquina = tbMaquinaParte.tbMaquina.id_maquina;
          //  maquina.nm_maquina = tbMaquinaParte.tbMaquina.nm_maquina;

            //maquina.departamento.codigo_departamento = tbMaquinaParte.tbMaquina.departamento.codigo_departamento;
            //maquina.departamento.depto = tbMaquinaParte.tbMaquina.departamento.depto;

            m.lMaquina = maquina;

            return m;
        }
    }
}
