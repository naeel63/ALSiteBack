using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ALSiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactController(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Contact>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetContacts()
        {
            var _contacts = await _contactRepository.GetContacts();
            var contacts = _mapper.Map<List<Contact>>(_contacts);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(contacts);
        }
    }
}
