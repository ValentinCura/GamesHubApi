using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ReviewForRequest
    {
        [Required]
        public string Content {  get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
