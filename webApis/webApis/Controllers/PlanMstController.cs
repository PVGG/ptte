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
    public class PlanMstController : ApiController
    {
        // POST: api/planmst/5
        public string Get(int id)
        {
            Models.Plan_Mst obj = new Models.Plan_Mst();

            string output = obj.GetPlan(id);

            return output;

        }

        // POST: api/planmst
        public string Get()
        {
            Models.Plan_Mst obj = new Models.Plan_Mst();

            string output = obj.GetAllPlan();

            return output;
        }

        // POST: api/planmst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Plan_Mst obj = new Models.Plan_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string plan_name = jsonArr.plan_name;
            int plan_type_id = jsonArr.plan_type_id;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddPlan(plan_name,plan_type_id,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/planmst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Plan_Mst obj = new Models.Plan_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string plan_name = jsonArr.plan_name;
            int plan_type_id = jsonArr.plan_type_id;
            int user_id = jsonArr.user_id;

            string output = obj.EditPlan(id, plan_name, plan_type_id, user_id);

            return output;
        }

        // DELETE: api/planmst/5
        public string Delete(int id)
        {
            Models.Plan_Mst obj = new Models.Plan_Mst();

            string output = obj.DeletePlan(id);

            return output;
        }
    }
}