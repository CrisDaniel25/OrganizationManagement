namespace AdminProSolutions.Domain.Dtos.Authentication
{
    public class GroupsUsersDto
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

        public virtual GroupsDto? Group { get; set; }

        //No add, avoid infinite loopback
        //public virtual UserDto User { get; set; }
    }
}
