using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRBMSWEBAPP.Controllers
{
    public class InvoiceController : Controller
    {
        IinvoiceDBRepository _repo;

        public InvoiceController(IinvoiceDBRepository repo)
        {
            _repo = repo;
        }

        public IActionResult GetAllInvoice()
        {
            var invoicelist = _repo.GetAllInvoice();
            return View(invoicelist);

        }

        public IActionResult Details(int invoiceId)
        {
            var invoice = _repo.GetInvoiceById(invoiceId);
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
        public IActionResult Update(Invoice invoice)
        {
            var _invoice = _repo.UpdateInvoice(invoice.Id, invoice);
            return RedirectToAction("GetAllInvoice");
        }
    }
}
