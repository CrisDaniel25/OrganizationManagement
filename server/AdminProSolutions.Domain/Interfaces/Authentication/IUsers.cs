using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Interfaces.Base;

namespace AdminProSolutions.Domain.Interfaces.Authentication
{
    public interface IUsers : IRepository<Users> 
    {
        Users AddNewUser(UserDto payload);
        Users? GetUserByIdIncludindGroups(int id);
        Users? GetUserByUserNameIncludindGroups(string userName);
        Users? UpdateUser(Users user, string? password);
        GroupsUsers AddRole(GroupsUsers userRole);
        Users ChangePasswod(Users payload, byte[] passwordHash);
        void SyncRoles(UserDto payload);
        void DeleteRole(int userId, int roleId);
        Users? CheckUserName(string userName);
        byte[] GetByUserIdHashPassword(int userId);
    }
}
