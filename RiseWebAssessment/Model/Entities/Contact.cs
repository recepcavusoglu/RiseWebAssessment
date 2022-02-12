using System.ComponentModel.DataAnnotations;
using RiseWebAssessment.Core;
using RiseWebAssessment.Model.Entities;

namespace RiseWebAssessment.Model
{
    public class Contact : BaseEntity
    {
        public int UserId { get; set; }
        //public User User { get; }
        public Enums.InfoType InfoType { get; set; }
        public string InfoContent { get; set; }
        //public int ContactInfoId { get; set; }
        //public BaseInfo Info { get; set; }
        
    }
}
