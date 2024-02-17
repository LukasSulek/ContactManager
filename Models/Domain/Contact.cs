using System.ComponentModel.DataAnnotations;

namespace ECoding_MVC_app.Models.Domain
{
    public class Contact : IIdentifiable
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public Contact(string firstName, string lastName, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
