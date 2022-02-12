namespace RiseWebAssessment.Model.Entities
{
    public class BaseEntity
    {
        public int Id { get; }
        public DateTime LastModify { get; set; }
        public DateTime CreationTime { get; } = DateTime.Now;

        public Boolean IsActive { get; set; }
    }
}
