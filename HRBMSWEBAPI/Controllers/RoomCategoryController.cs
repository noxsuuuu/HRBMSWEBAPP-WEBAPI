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
    public class RoomCategoryController : ControllerBase
    {
        IRoomCatRepository _repo;
        private readonly IMapper _mapper;


        public RoomCategoryController(IRoomCatRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllRoomCategories());
        }

        [HttpGet("{catId}")]
        public async Task<IActionResult> GetById([FromRoute] int catId)
        {
            if (catId == 0)
            {
                return BadRequest();
            }

            try
            {
                var category = await _repo.GetRoomCategoriesById(catId);
                if (category == null)
                    return NoContent();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{catId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int bookId)
        {
            if (bookId == 0)
                return BadRequest();

            var book = await _repo.GetRoomCategoriesById(bookId);

            if (book == null)
                return NotFound("No Resource Found");

            await _repo.DeleteRoomCategories(bookId);
            return Accepted();
        }

        [HttpPost]
        public IActionResult AddRoomCategories([FromBody] RoomCategoriesDTO categoryDTO)
        {
            /*
                             if (bookingDTO == null)
                             {
                                 return BadRequest("No data provided");
                             }

                             if (ModelState.IsValid)
                             {
                                 var book = _mapper.Map<RoomCategories>(bookingDTO);
                                 var newBook = _repo.AddRoomCategories(book);
                                 return CreatedAtAction("GetById", new { bookId = newBook.Id }, newBook);
                             }

                             return BadRequest(ModelState);*/

            if (categoryDTO == null)
                return BadRequest("No Data provided");

            if (ModelState.IsValid)
            {
                var category = _mapper.Map<RoomCategories>(categoryDTO);
                var newcat = _repo.AddRoomCategories(category);
                return CreatedAtAction("GetById", new { catId = newcat.Id }, newcat);
            }

            return BadRequest(ModelState);
        }



        [HttpPut("{catId}")]

        public IActionResult UpdateRoomCategories([FromBody] RoomCategories category, [FromRoute] int catId)
        {
            if (category == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var updatedRoomCategories = _repo.UpdateRoomCategories(catId, category);
                return AcceptedAtAction("GetById", new { catId = updatedRoomCategories.Id }, updatedRoomCategories);
            }

            return BadRequest();
        }
    }
}
