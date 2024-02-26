using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Interfaces.Base;

namespace AdminProSolutions.Domain.Interfaces.Authentication
{
    public interface IGroups : IRepository<Groups> 
    {
        IQueryable<GroupsUsers> GetUsers(int? groupId);
        List<FormsAccessDto> GetPermissions(int? groupId);
        void SyncRoles(int updatedUser, int groupId, List<FormsAccessDto>? formAccessTypes);
        void SyncUsers(int updatedUser, int groupId, List<int>? users);
        Groups? CheckName(string name);
    }
}
