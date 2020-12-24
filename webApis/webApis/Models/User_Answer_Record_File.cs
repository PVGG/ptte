using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class User_Answer_Record_File
    {
        public int index_id { get; set; }
        public int exam_id { get; set; }
        public int question_id { get; set; }
        public int user_id { get; set; }
        public string av_file_url { get; set; }
        public int duration_of_file { get; set; }
        public string recorded_date_time { get; set; }
        public int created_by_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All User Answer Record File
        public string GetAllUserAnswerRecordFile()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageUser_answer_record_file", con);
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
        #region Get User Answer Record File from Index ID
        public string GetUserAnswerRecordFile(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageUser_answer_record_file", con);
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
        #region Insert User Answer Record File
        public string AddUserAnswerRecordFile(int exam_id, int question_id, int user_id, string av_file_url, int duration_of_file, string recorded_date_time, int created_by_id)
        {
            connection();
            com = new SqlCommand("prManageUser_answer_record_file", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@exam_id", exam_id);
            com.Parameters.AddWithValue("@question_id", question_id);
            com.Parameters.AddWithValue("@user_id", user_id);
            com.Parameters.AddWithValue("@av_file_url", av_file_url);
            com.Parameters.AddWithValue("@duration_of_file", duration_of_file);
            com.Parameters.AddWithValue("@recorded_date_time", recorded_date_time);
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
        #region Update User Answer Record File
        public string EditUserAnswerRecordFile(int index_id, int exam_id, int question_id, int user_id, string av_file_url, int duration_of_file, string recorded_date_time, int created_by_id)
        {
            connection();
            com = new SqlCommand("prManageUser_answer_record_file", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@exam_id", exam_id);
            com.Parameters.AddWithValue("@question_id", question_id);
            com.Parameters.AddWithValue("@user_id", user_id);
            com.Parameters.AddWithValue("@av_file_url", av_file_url);
            com.Parameters.AddWithValue("@duration_of_file", duration_of_file);
            com.Parameters.AddWithValue("@recorded_date_time", recorded_date_time);
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
        #region Delete User Answer Record File
        public string DeleteUserAnswerRecordFile(int index_id)
        {
            connection();
            com = new SqlCommand("prManageUser_answer_record_file", con);
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