using AdminProSolutions.Domain.Entities.Authentication;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using AdminProSolutions.Domain.Helpers;
using AdminProSolutions.Infrastructure.Helper;

namespace AdminProSolutions.Infrastructure.Data
{
    public static class DbContextExtension
    {
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this DataContext context)
        {
            try
            {
                context.Database.OpenConnection();

                #region Users

                var users = JsonConvert.DeserializeObject<List<Users>>(GetRelativeFilePath.ReadFile("users"));
                List<Users> userList = users.Where(x => !context.Users.Any(y => y.UserId == x.UserId)).ToList();

                for (int i = 0; i < userList.Count; i++)
                {
                    byte[] passwordHash;
                    AuthorizationManager.CreatePasswordHash("1234", out passwordHash);

                    userList[i].HashPassword = passwordHash;
                }

                context.Users.AddRange(userList);
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                context.SaveChanges();
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");

                #endregion

                #region Groups

                var groups = JsonConvert.DeserializeObject<List<Groups>>(GetRelativeFilePath.ReadFile("groups"));
                List<Groups> groupList = groups.Where(x => !context.Groups.Any(y => y.GroupId == x.GroupId)).ToList();

                context.Groups.AddRange(groupList);
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Groups ON");
                context.SaveChanges();
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Groups OFF");

                #endregion

                #region GroupsUsers

                var groupsUsers = JsonConvert.DeserializeObject<List<GroupsUsers>>(GetRelativeFilePath.ReadFile("group_users"));
                List<GroupsUsers> groupsUserList = groupsUsers.Where(x => !context.GroupsUsers.Any(y => y.GroupUserId == x.GroupUserId)).ToList();

                context.GroupsUsers.AddRange(groupsUserList);
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.GroupsUsers ON");
                context.SaveChanges();
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.GroupsUsers OFF");

                #endregion

                #region AccessTypes

                var accessTypes = JsonConvert.DeserializeObject<List<AccessTypes>>(GetRelativeFilePath.ReadFile("access_type"));
                List<AccessTypes> accessTypesList = accessTypes.Where(x => !context.AccessTypes.Any(y => y.AccessTypeId == x.AccessTypeId)).ToList();

                context.AccessTypes.AddRange(accessTypesList);
                context.SaveChanges();

                #endregion

                #region Forms

                var forms = JsonConvert.DeserializeObject<List<Forms>>(GetRelativeFilePath.ReadFile("forms"));
                List<Forms> formList = forms.Where(x => !context.Forms.Any(y => y.FormId == x.FormId)).ToList();

                context.Forms.AddRange(formList);
                context.SaveChanges();

                #endregion

                #region FormsAccessTypes

                var formsAccessTypes = JsonConvert.DeserializeObject<List<FormsAccessTypes>>(GetRelativeFilePath.ReadFile("form_access_type"));
                List<FormsAccessTypes> formsAccessTypesList = formsAccessTypes.Where(x => !context.FormsAccessTypes.Any(y => y.FormAccessTypeId == x.FormAccessTypeId && y.FormId == x.FormId && y.AccessTypeId == x.AccessTypeId)).ToList();

                context.FormsAccessTypes.AddRange(formsAccessTypesList);
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FormsAccessTypes ON");
                context.SaveChanges();
                _ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.FormsAccessTypes OFF");

                #endregion

                #region GroupFormsAccessTypes

                var groupFormsAccessTypes = JsonConvert.DeserializeObject<List<GroupFormsAccessTypes>>(GetRelativeFilePath.ReadFile("group_forms_access_types"));
                List<GroupFormsAccessTypes> groupFormsAccessTypeList = groupFormsAccessTypes.Where(x => !context.GroupFormsAccessTypes.Any(y => y.GroupId == x.GroupId && y.FormAccessTypeId == x.FormAccessTypeId)).ToList();

                context.GroupFormsAccessTypes.AddRange(groupFormsAccessTypeList);
                context.SaveChanges();

                #endregion

            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}
