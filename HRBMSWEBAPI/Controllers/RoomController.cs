using AutoMapper;
using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;
using HRBMSWEBAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRBMSWEBAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        // GET: api/<RoomController>
        IRoomRepository _repo;
        private readonly IMapper _mapper;


        public RoomController(IRoomRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //calling getallrooms stored procedure 
            return Ok( _repo.spGetAllRooms());
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetById([FromRoute] int roomId)
        {
            if (roomId == 0)
            {
                return BadRequest();
            }

            try
            {
                var room = await _repo.GetRoomById(roomId);
                if (room == null)
                    return NoContent();
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int roomId)
        {
            if (roomId == 0)
                return BadRequest();

            var room = await _repo.GetRoomById(roomId);

            if (room == null)
                return NotFound("No Resource Found");

            await _repo.spDeleteRoom(roomId);
            return Accepted();
        }

    }
}
