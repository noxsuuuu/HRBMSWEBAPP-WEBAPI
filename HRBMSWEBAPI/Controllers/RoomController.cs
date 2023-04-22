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
            return Ok(await _repo.GetAllRoom());
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

            var book = await _repo.GetRoomById(roomId);

            if (book == null)
                return NotFound("No Resource Found");

            await _repo.DeleteRoom(roomId);
            return Accepted();
        }

        [HttpPost]
        public IActionResult AddBooking([FromBody] RoomDTO roomDTO)
        {
            /*
                             if (bookingDTO == null)
                             {
                                 return BadRequest("No data provided");
                             }

                             if (ModelState.IsValid)
                             {
                                 var book = _mapper.Map<Booking>(bookingDTO);
                                 var newBook = _repo.AddBooking(book);
                                 return CreatedAtAction("GetById", new { bookId = newBook.Id }, newBook);
                             }

                             return BadRequest(ModelState);*/

            if (roomDTO == null)
                return BadRequest("No Data provided");

            if (ModelState.IsValid)
            {
                var room = _mapper.Map<Room>(roomDTO);
                var newRoom = _repo.AddRoom(room);
                return CreatedAtAction("GetById", new { roomId = newRoom.Id }, newRoom);
            }

            return BadRequest(ModelState);
        }



        [HttpPut("{roomId}")]

        public IActionResult UpdateBooking([FromBody] Room room, [FromRoute] int roomId)
        {
            if (room == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var updatedRoom = _repo.UpdateRoom(roomId, room);
                return AcceptedAtAction("GetById", new { roomId = updatedRoom.Id }, updatedRoom);
            }

            return BadRequest();
        }
    }
}
