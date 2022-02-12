using RiseWebAssessment.Model;

namespace RiseWebAssessment
{
    public class User
    {
        public int Id { get; set; }
        public string UUID { get; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Company { get; set; } = String.Empty;
        public ICollection<Contact>? Contact { get; }
        //TODO: get requestte contact dönüyor.
    }
}
