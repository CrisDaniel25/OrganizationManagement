using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Enums;
using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Infrastructure.Helper;
using AdminProSolutions.Infrastructure.Repositories.Base;

namespace AdminProSolutions.Infrastructure.Repositories.Authentication
{
    public class UserRepository : Repository<Users>, IUsers
    {
        private IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public Users AddNewUser(UserDto user)
        {
            try
            {
                Users newUser = new();

                if (user.TypeAutentication.Equals(TypeAuthentication.EX))
                {
                    AuthorizationManager.CreatePasswordHash(user.Password, out byte[] passwordHash);
                    newUser = _mapper.Map<Users>(user);
                    newUser.HashPassword = passwordHash;
                    newUser.UserPasswordHasBeenReset = true;
                }

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return newUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users? GetUserByIdIncludindGroups(int id)
        {
            try
            {
                var record = _context.Users
                    .Include(u => u.GroupUsers)
                    .ThenInclude(r => r.Group)
                    .Where(u => u.UserId == id)
                    .FirstOrDefault();

                if (record == null) return null;                
                
                record.GroupsAlt = record.GroupUsers.Select(r => r.GroupId).ToArray();
                    
                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users? GetUserByUserNameIncludindGroups(string userName)
        {
            try
            {
                var record = _context.Users
                                     .Include(u => u.GroupUsers)
                                     .ThenInclude(r => r.Group)                    
                                     .SingleOrDefault(x => x.UserLogin == userName && 
                                                           (x.UserStatus == UserStatusTypeEnum.ACTIVE || 
                                                           x.UserStatus == UserStatusTypeEnum.LOCKED));

                return record;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users? UpdateUser(Users userParam, string? password = null)
        {
            try
            {
                var user = _context.Users.Find(userParam.UserId);

                if (user == null) return null;

               /* if (user == null)
                    throw new AppException("User not found");*/

                /*if (userParam.UserLogin.ToLower() != user.UserLogin.ToLower())
                {
                    // username has changed so check if the new username is already taken
                    if (_context.Users.Any(x => x.UserLogin == userParam.UserLogin))
                        throw new AppException("UserLogin " + userParam.UserName + " is already taken");
                }*/

                /* update user properties */
                user.UserName = userParam.UserName;
                user.UserEmail = userParam.UserEmail;
                user.UserLogin = userParam.UserLogin;
                user.TypeAutentication = userParam.TypeAutentication;
                user.UserPhone = userParam.UserPhone;
                user.UserSecretQuestion = userParam.UserSecretQuestion;
                user.UserSecretAnswer = userParam.UserSecretAnswer;
                user.UpdatedUser = userParam.UpdatedUser;
                user.UpdatedDate = DateTime.Now;
                user.UserStatus = userParam.UserStatus;

                /* update password if it was entered */
                if (!string.IsNullOrWhiteSpace(password))
                {
                    byte[] passwordHash;
                    AuthorizationManager.CreatePasswordHash(password, out passwordHash);

                    user.HashPassword = passwordHash;
                    user.UserPasswordHasBeenReset = true;
                }

                _context.Users.Update(user);
                _context.SaveChanges();

                var userDto = _mapper.Map<UserDto>(userParam);

                SyncRoles(userDto);

                return user;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public GroupsUsers AddRole(GroupsUsers userRole)
        {
            try
            {
                var user = _context.Users.Find(userRole.UserId);

                if (!_context.Users.Any(u => u.UserId == userRole.UserId))
                    return userRole;
                //throw new AppException("User not found");

                if (!_context.Groups.Any(r => r.GroupId == userRole.GroupId && r.GroupStatus == GroupStatusTypeEnum.ACTIVE))
                    return userRole;
                //throw new AppException("Group not found");

                if (_context.GroupsUsers.Any(r => r.UserId == userRole.UserId && r.GroupId == userRole.GroupId))
                    return userRole;
                //throw new AppException("Gro upId " + userRole.GroupId + " is already exists");

                userRole.CreatedDate = DateTime.Now;
                userRole.UserOrder = 100;

                _context.GroupsUsers.Add(userRole);
                _context.SaveChanges();

                return userRole;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRole(int userId, int groupId)
        {
            try
            {
                var userRole = _context.GroupsUsers.Find(userId, groupId);

                if (userRole != null)
                {
                    _context.GroupsUsers.Remove(userRole);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SyncRoles(UserDto user)
        {
            try
            {
                if (user.GroupsAlt != null)
                {
                    user.GroupUsers.Clear();

                    foreach (var role in user.GroupsAlt)
                        user.GroupUsers.Add(_mapper.Map<GroupsUsersDto>(new GroupsUsers { UserId = user.UserId, GroupId = role, CreatedUser = user.CreatedUser != null ? user.CreatedUser : user.UpdatedUser, CreatedDate = DateTime.Now }));
                    
                    var roleList = _context.GroupsUsers.Where(r => r.UserId == user.UserId).ToList();

                    var groupsUsers = _mapper.Map<ICollection<GroupsUsers>>(user.GroupUsers);
                    var addList = groupsUsers.Where(r => !roleList.Any(rl => rl.GroupId == r.GroupId) && _context.Groups.Any(ar => ar.GroupId == r.GroupId)).GroupBy(p => (p.UserId, p.GroupId)).Select(g => g.First()).ToList();
                    var removeList = roleList.Where(rl => !user.GroupUsers.Any(r => r.GroupId == rl.GroupId)).GroupBy(p => (p.UserId, p.GroupId)).Select(g => g.First()).ToList();

                    if (addList.Count() > 0)
                        _context.GroupsUsers.AddRange(addList);

                    if (removeList.Count() > 0)
                        _context.GroupsUsers.RemoveRange(removeList);

                    if (addList.Count() > 0 || removeList.Count() > 0)
                        _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users ChangePasswod(Users user, byte[] passwordHash)
        {
            try
            {
                user.HashPassword = passwordHash;
                user.UserPasswordHasBeenReset = false;

                _context.Users.Attach(user);
                _context.Entry(user).Property(x => x.HashPassword).IsModified = true;
                _context.Entry(user).Property(x => x.UserPasswordHasBeenReset).IsModified = true;

                _context.SaveChanges();

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users? CheckUserName(string userLogin)
        {
            try
            {
                var payload = _context.Users.Where(u => u.UserLogin == userLogin)
                                            .FirstOrDefault();
                return payload;
            }
            catch (Exception)
            {
                throw;
            }      
        }

        public byte[] GetByUserIdHashPassword(int userId)
        {
            try
            {
                var user = _context.Users.Where(u => u.UserId == userId)
                                         .AsNoTracking()
                                         .FirstOrDefault();

                if (user == null) return Array.Empty<byte>();

                return user.HashPassword;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
