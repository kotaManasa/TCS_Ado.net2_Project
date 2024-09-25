using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCS_Ado.net2_Project.Interface;
using TCS_Ado.net2_Project.Model_DTO;
using TCS_Ado.net2_Project.Service;

namespace TCS_Ado.net2_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet(Name = "GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var bookingData = await _bookingService.GetAllBookingDetails();
                if (bookingData != null)
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
        [HttpPost]
        [Route("AddBookingDetails")]
        public async Task<IActionResult> Post([FromBody] BookingDTO bookingdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var bookingData = await _bookingService.AddBookingDetails(bookingdtoobj);
                return StatusCode(StatusCodes.Status201Created, "Booking  Added Succesfully");
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpGet]
        [Route("GetBookingDetailsById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }
            try
            {
                var bookingData = await _bookingService.GetBookingsDetailsById(id);
                if (bookingData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "BookingID Id not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, bookingData);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteBookingDetilsById/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad input request");
            }

            try
            {
                var countryData = await _bookingService.DeleteBookingDetilsById(id);
                if (countryData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Booking Id not found");
                }
                else
                {
                    // var Data = await _bookingservice.DeleteBookingDetilsById(id);
                    return StatusCode(StatusCodes.Status204NoContent, "booking details deleted successfully");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateBookingDetils")]
        public async Task<IActionResult> PUT([FromBody] BookingDTO bookingdtoobj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _bookingService.UpdateBookingDetils(bookingdtoobj);
                return StatusCode(StatusCodes.Status201Created, "booking Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
