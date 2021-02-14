using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class TriplexbModel
    {
        public int id_modelo { get; set; }
        public int id { get; set; }
        public string part_nbr { get; set; }
        public string ferr_pre_forma { get; set; }
        public string ferr_pre_chapa { get; set; }
        public string inser_capa { get; set; }
        public string inser_base { get; set; }
        public string capa_larg_fita { get; set; }
        public string capa_vel_rosca { get; set; }
        public string capa_temp_max_extr { get; set; }
        public string base_larg_fita { get; set; }
        public string base_vel_rosca { get; set; }
        public string base_temp_max_extr { get; set; }
        public string mini_lateral_vel_rosca { get; set; }
        public string mini_lateral_temp_max_extr { get; set; }
        public string coxim_temp_max_extr { get; set; }
        public string temp_max_armaz { get; set; }
        public string vel_linha { get; set; }
        public string comp_peca_nominal { get; set; }
        public string adab_nominal { get; set; }
        public string cod_ret_proc_cor_nome { get; set; }
        public string cab_vblock { get; set; }
        public string cab_cabeca { get; set; }
        public string ext_aux_mini_lat_barril { get; set; }
        public string ext_aux_mini_lat_rosca { get; set; }
        public string ext_mini_lateral_barril_alim { get; set; }
        public string ext_mini_lateral_barril_1_2 { get; set; }
        public string ext_mini_lateral_rosca { get; set; }
        public string ext_cal_coxim_barril_rosca { get; set; }
        public string ext_cal_coxim_calandra { get; set; }
        public string ext_capa_barril { get; set; }
        public string ext_capa_rosca { get; set; }
        public string ext_base_barril { get; set; }
        public string ext_base_rosca { get; set; }
        public string tcu_tol { get; set; }
        public string adab1 { get; set; }
        public string adab2 { get; set; }
        public string adab3 { get; set; }
        public string operadorAdab1 { get; set; }
        public string operadorAdab2 { get; set; }
        public string operadorAdab3 { get; set; }
        public string picture_1 { get; set; }
        public string picture_2 { get; set; }
        public string Imagem { get; set; }

        //Cálculo
        public int ValorComprimentoPeca { get; set; }
        public int ValorLarguraTotal { get; set; }
        public int ValorLarguraOmbro { get; set; }
        public int ValorLarguraCoxim { get; set; }
        public double ValorEspessuraCoxim { get; set; }
        public double ValorPesoPeca { get; set; }
        public double ValorAdab { get; set; }
        public string CalculoMaxComprimentoPeca { get; set; }
        public string CalculoMinComprimentoPeca { get; set; }
        public string CalculoMaxLarguraTotal { get; set; }
        public string CalculoMinLarguraTotal { get; set; }
        public string CalculoMaxLarguraOmbro { get; set; }
        public string CalculoMinLarguraOmbro { get; set; }
        public string CalculoMaxLarguraCoxim { get; set; }
        public string CalculoMinLarguraCoxim { get; set; }
        public string CalculoMaxEspessuraCoxim { get; set; }
        public string CalculoMinEspessuraCoxim { get; set; }
        public string CalculoMaxPesoPeca { get; set; }
        public string CalculoMinPesoPeca { get; set; }
        public string CalculoMaxAdab { get; set; }
        public string CalculoMinAdab { get; set; }
        // TESS
        public string LMS2806A_DIENUM { get; set; }
        public string LMS2832C_MSV17A { get; set; }
        public string LMS2832C_MSV18A { get; set; }
        public string LMS2832C_MSV19A { get; set; }
        public string LMS2832C_MSV1AA { get; set; }
        public string LMS2806A_BASECE { get; set; }
        public string LMS2806A_Splice { get; set; }
        public string LMS2832C_MS3QA { get; set; }
        public string LMS2832C_WIDTH4 { get; set; }
        public string LMS2832C_GAUGE4 { get; set; }
        public string LMS2813A_STR1SP { get; set; }
        public string LMS2813A_TRDSET { get; set; }
        public string LMS2813A_TRDCOD { get; set; }
        public string LMS2905C_SHLDWD { get; set; }
        public string LMS2825C_CUST { get; set; }
        public string LMS2813A_CTRCLR { get; set; }
        public string LMS2813A_STR1CL { get; set; }
        public string LMS2813A_STRPWD { get; set; }
        public string LMS2813A_STR2CL { get; set; }

        public string LMS2806A_LENGTH { get; set; }

        public string LMS2801C_WEIGHT { get; set; }

        public int retornoTESS { get; set; }
        public void Mapper(TB_TRIPLEXB dbItem)
        {
            dbItem.id_modelo = id_modelo;
            dbItem.id = id;
            dbItem.part_nbr = part_nbr;
            dbItem.ferr_pre_forma = ferr_pre_forma;
            dbItem.ferr_pre_chapa = ferr_pre_chapa;
            dbItem.inser_capa = inser_capa;
            dbItem.inser_base = inser_base;
            dbItem.capa_larg_fita = capa_larg_fita;
            dbItem.capa_vel_rosca = capa_vel_rosca;
            dbItem.capa_temp_max_extr = capa_temp_max_extr;
            dbItem.base_larg_fita = base_larg_fita;
            dbItem.base_vel_rosca = base_vel_rosca;
            dbItem.base_temp_max_extr = base_temp_max_extr;
            dbItem.mini_lateral_vel_rosca = mini_lateral_vel_rosca;
            dbItem.mini_lateral_temp_max_extr = mini_lateral_temp_max_extr;
            dbItem.coxim_temp_max_extr = coxim_temp_max_extr;
            dbItem.temp_max_armaz = temp_max_armaz;
            dbItem.vel_linha = vel_linha;
            dbItem.comp_peca_nominal = comp_peca_nominal;
            dbItem.adab_nominal = adab_nominal;
            dbItem.cod_ret_proc_cor_nome = cod_ret_proc_cor_nome;
            dbItem.cab_vblock = cab_vblock;
            dbItem.cab_cabeca = cab_cabeca;
            dbItem.ext_aux_mini_lat_barril = ext_aux_mini_lat_barril;
            dbItem.ext_aux_mini_lat_rosca = ext_aux_mini_lat_rosca;
            dbItem.ext_mini_lateral_barril_alim = ext_mini_lateral_barril_alim;
            dbItem.ext_mini_lateral_barril_1_2 = ext_mini_lateral_barril_1_2;
            dbItem.ext_mini_lateral_rosca = ext_mini_lateral_rosca;
            dbItem.ext_cal_coxim_barril_rosca = ext_cal_coxim_barril_rosca;
            dbItem.ext_cal_coxim_calandra = ext_cal_coxim_calandra;
            dbItem.ext_capa_barril = ext_capa_barril;
            dbItem.ext_capa_rosca = ext_capa_rosca;
            dbItem.ext_base_barril = ext_base_barril;
            dbItem.ext_base_rosca = ext_base_rosca;
            dbItem.tcu_tol = tcu_tol;
            dbItem.adab1 = adab1;
            dbItem.adab2 = adab2;
            dbItem.adab3 = adab3;
            dbItem.operadorAdab1 = operadorAdab1;
            dbItem.operadorAdab2 = operadorAdab2;
            dbItem.operadorAdab3 = operadorAdab3;

            dbItem.ValorComprimentoPeca = ValorComprimentoPeca;
            dbItem.ValorLarguraTotal = ValorLarguraTotal;
            dbItem.ValorLarguraOmbro = ValorLarguraOmbro;
            dbItem.ValorLarguraCoxim = ValorLarguraCoxim;
            dbItem.ValorEspessuraCoxim = ValorEspessuraCoxim;
            dbItem.ValorPesoPeca = ValorPesoPeca;
            dbItem.ValorAdab = ValorAdab;
            dbItem.CalculoMaxComprimentoPeca = CalculoMaxComprimentoPeca;
            dbItem.CalculoMinComprimentoPeca = CalculoMinComprimentoPeca;
            dbItem.CalculoMaxLarguraTotal = CalculoMaxLarguraTotal;
            dbItem.CalculoMinLarguraTotal = CalculoMinLarguraTotal;
            dbItem.CalculoMaxLarguraOmbro = CalculoMaxLarguraOmbro;
            dbItem.CalculoMinLarguraOmbro = CalculoMinLarguraOmbro;
            dbItem.CalculoMaxLarguraCoxim = CalculoMaxLarguraCoxim;
            dbItem.CalculoMinLarguraCoxim = CalculoMinLarguraCoxim;
            dbItem.CalculoMaxEspessuraCoxim = CalculoMaxEspessuraCoxim;
            dbItem.CalculoMinEspessuraCoxim = CalculoMinEspessuraCoxim;
            dbItem.CalculoMaxPesoPeca = CalculoMaxPesoPeca;
            dbItem.CalculoMinPesoPeca = CalculoMinPesoPeca;
            dbItem.CalculoMaxAdab = CalculoMaxAdab;
            dbItem.CalculoMinAdab = CalculoMinAdab;

            dbItem.picture_1 = picture_1;
            dbItem.picture_2 = picture_2;
            //TESS
            dbItem.LMS2806A_DIENUM = LMS2806A_DIENUM;
            dbItem.LMS2832C_MSV17A = LMS2832C_MSV17A;
            dbItem.LMS2832C_MSV18A = LMS2832C_MSV18A;
            dbItem.LMS2832C_MSV19A = LMS2832C_MSV19A;
            dbItem.LMS2832C_MSV1AA = LMS2832C_MSV1AA;
            dbItem.LMS2806A_BASECE = LMS2806A_BASECE;
            dbItem.LMS2806A_Splice = LMS2806A_Splice;
            dbItem.LMS2832C_MS3QA = LMS2832C_MS3QA;
            dbItem.LMS2832C_WIDTH4 = LMS2832C_WIDTH4;
            dbItem.LMS2832C_GAUGE4 = LMS2832C_GAUGE4;
            dbItem.LMS2813A_STR1SP = LMS2813A_STR1SP;
            dbItem.LMS2813A_TRDSET = LMS2813A_TRDSET;
            dbItem.LMS2813A_TRDCOD = LMS2813A_TRDCOD;
            dbItem.LMS2905C_SHLDWD = LMS2905C_SHLDWD;
            dbItem.LMS2825C_CUST = LMS2825C_CUST;
            dbItem.LMS2813A_CTRCLR = LMS2813A_CTRCLR;
            dbItem.LMS2813A_STR1CL = LMS2813A_STR1CL;
            dbItem.LMS2813A_STRPWD = LMS2813A_STRPWD;
            dbItem.LMS2813A_STR2CL = LMS2813A_STR2CL;
            dbItem.LMS2801C_WEIGHT = LMS2801C_WEIGHT;
            dbItem.LMS2806A_LENGTH = LMS2806A_LENGTH;
            dbItem.retornoTESS = retornoTESS;
        }

        public static List<TriplexbModel> Mapper(List<TB_TRIPLEXB> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<TriplexbModel>();
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

        private static TriplexbModel Mapper(TB_TRIPLEXB tb_triplexb, object p)
        {
            TriplexbModel tModel = new TriplexbModel();
            tModel.id_modelo = tb_triplexb.id_modelo;
            tModel.id = tb_triplexb.id;
            tModel.part_nbr = tb_triplexb.part_nbr;
            tModel.ferr_pre_forma = tb_triplexb.ferr_pre_forma;
            tModel.ferr_pre_chapa = tb_triplexb.ferr_pre_chapa;
            tModel.inser_capa = tb_triplexb.inser_capa;
            tModel.inser_base = tb_triplexb.inser_base;
            tModel.capa_larg_fita = tb_triplexb.capa_larg_fita;
            tModel.capa_vel_rosca = tb_triplexb.capa_vel_rosca;
            tModel.capa_temp_max_extr = tb_triplexb.capa_temp_max_extr;
            tModel.base_larg_fita = tb_triplexb.base_larg_fita;
            tModel.base_vel_rosca = tb_triplexb.base_vel_rosca;
            tModel.base_temp_max_extr = tb_triplexb.base_temp_max_extr;
            tModel.mini_lateral_vel_rosca = tb_triplexb.mini_lateral_vel_rosca;
            tModel.mini_lateral_temp_max_extr = tb_triplexb.mini_lateral_temp_max_extr;
            tModel.coxim_temp_max_extr = tb_triplexb.coxim_temp_max_extr;
            tModel.temp_max_armaz = tb_triplexb.temp_max_armaz;
            tModel.vel_linha = tb_triplexb.vel_linha;
            tModel.comp_peca_nominal = tb_triplexb.comp_peca_nominal;
            tModel.adab_nominal = tb_triplexb.adab_nominal;
            tModel.cod_ret_proc_cor_nome = tb_triplexb.cod_ret_proc_cor_nome;
            tModel.cab_vblock = tb_triplexb.cab_vblock;
            tModel.cab_cabeca = tb_triplexb.cab_cabeca;
            tModel.ext_aux_mini_lat_barril = tb_triplexb.ext_aux_mini_lat_barril;
            tModel.ext_aux_mini_lat_rosca = tb_triplexb.ext_aux_mini_lat_rosca;
            tModel.ext_mini_lateral_barril_alim = tb_triplexb.ext_mini_lateral_barril_alim;
            tModel.ext_mini_lateral_barril_1_2 = tb_triplexb.ext_mini_lateral_barril_1_2;
            tModel.ext_mini_lateral_rosca = tb_triplexb.ext_mini_lateral_rosca;
            tModel.ext_cal_coxim_barril_rosca = tb_triplexb.ext_cal_coxim_barril_rosca;
            tModel.ext_cal_coxim_calandra = tb_triplexb.ext_cal_coxim_calandra;
            tModel.ext_capa_barril = tb_triplexb.ext_capa_barril;
            tModel.ext_capa_rosca = tb_triplexb.ext_capa_rosca;
            tModel.ext_base_barril = tb_triplexb.ext_base_barril;
            tModel.ext_base_rosca = tb_triplexb.ext_base_rosca;
            tModel.tcu_tol = tb_triplexb.tcu_tol;
            tModel.adab1 = tb_triplexb.adab1;
            tModel.adab2 = tb_triplexb.adab2;
            tModel.adab3 = tb_triplexb.adab3;
            tModel.operadorAdab1 = tb_triplexb.operadorAdab1;
            tModel.operadorAdab2 = tb_triplexb.operadorAdab2;
            tModel.operadorAdab3 = tb_triplexb.operadorAdab3;

            tModel.ValorComprimentoPeca = tb_triplexb.ValorComprimentoPeca;
            tModel.ValorLarguraTotal = tb_triplexb.ValorLarguraTotal;
            tModel.ValorLarguraOmbro = tb_triplexb.ValorLarguraOmbro;
            tModel.ValorLarguraCoxim = tb_triplexb.ValorLarguraCoxim;
            tModel.ValorEspessuraCoxim = tb_triplexb.ValorEspessuraCoxim;
            tModel.ValorPesoPeca = tb_triplexb.ValorPesoPeca;
            tModel.ValorAdab = tb_triplexb.ValorAdab;
            tModel.CalculoMaxComprimentoPeca = tb_triplexb.CalculoMaxComprimentoPeca;
            tModel.CalculoMinComprimentoPeca = tb_triplexb.CalculoMinComprimentoPeca;
            tModel.CalculoMaxLarguraTotal = tb_triplexb.CalculoMaxLarguraTotal;
            tModel.CalculoMinLarguraTotal = tb_triplexb.CalculoMinLarguraTotal;
            tModel.CalculoMaxLarguraOmbro = tb_triplexb.CalculoMaxLarguraOmbro;
            tModel.CalculoMinLarguraOmbro = tb_triplexb.CalculoMinLarguraOmbro;
            tModel.CalculoMaxLarguraCoxim = tb_triplexb.CalculoMaxLarguraCoxim;
            tModel.CalculoMinLarguraCoxim = tb_triplexb.CalculoMinLarguraCoxim;
            tModel.CalculoMaxEspessuraCoxim = tb_triplexb.CalculoMaxEspessuraCoxim;
            tModel.CalculoMinEspessuraCoxim = tb_triplexb.CalculoMinEspessuraCoxim;
            tModel.CalculoMaxPesoPeca = tb_triplexb.CalculoMaxPesoPeca;
            tModel.CalculoMinPesoPeca = tb_triplexb.CalculoMinPesoPeca;
            tModel.CalculoMaxAdab = tb_triplexb.CalculoMaxAdab;
            tModel.CalculoMinAdab = tb_triplexb.CalculoMinAdab;

            tModel.picture_1 = tb_triplexb.picture_1;
            tModel.picture_2 = tb_triplexb.picture_2;
            //TESS
            tModel.LMS2806A_DIENUM = tb_triplexb.LMS2806A_DIENUM;
            tModel.LMS2832C_MSV17A = tb_triplexb.LMS2832C_MSV17A;
            tModel.LMS2832C_MSV18A = tb_triplexb.LMS2832C_MSV18A;
            tModel.LMS2832C_MSV19A = tb_triplexb.LMS2832C_MSV19A;
            tModel.LMS2832C_MSV1AA = tb_triplexb.LMS2832C_MSV1AA;
            tModel.LMS2806A_BASECE = tb_triplexb.LMS2806A_BASECE;
            tModel.LMS2806A_Splice = tb_triplexb.LMS2806A_Splice;
            tModel.LMS2832C_MS3QA = tb_triplexb.LMS2832C_MS3QA;
            tModel.LMS2832C_WIDTH4 = tb_triplexb.LMS2832C_WIDTH4;
            tModel.LMS2832C_GAUGE4 = tb_triplexb.LMS2832C_GAUGE4;
            tModel.LMS2813A_STR1SP = tb_triplexb.LMS2813A_STR1SP;
            tModel.LMS2813A_TRDSET = tb_triplexb.LMS2813A_TRDSET;
            tModel.LMS2813A_TRDCOD = tb_triplexb.LMS2813A_TRDCOD;
            tModel.LMS2905C_SHLDWD = tb_triplexb.LMS2905C_SHLDWD;

            tModel.LMS2825C_CUST = tb_triplexb.LMS2825C_CUST;
            tModel.LMS2813A_CTRCLR = tb_triplexb.LMS2813A_CTRCLR;
            tModel.LMS2813A_STR1CL = tb_triplexb.LMS2813A_STR1CL;
            tModel.LMS2813A_STRPWD = tb_triplexb.LMS2813A_STRPWD;
            tModel.LMS2813A_STR2CL = tb_triplexb.LMS2813A_STR2CL;
            tModel.LMS2801C_WEIGHT = tb_triplexb.LMS2801C_WEIGHT;
            tModel.LMS2806A_LENGTH = tb_triplexb.LMS2806A_LENGTH;
            tModel.retornoTESS = tb_triplexb.retornoTESS;


            return tModel;

        }
    }
}