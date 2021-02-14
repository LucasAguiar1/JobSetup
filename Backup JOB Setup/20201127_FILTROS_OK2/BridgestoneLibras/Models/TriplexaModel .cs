using BridgestoneLibras.ModelsEntity;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.Models
{
    public class TriplexaModel
    {
        public int id { get; set; }
        public int id_modelo { get; set; }
        public string part_nbr { get; set; }
        public string ferr_pre_forma { get; set; }
        public string ferr_pre_chapa { get; set; }
        public string inser_capa { get; set; }
        public string inser_base { get; set; }
        public string capa_larg_fita { get; set; }
        public string capa_vel_rosca { get; set; }
        public string base_temp_max_extr { get; set; }
        public string mini_lateral_vel_rosca { get; set; }
        public string vel_linha { get; set; }
        public string capa_temp_max_extr { get; set; }
        public string mini_lateral_temp_max_extr { get; set; }
        public string coxim_temp_max_extr { get; set; }
        public string temp_max_armaz { get; set; }
        public string tcu_tol { get; set; }
        public string ext_mini_lat_feed_roll { get; set; }
        public string ext_capa_barril { get; set; }
        public string ext_aux_mini_lat_barril { get; set; }
        public string ext_capa_rosca { get; set; }
        public string ext_mini_lat_rosca { get; set; }
        public string ext_mini_lat_barril { get; set; }
        public string ext_coxim_rosca { get; set; }
        public string cal_coxim_cil_front { get; set; }
        public string ext_base_barril { get; set; }
        public string cal_coxim_cil_traseiro { get; set; }
        public string ext_base_rosca { get; set; }
        public string cab_cabeca { get; set; }

        public string ext_coxim_barril { get; set; }
        public string adab1 { get; set; }
        public string adab2 { get; set; }
        public string adab3 { get; set; }
        public string operadorAdab1 { get; set; }
        public string operadorAdab2 { get; set; }
        public string operadorAdab3 { get; set; }
        public string picture_1 { get; set; }
        public string picture_2 { get; set; }
        public string adab_nominal { get; set; }
        public string cod_ret_proc_cor_nome { get; set; }
        public string ext_aux_mini_lat_rosca { get; set; }
        public string NomeCampo { get; set; }

        //TESS
        public string LMS2806A_DIENUM { get; set; }
        public string LMS2905C_SHLDWD { get; set; }
        public string LMS2832C_MSV17A { get; set; }
        public string LMS2832C_MSV18A { get; set; }
        public string LMS2832C_MSV19A { get; set; }
        public string LMS2832C_MSV1AA { get; set; }
        public string LMS2832C_MS3QA { get; set; }
        public string LMS2832C_WIDTH4 { get; set; }
        public string LMS2832C_GAUGE4 { get; set; }
        public string LMS2813A_STR1SP { get; set; }
        public string LMS2813A_TRDSET { get; set; }
        public string LMS2813A_CTRCLR { get; set; }
        public string LMS2813A_STR1CL { get; set; }
        public string LMS2813A_STR2CL { get; set; }
        public string LMS2813A_STRPWD { get; set; }
        public string LMS2806A_BASECE { get; set; }
        public string LMS2806A_Splice { get; set; }
        public string LMS2813A_TRDCOD { get; set; }
        public string LMS2825C_CUST { get; set; }
        public string LMS2806A_LENGTH { get; set; }
        public string LMS2801C_WEIGHT { get; set; }

        //Cálculo.
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

        public void Mapper(ref TB_TRIPLEXA dbItem)
        {
            dbItem.id = id;
            dbItem.id_modelo = id_modelo;
            dbItem.part_nbr = part_nbr;
            dbItem.ferr_pre_forma = ferr_pre_forma;
            dbItem.ferr_pre_chapa = ferr_pre_chapa;
            dbItem.inser_capa = inser_capa;
            dbItem.inser_base = inser_base;
            dbItem.capa_larg_fita = capa_larg_fita;
            dbItem.capa_vel_rosca = capa_vel_rosca;
            dbItem.base_temp_max_extr = base_temp_max_extr;
            dbItem.mini_lateral_vel_rosca = mini_lateral_vel_rosca;
            dbItem.vel_linha = vel_linha;
            dbItem.capa_temp_max_extr = capa_temp_max_extr;
            dbItem.mini_lateral_temp_max_extr = mini_lateral_temp_max_extr;
            dbItem.coxim_temp_max_extr = coxim_temp_max_extr;
            dbItem.temp_max_armaz = temp_max_armaz;
            dbItem.tcu_tol = tcu_tol;
            dbItem.ext_mini_lat_feed_roll = ext_mini_lat_feed_roll;
            dbItem.ext_capa_barril = ext_capa_barril;
            dbItem.ext_aux_mini_lat_barril = ext_aux_mini_lat_barril;
            dbItem.ext_capa_rosca = ext_capa_rosca;
            dbItem.ext_mini_lat_rosca = ext_mini_lat_rosca;
            dbItem.ext_mini_lat_barril = ext_mini_lat_barril;
            dbItem.ext_coxim_rosca = ext_coxim_rosca;
            dbItem.cal_coxim_cil_front = cal_coxim_cil_front;
            dbItem.ext_base_barril = ext_base_barril;
            dbItem.cal_coxim_cil_traseiro = cal_coxim_cil_traseiro;
            dbItem.ext_base_rosca = ext_base_rosca;
            dbItem.cab_cabeca = cab_cabeca;
            dbItem.picture_1 = picture_1;
            dbItem.picture_2 = picture_2;
            dbItem.adab1 = adab1;
            dbItem.adab2 = adab2;
            dbItem.adab3 = adab3;
            dbItem.operadorAdab1 = operadorAdab1;
            dbItem.operadorAdab2 = operadorAdab2;
            dbItem.operadorAdab3 = operadorAdab3;
            dbItem.NomeCampo = NomeCampo;

            //Cálculo.
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

            //TESS
            dbItem.LMS2806A_DIENUM = LMS2806A_DIENUM;
            dbItem.LMS2905C_SHLDWD = LMS2905C_SHLDWD;
            dbItem.LMS2832C_MSV17A = LMS2832C_MSV17A;
            dbItem.LMS2832C_MSV18A = LMS2832C_MSV18A;
            dbItem.LMS2832C_MSV19A = LMS2832C_MSV19A;
            dbItem.LMS2832C_MSV1AA = LMS2832C_MSV1AA;
            dbItem.LMS2832C_MS3QA = LMS2832C_MS3QA;
            dbItem.LMS2832C_WIDTH4 = LMS2832C_WIDTH4;
            dbItem.LMS2832C_GAUGE4 = LMS2832C_GAUGE4;
            dbItem.LMS2813A_STR1SP = LMS2813A_STR1SP;
            dbItem.LMS2813A_TRDSET = LMS2813A_TRDSET;
            dbItem.LMS2813A_CTRCLR = LMS2813A_CTRCLR;
            dbItem.LMS2813A_STR1CL = LMS2813A_STR1CL;
            dbItem.LMS2813A_STR2CL = LMS2813A_STR2CL;
            dbItem.LMS2813A_STRPWD = LMS2813A_STRPWD;
            dbItem.LMS2806A_BASECE = LMS2806A_BASECE;
            dbItem.LMS2806A_Splice = LMS2806A_Splice;
            dbItem.LMS2813A_TRDCOD = LMS2813A_TRDCOD;
            dbItem.LMS2825C_CUST = LMS2825C_CUST;
            dbItem.LMS2806A_LENGTH = LMS2806A_LENGTH;
            dbItem.LMS2801C_WEIGHT = LMS2801C_WEIGHT;
        }

        public static List<TriplexaModel> Mapper(List<TB_TRIPLEXA> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<TriplexaModel>();
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

        private static TriplexaModel Mapper(TB_TRIPLEXA tb_triplexa, object p)
        {
            TriplexaModel tModel = new TriplexaModel();

            tModel.id = tb_triplexa.id;
            tModel.id_modelo = tb_triplexa.id_modelo;
            tModel.part_nbr = tb_triplexa.part_nbr;
            tModel.ferr_pre_forma = tb_triplexa.ferr_pre_forma;
            tModel.ferr_pre_chapa = tb_triplexa.ferr_pre_chapa;
            tModel.inser_capa = tb_triplexa.inser_capa;
            tModel.inser_base = tb_triplexa.inser_base;
            tModel.capa_larg_fita = tb_triplexa.capa_larg_fita;
            tModel.capa_vel_rosca = tb_triplexa.capa_vel_rosca;
            tModel.base_temp_max_extr = tb_triplexa.base_temp_max_extr;
            tModel.mini_lateral_vel_rosca = tb_triplexa.mini_lateral_vel_rosca;
            tModel.vel_linha = tb_triplexa.vel_linha;
            tModel.capa_temp_max_extr = tb_triplexa.capa_temp_max_extr;
            tModel.mini_lateral_temp_max_extr = tb_triplexa.mini_lateral_temp_max_extr;
            tModel.coxim_temp_max_extr = tb_triplexa.coxim_temp_max_extr;
            tModel.temp_max_armaz = tb_triplexa.temp_max_armaz;
            tModel.tcu_tol = tb_triplexa.tcu_tol;
            tModel.ext_mini_lat_feed_roll = tb_triplexa.ext_mini_lat_feed_roll;
            tModel.ext_capa_barril = tb_triplexa.ext_capa_barril;
            tModel.ext_aux_mini_lat_barril = tb_triplexa.ext_aux_mini_lat_barril;
            tModel.ext_capa_rosca = tb_triplexa.ext_capa_rosca;
            tModel.ext_mini_lat_rosca = tb_triplexa.ext_mini_lat_rosca;
            tModel.ext_mini_lat_barril = tb_triplexa.ext_mini_lat_barril;
            tModel.ext_coxim_rosca = tb_triplexa.ext_coxim_rosca;
            tModel.cal_coxim_cil_front = tb_triplexa.cal_coxim_cil_front;
            tModel.ext_base_barril = tb_triplexa.ext_base_barril;
            tModel.cal_coxim_cil_traseiro = tb_triplexa.cal_coxim_cil_traseiro;
            tModel.ext_base_rosca = tb_triplexa.ext_base_rosca;
            tModel.cab_cabeca = tb_triplexa.cab_cabeca;
            tModel.adab1 = tb_triplexa.adab1;
            tModel.adab2 = tb_triplexa.adab2;
            tModel.adab3 = tb_triplexa.adab3;
            tModel.operadorAdab1 = tb_triplexa.operadorAdab1;
            tModel.operadorAdab2 = tb_triplexa.operadorAdab2;
            tModel.operadorAdab3 = tb_triplexa.operadorAdab3;
            tModel.picture_1 = tb_triplexa.picture_1;
            tModel.picture_2 = tb_triplexa.picture_2;
            tModel.NomeCampo = tb_triplexa.NomeCampo;

            //Cálculo.
            tModel.ValorComprimentoPeca = tb_triplexa.ValorComprimentoPeca;
            tModel.ValorLarguraTotal = tb_triplexa.ValorLarguraTotal;
            tModel.ValorLarguraOmbro = tb_triplexa.ValorLarguraOmbro;
            tModel.ValorLarguraCoxim = tb_triplexa.ValorLarguraCoxim;
            tModel.ValorEspessuraCoxim = tb_triplexa.ValorEspessuraCoxim;
            tModel.ValorPesoPeca = tb_triplexa.ValorPesoPeca;
            tModel.ValorAdab = tb_triplexa.ValorAdab;
            tModel.CalculoMaxComprimentoPeca = tb_triplexa.CalculoMaxComprimentoPeca;
            tModel.CalculoMinComprimentoPeca = tb_triplexa.CalculoMinComprimentoPeca;
            tModel.CalculoMaxLarguraTotal = tb_triplexa.CalculoMaxLarguraTotal;
            tModel.CalculoMinLarguraTotal = tb_triplexa.CalculoMinLarguraTotal;
            tModel.CalculoMaxLarguraOmbro = tb_triplexa.CalculoMaxLarguraOmbro;
            tModel.CalculoMinLarguraOmbro = tb_triplexa.CalculoMinLarguraOmbro;
            tModel.CalculoMaxLarguraCoxim = tb_triplexa.CalculoMaxLarguraCoxim;
            tModel.CalculoMinLarguraCoxim = tb_triplexa.CalculoMinLarguraCoxim;
            tModel.CalculoMaxEspessuraCoxim = tb_triplexa.CalculoMaxEspessuraCoxim;
            tModel.CalculoMinEspessuraCoxim = tb_triplexa.CalculoMinEspessuraCoxim;
            tModel.CalculoMaxPesoPeca = tb_triplexa.CalculoMaxPesoPeca;
            tModel.CalculoMinPesoPeca = tb_triplexa.CalculoMinPesoPeca;
            tModel.CalculoMaxAdab = tb_triplexa.CalculoMaxAdab;
            tModel.CalculoMinAdab = tb_triplexa.CalculoMinAdab;

            //TESS
            tModel.LMS2806A_DIENUM = tb_triplexa.LMS2806A_DIENUM;
            tModel.LMS2905C_SHLDWD = tb_triplexa.LMS2905C_SHLDWD;
            tModel.LMS2832C_MSV17A = tb_triplexa.LMS2832C_MSV17A;
            tModel.LMS2832C_MSV18A = tb_triplexa.LMS2832C_MSV18A;
            tModel.LMS2832C_MSV19A = tb_triplexa.LMS2832C_MSV19A;
            tModel.LMS2832C_MSV1AA = tb_triplexa.LMS2832C_MSV1AA;
            tModel.LMS2832C_MS3QA = tb_triplexa.LMS2832C_MS3QA;
            tModel.LMS2832C_WIDTH4 = tb_triplexa.LMS2832C_WIDTH4;
            tModel.LMS2832C_GAUGE4 = tb_triplexa.LMS2832C_GAUGE4;
            tModel.LMS2813A_STR1SP = tb_triplexa.LMS2813A_STR1SP;
            tModel.LMS2813A_TRDSET = tb_triplexa.LMS2813A_TRDSET;
            tModel.LMS2813A_CTRCLR = tb_triplexa.LMS2813A_CTRCLR;
            tModel.LMS2813A_STR1CL = tb_triplexa.LMS2813A_STR1CL;
            tModel.LMS2813A_STR2CL = tb_triplexa.LMS2813A_STR2CL;
            tModel.LMS2813A_STRPWD = tb_triplexa.LMS2813A_STRPWD;
            tModel.LMS2806A_BASECE = tb_triplexa.LMS2806A_BASECE;
            tModel.LMS2806A_Splice = tb_triplexa.LMS2806A_Splice;
            tModel.LMS2813A_TRDCOD = tb_triplexa.LMS2813A_TRDCOD;
            tModel.LMS2825C_CUST = tb_triplexa.LMS2825C_CUST;
            tModel.LMS2806A_LENGTH = tb_triplexa.LMS2806A_LENGTH;
            tModel.LMS2801C_WEIGHT = tb_triplexa.LMS2801C_WEIGHT;

            return tModel;

        }
    }
}