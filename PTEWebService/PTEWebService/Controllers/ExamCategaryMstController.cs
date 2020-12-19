using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
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
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddExamCategary(exam_category_name);
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
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditExamCategary(id, exam_category_name);

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
