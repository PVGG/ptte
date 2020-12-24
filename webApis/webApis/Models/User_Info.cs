using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class User_Info
    {
        public int index_id { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string user_full_name { get; set; }
        public string password { get; set; }
        public int user_role_id { get; set; }
        public string user_email { get; set; }
        public string user_mobile_no { get; set; }
        public string user_photo { get; set; }
        public int is_approved { get; set; }
        public int is_locked { get; set; }
        public int user_failed_password_attempt_count { get; set; }
        public int parent_id { get; set; }
        public int customer_id { get; set; }
        public string locked_reason { get; set; }
        public int user_id { get; set; }


        
        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All User Info
        public string GetAllUserInfo()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageuser_info", con);
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
        #region Get User Info from Index ID
        public string GetUserInfo(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageuser_info", con);
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
        #region Insert User Info
        public string AddUserInfo(string user_code, string user_name, string user_full_name, string password, int user_role_id, string user_email, string user_mobile_no, string user_photo, int is_approved, int is_locked, int user_failed_password_attempt_count, int parent_id, int customer_id, string locked_reason, int user_id)
        {
            connection();
            com = new SqlCommand("prManageuser_info", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@user_code", user_code);
            com.Parameters.AddWithValue("@user_name", user_name);
            com.Parameters.AddWithValue("@user_full_name", user_full_name);
            com.Parameters.AddWithValue("@password", password);
            com.Parameters.AddWithValue("@user_role_id", user_role_id);
            com.Parameters.AddWithValue("@user_email", user_email);
            com.Parameters.AddWithValue("@user_mobile_no", user_mobile_no);
            com.Parameters.AddWithValue("@user_photo", user_photo);
            com.Parameters.AddWithValue("@is_approved", is_approved);
            com.Parameters.AddWithValue("@is_locked", is_locked);
            com.Parameters.AddWithValue("@user_failed_password_attempt_count", user_failed_password_attempt_count);
            com.Parameters.AddWithValue("@parent_id", parent_id);
            com.Parameters.AddWithValue("@customer_id", customer_id);
            com.Parameters.AddWithValue("@locked_reason", locked_reason);
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
        #region Update User Info
        public string EditUserInfo(int index_id,string user_code,string user_name,string user_full_name,string password,int user_role_id,string user_email,string user_mobile_no,string user_photo,int is_approved,int is_locked,int user_failed_password_attempt_count,int parent_id,int customer_id,string locked_reason,int user_id)
        {
            connection();
            com = new SqlCommand("prManageuser_info", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@user_code", user_code);
            com.Parameters.AddWithValue("@user_name", user_name);
            com.Parameters.AddWithValue("@user_full_name", user_full_name);
            com.Parameters.AddWithValue("@password", password);
            com.Parameters.AddWithValue("@user_role_id", user_role_id);
            com.Parameters.AddWithValue("@user_email", user_email);
            com.Parameters.AddWithValue("@user_mobile_no", user_mobile_no);
            com.Parameters.AddWithValue("@user_photo", user_photo);
            com.Parameters.AddWithValue("@is_approved", is_approved);
            com.Parameters.AddWithValue("@is_locked", is_locked);
            com.Parameters.AddWithValue("@user_failed_password_attempt_count", user_failed_password_attempt_count);
            com.Parameters.AddWithValue("@parent_id", parent_id);
            com.Parameters.AddWithValue("@customer_id", customer_id);
            com.Parameters.AddWithValue("@locked_reason", locked_reason);
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
        #region Delete User Info
        public string DeleteUserInfo(int index_id)
        {
            connection();
            com = new SqlCommand("prManageuser_info", con);
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