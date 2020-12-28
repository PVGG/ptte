using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Subscription_Plan_Mst
    {
        public int index_id { get; set; }
        public string subscription_plan_name { get; set; }
        public int subscription_period { get; set; }
        public float subscription_amount { get; set; }
        public string notes { get; set; }
        public int subscription_plan_type_id { get; set; }
        public int user_id { get; set; }
               

        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Subscription Plan
        public string GetAllSubscriptionPlan()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageSubscription_plan_mst", con);
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
        #region Get Subscription Plan from Index ID
        public string GetSubscriptionPlan(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageSubscription_plan_mst", con);
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
        #region Insert Subscription Plan
        public string AddSubscriptionPlan(string subscription_plan_name, int subscription_period, float subscription_amount, string notes, int subscription_plan_type_id, int user_id)
        {
            connection();
            com = new SqlCommand("prManageSubscription_plan_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@subscription_plan_name", subscription_plan_name);
            com.Parameters.AddWithValue("@subscription_period", subscription_period);
            com.Parameters.AddWithValue("@subscription_amount", subscription_amount);
            com.Parameters.AddWithValue("@notes", notes);
            com.Parameters.AddWithValue("@subscription_plan_type_id", subscription_plan_type_id);
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
        #region Update Subscription Plan
        public string EditSubscriptionPlan(int index_id, string subscription_plan_name, int subscription_period, float subscription_amount, string notes, int subscription_plan_type_id, int user_id)
        {
            connection();
            com = new SqlCommand("prManageSubscription_plan_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@subscription_plan_name", subscription_plan_name);
            com.Parameters.AddWithValue("@subscription_period", subscription_period);
            com.Parameters.AddWithValue("@subscription_amount", subscription_amount);
            com.Parameters.AddWithValue("@notes", notes);
            com.Parameters.AddWithValue("@subscription_plan_type_id", subscription_plan_type_id);
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
        #region Delete Subscription Plan
        public string DeleteSubscriptionPlan(int index_id)
        {
            connection();
            com = new SqlCommand("prManageSubscription_plan_mst", con);
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