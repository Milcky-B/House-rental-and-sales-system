using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseRentalAndSales
{
    class DAL
    {
        private SqlConnection con;
        string constr = "server=LAPTOP-AJ9AN0AD; Database=HRAS_DB; integrated security=true;";
        public DAL()
        {
            con = new SqlConnection(constr);
        }
        public string sendRole(int id, string pass)
        {
            string Role = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT dbo.sendRole(@id,@pass)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pass", pass);
            try
            {
                Role = (string)cmd.ExecuteScalar();
            }
            catch (InvalidCastException)
            {
                con.Close();
            }
            con.Close();
            return Role;
        }
        public string sendFullName(int id, string password)
        {
            string FullName;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT dbo.sendFullName(@id,@pass)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pass", password);
            FullName = (string)cmd.ExecuteScalar();
            con.Close();
            return FullName;
        }
        public DataTable getCustomer(int id,string spName)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(spName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            da.Fill(ds, "Info");
            DataTable dt = ds.Tables[0];
            con.Close();
            return dt;
        }
        public void updateCust(string fname,string lname,string phone,int id,string spName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fn",fname);
            cmd.Parameters.AddWithValue("@ln", lname);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ph", phone);
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                MessageBox.Show("Update Successful");
            }
            else
            {
                con.Close();
                throw new Error("No Info By that Id to Update");
            }
            con.Close();
        }
        public string insertCust(string fname, string lname, string phone,string spName)
        {
            string newId;
            con.Open();
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fn", fname);
            cmd.Parameters.AddWithValue("@ln", lname);
            cmd.Parameters.AddWithValue("@ph", phone);

            SqlParameter sqp = new SqlParameter();
            sqp.ParameterName = "@id";
            sqp.SqlDbType = SqlDbType.Int;
            sqp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sqp);
            int rowAffected = cmd.ExecuteNonQuery();
            newId = sqp.Value.ToString();
            if (rowAffected > 0)
            {
                MessageBox.Show("Insert Successful");
            }
            else
            {
                con.Close();
                throw new Error("Couldn't Insert Please Try Again");
            }
            con.Close();
            return newId;
        }
        public DataTable getProperty(string spName,int id)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(spName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            da.Fill(ds, "Info");
            DataTable dt = ds.Tables[0];
            con.Close();
            return dt;
        }
        public void updateProperty(string Address, string Type, string status, string sale, int price, int rooms, int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("updateProperty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Adress", Address);
            cmd.Parameters.AddWithValue("@SaleType", sale);
            cmd.Parameters.AddWithValue("HouseType", Type);
            cmd.Parameters.AddWithValue("@stat", status);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@rooms", rooms);
            cmd.Parameters.AddWithValue("@id", id);
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                MessageBox.Show("Update Successful");
            }
            else
            {
                con.Close();
                throw new Error("No Info By that Id to Update");
            }
            con.Close();
        }
        public void enterPicture(int id,byte[] pic)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("enterImage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pic", pic);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Picture Entered");
                }
                con.Close();
            }
            catch (SqlException)
            {
                con.Close();
                throw new Error("Cant Add A picture For this ID");
            }
        }
        public DataTable searchProperty(int v1, int v2, int v3, int v4, string txt2, string txt3)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("searchProperty", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@minRoom", v1);
            da.SelectCommand.Parameters.AddWithValue("@maxRoom", v2);
            da.SelectCommand.Parameters.AddWithValue("@minPrice", v3);
            da.SelectCommand.Parameters.AddWithValue("@maxPrice", v4);
            da.SelectCommand.Parameters.AddWithValue("@saleType", txt3);
            da.SelectCommand.Parameters.AddWithValue("@houseType", txt2);
            DataSet ds = new DataSet();
            da.Fill(ds, "Properties");
            DataTable dt = ds.Tables["Properties"];
            con.Close();
            return dt;
        }
        public DataTable searchImage(int id)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sendImage", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            da.Fill(ds, "Images");
            DataTable dt = ds.Tables["Images"];
            con.Close();
            return dt;
        }
        public DataTable getID(string spName)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(spName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "Info");
            DataTable dt = ds.Tables["Info"];
            con.Close();
            return dt;
        }
        public void insertAudit(int custId,int ownID,int propID,int empID,string type)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insertAudit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", custId);
                cmd.Parameters.AddWithValue("@ownID", ownID);
                cmd.Parameters.AddWithValue("@propID", propID);
                cmd.Parameters.AddWithValue("@empID", empID);
                cmd.Parameters.AddWithValue("@saleType", type);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Successfully Sold");
                }
                con.Close();
            }
            catch (SqlException)
            {
                con.Close();
                throw new Error("Please Check The Property ID Matches With Owner ID");
            }
        }
        public string insertEmployee(string fname,string lname,string pass,string role)
        {
            string newId;
            con.Open();
            try
            { 
                SqlCommand cmd = new SqlCommand("AddEmp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@role", role);

                SqlParameter sqp = new SqlParameter();
                sqp.ParameterName = "@id";
                sqp.SqlDbType = SqlDbType.Int;
                sqp.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(sqp);
                int rowAffected = cmd.ExecuteNonQuery();
                newId = sqp.Value.ToString();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Employee Added");
                }
            }
            catch (SqlException)
            {
                newId = "";
                con.Close();
                throw new Error("Please Check Password Length");
            }
            con.Close();
            return newId;
        }
        public void updateEmployee(string fname, string lname, string pass, string role,int id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateEmp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@id", id);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Employee Information Updated");
                }
                else
                {
                    con.Close();
                    throw new Error("Couldn't Update Please Check ID");
                }
            }
            catch(SqlException)
            {
                con.Close();
                throw new Error("Please check Password Lenth");
            }
            con.Close();
        }
        public void deleteEmp(int id,string spName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                MessageBox.Show("Deleted"); 
            }
            else
            {
                con.Close();
                throw new Error("Couldn't Delete Please Check ID");
            }
            con.Close();
        }
        public string countAllCustomers()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.countAllCustomers()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
        public string countAllOwners()
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.countAllOwners()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
        public string countAllProperties()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.countAllProperties()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
        public string countAvailableProperties()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.countAvailableProperties()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
        public string countSoldProperties()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.countSoldProperties()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
        public string countRentedProperties()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.countRentedProperties()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
        public string calculateRevenue()
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("select dbo.calculateRevenue()", con);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            string d = dr.GetInt32(0).ToString();
            con.Close();
            return d;

        }
       
        public void backUpDatabase()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("backUpDatabase", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Goodbye");
            con.Close();
        }

    }
}

