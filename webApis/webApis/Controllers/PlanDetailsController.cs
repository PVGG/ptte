﻿using Newtonsoft.Json.Linq;
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
    public class PlanDetailsController : ApiController
    {
        // POST: api/plandetails/5
        public string Get(int id)
        {
            Models.Plan_Details obj = new Models.Plan_Details();

            string output = obj.GetPlanDetails(id);

            return output;

        }

        // POST: api/plandetails
        public string Get()
        {
            Models.Plan_Details obj = new Models.Plan_Details();

            string output = obj.GetAllPlanDetails();

            return output;
        }

        // POST: api/plandetails
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value_data)
        {
            Models.Plan_Details obj = new Models.Plan_Details();

            string output = "Fail to add plan details";

            dynamic jsonArrs = JArray.Parse(value_data);
            var test = ((Newtonsoft.Json.Linq.JArray)jsonArrs).Count;
            for (int iCount = 0; iCount < test; iCount++)
            {
                dynamic jsonArr = jsonArrs[iCount];

                int plan_id = jsonArr.plan_id;
                int value = jsonArr.value;
                float price = jsonArr.price;
                string notes = jsonArr.notes;
                int user_id = jsonArr.user_id;
                //JSONArray ja_data = json.getJSONArray("data");

                output = obj.AddPlanDetails(plan_id, value, price, notes, user_id);
            }
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/plandetails/5
        public string Put(int id, [FromBody]string value_data)
        {
            Models.Plan_Details obj = new Models.Plan_Details();

            string output = "Fail to update plan details";

            dynamic jsonArrs = JArray.Parse(value_data);

            var test = ((Newtonsoft.Json.Linq.JArray)jsonArrs).Count;
            for (int iCount = 0; iCount < test; iCount++)
            {

                dynamic jsonArr = jsonArrs[iCount];

                int plan_id = jsonArr.plan_id;
                int value = jsonArr.value;
                float price = jsonArr.price;
                string notes = jsonArr.notes;
                int user_id = jsonArr.user_id;
                //int index_id = jsonArr.index_id;
                //JSONArray ja_data = json.getJSONArray("data");

                output = obj.EditPlanDetails(id, plan_id, value, price, notes, user_id);
            }

            return output;
        }

        // DELETE: api/plandetails/5
        public string Delete(int id)
        {
            Models.Plan_Details obj = new Models.Plan_Details();

            string output = obj.DeletePlanDetails(id);

            return output;
        }
    }
}