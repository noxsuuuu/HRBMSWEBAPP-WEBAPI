using AutoMapper;
using HRBMSWEBAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPI.Controllers
{

    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {


        IInvoiceRepository _repo;
        private readonly IMapper _mapper;


        public InvoiceController(IInvoiceRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllInvoice());
        }


        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetById([FromRoute] int invoiceId)
        {
            if (invoiceId == 0)
            {
                return BadRequest();
            }

            try
            {
                var book = await _repo.GetInvoiceById(invoiceId);
                if (book == null)
                    return NoContent();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int invoiceId)
        {
            if (invoiceId == 0)
                return BadRequest();

            var book = await _repo.GetInvoiceById(invoiceId);

            if (book == null)
                return NotFound("No Resource Found");

            await _repo.DeleteInvoice(invoiceId);
            return Accepted();
        }



    }
}
