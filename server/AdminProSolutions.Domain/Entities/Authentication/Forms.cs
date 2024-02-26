namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class Forms
    {
        public Forms() => FormsAccessTypes = new HashSet<FormsAccessTypes>();
        

        public int FormId { get; set; }
        public string FormModule { get; set; } = string.Empty;
        public string FormName { get; set; } = string.Empty;
        public string FormDescription { get; set; } = string.Empty;
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<FormsAccessTypes> FormsAccessTypes { get; set; }
    }

}
