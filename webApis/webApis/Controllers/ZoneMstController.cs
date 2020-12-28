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
    public class ZoneMstController : ApiController
    {
        // POST: api/zonemst/5
        public string Get(int id)
        {
            Models.Zone_Mst obj = new Models.Zone_Mst();

            string output = obj.GetZone(id);

            return output;

        }

        // POST: api/zonemst
        public string Get()
        {
            Models.Zone_Mst obj = new Models.Zone_Mst();

            string output = obj.GetAllZone();

            return output;
        }

        // POST: api/zonemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Zone_Mst obj = new Models.Zone_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            string zone_name = jsonArr.zone_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddZone(country_id,zone_name,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/zonemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Zone_Mst obj = new Models.Zone_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            string zone_name = jsonArr.zone_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditZone(id, country_id, zone_name, user_id);

            return output;
        }

        // DELETE: api/zonemst/5
        public string Delete(int id)
        {
            Models.Zone_Mst obj = new Models.Zone_Mst();

            string output = obj.DeleteZone(id);

            return output;
        }
    }
}
