namespace WebApi.Model.InfoModel
{
    public abstract class BaseInfo
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public ICollection<Contact> Contact { get; set; }
    }
}
