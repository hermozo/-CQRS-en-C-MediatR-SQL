using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API1.Data.Entity
{
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idmarca { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string? PaginaWeb { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? CorreoContacto { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
