using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IinvoiceDBRepository _repo;

        public InvoiceController(IinvoiceDBRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetAllInvoice()
        {
            List<Invoice> invoice = await this._repo.GetAllInvoice();
            return View(invoice);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Invoice invoice = await this._repo.GetInvoiceById((int)id);
            return View(invoice);
        }

        public IActionResult Delete(int id)
        {
            var invoicelist = _repo.DeleteInvoice(id);
            return RedirectToAction(controllerName: "Invoice", actionName: "GetAllInvoice");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                var _invoice = _repo.AddInvoice(invoice);
                return RedirectToAction("GetAllInvoice");
            }
            ViewData["Message"] = "Data is not valid to create the Invoice";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Invoice invoice)
        {

            await _repo.UpdateInvoice(invoice.Id, invoice);
            return RedirectToAction("GetAllInvoice");
        }
    }
}
