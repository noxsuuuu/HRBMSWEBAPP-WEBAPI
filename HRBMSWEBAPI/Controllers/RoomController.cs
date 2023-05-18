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

        //[HttpPost]
        //public async Task<IActionResult> AddRoom(int CategoryId, bool Status)
        //{

        //   // var parameter = new[]
        //   //{
        //   // new SqlParameter("@CategoryId", CategoryId),
        //   // new SqlParameter("@Status", Status)
        //   // };
        //    var result = await _context.Database
        //   .ExecuteSqlRawAsync($"addroom {CategoryId}, {Status}");
        //   // await _context.SaveChangesAsync();
        //    return Ok(result);
            
        //}

    }
}
