﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Question_Avi_Files
    {
        public int index_id { get; set; }
        public int question_id { get; set; }
        public int file_type { get; set; }
        public string avi_file_url { get; set; }
        public int user_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Question AVI FILE
        public string GetAllQuestionAviFile()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_avi_files", con);
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
        #region Get Question AVI FILE from Index ID
        public string GetQuestionAviFile(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_avi_files", con);
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

        #region Get Question AVI FILE from Question Id
        public string GetQuestionAviFileByQuestionId(int question_id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_avi_files", con);
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


        #region Insert Question AVI FILE
        public string AddQuestionAviFile(int question_id, int file_type, string avi_file_url, int user_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_avi_files", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@question_id", question_id);
            com.Parameters.AddWithValue("@file_type", file_type);
            com.Parameters.AddWithValue("@avi_file_url", avi_file_url);
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
        #region Update Question AVI FILE
        public string EditQuestionAviFile(int index_id, int question_id, int file_type, string avi_file_url, int user_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_avi_files", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@question_id", question_id);
            com.Parameters.AddWithValue("@file_type", file_type);
            com.Parameters.AddWithValue("@avi_file_url", avi_file_url);
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
        #region Delete Question AVI FILE
        public string DeleteQuestionAviFile(int index_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_avi_files", con);
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