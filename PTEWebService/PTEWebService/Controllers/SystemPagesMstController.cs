using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class SystemPagesMstController : ApiController
    {
        // POST: api/systempagesmst/5
        public string Get(int id)
        {

            Models.System_Pages_Mst obj = new Models.System_Pages_Mst();

            string output = obj.GetSystemPages(id);

            return output;

        }

        // POST: api/systempagesmst
        public string Get()
        {
            Models.System_Pages_Mst obj = new Models.System_Pages_Mst();

            string output = obj.GetAllSystemPages();

            return output;
        }

        // POST: api/systempagesmst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.System_Pages_Mst obj = new Models.System_Pages_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string pages_name = jsonArr.pages_name;
            string pages_url = jsonArr.pages_url;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddSystemPages(pages_name, pages_url, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/systempagesmst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.System_Pages_Mst obj = new Models.System_Pages_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string pages_name = jsonArr.pages_name;
            string pages_url = jsonArr.pages_url;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditSystemPages(id, pages_name, pages_url, user_id);

            return output;
        }

        // DELETE: api/systempagesmst/5
        public string Delete(int id)
        {
            Models.System_Pages_Mst obj = new Models.System_Pages_Mst();

            string output = obj.DeleteSystemPages(id);

            return output;
        }
    }
}