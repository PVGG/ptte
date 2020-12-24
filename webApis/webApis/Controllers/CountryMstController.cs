using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class CountryMstController : ApiController
    {
        // POST: api/countrymst/5
        public string Get(int id)
        {
            Models.Country_Mst obj = new Models.Country_Mst();

            string output = obj.GetCountry(id);

            return output;

        }

        // POST: api/countrymst
        public string Get()
        {
            Models.Country_Mst obj = new Models.Country_Mst();

            string output = obj.GetAllCountry();

            return output;
        }

        // POST: api/countrymst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Country_Mst obj = new Models.Country_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string country_name = jsonArr.country_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddCountry(country_name, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/countrymst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Country_Mst obj = new Models.Country_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string country_name = jsonArr.country_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditCountry(id, country_name, user_id);

            return output;
        }

        // DELETE: api/countrymst/5
        public string Delete(int id)
        {
            Models.Country_Mst obj = new Models.Country_Mst();

            string output = obj.DeleteCountry(id);

            return output;
        }
    }
}
