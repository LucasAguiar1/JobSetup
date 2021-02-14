using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class T8x6AModel
    {
        public int id { get; set; }
        public int id_modelo { get; set; }
        public string preforma { get; set; }
        public string part_nbr { get; set; }
        public string inser_vel_rosca { get; set; }
        public string coxim_vel_rosca { get; set; }
        public string vel_linha { get; set; }
        public string inser_extrus { get; set; }
        public string coxim_extrus { get; set; }
        public string inser_armaz { get; set; }
        public string coxim_armaz { get; set; }
        public string tcu_tol { get; set; }
        public string tcu_rosca { get; set; }
        public string tcu_barril { get; set; }
        public string tcu_barril_cabeca { get; set; }
        public string tcu_extrus_coxim_rosca { get; set; }
        public string tcu_extrus_coxim_barril { get; set; }
        public string tcu_extrus_coxim_cabeca { get; set; }
        public string picture_1 { get; set; }
        public string picture_2 { get; set; }

        public string NomeCampo { get; set; }

        //TESS
        public string vms2806_CompoundBEI { get; set; }
        public string vms2806_CompoundBlack { get; set; }
        public string vms2806_OverallWidth { get; set; }
        public string vms2806_CimentoEmenda { get; set; }
        public string vms2806_dienum { get; set; }

        public void Mapper(ref TB_8x6A dbItem)
        {
            dbItem.id = id; 
            dbItem.id_modelo = id_modelo;
            dbItem.preforma = preforma;
            dbItem.part_nbr = part_nbr;
            dbItem.inser_vel_rosca = inser_vel_rosca;
            dbItem.coxim_vel_rosca = coxim_vel_rosca;
            dbItem.vel_linha = vel_linha;
            dbItem.inser_extrus = inser_extrus;
            dbItem.coxim_extrus = coxim_extrus;
            dbItem.inser_armaz = inser_armaz;
            dbItem.coxim_armaz = coxim_armaz;
            dbItem.tcu_tol = tcu_tol;
            dbItem.tcu_rosca = tcu_rosca;
            dbItem.tcu_barril = tcu_barril;
            dbItem.tcu_barril_cabeca = tcu_barril_cabeca;
            dbItem.tcu_extrus_coxim_rosca = tcu_extrus_coxim_rosca;
            dbItem.tcu_extrus_coxim_barril = tcu_extrus_coxim_barril;
            dbItem.tcu_extrus_coxim_cabeca = tcu_extrus_coxim_cabeca;
            dbItem.picture_1 = picture_1;
            dbItem.picture_2 = picture_2;
            dbItem.vms2806_CompoundBEI = vms2806_CompoundBEI;
            dbItem.vms2806_CompoundBlack = vms2806_CompoundBlack;
            dbItem.vms2806_OverallWidth = vms2806_OverallWidth;
            dbItem.vms2806_CimentoEmenda = vms2806_CimentoEmenda;
            dbItem.vms2806_dienum = vms2806_dienum;
        }

        public static List<T8x6AModel> Mapper(List<TB_8x6A> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<T8x6AModel>();
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
                return lstRet.OrderBy(item => item.id).ToList();
            }
        }

        private static T8x6AModel Mapper(TB_8x6A tb, object p)
        {
            T8x6AModel s = new T8x6AModel();

            s.id = tb.id;
            s.id_modelo = tb.id_modelo;
            s.preforma = tb.preforma;
            s.part_nbr = tb.part_nbr;
            s.inser_vel_rosca = tb.inser_vel_rosca;
            s.coxim_vel_rosca = tb.coxim_vel_rosca;
            s.vel_linha = tb.vel_linha;
            s.inser_extrus = tb.inser_extrus;
            s.coxim_extrus = tb.coxim_extrus;
            s.inser_armaz = tb.inser_armaz;
            s.coxim_armaz = tb.coxim_armaz;
            s.tcu_tol = tb.tcu_tol;
            s.tcu_rosca = tb.tcu_rosca;
            s.tcu_barril = tb.tcu_barril;
            s.tcu_barril_cabeca = tb.tcu_barril_cabeca;
            s.tcu_extrus_coxim_rosca = tb.tcu_extrus_coxim_rosca;
            s.tcu_extrus_coxim_barril = tb.tcu_extrus_coxim_barril;
            s.tcu_extrus_coxim_cabeca = tb.tcu_extrus_coxim_cabeca;
            s.picture_1 = tb.picture_1;
            s.picture_2 = tb.picture_2;
            s.vms2806_CompoundBEI = tb.vms2806_CompoundBEI;
            s.vms2806_CompoundBlack = tb.vms2806_CompoundBlack;
            s.vms2806_OverallWidth = tb.vms2806_OverallWidth;
            s.vms2806_CimentoEmenda = tb.vms2806_CimentoEmenda;
            s.vms2806_dienum = tb.vms2806_dienum;
            return s;
        }
    }
}
