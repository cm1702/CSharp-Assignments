using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RRS
{
    class Program
    {
        private static readonly string connect = "Server=ICS-LT-D244D6D4\\SQLEXPRESS;Database=RRS;Integrated Security=true;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Railway Train Reservation System");
                Console.WriteLine("1. Search for the train");
                Console.WriteLine("2. Book the ticket for the train");
                Console.WriteLine("3. Cancel the booked ticket");
                Console.WriteLine("4. View all the available trains");
                Console.WriteLine("5. View the bookings by the Train");
                Console.WriteLine("6. View the booking information");
                Console.WriteLine("7. Add the new trains");
                Console.WriteLine("8. Updation of details");
                Console.WriteLine("9. Exit");
                Console.Write("\n--Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SearchTrains();
                        break;
                    case 2:
                        BookTicket();
                        break;
                    case 3:
                        CancelTicket();
                        break;
                    case 4:
                        ViewAllTrains();
                        break;
                    case 5:
                        ViewBookingsByTrain();
                        break;
                    case 6:
                        ViewBookingDetails();
                        break;
                    case 7:
                        AddNewTrain();
                        break;
                    case 8:
                        UpdateTrainDetails();
                        break;
                    case 9:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
                Console.Read();
            }
        }

        static void SearchTrains()
        {
            Console.Write("Enter Source: ");
            string source = Console.ReadLine();
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            List<Train> trains = GetTrains();

            var filteredTrains = trains.Where(t => t.Source == source && t.Destination == destination).ToList();

            Console.WriteLine("\n Available Trains");
            foreach (var train in filteredTrains)
            {
                Console.WriteLine($"TrainId: {train.TrainId}, Name: {train.TrainName}, AvailableSeats: {train.AvailableSeats}");
            }
        }

        static void BookTicket()
        {
            Console.Write("Enter TrainId: ");
            int trainId = int.Parse(Console.ReadLine());
            Console.Write("Enter Passenger Name: ");
            string passengerName = Console.ReadLine();

            Train train = GetTrainById(trainId);
            if (train != null && train.AvailableSeats > 0)
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();

                    string updateSeatsQuery = "UPDATE Trains SET AvailableSeats = AvailableSeats - 1 WHERE TrainId = @TrainId";
                    using (SqlCommand updateCmd = new SqlCommand(updateSeatsQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@TrainId", trainId);
                        updateCmd.ExecuteNonQuery();
                    }

                    string insertBookingQuery = "INSERT INTO Bookings (TrainId, PassengerName, SeatNumber, BookingDate) VALUES (@TrainId, @PassengerName, @SeatNumber, @BookingDate)";
                    using (SqlCommand insertCmd = new SqlCommand(insertBookingQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@TrainId", trainId);
                        insertCmd.Parameters.AddWithValue("@PassengerName", passengerName);
                        insertCmd.Parameters.AddWithValue("@SeatNumber", train.TotalSeats - train.AvailableSeats + 1);
                        insertCmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Ticket Booked Successfully!");
            }
            else
            {
                Console.WriteLine("No empty seats!");
            }
        }

        static void CancelTicket()
        {
            Console.Write("Enter BookingId: ");
            int bookingId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                string getTrainIdQuery = "SELECT TrainId FROM Bookings WHERE BookingId = @BookingId";
                int trainId = 0;
                using (SqlCommand getTrainIdCmd = new SqlCommand(getTrainIdQuery, conn))
                {
                    getTrainIdCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    object result = getTrainIdCmd.ExecuteScalar();
                    if (result != null)
                        trainId = (int)result;
                }

                if (trainId == 0)
                {
                    Console.WriteLine("Invalid BookingId!");
                    return;
                }

                string deleteBookingQuery = "DELETE FROM Bookings WHERE BookingId = @BookingId";
                using (SqlCommand deleteCmd = new SqlCommand(deleteBookingQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@BookingId", bookingId);
                    deleteCmd.ExecuteNonQuery();
                }

                string updateSeatsQuery = "UPDATE Trains SET AvailableSeats = AvailableSeats + 1 WHERE TrainId = @TrainId";
                using (SqlCommand updateCmd = new SqlCommand(updateSeatsQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@TrainId", trainId);
                    updateCmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Ticket Cancelled Successfully!");
        }

        static void ViewAllTrains()
        {
            List<Train> trains = GetTrains();

            Console.WriteLine("\n--- All Trains ---");
            foreach (var train in trains)
            {
                Console.WriteLine($"TrainId: {train.TrainId}, Name: {train.TrainName}, Source: {train.Source}, Destination: {train.Destination}, AvailableSeats: {train.AvailableSeats}");
            }
        }

        static void ViewBookingsByTrain()
        {
            Console.Write("Enter TrainId: ");
            int trainId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "SELECT * FROM Bookings WHERE TrainId = @TrainId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- Bookings for TrainId {0} ---", trainId);
                while (reader.Read())
                {
                    Console.WriteLine($"BookingId: {reader["BookingId"]}, Passenger: {reader["PassengerName"]}, Seat: {reader["SeatNumber"]}, Date: {reader["BookingDate"]}");
                }
            }
        }

        static void ViewBookingDetails()
        {
            Console.Write("Enter BookingId: ");
            int bookingId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "SELECT * FROM Bookings WHERE BookingId = @BookingId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingId", bookingId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Console.WriteLine($"BookingId: {reader["BookingId"]}, TrainId: {reader["TrainId"]}, Passenger: {reader["PassengerName"]}, Seat: {reader["SeatNumber"]}, Date: {reader["BookingDate"]}");
                }
                else
                {
                    Console.WriteLine("No Booking found with this BookingId!");
                }
            }
        }

        static void AddNewTrain()
        {
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter Source: ");
            string source = Console.ReadLine();
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();
            Console.Write("Enter Total Seats: ");
            int totalSeats = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "INSERT INTO Trains (TrainName, Source, Destination, TotalSeats, AvailableSeats, Date) VALUES (@TrainName, @Source, @Destination, @TotalSeats, @AvailableSeats, @Date)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@TotalSeats", totalSeats);
                cmd.Parameters.AddWithValue("@AvailableSeats", totalSeats);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Train Added Successfully!");
        }

        static void UpdateTrainDetails()
        {
            Console.Write("Enter TrainId to Update: ");
            int trainId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter New Source: ");
            string source = Console.ReadLine();
            Console.Write("Enter New Destination: ");
            string destination = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "UPDATE Trains SET TrainName = @TrainName, Source = @Source, Destination = @Destination WHERE TrainId = @TrainId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Train Details Updated Successfully!");
        }

        static List<Train> GetTrains()
        {
            List<Train> trains = new List<Train>();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "SELECT * FROM Trains";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trains.Add(new Train
                    {
                        TrainId = (int)reader["TrainId"],
                        TrainName = reader["TrainName"].ToString(),
                        Source = reader["Source"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        TotalSeats = (int)reader["TotalSeats"],
                        AvailableSeats = (int)reader["AvailableSeats"],
                        Date = Convert.ToDateTime(reader["Date"])
                    });
                }
            }
            return trains;
        }

        static Train GetTrainById(int trainId)
        {
            Train train = null;
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "SELECT * FROM Trains WHERE TrainId = @TrainId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainId", trainId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    train = new Train
                    {
                        TrainId = (int)reader["TrainId"],
                        TrainName = reader["TrainName"].ToString(),
                        Source = reader["Source"].ToString(),
                        Destination = reader["Destination"].ToString(),
                        TotalSeats = (int)reader["TotalSeats"],
                        AvailableSeats = (int)reader["AvailableSeats"],
                        Date = Convert.ToDateTime(reader["Date"])
                    };
                }
            }
            return train;
        }
    }

    public class Train
    {
        public int TrainId { get; set; }
        public string TrainName { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime Date { get; set; }
    }

}
