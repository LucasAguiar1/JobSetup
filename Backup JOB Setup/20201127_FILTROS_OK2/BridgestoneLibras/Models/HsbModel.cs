using BridgestoneLibras.ModelsEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BridgestoneLibras.Models
{
    public class HsbModel
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


        public void Mapper(ref TB_HSB dbItem)
        {
            dbItem.id = id_modelo;
            dbItem.id_modelo = id_modelo;
            dbItem.id_maquina = id_maquina;
            dbItem.part_nbr = part_nbr;
            dbItem.nroreceita = nroreceita;
            dbItem.insert_ext_Superior = insert_ext_Superior;
            dbItem.preformador = preformador;
            dbItem.vel_extr_alta_ext_superior = vel_extr_alta_ext_superior;
            dbItem.extr_media_ext_superior = extr_media_ext_superior;
            dbItem.vel_extr_baixa_ext_superior = vel_extr_baixa_ext_superior;
            dbItem.temp_max_ext_sup = temp_max_ext_sup;
            dbItem.vel_extr_alta_ext_interm = vel_extr_alta_ext_interm;
            dbItem.vel_extr_baixa_ext_interm = vel_extr_baixa_ext_interm;
            dbItem.temp_max_ext_interm = temp_max_ext_interm;
            dbItem.vel_extr_alta_ext_inferior = vel_extr_alta_ext_inferior;
            dbItem.vel_extr_media_ext_inferior = vel_extr_media_ext_inferior;
            dbItem.vel_extr_baixa_ext_inferior = vel_extr_baixa_ext_inferior;
            dbItem.temp_max_ext_inferior = temp_max_ext_inferior;
            dbItem.vel_extr_alta_veltransportador = vel_extr_alta_veltransportador;
            dbItem.vel_extr_media_veltransportador = vel_extr_media_veltransportador;
            dbItem.vel_extr_baixa_veltransportador = vel_extr_baixa_veltransportador;
            dbItem.desc_pos_ini_prato01 = desc_pos_ini_prato01;
            dbItem.desc_pos_enrol_prato01 = desc_pos_enrol_prato01;
            dbItem.desc_pos_emen_prato01 = desc_pos_emen_prato01;
            dbItem.desc_pos_final_prato01 = desc_pos_final_prato01;
            dbItem.prat_pos_inicial_prato01 = prat_pos_inicial_prato01;
            dbItem.rolet_pos_inicial_prato01 = rolet_pos_inicial_prato01;
            dbItem.prat_pos_corte_prato01 = prat_pos_corte_prato01;
            dbItem.prat_pos_emed_prato01 = prat_pos_emed_prato01;
            dbItem.guiapont_pos_emed_prato01 = guiapont_pos_emed_prato01;
            dbItem.desc_pos_ini_prato02 = desc_pos_ini_prato02;
            dbItem.desc_pos_enrol_prato02 = desc_pos_enrol_prato02;
            dbItem.desc_pos_emen_prato02 = desc_pos_emen_prato02;
            dbItem.desc_pos_final_prato02 = desc_pos_final_prato02;
            dbItem.prat_pos_inicial_prato02 = prat_pos_inicial_prato02;
            dbItem.rolet_pos_inicial_prato02 = rolet_pos_inicial_prato02;
            dbItem.prat_pos_corte_prato02 = prat_pos_corte_prato02;
            dbItem.prat_pos_emed_prato02 = prat_pos_emed_prato02;
            dbItem.guiapont_pos_peg_prato02 = guiapont_pos_peg_prato02;
            dbItem.guiapont_pos_emed_prato02 = guiapont_pos_emed_prato02;
            dbItem.desc_pos_ini_prato03 = desc_pos_ini_prato03;
            dbItem.desc_pos_enrol_prato03 = desc_pos_enrol_prato03;
            dbItem.desc_pos_emen_prato03 = desc_pos_emen_prato03;
            dbItem.desc_pos_final_prato03 = desc_pos_final_prato03;
            dbItem.prat_pos_inicial_prato03 = prat_pos_inicial_prato03;
            dbItem.rolet_pos_inicial_prato03 = rolet_pos_inicial_prato03;
            dbItem.prat_pos_corte_prato03 = prat_pos_corte_prato03;
            dbItem.prat_pos_emed_prato03 = prat_pos_emed_prato03;
            dbItem.guiapont_pos_peg_prato03 = guiapont_pos_peg_prato03;
            dbItem.guiapont_pos_emed_prato03 = guiapont_pos_emed_prato03;
            dbItem.desc_pos_ini_prato04 = desc_pos_ini_prato04;
            dbItem.desc_pos_enrol_prato04 = desc_pos_enrol_prato04;
            dbItem.desc_pos_emen_prato04 = desc_pos_emen_prato04;
            dbItem.desc_pos_final_prato04 = desc_pos_final_prato04;
            dbItem.prat_pos_inicial_prato04 = prat_pos_inicial_prato04;
            dbItem.rolet_pos_inicial_prato04 = rolet_pos_inicial_prato04;
            dbItem.prat_pos_corte_prato04 = prat_pos_corte_prato04;
            dbItem.prat_pos_emed_prato04 = prat_pos_emed_prato04;
            dbItem.guiapont_pos_peg_prato04 = guiapont_pos_peg_prato04;
            dbItem.guiapont_pos_emed_prato04 = guiapont_pos_emed_prato04;
            dbItem.cabeca = cabeca;
            dbItem.dieholder = dieholder;
            dbItem.feedrooll = feedrooll;
            dbItem.ext_inf_rosca = ext_inf_rosca;
            dbItem.ext_interm_rosca = ext_interm_rosca;
            dbItem.ext_superior_rosca = ext_superior_rosca;
            dbItem.vel_extr_media_ext_superior = vel_extr_media_ext_superior;
            dbItem.vel_extr_media_ext_interm = vel_extr_media_ext_interm;
            dbItem.guiapont_pos_peg_prato01 = guiapont_pos_peg_prato01;
            dbItem.tcu_tol = tcu_tol;
            dbItem.picture_1 = picture_1;
            dbItem.picture_2 = picture_2;
            dbItem.NomeCampo = NomeCampo;
            dbItem.NomeMaquina = NomeMaquina;
            //Cálculo
            dbItem.ValorLarguraEnchimentoTakeAway = ValorLarguraEnchimentoTakeAway;
            dbItem.ValorLarguraEnchimentoArmazenamento = ValorLarguraEnchimentoArmazenamento;
            dbItem.ValorLarguraEnchimentoAmostraPerfil = ValorLarguraEnchimentoAmostraPerfil;
            dbItem.ValorLarguraGoma = ValorLarguraGoma;
            dbItem.ValorDistanciaEntreGomaEncaixe = ValorDistanciaEntreGomaEncaixe;
            dbItem.ValorDistanciaEntreGomaEncaixe = ValorDistanciaEntreGomaEncaixe;
            dbItem.ValorMinLarguraEnchimentoTakeAway = ValorMinLarguraEnchimentoTakeAway;
            dbItem.ValorMaxLarguraEnchimentoTakeAway = ValorMaxLarguraEnchimentoTakeAway;
            dbItem.ValorMinLarguraEnchimentoArmazenamento = ValorMinLarguraEnchimentoArmazenamento;
            dbItem.ValorMaxLarguraEnchimentoArmazenamento = ValorMaxLarguraEnchimentoArmazenamento;
            dbItem.ValorMinLarguraEnchimentoAmostraPerfil = ValorMinLarguraEnchimentoAmostraPerfil;
            dbItem.ValorMaxLarguraEnchimentoAmostraPerfil = ValorMaxLarguraEnchimentoAmostraPerfil;
            dbItem.ValorMaxLarguraGoma = ValorMaxLarguraGoma;
            dbItem.ValorMinLarguraGoma = ValorMinLarguraGoma;
            dbItem.ValorMaxDistanciaEntreGomaEncaixe = ValorMaxDistanciaEntreGomaEncaixe;
            dbItem.ValorMinDistanciaEntreGomaEncaixe = ValorMinDistanciaEntreGomaEncaixe;

            //TESS
            dbItem.LMS2806A_DIENUM = LMS2806A_DIENUM;
            dbItem.LMS2810A_BDPART = LMS2810A_BDPART;
            dbItem.LMS2811A_BDRMDI = LMS2811A_BDRMDI;
            dbItem.LMS2806A_CUCOMP = LMS2806A_CUCOMP;
            dbItem.LMS2832C_MSV18A = LMS2832C_MSV18A;
            dbItem.LMS2832C_MSV17A = LMS2832C_MSV17A;
            dbItem.LMS2832C_MS3QA = LMS2832C_MS3QA;
            dbItem.LMS2806A_CUSHWD = LMS2806A_CUSHWD;
            dbItem.LMS2806A_SETPO3 = LMS2806A_SETPO3;
            dbItem.LMS2806A_BASECE = LMS2806A_BASECE;
        }

        public static List<HsbModel> Mapper(List<TB_HSB> lista, bool isExecutadoPorProc)
        {
            var lstRet = new List<HsbModel>();
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

        private static HsbModel Mapper(TB_HSB tbhsb01, object p)
        {
            HsbModel s = new HsbModel();

            s.id = tbhsb01.id;
            s.id_modelo = tbhsb01.id_modelo;
            s.id_maquina = tbhsb01.id_maquina;
            s.part_nbr = tbhsb01.part_nbr;
            s.nroreceita = tbhsb01.nroreceita;
            s.insert_ext_Superior = tbhsb01.insert_ext_Superior;
            s.preformador = tbhsb01.preformador;
            s.vel_extr_alta_ext_superior = tbhsb01.vel_extr_alta_ext_superior;
            s.extr_media_ext_superior = tbhsb01.extr_media_ext_superior;
            s.vel_extr_baixa_ext_superior = tbhsb01.vel_extr_baixa_ext_superior;
            s.temp_max_ext_sup = tbhsb01.temp_max_ext_sup;
            s.vel_extr_alta_ext_interm = tbhsb01.vel_extr_alta_ext_interm;
            s.vel_extr_baixa_ext_interm = tbhsb01.vel_extr_baixa_ext_interm;
            s.temp_max_ext_interm = tbhsb01.temp_max_ext_interm;
            s.vel_extr_alta_ext_inferior = tbhsb01.vel_extr_alta_ext_inferior;
            s.vel_extr_media_ext_inferior = tbhsb01.vel_extr_media_ext_inferior;
            s.vel_extr_baixa_ext_inferior = tbhsb01.vel_extr_baixa_ext_inferior;
            s.temp_max_ext_inferior = tbhsb01.temp_max_ext_inferior;
            s.vel_extr_alta_veltransportador = tbhsb01.vel_extr_alta_veltransportador;
            s.vel_extr_media_veltransportador = tbhsb01.vel_extr_media_veltransportador;
            s.vel_extr_baixa_veltransportador = tbhsb01.vel_extr_baixa_veltransportador;
            s.desc_pos_ini_prato01 = tbhsb01.desc_pos_ini_prato01;
            s.desc_pos_enrol_prato01 = tbhsb01.desc_pos_enrol_prato01;
            s.desc_pos_emen_prato01 = tbhsb01.desc_pos_emen_prato01;
            s.desc_pos_final_prato01 = tbhsb01.desc_pos_final_prato01;
            s.prat_pos_inicial_prato01 = tbhsb01.prat_pos_inicial_prato01;
            s.rolet_pos_inicial_prato01 = tbhsb01.rolet_pos_inicial_prato01;
            s.prat_pos_corte_prato01 = tbhsb01.prat_pos_corte_prato01;
            s.prat_pos_emed_prato01 = tbhsb01.prat_pos_emed_prato01;
            s.guiapont_pos_emed_prato01 = tbhsb01.guiapont_pos_emed_prato01;
            s.desc_pos_ini_prato02 = tbhsb01.desc_pos_ini_prato02;
            s.desc_pos_enrol_prato02 = tbhsb01.desc_pos_enrol_prato02;
            s.desc_pos_emen_prato02 = tbhsb01.desc_pos_emen_prato02;
            s.desc_pos_final_prato02 = tbhsb01.desc_pos_final_prato02;
            s.prat_pos_inicial_prato02 = tbhsb01.prat_pos_inicial_prato02;
            s.rolet_pos_inicial_prato02 = tbhsb01.rolet_pos_inicial_prato02;
            s.prat_pos_corte_prato02 = tbhsb01.prat_pos_corte_prato02;
            s.prat_pos_emed_prato02 = tbhsb01.prat_pos_emed_prato02;
            s.guiapont_pos_peg_prato02 = tbhsb01.guiapont_pos_peg_prato02;
            s.guiapont_pos_emed_prato02 = tbhsb01.guiapont_pos_emed_prato02;
            s.desc_pos_ini_prato03 = tbhsb01.desc_pos_ini_prato03;
            s.desc_pos_enrol_prato03 = tbhsb01.desc_pos_enrol_prato03;
            s.desc_pos_emen_prato03 = tbhsb01.desc_pos_emen_prato03;
            s.desc_pos_final_prato03 = tbhsb01.desc_pos_final_prato03;
            s.prat_pos_inicial_prato03 = tbhsb01.prat_pos_inicial_prato03;
            s.rolet_pos_inicial_prato03 = tbhsb01.rolet_pos_inicial_prato03;
            s.prat_pos_corte_prato03 = tbhsb01.prat_pos_corte_prato03;
            s.prat_pos_emed_prato03 = tbhsb01.prat_pos_emed_prato03;
            s.guiapont_pos_peg_prato03 = tbhsb01.guiapont_pos_peg_prato03;
            s.guiapont_pos_emed_prato03 = tbhsb01.guiapont_pos_emed_prato03;
            s.desc_pos_ini_prato04 = tbhsb01.desc_pos_ini_prato04;
            s.desc_pos_enrol_prato04 = tbhsb01.desc_pos_enrol_prato04;
            s.desc_pos_emen_prato04 = tbhsb01.desc_pos_emen_prato04;
            s.desc_pos_final_prato04 = tbhsb01.desc_pos_final_prato04;
            s.prat_pos_inicial_prato04 = tbhsb01.prat_pos_inicial_prato04;
            s.rolet_pos_inicial_prato04 = tbhsb01.rolet_pos_inicial_prato04;
            s.prat_pos_corte_prato04 = tbhsb01.prat_pos_corte_prato04;
            s.prat_pos_emed_prato04 = tbhsb01.prat_pos_emed_prato04;
            s.guiapont_pos_peg_prato04 = tbhsb01.guiapont_pos_peg_prato04;
            s.guiapont_pos_emed_prato04 = tbhsb01.guiapont_pos_emed_prato04;
            s.cabeca = tbhsb01.cabeca;
            s.dieholder = tbhsb01.dieholder;
            s.feedrooll = tbhsb01.feedrooll;
            s.ext_inf_rosca = tbhsb01.ext_inf_rosca;
            s.ext_interm_rosca = tbhsb01.ext_interm_rosca;
            s.ext_superior_rosca = tbhsb01.ext_superior_rosca;
            s.vel_extr_media_ext_superior = tbhsb01.vel_extr_media_ext_superior;
            s.vel_extr_media_ext_interm = tbhsb01.vel_extr_media_ext_interm;
            s.guiapont_pos_peg_prato01 = tbhsb01.guiapont_pos_peg_prato01;
            s.tcu_tol = tbhsb01.tcu_tol;
            s.picture_1 = tbhsb01.picture_1;
            s.picture_2 = tbhsb01.picture_2;
            s.NomeCampo = tbhsb01.NomeCampo;
            s.NomeMaquina = tbhsb01.NomeMaquina;
            //Cálculo
            s.ValorLarguraEnchimentoTakeAway = tbhsb01.ValorLarguraEnchimentoTakeAway;
            s.ValorLarguraEnchimentoArmazenamento = tbhsb01.ValorLarguraEnchimentoArmazenamento;
            s.ValorLarguraEnchimentoAmostraPerfil = tbhsb01.ValorLarguraEnchimentoAmostraPerfil;
            s.ValorLarguraGoma = tbhsb01.ValorLarguraGoma;
            s.ValorDistanciaEntreGomaEncaixe = tbhsb01.ValorDistanciaEntreGomaEncaixe;
            s.ValorDistanciaEntreGomaEncaixe = tbhsb01.ValorDistanciaEntreGomaEncaixe;
            s.ValorMinLarguraEnchimentoTakeAway = tbhsb01.ValorMinLarguraEnchimentoTakeAway;
            s.ValorMaxLarguraEnchimentoTakeAway = tbhsb01.ValorMaxLarguraEnchimentoTakeAway;
            s.ValorMinLarguraEnchimentoArmazenamento = tbhsb01.ValorMinLarguraEnchimentoArmazenamento;
            s.ValorMaxLarguraEnchimentoArmazenamento = tbhsb01.ValorMaxLarguraEnchimentoArmazenamento;
            s.ValorMinLarguraEnchimentoAmostraPerfil = tbhsb01.ValorMinLarguraEnchimentoAmostraPerfil;
            s.ValorMaxLarguraEnchimentoAmostraPerfil = tbhsb01.ValorMaxLarguraEnchimentoAmostraPerfil;
            s.ValorMaxLarguraGoma = tbhsb01.ValorMaxLarguraGoma;
            s.ValorMinLarguraGoma = tbhsb01.ValorMinLarguraGoma;
            s.ValorMaxDistanciaEntreGomaEncaixe = tbhsb01.ValorMaxDistanciaEntreGomaEncaixe;
            s.ValorMinDistanciaEntreGomaEncaixe = tbhsb01.ValorMinDistanciaEntreGomaEncaixe;

            //TESS
            s.LMS2806A_DIENUM = tbhsb01.LMS2806A_DIENUM;
            s.LMS2810A_BDPART = tbhsb01.LMS2810A_BDPART;
            s.LMS2811A_BDRMDI = tbhsb01.LMS2811A_BDRMDI;
            s.LMS2806A_CUCOMP = tbhsb01.LMS2806A_CUCOMP;
            s.LMS2832C_MSV18A = tbhsb01.LMS2832C_MSV18A;
            s.LMS2832C_MSV17A = tbhsb01.LMS2832C_MSV17A;
            s.LMS2832C_MS3QA = tbhsb01.LMS2832C_MS3QA;
            s.LMS2806A_CUSHWD = tbhsb01.LMS2806A_CUSHWD;
            s.LMS2806A_SETPO3 = tbhsb01.LMS2806A_SETPO3;
            s.LMS2806A_BASECE = tbhsb01.LMS2806A_BASECE;

            return s;
        }
    }
}
