namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class FormAccessTypesDto
    {
        public int FormAccessTypeId { get; set; }
        public int FormId { get; set; }
        public int AccessTypeId { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public FormDto Form { get; set; } = new FormDto();
        public List<AccessTypeDto> AccessTypesList { get; set; } = new List<AccessTypeDto>();

    }
}
