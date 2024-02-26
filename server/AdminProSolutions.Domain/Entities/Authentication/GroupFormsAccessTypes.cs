namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class GroupFormsAccessTypes
    {
        public int GroupId { get; set; }
        public int FormAccessTypeId { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual FormsAccessTypes? FormAccessType { get; set; }
        public virtual Groups? Group { get; set; }
    }

}
