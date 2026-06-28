using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using ALSiteBack.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;

namespace ALSiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;

        public GroupController(IMapper mapper, IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Group>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMainGroups()
        {
            var _groups = await _groupRepository.GetMainGroups();
            var groups = _mapper.Map<List<GroupDto>>(_groups);
            return Ok(groups);
        }

        [HttpGet("{GroupId}")]
        [ProducesResponseType(200, Type = typeof(Group))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMainGroups(int GroupId)
        {
            var _group = await _groupRepository.GetGroup(GroupId);
            var group = _mapper.Map<GroupDto>(_group);
            if (group == null) {
                return NotFound();
            }
            return Ok(group);
        }
    }
}
