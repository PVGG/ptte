using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;

namespace PTEWebService.Models
{
    public class CommonFunction
    {
        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        public string getMaxCount(string action,string table_name,string field_name)
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            SqlConnection con = new SqlConnection(constr);
            try
            {
                SqlCommand com = new SqlCommand("prGetMaxTableId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", action);
                com.Parameters.AddWithValue("@TableName", table_name);
                com.Parameters.AddWithValue("@FieldName", field_name);
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                con.Close();
                return ds.Tables[0].Rows[0][0].ToString();

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


        public string getValueById(string action, string table_name, string field_name,string where_field,string where_value)
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            SqlConnection con = new SqlConnection(constr);
            try
            {
                SqlCommand com = new SqlCommand("prGetValuebyId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", action);
                com.Parameters.AddWithValue("@TableName", table_name);
                com.Parameters.AddWithValue("@FieldName", field_name);
                com.Parameters.AddWithValue("@WhereField", where_field);
                com.Parameters.AddWithValue("@whereValue", where_value);
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                ada.Fill(ds);
                con.Close();
                return ds.Tables[0].Rows[0][0].ToString();

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

        public DataTable getListById(string action, string table_name, string field_name, string where_field, string where_value)
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            SqlConnection con = new SqlConnection(constr);
            try
            {
                SqlCommand com = new SqlCommand("prGetValuebyId", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Action", action);
                com.Parameters.AddWithValue("@TableName", table_name);
                com.Parameters.AddWithValue("@FieldName", field_name);
                com.Parameters.AddWithValue("@WhereField", where_field);
                com.Parameters.AddWithValue("@whereValue", where_value);
                con.Open();
                SqlDataAdapter ada = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                con.Close();
                return dt;

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


    }
}