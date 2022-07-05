using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class OrderItems 
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int OrderId { get; set; }
        public Orders Orders { get; set; }

        [ForeignKey("Id")]
        public int ProductId { get; set; }
        public Products Products { get; set; }

        [Range(1, 100, ErrorMessage = "Range should be between 1 and 100.")]
        public int Quantity { get; set; }
    }
}
