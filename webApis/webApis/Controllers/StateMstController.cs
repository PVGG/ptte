using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class StateMstController : ApiController
    {
        // POST: api/statemst/5
        public string Get(int id)
        {
            Models.State_Mst obj = new Models.State_Mst();

            string output = obj.GetState(id);

            return output;

        }

        // POST: api/statemst
        public string Get()
        {
            Models.State_Mst obj = new Models.State_Mst();

            string output = obj.GetAllState();

            return output;
        }

        // POST: api/statemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.State_Mst obj = new Models.State_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            int zone_id = jsonArr.zone_id;
            string state_name = jsonArr.state_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddState(country_id,zone_id, state_name, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/statemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.State_Mst obj = new Models.State_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            int zone_id = jsonArr.zone_id;
            string state_name = jsonArr.state_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditState(id, country_id, zone_id, state_name, user_id);

            return output;
        }

        // DELETE: api/statemst/5
        public string Delete(int id)
        {
            Models.State_Mst obj = new Models.State_Mst();

            string output = obj.DeleteState(id);

            return output;
        }
    }
}
