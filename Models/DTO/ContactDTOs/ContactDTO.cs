using System.ComponentModel.DataAnnotations;

namespace ECoding_MVC_app.Models.DTO.ContactDTOs
{
    public class ContactDTO : IDTO
    {
        public Guid Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
