using AutoMapper;
using HRBMSWEBAPI.DTO;
using HRBMSWEBAPI.Models;
using HRBMSWEBAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPI.Controllers
{
    //[Authorize]
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
            return Ok(await _repo.GetAllBooking());
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

        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingDTO bookingDTO)
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

            if (bookingDTO == null)
                return BadRequest("No Data provided");

            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Booking>(bookingDTO);
                var newBook = _repo.AddBooking(book);
                return CreatedAtAction("GetById", new { bookId = newBook.Id }, newBook);
            }

            return BadRequest(ModelState);
        }
        
        
        
        [HttpPut("{bookId}")]

        public IActionResult UpdateBooking([FromBody] Booking booking, [FromRoute] int bookId)
        {
            if (booking == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var updatedBooking = _repo.UpdateBooking(bookId, booking);
                return AcceptedAtAction("GetById", new { bookId = updatedBooking.Id }, updatedBooking);
            }

            return BadRequest(); 
        }
    }
}
