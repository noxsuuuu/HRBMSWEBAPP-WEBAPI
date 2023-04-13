using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.Database
{
    public class InvoiceDbRepository : IInvoiceRepository
    {
        HRBMSDBCONTEXT _context;



        public InvoiceDbRepository( HRBMSDBCONTEXT context)
        {
            _context = context;
        }
        
        public Task<Invoice> GetInvoiceById(int id)
        {
            var invoice = this._context.Invoice
                .FirstOrDefaultAsync(x => x.Id == id);

            if (invoice == null)
            {
                return null;
            }

            return invoice;
        }


        public Task<List<Invoice>> GetAllInvoice()
        {
            return this._context.Invoice.ToListAsync();
        }

        public Task DeleteInvoice(int id)
        {
            var invoice = this._context.Invoice.FindAsync(id);
            if(invoice.Result != null)
            {
                this._context.Invoice.Remove(invoice.Result);
            }

            return this._context.SaveChangesAsync();
        }


    }
}
