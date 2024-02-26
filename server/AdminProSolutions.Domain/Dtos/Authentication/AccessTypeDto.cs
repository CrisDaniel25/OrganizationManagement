namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class AccessTypeDto
    {
        public int AccessTypeId { get; set; }
        public string AccessTypeDescription { get; set; } = string.Empty;
        public bool Checked { get; set; }

        public int FormAccessTypeId { get; set; }
    }
}
