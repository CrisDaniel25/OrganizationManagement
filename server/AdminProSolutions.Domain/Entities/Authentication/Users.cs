namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class Users
    {
        public Users()
        {
            GroupUsers = new HashSet<GroupsUsers>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserPhone { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserStatus { get; set; } = string.Empty;
        public string UserSecretQuestion { get; set; } = string.Empty;
        public string UserSecretAnswer { get; set; } = string.Empty;
        public bool? UserPasswordHasBeenReset { get; set; }
        public bool? IsPasswordExpires { get; set; }
        public DateTime? PasswordExpiresDate { get; set; }
        public DateTime? ActiveDateBegin { get; set; }
        public DateTime? ActiveDateEnd { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TypeAutentication { get; set; } = string.Empty;
        public byte[] HashPassword { get; set; } = Array.Empty<byte>();

        public virtual ICollection<GroupsUsers> GroupUsers { get; set; }

        public string FullName => $"{this.UserName}";

        public string Token { get; set; } = string.Empty;
        public int[] GroupsAlt { get; set; } = Array.Empty<int>();
        public int[] OfficesAlt { get; set; } = Array.Empty<int>();
        public string[] Claims { get; set; } = Array.Empty<string>();

        public int PasswordFailedQuantity { get; set; }
    }
}
