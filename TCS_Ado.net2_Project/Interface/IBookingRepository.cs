using TCS_Ado.net2_Project.Entity;

namespace TCS_Ado.net2_Project.Interface
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingDetails();
        Task<Booking> GetBookingDetailsById(int id);
        Task<bool> AddBookingDetails(Booking bookingDetail);
        Task<bool> UpdateBookingDetils(Booking bookingDetail);
        Task<bool> DeleteBookingDetilsById(int id);
    }
}
