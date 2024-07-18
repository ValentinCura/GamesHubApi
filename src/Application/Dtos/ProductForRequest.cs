using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ProductForRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string Console { get; set; }
    }
}
