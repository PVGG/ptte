using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class RoleMstController : ApiController
    {
        // POST: api/rolemst/5
        public string Get(int id)
        {
            Models.Role_Mst obj = new Models.Role_Mst();

            string output = obj.GetRole(id);

            return output;

        }

        // POST: api/rolemst
        public string Get()
        {
            Models.Role_Mst obj = new Models.Role_Mst();

            string output = obj.GetAllRole();

            return output;
        }

        // POST: api/rolemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Role_Mst obj = new Models.Role_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string role_name = jsonArr.role_name;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddRole(role_name);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/rolemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Role_Mst obj = new Models.Role_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string role_name = jsonArr.role_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditRole(id, country_name);

            return output;
        }

        // DELETE: api/rolemst/5
        public string Delete(int id)
        {
            Models.Role_Mst obj = new Models.Role_Mst();

            string output = obj.DeleteRole(id);

            return output;
        }
    }
}