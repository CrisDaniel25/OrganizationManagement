namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class AccessTypes
    {
        public int AccessTypeId { get; set; }
        public string AccessTypeDescription { get; set; } = string.Empty;
        public string AccessTypeStatus { get; set; } = string.Empty;
        public bool? AccessTypeIsDefault { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
