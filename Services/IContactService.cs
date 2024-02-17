using ECoding_MVC_app.Models.DTO.ContactDTOs;

namespace ECoding_MVC_app.Services
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(Guid id);
        Task<ContactDTO> InsertSingleContactAsync(InsertContactDTO insertContactDTO);
        Task DeleteContactByIdAsync(Guid id);
        Task<ContactDTO> UpdateContactByIdAsync(Guid id, UpdateContactDTO updateContactDTO);
    }
}
