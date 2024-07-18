using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class SaleDetailForRequest
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
