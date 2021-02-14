using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class SetorModel
    {
        public int IdSetor { get; set; }
        public string Descricao { get; set; }

      

        public void Mapper(ref TB_SETOR dbItem)
        {
            dbItem.Descricao = Descricao;
            dbItem.IdSetor = IdSetor;
         
        }

        public static List<SetorModel> Mapper(List<TB_SETOR> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<SetorModel>();
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

        private static SetorModel Mapper(TB_SETOR tB_SETOR, object p)
        {
            SetorModel s = new SetorModel();

            s.IdSetor = tB_SETOR.IdSetor;
            s.Descricao = tB_SETOR.Descricao;
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
