namespace AdminProSolutions.Domain.Entities.Organization
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string IdentityDocument { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty; 
         
        public string Email { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime? EndDate { get; set; }

        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public int ClientId { get; set; }

        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Clients Client { get; set; }
    }
}
