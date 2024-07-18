using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationContext _context;
        public SaleRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
