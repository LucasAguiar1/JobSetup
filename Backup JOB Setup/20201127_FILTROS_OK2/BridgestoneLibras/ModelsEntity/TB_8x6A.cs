using BridgestoneLibras.Data;
using Microsoft.Extensions.Primitives;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace BridgestoneLibras.ModelsEntity
{
    [Table("TB_8x6A")]
    public class TB_8x6A : Entity
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
    }
}
