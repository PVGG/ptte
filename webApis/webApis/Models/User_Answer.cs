using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class User_Answer
    {
        public int index_id { get; set; }
        public int exam_id { get; set; }
        public int question_id { get; set; }
        public int user_id { get; set; }
        public string answer { get; set; }
        public int total_record_time { get; set; }
        public string answer_submitted_date_time { get; set; }
        public int created_by_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All User Answer
        public string GetAllUserAnswer()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageUser_answer", con);
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
        #region Get User Answer from Index ID
        public string GetUserAnswer(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageUser_answer", con);
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
        #region Insert User Answer
        public string AddUserAnswer(int exam_id, int question_id, int user_id, string answer, int total_record_time, string answer_submitted_date_time, int created_by_id)
        {
            connection();
            com = new SqlCommand("prManageUser_answer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@exam_id", exam_id);
            com.Parameters.AddWithValue("@user_id", question_id);
            com.Parameters.AddWithValue("@question_id", user_id);
            com.Parameters.AddWithValue("@answer", answer);
            com.Parameters.AddWithValue("@total_record_time", total_record_time);
            com.Parameters.AddWithValue("@answer_submitted_date_time", answer_submitted_date_time);
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
        #region Update User Answer
        public string EditUserAnswer(int index_id, int exam_id, int question_id, int user_id, string answer, int total_record_time, string answer_submitted_date_time, int created_by_id)
        {
            connection();
            com = new SqlCommand("prManageUser_answer", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@exam_id", exam_id);
            com.Parameters.AddWithValue("@user_id", question_id);
            com.Parameters.AddWithValue("@question_id", user_id);
            com.Parameters.AddWithValue("@answer", answer);
            com.Parameters.AddWithValue("@total_record_time", total_record_time);
            com.Parameters.AddWithValue("@answer_submitted_date_time", answer_submitted_date_time);
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
        #region Delete User Answer
        public string DeleteUserAnswer(int index_id)
        {
            connection();
            com = new SqlCommand("prManageUser_answer", con);
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