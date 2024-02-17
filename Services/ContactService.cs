using AutoMapper;
using ECoding_MVC_app.DatabaseContext;
using ECoding_MVC_app.Factories;
using ECoding_MVC_app.Models.Domain;
using ECoding_MVC_app.Models.DTO.ContactDTOs;

namespace ECoding_MVC_app.Services
{
    public class ContactService : Service<Contact, ContactDTO, InsertContactDTO, UpdateContactDTO, DeleteContactDTO>, IContactService
    {
        private readonly IContactFactory _contactFactory;


        public ContactService(IAppDbContext db, IMapper mapper, IContactFactory contactFactory) : base(db, mapper)
        {
            _contactFactory = contactFactory;
        }


        public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync() => await base.GetAllAsync();


        public async Task<ContactDTO> GetContactByIdAsync(Guid id) => await base.GetByIdAsync(id);


        public async Task<ContactDTO> InsertSingleContactAsync(InsertContactDTO insertContactDTO)
        {
            Contact contact = _contactFactory.CreateContactEntity(
                insertContactDTO.FirstName,
                insertContactDTO.LastName,
                insertContactDTO.Email,
                insertContactDTO.PhoneNumber
            );

            return await base.InsertSingleAsync(contact);
        }


        public async Task DeleteContactByIdAsync(Guid id) => await base.DeleteByIdAsync(id);

        public async Task<ContactDTO> UpdateContactByIdAsync(Guid id, UpdateContactDTO updateContactDTO)
        {
            return await base.UpdateByIdAsync(id, updateContactDTO);
        }
    }
}
