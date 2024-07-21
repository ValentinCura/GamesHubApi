using Domain.Entities;
using Domain.Interfaces;


namespace Infraestructure.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly ApplicationContext _context;
        public ClientRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
