namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class FormDto
    {
        public int FormId { get; set; }
        public string FormModule { get; set; } = string.Empty;
        public string FormName { get; set; } = string.Empty;
        public string FormDescription { get; set; } = string.Empty; 

    }
}
