using ECoding_MVC_app.Models.DTO.ContactDTOs;
using ECoding_MVC_app.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECoding_MVC_app.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactService _contactService;

        public ContactsController(ILogger<ContactsController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await _contactService.GetAllContactsAsync();

            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }


        [HttpGet("{id:Guid}", Name= "ContactDetails")]
        public async Task<IActionResult> Details([FromRoute] Guid id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }



        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsertContactDTO insertContactDTO)
        {
            if (ModelState.IsValid)
            {
                await _contactService.InsertSingleContactAsync(insertContactDTO);

                return RedirectToAction(nameof(Index));
            }

            return View(insertContactDTO);
        }



        [HttpGet("{id:Guid}/Edit", Name = "EditContact")]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);

            return View(contact);
        }


        [HttpPost("{id:Guid}/Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] Guid id, UpdateContactDTO updateContactDTO)
        {
            try
            {
                await _contactService.UpdateContactByIdAsync(id, updateContactDTO);

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database Update Error: {ex}");
                return StatusCode(500, new { Message = "An error occured while updating the database" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return StatusCode(500, new { Message = "An error occured while processing the request" });
            }
        }



        [HttpGet("{id:Guid}/Delete", Name = "DeleteContact")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            return View(contact);
        }


        [HttpPost("{id:Guid}/Delete")]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] Guid id)
        {
            await _contactService.DeleteContactByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
