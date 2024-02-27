namespace AdminProSolutions.Domain.Dtos.Organization
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Headquarters { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int CompanySize { get; set; } = 0;
        public string Website { get; set; } = string.Empty;
        public DateTime Founded { get; set; }

        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
