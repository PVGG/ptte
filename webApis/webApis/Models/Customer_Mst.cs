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
                com = new SqlCommand("prManageCustomer_mst", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "SelectAll");
                com.Parameters.AddWithValue("@is_deleted", false);
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                CommonFunction obj = new CommonFunction();
                string json_data = obj.DataTableToJSONWithStringBuilder(dt);
                con.Close();
                return json_data;
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
                com = new SqlCommand("prManageCustomer_mst", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Select");
                com.Parameters.AddWithValue("@index_id", id);
                com.Parameters.AddWithValue("@is_deleted", false);
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                CommonFunction obj = new CommonFunction();
                string json_data = obj.DataTableToJSONWithStringBuilder(dt);
                con.Close();
                return json_data;
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
                com = new SqlCommand("prManageCustomer_mst", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Insert");
                com.Parameters.AddWithValue("@customer_name", customer_name);

                com.Parameters.AddWithValue("@customer_address", customer_address);
                com.Parameters.AddWithValue("@customer_contact_no", customer_contact_no);
                com.Parameters.AddWithValue("@customer_pincode", customer_pincode);
                com.Parameters.AddWithValue("@customer_country_id", customer_country_id);

                com.Parameters.AddWithValue("@customer_state_id", customer_state_id);
                com.Parameters.AddWithValue("@customer_city_id", customer_city_id);
                com.Parameters.AddWithValue("@customer_zone_id", customer_zone_id);
                com.Parameters.AddWithValue("@customer_area_id", customer_area_id);
                com.Parameters.AddWithValue("@customer_email", customer_email);

                com.Parameters.AddWithValue("@customer_contact_person", customer_contact_person);
                com.Parameters.AddWithValue("@customer_registration_no", customer_registration_no);
                com.Parameters.AddWithValue("@customer_logo", customer_logo);
                com.Parameters.AddWithValue("@customer_bank_id", customer_bank_id);
                com.Parameters.AddWithValue("@customer_bank_branch_id", customer_bank_branch_id);

                com.Parameters.AddWithValue("@customer_branch_ifsc", customer_branch_ifsc);
                com.Parameters.AddWithValue("@customer_account_no", customer_account_no);
                com.Parameters.AddWithValue("@customer_first_subscription_date", customer_first_subscription_date);
                com.Parameters.AddWithValue("@parent_id", parent_id);

                com.Parameters.AddWithValue("@created_by", user_id);
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
            com = new SqlCommand("prManageCustomer_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);

            com.Parameters.AddWithValue("@customer_name", customer_name);

            com.Parameters.AddWithValue("@customer_address", customer_address);
            com.Parameters.AddWithValue("@customer_contact_no", customer_contact_no);
            com.Parameters.AddWithValue("@customer_pincode", customer_pincode);
            com.Parameters.AddWithValue("@customer_country_id", customer_country_id);

            com.Parameters.AddWithValue("@customer_state_id", customer_state_id);
            com.Parameters.AddWithValue("@customer_city_id", customer_city_id);
            com.Parameters.AddWithValue("@customer_zone_id", customer_zone_id);
            com.Parameters.AddWithValue("@customer_area_id", customer_area_id);
            com.Parameters.AddWithValue("@customer_email", customer_email);

            com.Parameters.AddWithValue("@customer_contact_person", customer_contact_person);
            com.Parameters.AddWithValue("@customer_registration_no", customer_registration_no);
            com.Parameters.AddWithValue("@customer_logo", customer_logo);
            com.Parameters.AddWithValue("@customer_bank_id", customer_bank_id);
            com.Parameters.AddWithValue("@customer_bank_branch_id", customer_bank_branch_id);

            com.Parameters.AddWithValue("@customer_branch_ifsc", customer_branch_ifsc);
            com.Parameters.AddWithValue("@customer_account_no", customer_account_no);
            com.Parameters.AddWithValue("@customer_first_subscription_date", customer_first_subscription_date);
            com.Parameters.AddWithValue("@parent_id", parent_id);

            com.Parameters.AddWithValue("@updated_date", DateTime.Now.ToShortDateString());
            com.Parameters.AddWithValue("@updated_by", user_id);
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
            com = new SqlCommand("prManageCustomer_mst", con);
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