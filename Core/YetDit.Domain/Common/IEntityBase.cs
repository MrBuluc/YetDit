namespace YetDit.Domain.Common
{
    public interface IEntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
