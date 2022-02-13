namespace RiseWebAssessment.Model.Entities
{
    public class BaseEntity
    {
        public int Id { get; }
        public DateTime LastModify { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        public bool IsActive { get; set; } = true;
    }
}
