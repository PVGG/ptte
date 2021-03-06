﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Exam_Mst
    {
        public int index_id { get; set; }
        public string exam_name { get; set; }
        public int exam_category_id { get; set; }
        public int level_id { get; set; }
        public int exam_type_id { get; set; }
        public int customer_id { get; set; }
        public string question_categories { get; set; }

        public int user_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Exam
        public string GetAllExam()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageExam_mst", con);
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
        #region Get Exam from Index ID
        public string GetExam(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageExam_mst", con);
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
        #region Insert Exam
        public string AddExam(string exam_name, int exam_category_id, int level_id, int exam_type_id, int customer_id, string question_categories, int user_id)
        {
            connection();
            com = new SqlCommand("prManageExam_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@exam_name", exam_name);
            com.Parameters.AddWithValue("@exam_category_id", exam_category_id);
            com.Parameters.AddWithValue("@level_id", level_id);
            com.Parameters.AddWithValue("@exam_type_id", exam_type_id);
            com.Parameters.AddWithValue("@customer_id", customer_id);
            com.Parameters.AddWithValue("@question_categories", question_categories);
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
        #region Update Exam
        public string EditExam(int index_id, string exam_name, int exam_category_id, int level_id, int exam_type_id, int customer_id, string question_categories, int user_id)
        {
            connection();
            com = new SqlCommand("prManageExam_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@exam_name", exam_name);
            com.Parameters.AddWithValue("@exam_category_id", exam_category_id);
            com.Parameters.AddWithValue("@level_id", level_id);
            com.Parameters.AddWithValue("@exam_type_id", exam_type_id);
            com.Parameters.AddWithValue("@customer_id", customer_id);
            com.Parameters.AddWithValue("@question_categories", question_categories);
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
        #region Delete Exam
        public string DeleteExam(int index_id)
        {
            connection();
            com = new SqlCommand("prManageExam_mst", con);
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