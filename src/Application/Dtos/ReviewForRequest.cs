using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ReviewForRequest
    {
        public string Content {  get; set; }
        public int ProductId { get; set; }
    }
}
