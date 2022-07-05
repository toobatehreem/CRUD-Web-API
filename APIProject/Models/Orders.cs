using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class Orders 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("Id")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }

    }
}
