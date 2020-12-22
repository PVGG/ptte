using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class SubscriptionMstController : ApiController
    {
        // POST: api/subscriptionmst/5
        public string Get(int id)
        {
            Models.Subscription_Mst obj = new Models.Subscription_Mst();

            string output = obj.GetSubscription(id);

            return output;

        }

        // POST: api/subscriptionmst
        public string Get()
        {
            Models.Subscription_Mst obj = new Models.Subscription_Mst();

            string output = obj.GetAllSubscription();

            return output;
        }

        // POST: api/subscriptionmst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Subscription_Mst obj = new Models.Subscription_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string country_name = jsonArr.country_name;
            int plan_id = jsonArr.plan_id;
            string subscription_date = jsonArr.subscription_date;
            string subscription_expire_date = jsonArr.subscription_expire_date;
            int customer_id = jsonArr.customer_id;
            int user_id = jsonArr.user_id;


            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddSubscription(plan_id, subscription_date, subscription_expire_date, customer_id, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/subscriptionmst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Subscription_Mst obj = new Models.Subscription_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];


            string country_name = jsonArr.country_name;
            int plan_id = jsonArr.plan_id;
            string subscription_date = jsonArr.subscription_date;
            string subscription_expire_date = jsonArr.subscription_expire_date;
            int customer_id = jsonArr.customer_id;
            int user_id = jsonArr.user_id;

            //string country_name = jsonArr.country_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditSubscription(id, plan_id, subscription_date, subscription_expire_date, customer_id, user_id);

            return output;
        }

        // DELETE: api/subscriptionmst/5
        public string Delete(int id)
        {
            Models.Subscription_Mst obj = new Models.Subscription_Mst();

            string output = obj.DeleteSubscription(id);

            return output;
        }
    }
}