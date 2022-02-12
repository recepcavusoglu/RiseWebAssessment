namespace RiseWebAssessment.Model.Entities
{
    public class BaseEntity
    {
        public int Id { get; }
        public DateTime LastModify { get; set; }
        // TODO: Check CreationTime Tables dont have it
        public DateTime CreationTime { get; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
        public bool IsActive { get; set; } = true;
    }
}
