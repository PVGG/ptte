using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class LevelMstController : ApiController
    {
        // POST: api/levelmst/5
        public string Get(int id)
        {
            Models.Level_Mst obj = new Models.Level_Mst();

            string output = obj.GetLevel(id);

            return output;

        }

        // POST: api/levelmst
        public string Get()
        {
            Models.Level_Mst obj = new Models.Level_Mst();

            string output = obj.GetAllLevel();

            return output;
        }

        // POST: api/levelmst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Level_Mst obj = new Models.Level_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string level_name = jsonArr.level_name;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddLevel(level_name);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/levelmst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Level_Mst obj = new Models.Level_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string level_name = jsonArr.level_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditLevel(id, level_name);

            return output;
        }

        // DELETE: api/levelmst/5
        public string Delete(int id)
        {
            Models.Level_Mst obj = new Models.Level_Mst();

            string output = obj.DeleteLevel(id);

            return output;
        }
    }
}
