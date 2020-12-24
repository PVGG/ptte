using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class SubscriptionPlanMstController : ApiController
    {
        // POST: api/subscriptionplanmst/5
        public string Get(int id)
        {
            Models.Subscription_Plan_Mst obj = new Models.Subscription_Plan_Mst();

            string output = obj.GetSubscriptionPlan(id);

            return output;

        }

        // POST: api/subscriptionplanmst
        public string Get()
        {
            Models.Subscription_Plan_Mst obj = new Models.Subscription_Plan_Mst();

            string output = obj.GetAllSubscriptionPlan();

            return output;
        }

        // POST: api/subscriptionplanmst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Subscription_Plan_Mst obj = new Models.Subscription_Plan_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string subscription_plan_name = jsonArr.subscription_plan_name;
            int subscription_period = jsonArr.subscription_period;
            float subscription_amount = jsonArr.subscription_amount;
            string notes = jsonArr.notes;
            int subscription_plan_type_id = jsonArr.subscription_plan_type_id;
            int user_id = jsonArr.user_id;


            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddSubscriptionPlan(subscription_plan_name, subscription_period, subscription_amount, notes, subscription_plan_type_id, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/subscriptionplanmst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Subscription_Plan_Mst obj = new Models.Subscription_Plan_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];


            string subscription_plan_name = jsonArr.subscription_plan_name;
            int subscription_period = jsonArr.subscription_period;
            float subscription_amount = jsonArr.subscription_amount;
            string notes = jsonArr.notes;
            int subscription_plan_type_id = jsonArr.subscription_plan_type_id;
            int user_id = jsonArr.user_id;

            //string country_name = jsonArr.country_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditSubscriptionPlan(id, subscription_plan_name, subscription_period, subscription_amount, notes, subscription_plan_type_id, user_id);

            return output;
        }

        // DELETE: api/subscriptionplanmst/5
        public string Delete(int id)
        {
            Models.Subscription_Plan_Mst obj = new Models.Subscription_Plan_Mst();

            string output = obj.DeleteSubscriptionPlan(id);

            return output;
        }
    }
}