using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace AdminProSolutions.Infrastructure.Repositories.Authentication
{
    public class RoleRepository : Repository<Groups>, IGroups
    {

        private IMapper _mapper;

        public RoleRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IQueryable<GroupsUsers> GetUsers(int? groupId)
        {
            try
            {
                var list = _context.GroupsUsers.Include(e => e.User).Where(e => e.GroupId == groupId).AsQueryable();
                return list.AsNoTracking();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<FormsAccessDto> GetPermissions(int? groupId)
        {
            try
            {
                var groupPermissions = _context.GroupFormsAccessTypes.Where(e => e.GroupId == groupId).ToList();
                var allPermissions = (from e in _mapper.Map<List<FormAccessTypesDto>>(_context.FormsAccessTypes.Include(e => e.Form))
                     group e by new { e.FormId, e.Form.FormModule, e.Form.FormName, e.Form.FormDescription } into newGroup
                     select new FormsAccessDto
                     {
                         Form = newGroup.Key,
                         AccessTypes = newGroup.Select(e => new AccessTypeDto
                         {
                             AccessTypeId = e.AccessTypeId,
                             AccessTypeDescription = Enum.GetName(typeof(Domain.Enums.PermissionAction), e.AccessTypeId),
                             Checked = groupPermissions.Any(k => k.FormAccessType.FormId == e.FormId && k.FormAccessType.AccessTypeId == e.AccessTypeId),
                             FormAccessTypeId = e.FormAccessTypeId
                         }).ToList()
                     }).ToList();


                return allPermissions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SyncRoles(int updatedUser, int groupId, List<FormsAccessDto>? formAccessTypes)
        {
            try
            {

                var toDelete = new List<GroupFormsAccessTypes>();
                var toAdd = new List<GroupFormsAccessTypes>();

                for (int i1 = 0; i1 < formAccessTypes.Count; i1++)
                {
                    var m = formAccessTypes[i1];
                    for (int i2 = 0; i2 < formAccessTypes[i1].AccessTypes.Count; i2++)
                    {
                        var d = m.AccessTypes[i2];
                        if (d.Checked == true)
                        {
                            if (!_context.GroupFormsAccessTypes.Any(p => p.GroupId == groupId && p.FormAccessTypeId == d.FormAccessTypeId))
                            {
                                toAdd.Add(new GroupFormsAccessTypes
                                {
                                    GroupId = groupId,
                                    FormAccessTypeId = d.FormAccessTypeId,
                                    CreatedUser = updatedUser,
                                    CreatedDate = DateTime.Now
                                });
                            }
                        }
                        else if (d.Checked == false)
                        {
                            var add = _context.GroupFormsAccessTypes.Where(p => p.GroupId == groupId && p.FormAccessTypeId == d.FormAccessTypeId).FirstOrDefault();
                            if (add != null)
                            {
                                toDelete.Add(add);
                            };
                        }
                    }
                }
                _context.GroupFormsAccessTypes.RemoveRange(toDelete);
                _context.GroupFormsAccessTypes.AddRange(toAdd);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SyncUsers(int updatedUser, int groupId, List<int>? users)
        {

            try
            {

                var groupUsers = _context.GroupsUsers.Where(p => p.GroupId == groupId).ToList();
                var toAddRange = new List<GroupsUsers>();
                var toDeleteRange = _context.GroupsUsers.Where(p => p.GroupId == groupId && !users.Any(x => x == p.UserId)).ToList();
                var toAdd = _context.Users.Where(p => users.Any(x => x == p.UserId));

                for (int i = 0; i < users.Count; i++)
                {
                    if (!groupUsers.Any(p => p.GroupId == groupId && p.UserId == users[i]))
                    {
                        toAddRange.Add(new GroupsUsers
                        {
                            GroupId = groupId,
                            UserId = users[i],
                            CreatedDate = DateTime.Now,
                            CreatedUser = updatedUser
                        });
                    }
                };

                _context.GroupsUsers.RemoveRange(toDeleteRange);
                _context.GroupsUsers.AddRange(toAddRange);

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Groups? CheckName(string name)
        {
            try
            {
                var res = _context.Groups.Where(u => u.GroupName.ToLower() == name.ToLower()).FirstOrDefault();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
    