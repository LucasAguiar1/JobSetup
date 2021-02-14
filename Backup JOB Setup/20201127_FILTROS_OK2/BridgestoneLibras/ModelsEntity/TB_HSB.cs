using BridgestoneLibras.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_HSB01")]
    public class TB_HSB : Entity
    {
        public int id { get; set; }
        public int id_modelo { get; set; }
        public int id_maquina { get; set; }        
        public string part_nbr { get; set; }
        public string nroreceita { get; set; }
        public string insert_ext_Superior { get; set; }
        public string preformador { get; set; }
        public string vel_extr_alta_ext_superior { get; set; }
        public string extr_media_ext_superior { get; set; }
        public string vel_extr_baixa_ext_superior { get; set; }
        public string temp_max_ext_sup { get; set; }
        public string vel_extr_alta_ext_interm { get; set; }
        public string vel_extr_baixa_ext_interm { get; set; }
        public string temp_max_ext_interm { get; set; }
        public string vel_extr_alta_ext_inferior { get; set; }
        public string vel_extr_media_ext_inferior { get; set; }
        public string vel_extr_baixa_ext_inferior { get; set; }
        public string temp_max_ext_inferior { get; set; }
        public string vel_extr_alta_veltransportador { get; set; }
        public string vel_extr_media_veltransportador { get; set; }
        public string vel_extr_baixa_veltransportador { get; set; }
        public string desc_pos_ini_prato01 { get; set; }
        public string desc_pos_enrol_prato01 { get; set; }
        public string desc_pos_emen_prato01 { get; set; }
        public string desc_pos_final_prato01 { get; set; }
        public string prat_pos_inicial_prato01 { get; set; }
        public string rolet_pos_inicial_prato01 { get; set; }
        public string prat_pos_corte_prato01 { get; set; }
        public string prat_pos_emed_prato01 { get; set; }
        public string guiapont_pos_emed_prato01 { get; set; }
        public string desc_pos_ini_prato02 { get; set; }
        public string desc_pos_enrol_prato02 { get; set; }
        public string desc_pos_emen_prato02 { get; set; }
        public string desc_pos_final_prato02 { get; set; }
        public string prat_pos_inicial_prato02 { get; set; }
        public string rolet_pos_inicial_prato02 { get; set; }
        public string prat_pos_corte_prato02 { get; set; }
        public string prat_pos_emed_prato02 { get; set; }
        public string guiapont_pos_peg_prato02 { get; set; }
        public string guiapont_pos_emed_prato02 { get; set; }
        public string desc_pos_ini_prato03 { get; set; }
        public string desc_pos_enrol_prato03 { get; set; }
        public string desc_pos_emen_prato03 { get; set; }
        public string desc_pos_final_prato03 { get; set; }
        public string prat_pos_inicial_prato03 { get; set; }
        public string rolet_pos_inicial_prato03 { get; set; }
        public string prat_pos_corte_prato03 { get; set; }
        public string prat_pos_emed_prato03 { get; set; }
        public string guiapont_pos_peg_prato03 { get; set; }
        public string guiapont_pos_emed_prato03 { get; set; }
        public string desc_pos_ini_prato04 { get; set; }
        public string desc_pos_enrol_prato04 { get; set; }
        public string desc_pos_emen_prato04 { get; set; }
        public string desc_pos_final_prato04 { get; set; }
        public string prat_pos_inicial_prato04 { get; set; }
        public string rolet_pos_inicial_prato04 { get; set; }
        public string prat_pos_corte_prato04 { get; set; }
        public string prat_pos_emed_prato04 { get; set; }
        public string guiapont_pos_peg_prato04 { get; set; }
        public string guiapont_pos_emed_prato04 { get; set; }
        public string cabeca { get; set; }
        public string dieholder { get; set; }
        public string feedrooll { get; set; }
        public string ext_inf_rosca { get; set; }
        public string ext_interm_rosca { get; set; }
        public string ext_superior_rosca { get; set; }
        public string vel_extr_media_ext_superior { get; set; }
        public string vel_extr_media_ext_interm { get; set; }
        public string guiapont_pos_peg_prato01 { get; set; }
        public string tcu_tol { get; set; }
        public string picture_1 { get; set; }
        public string picture_2 { get; set; }
        public string NomeCampo { get; set; }
        public string NomeMaquina { get; set; }

        //Cálculo
        public int ValorLarguraEnchimentoTakeAway { get; set; }
        public int ValorLarguraEnchimentoArmazenamento { get; set; }
        public int ValorLarguraEnchimentoAmostraPerfil { get; set; }
        public int ValorLarguraGoma { get; set; }
        public int ValorDistanciaEntreGomaEncaixe { get; set; }
        public string ValorMinLarguraEnchimentoTakeAway { get; set; }
        public string ValorMaxLarguraEnchimentoTakeAway { get; set; }
        public string ValorMinLarguraEnchimentoArmazenamento { get; set; }
        public string ValorMaxLarguraEnchimentoArmazenamento { get; set; }
        public string ValorMinLarguraEnchimentoAmostraPerfil { get; set; }
        public string ValorMaxLarguraEnchimentoAmostraPerfil { get; set; }
        public string ValorMaxLarguraGoma { get; set; }
        public string ValorMinLarguraGoma { get; set; }
        public string ValorMaxDistanciaEntreGomaEncaixe { get; set; }
        public string ValorMinDistanciaEntreGomaEncaixe { get; set; }

        //TESS

        public string LMS2806A_DIENUM { get; set; }
        public string LMS2810A_BDPART { get; set; }
        public string LMS2811A_BDRMDI { get; set; }
        public string LMS2806A_CUCOMP { get; set; }
        public string LMS2832C_MSV18A { get; set; }
        public string LMS2832C_MSV17A { get; set; }
        public string LMS2832C_MS3QA { get; set; }
        public string LMS2806A_CUSHWD { get; set; }
        public string LMS2806A_SETPO3 { get; set; }
        public string LMS2806A_BASECE { get; set; }

    }
}
