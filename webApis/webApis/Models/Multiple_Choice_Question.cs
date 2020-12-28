using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Multiple_Choice_Question
    {
        public int index_id { get; set; }
        public int question_id { get; set; }
        public string option_one { get; set; }
        public string option_two { get; set; }
        public string option_three { get; set; }
        public string option_four { get; set; }
        public int correct_option { get; set; }
        public int user_id { get; set; }



        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Multiple Choice Question
        public string GetAllMultipleChoiceQuestion()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageMultiple_choice_question", con);
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
        #region Get Multiple Choice Question from Index ID
        public string GetMultipleChoiceQuestion(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageMultiple_choice_question", con);
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

        #region Get Multiple Choice Question from Question Id
        public string GetMultipleChoiceQuestionByQuestionId(int question_id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageMultiple_choice_question", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "SelectByQuestionId");
                com.Parameters.AddWithValue("@question_id", question_id);
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

        #region Insert Multiple Choice Question
        public string AddMultipleChoiceQuestion(int question_id, string option_one, string option_two, string option_three, string option_four, int correct_option, int user_id)
        {
            connection();
            com = new SqlCommand("prManageMultiple_choice_question", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@question_id", question_id);
            com.Parameters.AddWithValue("@option_one", option_one);
            com.Parameters.AddWithValue("@option_two", option_two);
            com.Parameters.AddWithValue("@option_three", option_three);
            com.Parameters.AddWithValue("@option_four", option_four);
            //com.Parameters.AddWithValue("@option_five", name);
            com.Parameters.AddWithValue("@correct_option", correct_option);
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
        #region Update Multiple Choice Question
        public string EditMultipleChoiceQuestion(int index_id, int question_id, string option_one, string option_two, string option_three, string option_four, int correct_option, int user_id)
        {
            connection();
            com = new SqlCommand("prManageMultiple_choice_question", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@question_id", question_id);
            com.Parameters.AddWithValue("@option_one", option_one);
            com.Parameters.AddWithValue("@option_two", option_two);
            com.Parameters.AddWithValue("@option_three", option_three);
            com.Parameters.AddWithValue("@option_four", option_four);
            //com.Parameters.AddWithValue("@option_five", name);
            com.Parameters.AddWithValue("@correct_option", correct_option);
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
        #region Delete Multiple Choice Question
        public string DeleteMultipleChoiceQuestion(int index_id)
        {
            connection();
            com = new SqlCommand("prManageMultiple_choice_question", con);
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