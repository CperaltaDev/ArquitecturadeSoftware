using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Data.Entities
{


    [Table("TBL_TipoDocumento", Schema = "dbo")]
    public class TipoDocumentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NombreDocumento { get; set; }
        [Required]
        public string CodigoDocumento{ get; set; }
        [Required]
        public string CodigoProducto { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
