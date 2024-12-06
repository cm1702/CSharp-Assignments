using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ADO_Example
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static IDataReader dr;
        static void Main()
        {
            CreateTable();
            InsertData();
            DeleteData();
            SelectData();
            UpdateData();
            Console.Read();
        }

        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-D244D6D4\\SQLEXPRESS; Initial Catalog=adotest;" +
                "Integrated Security=true;");
            con.Open();
            return con;
        }

        static void CreateTable()
        {
            con = getConnection();
            cmd = new SqlCommand("create table tblemployee(empid int not null , empname varchar(30) , gender varchar(20) , salary int , dept int not null , phone bigint)");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
        }

        static void SelectData()
        {
            con = getConnection();
            cmd = new SqlCommand("select * from tblemployee");
            cmd.Connection = con;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4]);

                //Console.WriteLine("Employee ID :" + dr[0]);
                //Console.WriteLine("Employee Name :" + dr[1]);
                //Console.WriteLine("Employee Salary :" + dr[3]);
            }

        }

        static void InsertData()
        {
            con = getConnection();
            Console.WriteLine("Enter Empid, EmpName, Gender,Salary,Dept,Phone :");
            int eid = Convert.ToInt32(Console.ReadLine());
            string ename = Console.ReadLine();
            string egen = Console.ReadLine();
            float esal = Convert.ToSingle(Console.ReadLine());
            int edept = Convert.ToInt32(Console.ReadLine());
            string ephone = Console.ReadLine();
            //  cmd=new SqlCommand("Insert into tblemployee values(150,'Rama','Male',15000,5,0000007)",con);

            cmd = new SqlCommand("Insert into tblemployee values(@ecode,@empname,@egender@esalary,@edid,@eph)", con);
            //all the above variables are now appended to the parameters collection of the command object
            cmd.Parameters.AddWithValue("@ecode", eid);
            cmd.Parameters.AddWithValue("@empname", ename);
            cmd.Parameters.AddWithValue("@egender", egen);
            cmd.Parameters.AddWithValue("@esalary", esal);
            cmd.Parameters.AddWithValue("@edid", edept);
            cmd.Parameters.AddWithValue("@eph", ephone);

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
                Console.WriteLine("Inserted Successfully");
            else
                Console.WriteLine("Could not Insert..");
        }

        static void UpdateData()
        {
            con = getConnection();
            Console.WriteLine("Enter Empid to update:");
            int eid = Convert.ToInt32(Console.ReadLine());

            cmd = new SqlCommand("SELECT * FROM tblemployee WHERE empid=@eid", con);
            cmd.Parameters.AddWithValue("@eid", eid);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Console.WriteLine("Current Details:");
                Console.WriteLine("Emp ID: " + dr[0]);
                Console.WriteLine("Emp Name: " + dr[1]);
                Console.WriteLine("Emp Gender: " + dr[2]);
                Console.WriteLine("Emp Salary: " + dr[3]);
                Console.WriteLine("Emp Dept: " + dr[4]);
                Console.WriteLine("Emp Phone: " + dr[5]);
            }
            else
            {
                Console.WriteLine("Employee ID not found.");
                return;
            }
            dr.Close(); 

            Console.WriteLine("Enter new EmpName :");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter new Gender :");
            string newGender = Console.ReadLine();
            Console.WriteLine("Enter new Salary :");
            string salaryInput = Console.ReadLine();
            Console.WriteLine("Enter new Dept :");
            string deptInput = Console.ReadLine();
            Console.WriteLine("Enter new Phone :");
            string newPhone = Console.ReadLine();

            StringBuilder updateQuery = new StringBuilder("UPDATE tblemployee SET ");
            List<string> updates = new List<string>();

            if (!string.IsNullOrEmpty(newName))
            {
                updates.Add("empname=@newName");
                cmd.Parameters.AddWithValue("@newName", newName);
            }
            if (!string.IsNullOrEmpty(newGender))
            {
                updates.Add("egender=@newGender");
                cmd.Parameters.AddWithValue("@newGender", newGender);
            }
            if (!string.IsNullOrEmpty(salaryInput))
            {
                updates.Add("esalary=@newSalary");
                cmd.Parameters.AddWithValue("@newSalary", Convert.ToSingle(salaryInput));
            }
            if (!string.IsNullOrEmpty(deptInput))
            {
                updates.Add("edid=@newDept");
                cmd.Parameters.AddWithValue("@newDept", Convert.ToInt32(deptInput));
            }
            if (!string.IsNullOrEmpty(newPhone))
            {
                updates.Add("eph=@newPhone");
                cmd.Parameters.AddWithValue("@newPhone", newPhone);
            }

            updateQuery.Append(String.Join(", ", updates));
            updateQuery.Append(" WHERE empid=@eid");

            cmd = new SqlCommand(updateQuery.ToString(), con);
            cmd.Parameters.AddWithValue("@eid", eid);

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                Console.WriteLine("Updated Successfully");
            }
            else
            {
                Console.WriteLine("Couldn't update the record.");
            }
        }

        static void DeleteData()
        {
            con = getConnection();
            Console.WriteLine("Enter Empid to delete :");
            string eid = Console.ReadLine();
            SqlCommand cmd1 = new SqlCommand("select * from tblemployee where empid=@eid");
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@eid", eid);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                for (int i = 0; i < dr1.FieldCount; i++)
                {
                    Console.WriteLine(dr1[i]);
                }
            }
            con.Close();
            Console.WriteLine();
            Console.WriteLine("Are You sure to delete this Employee ( Y/N )? :");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                cmd = new SqlCommand("delete from tblemployee where empid=@eid", con);
                cmd.Parameters.AddWithValue("@eid", eid);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully..");
            }
        }
    }

}
