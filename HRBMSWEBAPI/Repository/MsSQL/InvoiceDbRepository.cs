using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.MsSQL
{
    public class InvoiceDbRepository : IInvoiceRepository
    {
        HRMSDbContext _dbContext;

        public InvoiceDbRepository(HRMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Invoice AddInvoice(Invoice invoice)
        {
            _dbContext.Add(invoice);
            _dbContext.SaveChanges();
            return invoice;
        }

        public Invoice DeleteInvoice(int invoiceId)
        {
            var invoice = GetInvoiceById(invoiceId);
            if (invoice != null)
            {
                _dbContext.Invoices.Remove(invoice);
                _dbContext.SaveChanges();
            }
            return invoice;
        }

        public List<Invoice> GetAllInvoices()
        {
            return _dbContext.Invoices.AsNoTracking().ToList();
        }


        public Invoice GetInvoiceById(int invoiceId)
        {
            return _dbContext.Invoices.AsNoTracking().ToList().FirstOrDefault(t => t.Id == invoiceId);
        }

        public Invoice UpdateInvoice(int invoiceId, Invoice invoice)
        {
            _dbContext.Invoices.Update(invoice);
            _dbContext.SaveChanges();
            return invoice;
        }
    }
}
