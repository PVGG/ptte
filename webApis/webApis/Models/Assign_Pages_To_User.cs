using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Assign_Pages_To_User
    {
        public int index_id { get; set; }
        public int user_id { get; set; }
        public int page_id { get; set; }
        public int created_by_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Assign Page
        public string GetAllAssignPage()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageAssign_pages_to_user", con);
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
        #region Get Assign Page from Index ID
        public string GetAssignPage(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageAssign_pages_to_user", con);
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
        #region Insert Assign Page
        public string AddAssignPage(int user_id, int page_id, int created_by_id)
        {
            connection();
            com = new SqlCommand("prManageAssign_pages_to_user", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@user_id", user_id);
            com.Parameters.AddWithValue("@page_id", page_id);
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
        #region Update Assign Page
        public string EditAssignPage(int index_id, int user_id, int page_id, int created_by_id)
        {
            connection();
            com = new SqlCommand("prManageAssign_pages_to_user", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@user_id", user_id);
            com.Parameters.AddWithValue("@page_id", page_id);
            com.Parameters.AddWithValue("@updated_date", DateTime.Now.ToShortDateString());
            com.Parameters.AddWithValue("@updated_by", created_by_id);
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
        #region Delete Assign Page
        public string DeleteAssignPage(int index_id)
        {
            connection();
            com = new SqlCommand("prManageAssign_pages_to_user", con);
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