using System.ComponentModel.DataAnnotations;
using WebApi.Assets;

namespace WebApi.Model
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
