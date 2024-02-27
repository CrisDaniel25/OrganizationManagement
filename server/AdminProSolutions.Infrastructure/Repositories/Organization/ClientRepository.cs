using AdminProSolutions.Domain.Entities.Organization;
using AdminProSolutions.Domain.Interfaces.Organization;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Infrastructure.Repositories.Base;
using AutoMapper;

namespace AdminProSolutions.Infrastructure.Repositories.Organization
{
    public class ClientRepository : Repository<Clients>, IClients
    {
        private IMapper _mapper;
        public ClientRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
