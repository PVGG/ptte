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
    public class PlanExamDetailsController : ApiController
    {
        // POST: api/planexamdetails/5
        public string Get(int id)
        {
            Models.Plan_Exam_Details obj = new Models.Plan_Exam_Details();

            string output = obj.GetPlanExamDetails(id);

            return output;

        }

        // POST: api/planexamdetails
        public string Get()
        {
            Models.Plan_Exam_Details obj = new Models.Plan_Exam_Details();

            string output = obj.GetAllPlanExamDetails();

            return output;
        }

        // POST: api/planexamdetails
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Plan_Exam_Details obj = new Models.Plan_Exam_Details();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int plan_id = jsonArr.plan_id;
            int plan_detail_id = jsonArr.plan_detail_id;
            int exam_id = jsonArr.exam_id;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddPlanExamDetails(plan_id, plan_detail_id, exam_id,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/planexamdetails/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Plan_Exam_Details obj = new Models.Plan_Exam_Details();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int plan_id = jsonArr.plan_id;
            int plan_detail_id = jsonArr.plan_detail_id;
            int exam_id = jsonArr.exam_id;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditPlanExamDetails(id, plan_id, plan_detail_id, exam_id, user_id);

            return output;
        }

        // DELETE: api/planexamdetails/5
        public string Delete(int id)
        {
            Models.Plan_Exam_Details obj = new Models.Plan_Exam_Details();

            string output = obj.DeletePlanExamDetails(id);

            return output;
        }
    }
}