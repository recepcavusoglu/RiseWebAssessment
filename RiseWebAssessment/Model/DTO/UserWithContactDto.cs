namespace RiseWebAssessment.Model.DTO
{
    public class UserWithContactDto : UserDto
    {
        public ICollection<ContactDto> Contact { get; set; }
    }
}
