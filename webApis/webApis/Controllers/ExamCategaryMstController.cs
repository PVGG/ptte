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
    public class ExamCategaryMstController : ApiController
    {
        // POST: api/examcategarymst/5
        public string Get(int id)
        {
            Models.Exam_Category_Mst obj = new Models.Exam_Category_Mst();

            string output = obj.GetExamCategary(id);

            return output;

        }

        // POST: api/examcategarymst
        public string Get()
        {
            Models.Exam_Category_Mst obj = new Models.Exam_Category_Mst();

            string output = obj.GetAllExamCategary();

            return output;
        }

        // POST: api/examcategarymst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Exam_Category_Mst obj = new Models.Exam_Category_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_category_name = jsonArr.exam_category_name;
            int user_id= jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddExamCategary(exam_category_name,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/examcategarymst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Exam_Category_Mst obj = new Models.Exam_Category_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_category_name = jsonArr.exam_category_name;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditExamCategary(id, exam_category_name,user_id);

            return output;
        }

        // DELETE: api/examcategarymst/5
        public string Delete(int id)
        {
            Models.Exam_Category_Mst obj = new Models.Exam_Category_Mst();

            string output = obj.DeleteExamCategary(id);

            return output;
        }
    }
}
