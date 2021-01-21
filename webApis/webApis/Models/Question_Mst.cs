using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Question_Mst
    {
        public int index_id { get; set; }
        public int module_id { get; set; }
        public int question_category_id { get; set; }
        public int customer_id { get; set; }
        public int level_id { get; set; }
        public string avi_file_url { get; set; }
        public int record_begin_time { get; set; }
        public int recording_time { get; set; }
        public int wait_time { get; set; }
        public string excerpt { get; set; }
        public string instruction { get; set; }
        public string description { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public int user_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Questions
        public string GetAllQuestion()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_mst", con);
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
        #region Get Question from Index ID
        public string GetQuestion(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_mst", con);
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

        #region Get Question from Question Categary Index ID
        public string GetQuestionByCategaryId(int id)
        {
            try
            {
                CommonFunction obj = new CommonFunction();
                DataTable dt = new DataTable();
                dt = obj.getListById("Select", "question_mst", "*", "is_deleted=0 AND question_category_id", id.ToString());
                string json_data = obj.DataTableToJSONWithStringBuilder(dt);
                return json_data;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return null;
            }

        }
        #endregion

        #region Insert Question
        public string AddQuestion(int module_id, int question_category_id, int customer_id, int level_id, string avi_file_url, int record_begin_time, int recording_time, int wait_time, string excerpt, string instruction, string description, string question, string answer, int user_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@module_id", module_id);
            com.Parameters.AddWithValue("@question_category_id", question_category_id);
            com.Parameters.AddWithValue("@customer_id", customer_id);
            com.Parameters.AddWithValue("@level_id", level_id);
            com.Parameters.AddWithValue("@avi_file_url", avi_file_url);
            com.Parameters.AddWithValue("@record_begin_time", record_begin_time);
            com.Parameters.AddWithValue("@recording_time", recording_time);
            com.Parameters.AddWithValue("@wait_time", wait_time);
            com.Parameters.AddWithValue("@excerpt", excerpt);
            com.Parameters.AddWithValue("@instruction", instruction);
            com.Parameters.AddWithValue("@description", description);
            com.Parameters.AddWithValue("@question", question);
            com.Parameters.AddWithValue("@answer", answer);
            com.Parameters.AddWithValue("@created_date", Convert.ToString(DateTime.Now.ToShortDateString()));
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
        #region Update Question
        public string EditQuestion(int index_id, int module_id, int question_category_id, int customer_id, int level_id, string avi_file_url, int record_begin_time, int recording_time, int wait_time, string excerpt, string instruction, string description, string question, string answer, int user_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@module_id", module_id);
            com.Parameters.AddWithValue("@question_category_id", question_category_id);
            com.Parameters.AddWithValue("@customer_id", customer_id);
            com.Parameters.AddWithValue("@level_id", level_id);
            com.Parameters.AddWithValue("@avi_file_url", avi_file_url);
            com.Parameters.AddWithValue("@record_begin_time", record_begin_time);
            com.Parameters.AddWithValue("@recording_time", recording_time);
            com.Parameters.AddWithValue("@wait_time", wait_time);
            com.Parameters.AddWithValue("@excerpt", excerpt);
            com.Parameters.AddWithValue("@instruction", instruction);
            com.Parameters.AddWithValue("@description", description);
            com.Parameters.AddWithValue("@question", question);
            com.Parameters.AddWithValue("@answer", answer);
            com.Parameters.AddWithValue("@updated_date", Convert.ToString(DateTime.Now.ToShortDateString()));
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
        #region Delete Question
        public string DeleteQuestion(int index_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_mst", con);
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