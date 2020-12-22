using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class PlanTypeMstController : ApiController
    {
        // POST: api/plantypemst/5
        public string Get(int id)
        {
            Models.Plan_Type_Mst obj = new Models.Plan_Type_Mst();

            string output = obj.GetPlanType(id);

            return output;

        }

        // POST: api/plantypemst
        public string Get()
        {
            Models.Plan_Type_Mst obj = new Models.Plan_Type_Mst();

            string output = obj.GetAllPlanType();

            return output;
        }

        // POST: api/plantypemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Plan_Type_Mst obj = new Models.Plan_Type_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string plan_type_name = jsonArr.plan_type_name;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddPlanType(plan_type_name);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/plantypemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Plan_Type_Mst obj = new Models.Plan_Type_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string plan_type_name = jsonArr.plan_type_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditPlanType(id, plan_type_name);

            return output;
        }

        // DELETE: api/plantypemst/5
        public string Delete(int id)
        {
            Models.Plan_Type_Mst obj = new Models.Plan_Type_Mst();

            string output = obj.DeletePlanType(id);

            return output;
        }
    }
}