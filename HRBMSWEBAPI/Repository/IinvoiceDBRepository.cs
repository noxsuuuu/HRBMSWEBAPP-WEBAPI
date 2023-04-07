using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IinvoiceDBRepository
    {
        Task<List<Invoice>> GetAllInvoice();
        Task<Invoice> GetInvoiceById(int invoice_id);
        Task AddInvoice(Invoice invoice);
        Task DeleteInvoice(int invoice_id);
        Task UpdateInvoice(int invoice_id, Invoice invoice);
    }
}
