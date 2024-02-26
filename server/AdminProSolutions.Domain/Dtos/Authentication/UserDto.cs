using AdminProSolutions.Domain.Entities.Authentication;

namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName => $"{this.UserName}";

        public string UserName { get; set; } = string.Empty;
        public string UserLogin { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;

        public string UserPhone { get; set; } = string.Empty; 
        public string UserEmail { get; set; } = string.Empty; 

        public string TypeAutentication { get; set; } = string.Empty; 
        public string UserStatus { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;


        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<GroupsUsersDto> GroupUsers { get; set; } = new List<GroupsUsersDto>();

        public int[] GroupsAlt { get; set; } = Array.Empty<int>();

        public int[] OfficesAlt { get; set; } = Array.Empty<int>();

        public static implicit operator UserDto(Users v)
        {
            throw new NotImplementedException();
        }
    }
}
