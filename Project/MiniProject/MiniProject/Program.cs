using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MiniProject
{
    class Program
    {
        private static readonly string connectionString = "Server=ICS-LT-D244D6D4\\SQLEXPRESS;Database=RailRes_A;Integrated Security=true;";

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("***------------------------------------------------------------------------------------***\n");
                    Console.WriteLine("----****-----****-----ICS Railway Reservation System (mini project)-----****-----****-----\n");
                    Console.WriteLine("***------------------------------------------------------------------------------------***\n");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    Console.WriteLine("3. Exit");
                    Console.Write("Select your role: ");

                    if (int.TryParse(Console.ReadLine(), out int role))
                    {
                        switch (role)
                        {
                            case 1:
                                AdminMenu();
                                break;
                            case 2:
                                UserMenu();
                                break;
                            case 3:
                                Console.WriteLine("Have a safe journey!");
                                return;
                            default:
                                Console.WriteLine("Invalid choice!");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

        }

        static void AdminMenu()
        {
            try
            {
                Console.Write("Enter Admin Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Admin Password: ");
                string password = Console.ReadLine();

                if (Authenticate("Admins", username, password))
                {
                    while (true)
                    {
                        Console.WriteLine("\n--- Admin Menu ");
                        Console.WriteLine("1. Add Train");
                        Console.WriteLine("2. View All Trains");
                        Console.WriteLine("3. Delete Train");
                        Console.WriteLine("4. Update Train");
                        Console.WriteLine("5. Logout");
                        Console.Write("Select your choice: ");

                        if (int.TryParse(Console.ReadLine(), out int choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    AddTrain();
                                    break;
                                case 2:
                                    ViewAllTrains();
                                    break;
                                case 3:
                                    DeleteTrain();
                                    break;
                                case 4:
                                    UpdateTrain();
                                    break;
                                case 5:
                                    return;
                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unauthorised access!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UserMenu()
        {
            try
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                int userId = GetUserId(username, password);
                if (userId > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\n--- User Menu ");
                        Console.WriteLine("1. View Trains");
                        Console.WriteLine("2. Book Ticket");
                        Console.WriteLine("3. View My Bookings");
                        Console.WriteLine("4. Logout");
                        Console.Write("Select your choice: ");

                        if (int.TryParse(Console.ReadLine(), out int choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    ViewAllTrains();
                                    break;
                                case 2:
                                    BookTicket(userId);
                                    break;
                                case 3:
                                    ViewMyBookings(userId);
                                    break;
                                case 4:
                                    return;
                                default:
                                    Console.WriteLine("Invalid choice!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unauthorised access!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static bool Authenticate(string table, string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = $"SELECT COUNT(*) FROM {table} WHERE Username = @Username AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Authentication Error: {ex.Message}");
                return false;
            }
        }

        static int GetUserId(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUserId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching User ID: {ex.Message}");
                return 0;
            }
        }

        static void AddTrain()
        {
            try
            {
                Console.Write("Enter Train Name: ");
                string trainName = Console.ReadLine();
                Console.Write("Enter Source: ");
                string source = Console.ReadLine();
                Console.Write("Enter Destination: ");
                string destination = Console.ReadLine();
                Console.Write("Enter Total Seats: ");
                int totalSeats = int.Parse(Console.ReadLine());
                Console.Write("Enter Date of Journey (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();

                if (!DateTime.TryParse(dateInput, out DateTime dateOfJourney))
                {
                    Console.WriteLine("Invalid date format! Please enter a date in the format yyyy-mm-dd.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AddTrain", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TrainName", trainName);
                    cmd.Parameters.AddWithValue("@Source", source);
                    cmd.Parameters.AddWithValue("@Destination", destination);
                    cmd.Parameters.AddWithValue("@TotalSeats", totalSeats);
                    cmd.Parameters.AddWithValue("@DateOfJourney", dateOfJourney);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Train has been added successfully!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewAllTrains()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllTrains", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    DataTable trainsTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(trainsTable);

                    var trains = trainsTable.AsEnumerable()
                        .Select(row => new
                        {
                            TrainId = row["TrainId"],
                            TrainName = row["TrainName"],
                            Source = row["Source"],
                            Destination = row["Destination"],
                            AvailableSeats = row["AvailableSeats"],
                            DateOfJourney = row["DateOfJourney"]
                        });

                    Console.WriteLine("\nTrainId | TrainName | Source | Destination | AvailableSeats | DateOfJourney");
                    foreach (var train in trains)
                    {
                        Console.WriteLine($"{train.TrainId} | {train.TrainName} | {train.Source} | {train.Destination} | {train.AvailableSeats} | {train.DateOfJourney}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void BookTicket(int userId)
        {
            try
            {
                Console.Write("Enter TrainId: ");
                int trainId = int.Parse(Console.ReadLine());
                Console.Write("Enter Passenger Name: ");
                string passengerName = Console.ReadLine();
                Console.Write("Enter Seat Number: ");
                int seatNumber = int.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("BookTicket", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TrainId", trainId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@PassengerName", passengerName);
                    cmd.Parameters.AddWithValue("@SeatNumber", seatNumber);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Ticket booked successfully!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteTrain()
        {
            try
            {
                Console.Write("Enter Train ID to delete: ");
                if (int.TryParse(Console.ReadLine(), out int trainId))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("DeleteTrain", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TrainId", trainId);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Train with ID {trainId} deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Train with ID {trainId} not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Train ID! Please enter a number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void UpdateTrain()
        {
            try
            {
                Console.Write("Enter Train ID to update: ");
                if (int.TryParse(Console.ReadLine(), out int trainId))
                {
                    Console.Write("Enter new Train Name (or press Enter to skip): ");
                    string trainName = Console.ReadLine();
                    Console.Write("Enter new Source (or press Enter to skip): ");
                    string source = Console.ReadLine();
                    Console.Write("Enter new Destination (or press Enter to skip): ");
                    string destination = Console.ReadLine();
                    Console.Write("Enter new Total Seats (or press Enter to skip): ");
                    string totalSeatsInput = Console.ReadLine();
                    int? totalSeats = string.IsNullOrWhiteSpace(totalSeatsInput) ? (int?)null : int.Parse(totalSeatsInput);
                    Console.Write("Enter new Date of Journey (yyyy-mm-dd) (or press Enter to skip): ");
                    string dateInput = Console.ReadLine();
                    DateTime? dateOfJourney = string.IsNullOrWhiteSpace(dateInput) ? (DateTime?)null : DateTime.Parse(dateInput);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("UpdateTrain", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TrainId", trainId);
                        cmd.Parameters.AddWithValue("@TrainName", string.IsNullOrWhiteSpace(trainName) ? DBNull.Value : (object)trainName);
                        cmd.Parameters.AddWithValue("@Source", string.IsNullOrWhiteSpace(source) ? DBNull.Value : (object)source);
                        cmd.Parameters.AddWithValue("@Destination", string.IsNullOrWhiteSpace(destination) ? DBNull.Value : (object)destination);
                        cmd.Parameters.AddWithValue("@TotalSeats", totalSeats.HasValue ? (object)totalSeats.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfJourney", dateOfJourney.HasValue ? (object)dateOfJourney.Value : DBNull.Value);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Train with ID {trainId} updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine($"Train with ID {trainId} not found.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Train ID! Please enter a number.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter the correct format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewMyBookings(int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUserBookings", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nBookingId || TrainName || PassengerName || SeatNumber || DateOfJourney");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["BookingId"]} || {reader["TrainName"]} || {reader["PassengerName"]} || {reader["SeatNumber"]} || {reader["DateOfJourney"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}