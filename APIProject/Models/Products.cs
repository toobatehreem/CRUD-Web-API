using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class Products 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(60, ErrorMessage = "Name length should be less than or equal to 60 characters.")]
        public string ProductName { get; set; }

        [ForeignKey("Id")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Required(ErrorMessage = "Product Price is required.")]
        
        public double ProductPrice { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }



    }
}
