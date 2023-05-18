using AutoMapper;
using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;
using HRBMSWEBAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPI.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingRepository _repo;
        private readonly IMapper _mapper;


        public BookingController(IBookingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //stored procedure 
            return Ok(_repo.spGetAllBooking());
            //return Ok(await _repo.GetAllBooking());
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetById([FromRoute] int bookId)
        {
            if (bookId == 0)
            {
                return BadRequest();
            }

            try
            {
                var book = await _repo.GetBookingById(bookId);
                if (book == null)
                    return NoContent();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int bookId)
        {
            if(bookId == 0)
                return BadRequest();

            var book = await _repo.GetBookingById(bookId);

            if (book == null)
                return NotFound("No Resource Found");

            await _repo.DeleteBooking(bookId);
            return Accepted();
        }
    }
}
