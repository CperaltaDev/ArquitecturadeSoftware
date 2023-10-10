
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Data.Entities
{
    [Table("TBL_Documentos", Schema = "dbo")]
    public class Documentos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        public string Nombre { get; set; }
        [Required]
        public string Identificacion { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string CodigoProducto { get; set; }
        [Required]
        public string CodigoDocumento { get; set; }
        [Required]
        public string Activo { get; set; }
       
      

    }
}
