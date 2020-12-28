using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PTEWebService.Models
{
    public class Company_Info
    {
        public int index_id { get; set; }

        public string company_name { get; set; }
        public string company_address { get; set; }
        public string company_pincode { get; set; }
        public int company_country_id { get; set; }
        public int company_state_id { get; set; }
        public int company_city_id { get; set; }
        public int company_area_id { get; set; }
        public string company_email { get; set; }
        public string cucompany_contact_person { get; set; }
        public string company_contact_no { get; set; }
        public string company_fax_no { get; set; }
        public string company_pan_no { get; set; }
        public string company_registration_no { get; set; }
        public string company_gstin_no { get; set; }
        public string company_logo { get; set; }
        public int company_bank_id { get; set; }
        public int company_bank_branch_id { get; set; }
        public string company_bank_ifsc { get; set; }
        public string company_account_no { get; set; }
        public string company_cin_no { get; set; }
        public string company_cst_no { get; set; }

        public int user_id { get; set; }




        /*string company_name,
        string company_address,
        string company_pincode,
        int company_country_id,
        int company_state_id,
        int company_city_id,
        int company_area_id,
        string company_email,
        string cucompany_contact_person,
        string company_contact_no,
        string company_fax_no,
        string company_pan_no,
        string company_registration_no,
        string company_gstin_no,
        string company_logo,
        int company_bank_id,
        int company_bank_branch_id,
        string company_bank_ifsc,
        string company_account_no,
        string company_cin_no,
        string company_cst_no,
        int user_id*/




        private SqlConnection con;
        private SqlCommand com;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        #region Get All Company
        public string GetAllCompany()
        {
            try
            {
                connection();
                com = new SqlCommand("prManageCompany_info", con);
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
        #region Get Company from Index ID
        public string GetCompany(int id)
        {
            try
            {
                connection();
                com = new SqlCommand("prManageCompany_info", con);
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
        #region Insert Company
        public string AddCompany(string company_name,
        string company_address,
        string company_pincode,
        int company_country_id,
        int company_state_id,
        int company_city_id,
        int company_area_id,
        string company_email,
        string cucompany_contact_person,
        string company_contact_no,
        string company_fax_no,
        string company_pan_no,
        string company_registration_no,
        string company_gstin_no,
        string company_logo,
        int company_bank_id,
        int company_bank_branch_id,
        string company_bank_ifsc,
        string company_account_no,
        string company_cin_no,
        string company_cst_no,
        int user_id)
        {
            connection();
            com = new SqlCommand("prManageCompany_info", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Insert");
            com.Parameters.AddWithValue("@company_name", company_name);

            com.Parameters.AddWithValue("@company_address", company_address);
            com.Parameters.AddWithValue("@company_pincode", company_pincode);
            com.Parameters.AddWithValue("@company_country_id", company_country_id);
            com.Parameters.AddWithValue("@company_state_id", company_state_id);
            com.Parameters.AddWithValue("@company_city_id", company_city_id);
            com.Parameters.AddWithValue("@company_area_id", company_area_id);
            com.Parameters.AddWithValue("@company_email", company_email);
            com.Parameters.AddWithValue("@cucompany_contact_person", cucompany_contact_person);
            com.Parameters.AddWithValue("@company_contact_no", company_contact_no);
            com.Parameters.AddWithValue("@company_fax_no", company_fax_no);

            com.Parameters.AddWithValue("@company_pan_no", company_pan_no);
            com.Parameters.AddWithValue("@company_registration_no", company_registration_no);
            com.Parameters.AddWithValue("@company_gstin_no", company_gstin_no);
            com.Parameters.AddWithValue("@company_logo", company_logo);
            com.Parameters.AddWithValue("@company_bank_id", company_bank_id);
            com.Parameters.AddWithValue("@company_bank_branch_id", company_bank_branch_id);
            com.Parameters.AddWithValue("@company_bank_ifsc", company_bank_ifsc);
            com.Parameters.AddWithValue("@company_account_no", company_account_no);
            com.Parameters.AddWithValue("@company_cin_no", company_cin_no);
            com.Parameters.AddWithValue("@company_cst_no", company_cst_no);            


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
        #region Update Company
        public string EditCompany(int index_id, string company_name,
        string company_address,
        string company_pincode,
        int company_country_id,
        int company_state_id,
        int company_city_id,
        int company_area_id,
        string company_email,
        string cucompany_contact_person,
        string company_contact_no,
        string company_fax_no,
        string company_pan_no,
        string company_registration_no,
        string company_gstin_no,
        string company_logo,
        int company_bank_id,
        int company_bank_branch_id,
        string company_bank_ifsc,
        string company_account_no,
        string company_cin_no,
        string company_cst_no,
        int user_id)
        {
            connection();
            com = new SqlCommand("prManageCompany_info", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Action", "Update");
            com.Parameters.AddWithValue("@index_id", index_id);
            com.Parameters.AddWithValue("@company_name", company_name);

            com.Parameters.AddWithValue("@company_address", company_address);
            com.Parameters.AddWithValue("@company_pincode", company_pincode);
            com.Parameters.AddWithValue("@company_country_id", company_country_id);
            com.Parameters.AddWithValue("@company_state_id", company_state_id);
            com.Parameters.AddWithValue("@company_city_id", company_city_id);
            com.Parameters.AddWithValue("@company_area_id", company_area_id);
            com.Parameters.AddWithValue("@company_email", company_email);
            com.Parameters.AddWithValue("@cucompany_contact_person", cucompany_contact_person);
            com.Parameters.AddWithValue("@company_contact_no", company_contact_no);
            com.Parameters.AddWithValue("@company_fax_no", company_fax_no);

            com.Parameters.AddWithValue("@company_pan_no", company_pan_no);
            com.Parameters.AddWithValue("@company_registration_no", company_registration_no);
            com.Parameters.AddWithValue("@company_gstin_no", company_gstin_no);
            com.Parameters.AddWithValue("@company_logo", company_logo);
            com.Parameters.AddWithValue("@company_bank_id", company_bank_id);
            com.Parameters.AddWithValue("@company_bank_branch_id", company_bank_branch_id);
            com.Parameters.AddWithValue("@company_bank_ifsc", company_bank_ifsc);
            com.Parameters.AddWithValue("@company_account_no", company_account_no);
            com.Parameters.AddWithValue("@company_cin_no", company_cin_no);
            com.Parameters.AddWithValue("@company_cst_no", company_cst_no);
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
        #region Delete Company
        public string DeleteCompany(int index_id)
        {
            connection();
            com = new SqlCommand("prManageCompany_info", con);
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