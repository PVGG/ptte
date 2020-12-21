using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Customer_Mst
    {
        public int index_id { get; set; }

        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string customer_contact_no { get; set; }
        public string customer_pincode { get; set; }
        public int customer_country_id { get; set; }
        public int customer_state_id { get; set; }
        public int customer_city_id { get; set; }
        public int customer_zone_id { get; set; }
        public int customer_area_id { get; set; }
        public string customer_email { get; set; }
        public string customer_contact_person { get; set; }
        public string customer_registration_no { get; set; }
        public string customer_gstin { get; set; }
        public string customer_logo { get; set; }
        public int customer_bank_id { get; set; }
        public int customer_bank_branch_id { get; set; }
        public string customer_branch_ifsc { get; set; }
        public string customer_account_no { get; set; }
        public string customer_first_subscription_date { get; set; }
        public int parent_id { get; set; }
      
        public int user_id { get; set; }


        /*string customer_name,
        string customer_address,
        string customer_contact_no,
        string customer_pincode,
        int customer_country_id,
        int customer_state_id,
        int customer_city_id,
        int customer_zone_id,
        int customer_area_id,
        string customer_email,
        string customer_contact_person,
        string customer_registration_no,
        string customer_gstin,
        string customer_logo,
        int customer_bank_id,
        int customer_bank_branch_id,
        string customer_branch_ifsc,
        string customer_account_no,
        string customer_first_subscription_date,
        int parent_id,
         int user_id*/




        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Customer
        public string GetAllCustomer()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageModules", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "SelectAll");
                com.Parameters.AddWithValue("@is_deleted", false);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                {
                    return "Get Data Successfully";
                }
                else
                {
                    return "Get Data Not Successfully";
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Get Customer from Index ID
        public string GetCustomer(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageModules", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Select");
                com.Parameters.AddWithValue("@index_id", user_id);
                com.Parameters.AddWithValue("@is_deleted", false);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                {
                    return "Get Data Successfully";
                }
                else
                {
                    return "Get Data Not Successfully";
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Insert Customer
        public string AddCustomer(string customer_name,
        string customer_address,
        string customer_contact_no,
        string customer_pincode,
        int customer_country_id,
        int customer_state_id,
        int customer_city_id,
        int customer_zone_id,
        int customer_area_id,
        string customer_email,
        string customer_contact_person,
        string customer_registration_no,
        string customer_gstin,
        string customer_logo,
        int customer_bank_id,
        int customer_bank_branch_id,
        string customer_branch_ifsc,
        string customer_account_no,
        string customer_first_subscription_date,
        int parent_id,
         int user_id)
        {
            connection();
            com = new SqlCommand("prManageModules", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@module_name", area_name);
            com.Parameters.AddWithValue("@created_by", created_by_id);
            com.Parameters.AddWithValue("@is_deleted", false);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return "Data Added Successfully";
            }
            else
            {
                return "Data Not Added";
            }
        }
        #endregion
        #region Update Customer
        public string EditCustomer(int index_id, string customer_name,
        string customer_address,
        string customer_contact_no,
        string customer_pincode,
        int customer_country_id,
        int customer_state_id,
        int customer_city_id,
        int customer_zone_id,
        int customer_area_id,
        string customer_email,
        string customer_contact_person,
        string customer_registration_no,
        string customer_gstin,
        string customer_logo,
        int customer_bank_id,
        int customer_bank_branch_id,
        string customer_branch_ifsc,
        string customer_account_no,
        string customer_first_subscription_date,
        int parent_id,
         int user_id)
        {
            connection();
            com = new SqlCommand("prManageModules", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@module_name", area_name);
            com.Parameters.AddWithValue("@updated_date", DateTime.Now.ToShortDateString());
            com.Parameters.AddWithValue("@updated_by", "UserId");
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "Data Updated Successfully";
            }
            else
            {
                return "Data Not Updated";
            }
        }
        #endregion
        #region Delete Customer
        public string DeleteCustomer(int index_id)
        {
            connection();
            com = new SqlCommand("prManageModules", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Delete");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@is_deleted", true);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return "Data Deleted Successfully";
            }
            else
            {
                return "Data Not Deleted";
            }
        }
        #endregion
    }
}