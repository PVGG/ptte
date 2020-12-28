using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PTEWebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE")]
    public class AssignPagesToUserController : ApiController
    {
        // POST: api/assignpagestouser/5
        public string Get(int id)
        {
            Models.Assign_Pages_To_User obj = new Models.Assign_Pages_To_User();

            string output = obj.GetAssignPage(id);

            return output;

        }

        // POST: api/assignpagestouser
        public string Get()
        {
            Models.Assign_Pages_To_User obj = new Models.Assign_Pages_To_User();

            string output = obj.GetAllAssignPage();

            return output;
        }

        // POST: api/assignpagestouser
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Assign_Pages_To_User obj = new Models.Assign_Pages_To_User();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int user_id = jsonArr.user_id;
            int page_id = jsonArr.page_id;
            int created_by_id = jsonArr.created_by_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddAssignPage(user_id, page_id, created_by_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/assignpagestouser/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Assign_Pages_To_User obj = new Models.Assign_Pages_To_User();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int user_id = jsonArr.user_id;
            int page_id = jsonArr.page_id;
            int created_by_id = jsonArr.created_by_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditAssignPage(id, user_id, page_id, created_by_id);

            return output;
        }

        // DELETE: api/assignpagestouser/5
        public string Delete(int id)
        {
            Models.Assign_Pages_To_User obj = new Models.Assign_Pages_To_User();

            string output = obj.DeleteAssignPage(id);

            return output;
        }
    }
}