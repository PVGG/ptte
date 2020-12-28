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
    public class AreaMstController : ApiController
    {
        // POST: api/areamst/5
        public string Get(int id)
        {
            Models.Area_Mst obj = new Models.Area_Mst();

            string output = obj.GetArea(id);

            return output;

        }

        // POST: api/areamst
        public string Get()
        {
            Models.Area_Mst obj = new Models.Area_Mst();

            string output = obj.GetAllArea();

            return output;
        }

        // POST: api/areamst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Area_Mst obj = new Models.Area_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            int zone_id = jsonArr.zone_id;
            int state_id = jsonArr.state_id;
            int city_id = jsonArr.city_id;
            string area_name = jsonArr.area_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddArea(country_id, zone_id, state_id, city_id, area_name, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/areamst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Area_Mst obj = new Models.Area_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            int zone_id = jsonArr.zone_id;
            int state_id = jsonArr.state_id;
            int city_id = jsonArr.city_id;
            string area_name = jsonArr.area_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditArea(id, country_id, zone_id, state_id, city_id,area_name, user_id);

            return output;
        }

        // DELETE: api/areamst/5
        public string Delete(int id)
        {
            Models.Area_Mst obj = new Models.Area_Mst();

            string output = obj.DeleteArea(id);

            return output;
        }
    }
}
