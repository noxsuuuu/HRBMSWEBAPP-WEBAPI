using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IInvoiceRepository 
    {
       Task<Invoice> GetInvoiceById(int id);

       Task<List<Invoice>> GetAllInvoice();
        
       Task DeleteInvoice(int id);
    }
}
