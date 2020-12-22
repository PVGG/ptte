using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class LogDetailsController : ApiController
    {
        // POST: api/logdetails/5
        public string Get(int id)
        {

            Models.Log_Details obj = new Models.Log_Details();

            string output = obj.GetLogDetails(id);

            return output;

        }

        // POST: api/logdetails
        public string Get()
        {
            Models.Log_Details obj = new Models.Log_Details();

            string output = obj.GetAllLogDetails();

            return output;
        }

        // POST: api/logdetails
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Log_Details obj = new Models.Log_Details();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int user_id = jsonArr.user_id;
            string login_date_time = jsonArr.login_date_time;
            string logout_date_time = jsonArr.logout_date_time;
            int created_by_id = jsonArr.created_by_id; 

            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddLogDetails(user_id, login_date_time, logout_date_time, created_by_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/logdetails/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Log_Details obj = new Models.Log_Details();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int user_id = jsonArr.user_id;
            string login_date_time = jsonArr.login_date_time;
            string logout_date_time = jsonArr.logout_date_time;
            int created_by_id = jsonArr.created_by_id; 
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditLogDetails(id, user_id, login_date_time, logout_date_time, created_by_id);

            return output;
        }

        // DELETE: api/logdetails/5
        public string Delete(int id)
        {
            Models.Log_Details obj = new Models.Log_Details();

            string output = obj.DeleteLogDetails(id);

            return output;
        }
    }
}