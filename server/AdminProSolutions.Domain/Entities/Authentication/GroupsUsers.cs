namespace AdminProSolutions.Domain.Entities.Authentication
{
    public partial class GroupsUsers
    {
        public int GroupUserId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int? CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserOrder { get; set; }
        public bool? IsSendInitialMail { get; set; }
        public bool? IsSendAllTimeMail { get; set; }
        public bool? IsSendTimeMail { get; set; }
        public int? TimeToSendMail { get; set; }
        public string TimeType { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUser { get; set; }

        public virtual Groups? Group { get; set; }
        public virtual Users? User { get; set; }

    }
}
