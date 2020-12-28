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
    //[EnableCors(origins: "https://trial.spyderxindia.com", headers: "*", methods: "*")]
    public class ModuleMstController : ApiController
    {
        // POST: api/modulemst/5
        public string Get(int id)
        {
            Models.Module_Mst obj = new Models.Module_Mst();

            string output = obj.GetModule(id);

            return output;

        }

        // POST: api/modulemst
        public string Get()
        {
            Models.Module_Mst obj = new Models.Module_Mst();

            string output = obj.GetAllModule();

            return output;
        }

        // POST: api/modulemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Module_Mst obj = new Models.Module_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string module_name = jsonArr.module_name;
            int  user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddModule(module_name, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/modulemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Module_Mst obj = new Models.Module_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string module_name = jsonArr.module_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditModule(id, module_name, user_id);

            return output;
        }

        // DELETE: api/modulemst/5
        public string Delete(int id)
        {
            Models.Module_Mst obj = new Models.Module_Mst();

            string output = obj.DeleteModule(id);

            return output;
        }
    }
}
