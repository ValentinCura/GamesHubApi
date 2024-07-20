using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client? Client{ get; set; }


    }
}
