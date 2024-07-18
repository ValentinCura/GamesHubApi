using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public ICollection<Sale> Buys { get; set; } = new List<Sale>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
