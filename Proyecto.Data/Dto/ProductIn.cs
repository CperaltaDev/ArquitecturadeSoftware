using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Data.Dto
{
    [DataContract]
    public class ProductIn
    {
        [Required(ErrorMessage = "User is required")]
        [DataMember]
        public string Id { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataMember]
        public string NombreProducto { get; set; }

    }
}
