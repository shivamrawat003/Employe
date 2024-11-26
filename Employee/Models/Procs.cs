using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class Procs
    {
        public static string GetConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Contxt"].ConnectionString;
            }
        }
        public static DataTable GetEmployeeDetails(int? Id)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from Show_Employee where Id=@Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception ex) { }
            return dt;

        }
        public static DataTable GetEmployeeDetail(int? Id)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from EmployeeData where Id=@Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception ex) { }
            return dt;

        }
        public static DataTable GetEmployees()
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from Show_Employee", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public static string UpdateEmployeeData(int Id,string FName, string LName, string Email, string ContactNum, int? Salary, int? Department, string Address, int? State, int? Country, string Password)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("update EmployeeData set First_Name=@fname,Last_Name=@lname,Email=@email,Contact_Num=@contactnum,Salary=@salary,Department=@department,Address=@address,State=@state,Country=@country,Password=@password where Id=@id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.Parameters.AddWithValue("@fname", FName);
            cmd.Parameters.AddWithValue("@lname", LName);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@contactnum", ContactNum);
            cmd.Parameters.AddWithValue("@salary", Salary);
            cmd.Parameters.AddWithValue("@department", Department);
            cmd.Parameters.AddWithValue("@address", Address);
            cmd.Parameters.AddWithValue("@state", State);
            cmd.Parameters.AddWithValue("@country", Country);
            cmd.Parameters.AddWithValue("@password", Password);
            string res = "1";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = "0";
            }
            finally
            {
                con.Close();
            }
            return res;
        }
        public static string Delete_Employee(int? Id)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Delete from EmployeeData where Id=@id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", Id);
            string res = "1";
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = "0";
               
            }
            finally
            {
                con.Close();
            }
            return res;
        }
        public static string SaveEmployeeData(string FName, string LName, string Email, string ContactNum, int? Salary, int? Department, string Address, int? State, int? Country, string Password)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("insert into EmployeeData values (@fname,@lname,@email,@contactnum,@salary,@department,@address,@state,@country,@password)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@fname", FName); 
            cmd.Parameters.AddWithValue("@lname", LName);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@contactnum", ContactNum);
            cmd.Parameters.AddWithValue("@salary", Salary);
            cmd.Parameters.AddWithValue("@department", Department);
            cmd.Parameters.AddWithValue("@address", Address); 
            cmd.Parameters.AddWithValue("@state", State); 
            cmd.Parameters.AddWithValue("@country", Country);
            cmd.Parameters.AddWithValue("@password", Password);
            string res = "1";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = "0";
            }
            finally
            {
                con.Close();
            }
            return res;
        }
        public static DataTable Dept_Select()
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from DepartmentData order by Dept_Name asc", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;
        }
        public static DataTable Country_Select()
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from CountryData order by Country_Name asc", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            } 
            catch (Exception) { }
            return dt;
        }
        public static DataTable State_Select(int? Id)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from StateData where Country_Id=@Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception ex) { }
            return dt;
        }
        public static DataSet EmpSearch(int? Rows, int? Offset, string Val = null)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("EmpSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Rows", Rows);
            cmd.Parameters.AddWithValue("Offset", Offset);
            cmd.Parameters.AddWithValue("Val", Val);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataSet dt = new DataSet();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception) { }
            return dt;
        }
        public static DataTable StudentsList()
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable ds = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(ds);
            }
            catch (Exception) { }
            return ds;
        }
        public static int SaveStudent( int? Id, string Name, string Course, double? Fees)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("SaveStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("Course", Course);
            cmd.Parameters.AddWithValue("Fees", Fees);
            int res = 0;
            try
            {
                con.Open();
                var r = cmd.ExecuteScalar();
                if (r != null)
                    res = int.Parse(r.ToString());
            }
            catch (Exception) { }
            finally { con.Close(); }
            return res;
        }
        public static string SaveSubject(int? Id, int? StudId, string Subject, int? Semester)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("SaveSubject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Id", Id);
            cmd.Parameters.AddWithValue("StudId", StudId);
            cmd.Parameters.AddWithValue("Sub_Name", Subject);
            cmd.Parameters.AddWithValue("Sem", Semester);
            string res = "1";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                res = "0";
            }
            finally { con.Close(); }
            return res;
        }
        public static DataSet StudentDetails(int? Id)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("select * from student WHERE Id=@ID; SELECT * FROM subject WHERE StudentId=@ID", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("ID", Id);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(ds);
            }
            catch (Exception) { }
            return ds;
        }
        public static string DeleteSubs(string Ids)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("DELETE FROM Subject WHERE Id IN(@ids)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("ids", Ids);
            string res = "0";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                res = "1";
            }
            catch (Exception) { }
            finally { con.Close(); }
            return res;
        }
        public static string Delete_Student(int? Id)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("DELETE FROM Subject WHERE StudentId = @Id; Delete from Student where Id = @Id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            string res = "1";
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = "0";

            }
            finally
            {
                con.Close();
            }
            return res;
        }
        public static DataTable AutoSuggest(string Search)
        {
            SqlConnection con = new SqlConnection(GetConnection);
            SqlCommand cmd = new SqlCommand("Select distinct (First_name) from employeedata where First_name like '%' + @Data +'%' order by First_name offset 0 rows fetch next 10 rows only", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("Data", Search);
            SqlDataAdapter sd = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                sd.SelectCommand = cmd;
                sd.Fill(dt);
            }
            catch (Exception ex) { }
            return dt;
        }
    
    }
}