using BridgestoneLibras.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_TRIPLEXB")]
    public class TB_TRIPLEXB : Entity
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

        //Controla o nivel que foi selecionado na  pagina de parametros.
        public string NomeCampo { get; set; }
        //
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
        //public string CalculoMinValorAdab { get; set; }

        //TESS
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
    }
}
