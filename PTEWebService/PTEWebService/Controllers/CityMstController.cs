using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class CityMstController : ApiController
    {
        // POST: api/citymst/5
        public string Get(int id)
        {
            Models.City_Mst obj = new Models.City_Mst();

            string output = obj.GetCity(id);

            return output;

        }

        // POST: api/citymst
        public string Get()
        {
            Models.City_Mst obj = new Models.City_Mst();

            string output = obj.GetAllCity();

            return output;
        }

        // POST: api/citymst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.City_Mst obj = new Models.City_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            int zone_id = jsonArr.zone_id;
            int state_id = jsonArr.state_id;
            string city_name = jsonArr.city_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddCity(country_id,zone_id, state_id,city_name, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/citymst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.City_Mst obj = new Models.City_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int country_id = jsonArr.country_id;
            int zone_id = jsonArr.zone_id;
            int state_id = jsonArr.state_id;
            string city_name = jsonArr.city_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditCity(id, country_id, zone_id, state_id, city_name, user_id);

            return output;
        }

        // DELETE: api/citymst/5
        public string Delete(int id)
        {
            Models.City_Mst obj = new Models.City_Mst();

            string output = obj.DeleteCity(id);

            return output;
        }
    }
}
