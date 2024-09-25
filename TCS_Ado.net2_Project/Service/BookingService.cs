using TCS_Ado.net2_Project.Entity;
using TCS_Ado.net2_Project.Interface;
using TCS_Ado.net2_Project.Model_DTO;
using TCS_Ado.net2_Project.Repository;

namespace TCS_Ado.net2_Project.Service
{
    public class BookingService : IBookingService
    {
        IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<bool> AddBookingDetails(BookingDTO bookingDetail)
        {
            Booking obj = new Booking();
            obj.id = bookingDetail.id;
            obj.CustomerName = bookingDetail.CustomerName;
            obj.Country = bookingDetail.Country;
            obj.City = bookingDetail.City;
            obj.Email = bookingDetail.Email;


            await _bookingRepository.AddBookingDetails(obj);
            return true;
        }

        public async Task<bool> DeleteBookingDetilsById(int id)
        {
            await _bookingRepository.DeleteBookingDetilsById(id);
            return true;
        }

        public async Task<List<BookingDTO>> GetAllBookingDetails()
        {
            List<BookingDTO> objBookingDto = new List<BookingDTO>();
            var result = await _bookingRepository.GetAllBookingDetails();
            foreach (Booking bookingobj in result)
            {
                BookingDTO obj = new BookingDTO();
                obj.id = bookingobj.id;
                obj.CustomerName = bookingobj.CustomerName;
                obj.Country = bookingobj.Country;
                obj.City = bookingobj.City;
                obj.Email = bookingobj.Email;
                objBookingDto.Add(obj);
            }
            return objBookingDto;
        }

        public async Task<BookingDTO> GetBookingsDetailsById(int id)
        {
            var bookingobj = await _bookingRepository.GetBookingDetailsById(id);

            BookingDTO bookingdtoobj = new BookingDTO();
            bookingdtoobj.id = bookingobj.id;
            bookingdtoobj.CustomerName = bookingobj.CustomerName;
            bookingdtoobj.Email = bookingobj.Email;
            bookingdtoobj.City = bookingobj.City;
            bookingdtoobj.Country = bookingobj.Country;

            return bookingdtoobj;
        }

        public async Task<bool> UpdateBookingDetils(BookingDTO bookingDetail)
        {
            Booking obj = new Booking();
            obj.id = bookingDetail.id;
            obj.CustomerName = bookingDetail.CustomerName;
            obj.City = bookingDetail.City;
            obj.Country = bookingDetail.Country;
            obj.Email = bookingDetail.Email;

            await _bookingRepository.UpdateBookingDetils(obj);
            return true;
        }
    }
}
