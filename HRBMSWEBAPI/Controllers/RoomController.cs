using AutoMapper;
using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;
using HRBMSWEBAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        HRBMSDBCONTEXT _context;

        public RoomController(IRoomRepository repo, IMapper mapper, HRBMSDBCONTEXT context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //calling getallrooms stored procedure 
            return Ok( await _repo.GetAllRoom());
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

        [HttpPost]
        public IActionResult AddRoom([FromBody] RoomDTO roomDTO)
        {
            

            if (roomDTO == null)
                return BadRequest("No Data provided");

            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomDTO);
                var newRoom = _repo.spAddroom(room);
                return CreatedAtAction("GetById", new { roomId = newRoom.Id }, newRoom);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{roomId}")]

        public IActionResult UpdateRoom([FromBody] Room room, [FromRoute] int roomId)
        {
            if (room == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var updatedRoom = _repo.spUpdateRoom(roomId, room);
                return AcceptedAtAction("GetById", new { roomId = updatedRoom.Id }, updatedRoom);
            }

            return BadRequest();
        }

    }
}
