using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Exam_Question_Mst
    {
        public int index_id { get; set; }
        public int exam_id { get; set; }
        public int module_id { get; set; }
        public int question_category_id { get; set; }
        public int question_id { get; set; }
        public int user_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Exam Question
        public string GetAllExamQuestion()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageExam_question_mst", con);
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
        #region Get Exam Question from Index ID
        public string GetExamQuestion(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageExam_question_mst", con);
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

        #region Insert Exam Question
        public string AddExamQuestion(int exam_id, int module_id, int question_category_id, int question_id, int user_id)
        {
            connection();
            com = new SqlCommand("prManageExam_question_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@exam_id", exam_id);
            com.Parameters.AddWithValue("@module_id", module_id);
            com.Parameters.AddWithValue("@question_category_id", question_category_id);
            com.Parameters.AddWithValue("@question_id", question_id);
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
        #region Update Exam Question
        public string EditExamQuestion(int index_id, int exam_id, int module_id, int question_category_id, int question_id, int user_id)
        {
            connection();
            com = new SqlCommand("prManageExam_question_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@exam_id", exam_id);
            com.Parameters.AddWithValue("@module_id", module_id);
            com.Parameters.AddWithValue("@question_category_id", question_category_id);
            com.Parameters.AddWithValue("@question_id", question_id);
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
        #region Delete Exam Question
        public string DeleteExamQuestion(int index_id)
        {
            connection();
            com = new SqlCommand("prManageExam_question_mst", con);
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