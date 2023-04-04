using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace HRBMSWEBAPP.Repository.Database
{
    public class InvoiceDBRepository : IinvoiceDBRepository
    {
        HRBMSDBCONTEXT _context;
        public InvoiceDBRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }

        public Task AddInvoice(Invoice invoice)
        {
            this._context.Add(invoice);
            return this._context.SaveChangesAsync();
        }

        public Task DeleteInvoice(int invoice_id)
        {
            var invoice = this._context.Invoice.FindAsync(invoice_id);
            if (invoice.Result != null)
            {
                this._context.Invoice.Remove(invoice.Result);
            }

            return this._context.SaveChangesAsync();
        }

        public Task<List<Invoice>> GetAllInvoice()
        {
            //try
            //{
                return this._context.Invoice/*.Include(e => e.User)
                                            */.Include(e => e.Booking)
                                            .Include(e => e.Room)
                                            .Include(e => e.Category).ToListAsync();
            //}
            //catch (DbException ex)
            //{
            //    // Log the database exception and show an alert box with the error message
            //    Console.WriteLine($"An error occurred while fetching invoices from the database: {ex.Message}");
            //    //ViewBag.ErrorMessage = ex.Message;
            //    //return View("Index");
            //}
            //catch (Exception ex)
            //{
            //    // Log the exception and show an alert box with a generic error message
            //    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            //    //ViewBag.ErrorMessage = "An unexpected error occurred.";
            //    //return View("Index");
            //}
            

        }

        public Task<Invoice> GetInvoiceById(int invoice_id)
        {
            var invoice = this._context.Invoice
                     /*.Include(e => e.User)
                     */.Include(e => e.Room)
                     .Include(e => e.Booking)
                     .Include(e => e.Category)
                     .FirstOrDefaultAsync(m => m.Id == invoice_id);
            if (invoice == null)
            {
                return null;
            }

            return invoice;
        }

        public Task UpdateInvoice(int invoice_id, Invoice invoice)
        {
            this._context.Update(invoice);
            return this._context.SaveChangesAsync();
        }
    }
}
