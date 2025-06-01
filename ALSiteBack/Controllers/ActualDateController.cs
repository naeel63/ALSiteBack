using ALSiteBack.Dto;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ALSiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualDateController : Controller
    {
        private readonly IMapper _mapper; 
        private readonly IActualDateRepository _actualDateRepository;

        public ActualDateController(IMapper mapper, IActualDateRepository actualDateRepository)
        {
            _mapper = mapper;
            _actualDateRepository = actualDateRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ActualDate))]
        [ProducesResponseType(500)]
        public IActionResult GetActualDate()
        {
            var actualDate = _mapper.Map<ActualDateDto>(_actualDateRepository.GetActualDate());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(actualDate);
        }
    }
}
