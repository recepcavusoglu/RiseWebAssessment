using RiseWebAssessment.Core;

namespace RiseWebAssessment.Model.DTO
{
    public class ContactDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public User User { get; }
        public Enums.InfoType InfoType { get; }
        public string InfoContent { get; set; }
    }
}
