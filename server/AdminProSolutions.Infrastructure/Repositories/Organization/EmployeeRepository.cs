using AdminProSolutions.Domain.Entities.Organization;
using AdminProSolutions.Domain.Interfaces.Organization;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Infrastructure.Repositories.Base;
using AutoMapper;

namespace AdminProSolutions.Infrastructure.Repositories.Organization
{
    public class EmployeeRepository : Repository<Employees>, IEmployees
    {
        private IMapper _mapper;
        public EmployeeRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public List<Employees> GetEmployeesByClientId(int clientId)
        {
            try
            {
                var data = _context.Employees.Where(x => x.ClientId == clientId).ToList();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
