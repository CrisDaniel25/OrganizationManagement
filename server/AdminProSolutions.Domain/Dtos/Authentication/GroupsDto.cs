namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class GroupsDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string GroupDescription { get; set; } = string.Empty;
        public string ActiveDirectoryName { get; set; } = string.Empty;
        public string GroupStatus { get; set; } = string.Empty;
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<FormsAccessDto>? AccessTypes { get; set; }

        public List<int>? UsersAlt { get; set; }
    }
}
