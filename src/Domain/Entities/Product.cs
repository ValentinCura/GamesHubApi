using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } 

        public string Type { get; set; }    

        public double Price { get; set; }   

        public int Stock { get; set; } 

        public string Console {  get; set; }    

        public ICollection<Review> Reviews { get; set; } = new List<Review>();  
    }
}
