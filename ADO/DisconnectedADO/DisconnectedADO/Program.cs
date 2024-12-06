using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DisconnectedADO
{
    class Program
    {
        public static SqlConnection con = null;
        public static SqlDataAdapter da = null;
        static void Main(string[] args)
        {
            Disconnected_approach();
            AddRegion_with_Adapter();
            Console.Read();
        }

        public static void Disconnected_approach()
        {
            con = new SqlConnection("Data Source = ICS-LT-D244D6D4\\SQLEXPRESS; database = northwind; trusted_connection = true");
            con.Open();
            da = new SqlDataAdapter("select * from region", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Nortwindregion");
            DataTable dt = ds.Tables["NorthwindRegion"];

            //to access rows and columns from data table
            foreach(DataRow drow in dt.Rows)
            {
                foreach (DataColumn dcol in dt.Columns)
                {
                    Console.Write(drow[dcol]);
                    Console.WriteLine(" ");
                }
            }

            //adding one maore table to the dataset
            Console.WriteLine("****************************************");
            da = new SqlDataAdapter("select * from shippers", con);
            da.Fill(ds , "NorthwindShippers");
            dt = ds.Tables["NorthwindShippers"];

            foreach (DataRow drow in dt.Rows)
            {
                foreach (DataColumn dcol in dt.Columns)
                {
                    Console.Write(drow[dcol]);
                    Console.WriteLine(" ");
                }
            }
            da = new SqlDataAdapter("[ten most expensive products]", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds, "ExpensiveProducts");
            dt = ds.Tables["ExpensiveProducts"];

            Console.WriteLine("****************************************");

            foreach (DataRow drow in dt.Rows)
            {
                foreach (DataColumn dcol in dt.Columns)
                {
                    Console.Write(drow[dcol]);
                    Console.WriteLine(" ");
                }
            }

        }

        public static void AddRegion_with_Adapter()
        {
            try
            {
                con = new SqlConnection("Data Source = ICS-LT-D244D6D4\\SQLEXPRESS; database = northwind; trusted_connection = true");
                con.Open();
                da = new SqlDataAdapter("select * from region", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "NRegion");

                DataTable dt = ds.Tables["NRegion"];


                //add one row more 
                DataRow row = ds.Tables["NRegion"].NewRow();

                //give values to columns in the new row
                row["RegionId"] = 200;
                row["RegionDescription"] = "Cyclone Region";

                //add new row with data to rows collection of datatable
                ds.Tables["NRegion"].Rows.Add(row);

                SqlCommandBuilder scb = new SqlCommandBuilder();
                da.InsertCommand = scb.GetInsertCommand();
                da.Update(ds, "NRegion");

                Console.WriteLine("----post insertion----");
                da.Fill(ds);  //to refresh the dataset after changes made
            }
            catch(SqlException e)
            {

            }
        }
    }
}
