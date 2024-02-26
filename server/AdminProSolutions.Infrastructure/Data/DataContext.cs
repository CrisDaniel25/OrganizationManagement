using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Entities.Miscellaneous;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AdminProSolutions.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region MISCELLANEOUS TABLES 
        public DbSet<Audit> Audits { get; private set; }
        #endregion

        #region AUTHENTICATION TABLES
        public virtual DbSet<AccessTypes> AccessTypes { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<FormsAccessTypes> FormsAccessTypes { get; set; }
        public virtual DbSet<GroupFormsAccessTypes> GroupFormsAccessTypes { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<GroupsUsers> GroupsUsers { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccessTypes>(entity => {
                entity.HasKey(e => e.AccessTypeId);

                entity.HasIndex(e => e.CreatedUser)
                    .HasDatabaseName("IX_AccessTypes, UserId");

                entity.Property(e => e.AccessTypeId).ValueGeneratedNever();

                entity.Property(e => e.AccessTypeDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AccessTypeStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<Forms>(entity => {
                entity.HasKey(e => e.FormId);

                entity.Property(e => e.FormId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.FormDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormModule)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FormName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<FormsAccessTypes>(entity => {
                entity.HasKey(e => e.FormAccessTypeId);

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormsAccessTypes)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormsAccessTypes_Forms");
            });

            modelBuilder.Entity<GroupFormsAccessTypes>(entity => {
                entity.HasKey(e => new { e.GroupId, e.FormAccessTypeId });

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();

                entity.HasOne(d => d.FormAccessType)
                    .WithMany(p => p.GroupFormsAccessTypes)
                    .HasForeignKey(d => d.FormAccessTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupFormsAccessTypes_FormsAccessTypes");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupFormsAccessTypes)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupFormsAccessTypes_Groups");
            });

            modelBuilder.Entity<Groups>(entity => {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.ActiveDirectoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.GroupDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GroupStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();
            });

            modelBuilder.Entity<GroupsUsers>(entity => {
                entity.HasKey(e => e.GroupUserId);

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.TimeType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsUsers)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupsUsers_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupsUsers_Users");
            });

            modelBuilder.Entity<Users>(entity => {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.UserLogin)
                    .IsUnique();

                entity.Property(e => e.ActiveDateBegin).HasColumnType("datetime");

                entity.Property(e => e.ActiveDateEnd).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.HashPassword).HasMaxLength(250);

                entity.Property(e => e.PasswordExpiresDate).HasColumnType("datetime");

                entity.Property(e => e.TypeAutentication)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('AD')");

                entity.Property(e => e.UpdatedDate)
                      .HasColumnType("datetime")
                      .HasDefaultValue(DateTime.UtcNow)
                      .ValueGeneratedOnUpdate();

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserSecretAnswer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserSecretQuestion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PasswordFailedQuantity);

                //Ignore Properties
                entity.Ignore(e => e.GroupsAlt);
                entity.Ignore(e => e.OfficesAlt);
                entity.Ignore(e => e.Claims);
                entity.Ignore(e => e.Token);
                entity.Ignore(e => e.FullName);
            });
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var auditEntries = OnBeforeSaveChanges();
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            OnAfterSaveChanges(auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            try
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                        continue;

                    string userId = GetCurrentUserId(), changeBy = "";

                    if (!string.IsNullOrEmpty(userId))
                    {
                        var user = Users.FirstOrDefault(u => u.UserId == int.Parse(userId));
                        changeBy = $"{user.FullName} - ({user.UserLogin})";
                    }

                    var auditEntry = new AuditEntry(entry)
                    {
                        TableName = entry.Metadata.GetTableName(), /* Relational().TableName */
                        ChangeBy = changeBy                    
                    };

                    auditEntries.Add(auditEntry);

                    foreach (var property in entry.Properties)
                    {
                        if (property.IsTemporary)
                        {
                            /* value will be generated by the database, get the value after saving */
                            auditEntry.TemporaryProperties.Add(property);
                            continue;
                        }

                        string propertyName = property.Metadata.Name;
                        if (property.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[propertyName] = property.CurrentValue;
                            continue;
                        }

                        switch (entry.State)
                        {
                            case EntityState.Added:
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                                auditEntry.Operation = Audit.Ops.Create;
                                break;

                            case EntityState.Deleted:
                                auditEntry.OldValues[propertyName] = property.EntityEntry.GetDatabaseValues().GetValue<object>(propertyName);
                                auditEntry.Operation = Audit.Ops.Delete;
                                break;

                            case EntityState.Modified:
                                if (property.IsModified)
                                {
                                    auditEntry.OldValues[propertyName] = property.EntityEntry.GetDatabaseValues().GetValue<object>(propertyName);
                                    auditEntry.NewValues[propertyName] = property.CurrentValue;

                                    if (auditEntry.OldValues is object && auditEntry.OldValues.Count > 0 &&
                                        auditEntry.NewValues is object && auditEntry.NewValues.Count > 0)
                                    {
                                        auditEntry.Operation = Audit.Ops.Update;
                                    }
                                    else if (auditEntry.OldValues is null &&
                                        auditEntry.NewValues is object && auditEntry.NewValues.Count > 0)
                                    {
                                        auditEntry.Operation = Audit.Ops.Create;
                                    }
                                    else if (auditEntry.OldValues is object && auditEntry.OldValues.Count > 0 &&
                                        auditEntry.NewValues is null)
                                    {
                                        auditEntry.Operation = Audit.Ops.Delete;
                                    }
                                }
                                break;
                        }
                    }
                }

                // Save audit entities that have all the modifications
                foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
                {
                    Audits.Add(auditEntry.ToAudit());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            /* keep a list of entries where the value of some properties are unknown at this step */
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private int OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            try
            {
                if (auditEntries == null || auditEntries.Count == 0)
                    return 0;

                foreach (var auditEntry in auditEntries)
                {
                    /* Get the final value of the temporary properties */
                    foreach (var prop in auditEntry.TemporaryProperties)
                    {
                        if (prop.Metadata.IsPrimaryKey())
                        {
                            auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                        }
                        else
                        {
                            auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                        }
                    }
                    /* Save the Audit entry */
                    Audits.Add(auditEntry.ToAudit());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return SaveChanges();
        }

        public string GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user != null)
            {
                // Find the claim with the user's ID
                var userIdClaim = user.FindFirst(ClaimTypes.Name); // Adjust the claim type as needed

                if (userIdClaim != null)
                {
                    // Get the user ID value
                    string userId = userIdClaim.Value;
                    return userId;
                }
            }

            // If user or user ID claim is not found, return null or handle as needed
            return null;
        }
    }
}
