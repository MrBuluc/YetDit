namespace YetDit.Domain.Common
{
    public interface ICreatedOn
    {
        public string CreatedByUserId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
