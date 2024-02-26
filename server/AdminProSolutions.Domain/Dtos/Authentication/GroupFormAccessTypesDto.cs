namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class GroupFormAccessTypesDto
    {
        public int GroupId { get; set; }
        public int FormAccessTypeId { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual FormAccessTypesDto FormAccessType { get; set; } = new FormAccessTypesDto();

    }
}
