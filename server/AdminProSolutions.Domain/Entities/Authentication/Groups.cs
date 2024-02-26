namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class Groups
    {
        public Groups()
        {
            GroupFormsAccessTypes = new HashSet<GroupFormsAccessTypes>();
            GroupsUsers = new HashSet<GroupsUsers>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string GroupDescription { get; set; } = string.Empty;
        public string ActiveDirectoryName { get; set; } = string.Empty;
        public string GroupStatus { get; set; } = string.Empty;
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<GroupFormsAccessTypes> GroupFormsAccessTypes { get; set; }
        public virtual ICollection<GroupsUsers> GroupsUsers { get; set; }

    }
}
