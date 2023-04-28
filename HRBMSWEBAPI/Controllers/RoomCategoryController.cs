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
    }
}
