namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class FormsAccessTypes
    {
        public FormsAccessTypes() => GroupFormsAccessTypes = new HashSet<GroupFormsAccessTypes>();        

        public int FormAccessTypeId { get; set; }
        public int FormId { get; set; }
        public int AccessTypeId { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Forms? Form { get; set; }
        public virtual ICollection<GroupFormsAccessTypes> GroupFormsAccessTypes { get; set; }
    }

}
