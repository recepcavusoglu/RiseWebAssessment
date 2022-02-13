using RiseWebAssessment.Core;

namespace RiseWebAssessment.Model.DTO
{
    public class ContactDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Enums.InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
    }
}
