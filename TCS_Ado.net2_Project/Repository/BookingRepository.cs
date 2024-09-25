using System.Data.SqlClient;
using System.Data;
using TCS_Ado.net2_Project.Entity;
using TCS_Ado.net2_Project.Interface;

namespace TCS_Ado.net2_Project.Repository
{
    public class BookingRepository : IBookingRepository
    {
        string connectionString = "data source=HP-PAVILION-14-;integrated security=yes;initial catalog=hotelmanagement";
        public BookingRepository()
        {
            
        }

        public async Task<bool> AddBookingDetails(Booking bookingDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand("Usp_AddBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", bookingDetail.id);
                cmd.Parameters.AddWithValue("@CustomerName", bookingDetail.CustomerName);
                cmd.Parameters.AddWithValue("@City", bookingDetail.City);
                cmd.Parameters.AddWithValue("@Country", bookingDetail.Country);
                cmd.Parameters.AddWithValue("@Email", bookingDetail.Email);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Booking");

            }
            return true;
        }

        public async Task<bool> DeleteBookingDetilsById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_DeleteBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Booking");
            }
            return true;
        }

        public async Task<List<Booking>> GetAllBookingDetails()
        {
            //we need to create empty booking list
            List<Booking> lstBooking = new List<Booking>();
            //1. in sqlconnection object creation time we must pass the connectionString variable
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //3.in sqlcommand object creation time we must pass the sqlquery/stored procedure along with sqlconnection object
                SqlCommand cmd = new SqlCommand("Usp_GetAllBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //sql dataadapter will open the connection , executing the query,after excuting results will store in dataset.
                //after that it will close the connection
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //dataset is nothing but local database or temporary memory area
                //dataset having a data tables
                DataSet ds = new DataSet();
                //after getting the result sql data adaapter will assign data to dataset by using fill method.
                //below is the reference
                da.Fill(ds, "Booking");

                // Display the data (optional)
                foreach (DataRow row in ds.Tables["Booking"].Rows)
                {
                    //foreach is looping mechansim which is used to iterate data one by one
                    Booking objBooking = new Booking();//this is booking object it will store only 1 object/record
                    objBooking.id = Convert.ToInt32(row["id"]);
                    objBooking.CustomerName = Convert.ToString(row["CustomerName"]);
                    objBooking.Email = Convert.ToString(row["Email"]);
                    objBooking.City = Convert.ToString(row["City"]);
                    objBooking.Country = Convert.ToString(row["Country"]);
                    lstBooking.Add(objBooking);//here that booking object we are adding to list objects
                }
            }
            return lstBooking;
        }

        public async Task<Booking> GetBookingDetailsById(int id)
        {
            Booking booking = new Booking();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // string sqlQuery = "SELECT * FROM Countries WHERE Id= " + id;//inline query usage 

                SqlCommand cmd = new SqlCommand("Usp_GetBookingById", con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Booking");
                foreach (DataRow row in ds.Tables["Booking"].Rows)
                {
                    //  Booking objBooking = new Booking();
                    booking.id = Convert.ToInt32(row["id"]);
                    booking.CustomerName = Convert.ToString(row["CustomerName"]);
                    booking.Email = Convert.ToString(row["Email"]);
                    booking.City = Convert.ToString(row["City"]);
                    booking.Country = Convert.ToString(row["Country"]);
                }
            }
            return booking;
        }

        public async Task<bool> UpdateBookingDetils(Booking bookingDetail)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", bookingDetail.id);
                cmd.Parameters.AddWithValue("@CustomerName", bookingDetail.CustomerName);
                cmd.Parameters.AddWithValue("@City", bookingDetail.City);
                cmd.Parameters.AddWithValue("@Country", bookingDetail.Country);
                cmd.Parameters.AddWithValue("@Email", bookingDetail.Email);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Booking");
            }
            return true;
        }
    }
}
