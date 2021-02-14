using BridgestoneLibras.Data;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BridgestoneLibras.ModelsEntity
{

    [Table("TB_PARAMETROS")]
    public class TB_PARAMETROS : Entity
    {
        
        public TB_PARAMETROS()
        {             
        }

        public string ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string  Size { get; set; }
        public string Cabecalho { get; set; }
        public int Tipo { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public string id_parametro { get; set; }
        //[MaxLength(100)]
        //public string nm_parametro { get; set; }
        //[MaxLength(1000)]
        //public string vl_parametro { get; set; }

    }


}
