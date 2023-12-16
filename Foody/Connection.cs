using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using Foody.Admin;

namespace Foody
{
    public class Connection
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        }
    }
    public class Utils
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter sda;
        public static bool IsValidExtension(string fileName)
        {
            bool isValid = false;
            string[] fileExtension = { ".jpg", ".png", ".jpeg" };
            for (int i = 0; i < fileExtension.Length; i++)
            {
                if (fileName.Contains(fileExtension[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        //setting default image if their is no image for any job
        public static string GetImageUrl(object url) {
            string url1 = "";
            if (string.IsNullOrEmpty(url.ToString())|| url == DBNull.Value)
            {
                url1 = "../Images/No_image.png";
            }
            else
            {
                url1 = string.Format("../{0}", url);
            }
            return url1;
        }

        //Check if the item had been updated
        public bool updateCartQuantity(int quantity, int productId, int userId)
        {
            bool isUpdateCart = false;

            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Cart_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "UPDATE");
            cmd.Parameters.AddWithValue("@ProductId ", productId);
            cmd.Parameters.AddWithValue("@Quantity ", quantity);
            cmd.Parameters.AddWithValue("@UserId ", userId);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                isUpdateCart = true;
            }
            catch (Exception ex)
            {
                isUpdateCart = false;
                HttpContext.Current.Response.Write("<script>alert('Error - " + ex.Message + " ');</script>");
            }
            finally { 
                con.Close(); 
            }

            return isUpdateCart;
        }


        // Count the number of item in cart
        public int cartCount(int userId)
        {
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("Cart_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.Parameters.AddWithValue("@UserId ", userId);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt.Rows.Count;
        }

        //Create a random unique alphabet number string
        public static string getUniqueId()
        {
            Guid guid = Guid.NewGuid();
            string uniqueId = guid.ToString();
            return uniqueId;
        }
    }

    public class DashBoardCount
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;

        public int Count(string Action)
        {
            int count = 0;
            con = new SqlConnection(Connection.GetConnectionString());
            cmd = new SqlCommand("DashBoard", con);
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr[0] == DBNull.Value)
                {
                    count = 0;
                }
                else
                {
                    count = Convert.ToInt32(sdr[0]);
                }
            }
            sdr.Close();
            con.Close();
            return count;
        }
    }


}