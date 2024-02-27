namespace AdminProSolutions.Domain.Model
{
    public class AppSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public int TokenValidDuration { get; set; }
        public string DefaultConnection { get; set; } = string.Empty;
        public int OtpValidDays { get; set; }
        public int MaxPasswordFailedQuantity { get; set; }
        public LdapConfig? LDAP { get; set; }
    }
}
