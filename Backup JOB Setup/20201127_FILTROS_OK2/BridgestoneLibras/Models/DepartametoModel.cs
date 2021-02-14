using BridgestoneLibras.ModelsEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class DepartamentoModel
    {
        public int id_depto { get; set; }

        [Required(ErrorMessage = "O nome do departamento é obrigatório", AllowEmptyStrings = false)]
        public string  depto { get; set; }
        public int id_status { get; set; }
        public int codigo_departamento { get; set; }
        public List<TB_MAQUINA> lMaquina { get; set; }
        
        public DepartamentoModel()
        {
            lMaquina = new List<TB_MAQUINA>();
        }

        public void Mapper(ref TB_DEPARTAMENTO dbItem)
        {
            //dbItem.id_depto = id_depto;
            //dbItem.depto = depto;
            //dbItem.id_status = id_status;
            //dbItem.codigo_departamento = codigo_departamento;
        }

        public static List<DepartamentoModel> Mapper(List<TB_DEPARTAMENTO> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<DepartamentoModel>();
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
                return lstRet.OrderBy(item => item.depto).ToList();
            }
        }

        private static DepartamentoModel Mapper(TB_DEPARTAMENTO tB_SETOR, object p)
        {
            DepartamentoModel s = new DepartamentoModel();

            //s.id_depto = tB_SETOR.id_depto;
            //s.depto = tB_SETOR.depto;
            //s.id_status = tB_SETOR.id_status;
            //s.codigo_departamento = tB_SETOR.codigo_departamento;
            return s;
        }

        ///// <summary>
        ///// Retorna MV da model.
        ///// </summary>
        //public static PeriodoModel Mapper(TB_PERIODOS dbItem, TB_PERIODOS dbItemProx = null)
        //{
        //    return new PeriodoModel()
        //    {
        //        IdPeriodo = dbItem.id_periodo,
        //        Competencia = dbItem.dt_competencia,
        //        Inicio = dbItem.dt_inicio,
        //        Fim = dbItem.dt_fim,
        //        DiasBridge = dbItem.nr_dia_bridge,
        //        PesoAjustado = dbItem.vl_peso_ajustado,
        //        IdSituacao = dbItem.id_situacao,
        //        Situacao = dbItem.nm_situacao
        //};
        //}

    }


}
