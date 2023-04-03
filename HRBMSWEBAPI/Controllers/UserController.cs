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

    public class UserController : ControllerBase
    {
        IUserRepository _repo;

        private readonly IMapper _mapper;

        public UserController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_repo.GetAllUsers());
        }

        [HttpGet("{userId}")]

        public IActionResult GetById([FromRoute] int userId)
        {
            if (userId == 0)
                return BadRequest();

            User user;
            try
            {
                user = _repo.GetUserById(userId);
                if (user == null)
                    return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(user);

        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromRoute] int userId) // model binding 
        {
            if (userId == 0)
                return BadRequest();
            var user = _repo.GetUserById(userId);
            if (user == null)
                return NotFound("No resource found");
            return Accepted(_repo.DeleteUser(userId)); // json or xml
        }

        [HttpPost]
        // model binding 
        // userDTO? -> asp.net framework, model binding -> validation of your data against the model
        // data transfer object Client to server -> database -> model
        public IActionResult AddUser([FromBody] UserDTO userDTO) // model binding // validation
        {
            if (userDTO == null)
                return BadRequest("No data provided");
            if (ModelState.IsValid)
            {
                /*var user = new User()
                {
                    Title=userDTO.Title,
                    Description=userDTO.Description,
                    Status=userDTO.Status,
                    DueDate=userDTO.DueDate
                };*/

                var user = _mapper.Map<User>(userDTO);

                var newuser = _repo.AddUser(user);
                // return the url for it
                return CreatedAtAction("GetById", new { userId = newuser.Id }, newuser);
                //return CreatedAtAction("GetById",new { userId = newuser.Id },null); // json or xml
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser([FromBody] User user, [FromRoute] int userId) // model binding // validation
        {
            if (user == null)
                return BadRequest("No data provided");
            if (ModelState.IsValid)
            {
                var updatedUser = _repo.UpdateUser(userId, user);
                return AcceptedAtAction("GetById", new { userId = updatedUser.Id }, updatedUser); // json or xml
            }
            return BadRequest(ModelState);
        }
    }
}
