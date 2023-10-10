
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Proyecto.Data.Entities

{
    [Table("TBL_Productos", Schema = "dbo")]
    public class Producto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        public string CodigoProducto { get; set; }
        [Required]
        public bool activo { get; set; }

    }
}
