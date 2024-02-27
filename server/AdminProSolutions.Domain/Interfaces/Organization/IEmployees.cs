using AdminProSolutions.Domain.Entities.Organization;
using AdminProSolutions.Domain.Interfaces.Base;

namespace AdminProSolutions.Domain.Interfaces.Organization
{
    public interface IEmployees : IRepository<Employees>
    {
        List<Employees> GetEmployeesByClientId(int clientId);
    }
}
