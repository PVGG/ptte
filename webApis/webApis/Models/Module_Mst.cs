using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Module_Mst
    {
        public int index_id { get; set; }
        public string module_name { get; set; }
        public int user_id { get; set; }

        private SqlConnection con;
        private SqlCommand com;
        private static readonly log4net.ILog log
       = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Modules
        public string GetAllModule()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageModule_mst", con);
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
                log.Info("Get All Module Sucessfully!!!");

                return json_data;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                log.Error(error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Get Module from Index ID
        public string GetModule(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageModule_mst", con);
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
                log.Info("Get All Module Sucessfully!!!");
                return json_data;

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                log.Error(error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Insert Module
        public string AddModule(string name,int user_id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageModule_mst", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Insert");
                com.Parameters.AddWithValue("@module_name", name);
                com.Parameters.AddWithValue("@created_by", user_id);
                com.Parameters.AddWithValue("@is_deleted", false);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                {
                    log.Info("Data Added Sucessfully!!!");
                    return "Data Added Successfully";
                }
                else
                {
                    log.Error("Data Not Added Sucessfully!!!");
                    return "Data Not Added Successfully";
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                log.Error(error);
                return null;
            }
        }
        #endregion
        #region Update Module
        public string EditModule(int index_id, string name, int user_id)
        {
            connection();
            com = new SqlCommand("prManageModule_mst", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@module_name", name);
            com.Parameters.AddWithValue("@updated_date", DateTime.Now.ToShortDateString());
            com.Parameters.AddWithValue("@updated_by", user_id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            log.Info("Update All Module Sucessfully!!!");

            if (i >= 1)
            {
                log.Info("Data Updated Sucessfully!!!");
                return "Data Updated Successfully";
            }
            else
            {
                log.Error("Data Not Updated Sucessfully!!!");
                return "Data Not Updated";
            }
        }
        #endregion
        #region Delete Modules
        public string DeleteModule(int index_id)
        {
            try { 
                connection();
                com = new SqlCommand("prManageModule_mst", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", "Delete");
                com.Parameters.AddWithValue("@index_id", index_id);
                com.Parameters.AddWithValue("@is_deleted", true);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                log.Info("Delete All Module Sucessfully!!!");
                if (i >= 1)
                {
                    log.Info("Data Deleted Sucessfully!!!");
                    return "Data Deleted Successfully";
                }
                else
                {
                    log.Error("Data Not Deleted Sucessfully!!!");
                    return "Data Not Deleted";
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                log.Error(error);
                return null;
            }
        }
        #endregion
    }
}