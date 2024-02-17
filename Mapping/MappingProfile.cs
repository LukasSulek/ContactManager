using AutoMapper;
using ECoding_MVC_app.Models.Domain;
using ECoding_MVC_app.Models.DTO.ContactDTOs;

namespace ECoding_MVC_app.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            ConfigureContactMapping();

        }

        private void ConfigureContactMapping()
        {
            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactDTO>();

            CreateMap<InsertContactDTO, Contact>();
            CreateMap<Contact, InsertContactDTO>();

            CreateMap<UpdateContactDTO, Contact>();
            CreateMap<Contact, UpdateContactDTO>();

            CreateMap<DeleteContactDTO, Contact>();
            CreateMap<Contact, DeleteContactDTO>();
        }
    }
}
