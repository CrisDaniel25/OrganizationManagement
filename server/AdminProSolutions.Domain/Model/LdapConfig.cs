namespace AdminProSolutions.Domain.Model
{
    public class LdapConfig
    {
        public string Url { get; set; } = string.Empty;
        public string BindDn { get; set; } = string.Empty;
        public string BindCredentials { get; set; } = string.Empty; 
    }
}
