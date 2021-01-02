﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Question_Category_Mst
    {
        public int index_id { get; set; }
        public int module_id { get; set; }
        public string question_category_name { get; set; }
        public string av_url { get; set; }
        public string notes { get; set; }
        public string instructions { get; set; }
        public int user_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Question Categary
        public string GetAllQuestionCategary()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_category_mst", con);
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
        #region Get Question Categary from Index ID
        public string GetQuestionCategary(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageQuestion_category_mst", con);
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

        #region Get Question Categary from Index ID
        public string GetQuestionCategaryByModuleId(int id)
        {
            try
            {
                CommonFunction obj = new CommonFunction();
                DataTable dt = new DataTable();
                dt = obj.getListById("Select", "question_category_mst", "index_id,question_category_name", "is_deleted=0 AND module_id", id.ToString());
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

        #region Insert Question Categary
        public string AddQuestionCategary(int module_id, string question_category_name, string av_url, string notes, string instructions, int user_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_category_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@module_id", module_id);
            com.Parameters.AddWithValue("@question_category_name", question_category_name);
            com.Parameters.AddWithValue("@av_url", av_url);
            com.Parameters.AddWithValue("@notes", notes);
            com.Parameters.AddWithValue("@instructions", instructions);
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
        #region Update Question Categary
        public string EditQuestionCategary(int index_id, int module_id, string question_category_name, string av_url, string notes, string instructions, int user_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_category_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@module_id", module_id);
            com.Parameters.AddWithValue("@question_category_name", question_category_name);
            com.Parameters.AddWithValue("@av_url", av_url);
            com.Parameters.AddWithValue("@notes", notes);
            com.Parameters.AddWithValue("@instructions", instructions);
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
        #region Delete Question Categary
        public string DeleteQuestionCategary(int index_id)
        {
            connection();
            com = new SqlCommand("prManageQuestion_category_mst", con);
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