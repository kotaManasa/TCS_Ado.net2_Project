using TCS_Ado.net2_Project.Model_DTO;

namespace TCS_Ado.net2_Project.Interface
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllBookingDetails();
        Task<BookingDTO> GetBookingsDetailsById(int id);
        Task<bool> AddBookingDetails(BookingDTO bookingDetail);
        Task<bool> UpdateBookingDetils(BookingDTO bookingDetail);
        Task<bool> DeleteBookingDetilsById(int id);
    }
}
