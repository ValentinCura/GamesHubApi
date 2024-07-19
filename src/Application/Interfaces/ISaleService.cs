using Application.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        Sale Add(Sale saleToAdd);
        Sale GetById(int id);

    }
}
