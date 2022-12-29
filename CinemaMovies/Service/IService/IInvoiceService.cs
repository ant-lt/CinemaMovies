using CinemaMovies.Models;
using CinemaMovies.Models.DTO;

namespace CinemaMovies.Service.IService
{
    public interface IInvoiceService
    {
        InvoiceDto BuildInvoice(Purchase purchase);
    }
}
