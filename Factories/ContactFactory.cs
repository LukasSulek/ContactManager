using ECoding_MVC_app.Models.Domain;

namespace ECoding_MVC_app.Factories
{
    public class ContactFactory : IContactFactory
    {
        public Contact CreateContactEntity(string firstName, string lastName, string email, string phoneNumber)
        {
            return new Contact(firstName, lastName, email, phoneNumber);
        }
    }
}
