using Microsoft.AspNetCore.Mvc;
using tp4.Core.Entities;
using tp4.Core.Interfaces.Services;

namespace tp4.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipTypeController : ControllerBase
    {
        private readonly IMembershipTypeService _membershipTypeService;

        public MembershipTypeController(IMembershipTypeService membershipTypeService)
        {
            _membershipTypeService = membershipTypeService;
        }

        [HttpGet]
        public IActionResult GetAllMembershipTypes()
        {
            var membershipTypes = _membershipTypeService.GetAllMembershipTypes();
            return Ok(membershipTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetMembershipTypeById(int id)
        {
            var membershipType = _membershipTypeService.GetMembershipTypeById(id);
            if (membershipType == null) return NotFound();
            return Ok(membershipType);
        }
    }
}
