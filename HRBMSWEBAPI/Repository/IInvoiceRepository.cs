using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAllInvoices();

        Invoice GetInvoiceById(int invoiceId);

        Invoice AddInvoice(Invoice invoice);

        Invoice UpdateInvoice(int invoiceId, Invoice invoice);

        Invoice DeleteInvoice(int invoiceId);
    }
}
