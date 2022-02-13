using RiseWebAssessment.Model;
using RiseWebAssessment.Model.Entities;

namespace RiseWebAssessment
{
    public class User : BaseEntity
    {
        public string UUID { get; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Company { get; set; } = String.Empty;
        public ICollection<Contact> Contact { get; set; }
    }
}
