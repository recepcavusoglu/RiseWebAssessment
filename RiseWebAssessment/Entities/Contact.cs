using System.ComponentModel.DataAnnotations;
using RiseWebAssessment.Core;

namespace RiseWebAssessment.Model
{
    public class Contact
    {
        public int Id { get; }
        public int UserId { get; set; }
        //public User User { get; }
        public Enums.InfoType InfoType { get; }
        public string InfoContent { get; set; }
        //public int ContactInfoId { get; set; }
        //public BaseInfo Info { get; set; }
        
    }
}
