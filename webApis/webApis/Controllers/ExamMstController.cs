using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class ExamMstController : ApiController
    {
        // POST: api/exammst/5
        public string Get(int id)
        {

            Models.Exam_Mst obj = new Models.Exam_Mst();

            string output = obj.GetExam(id);

            return output;

        }

        // POST: api/exammst
        public string Get()
        {
            Models.Exam_Mst obj = new Models.Exam_Mst();

            string output = obj.GetAllExam();

            return output;
        }

        // POST: api/exammst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Exam_Mst obj = new Models.Exam_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_name=jsonArr.exam_name;
            int exam_category_id = jsonArr.exam_category_id;
            int level_id = jsonArr.level_id;
            int exam_type_id = jsonArr.exam_type_id;
            int customer_id = jsonArr.customer_id;
            string question_categories = jsonArr.question_categories;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddExam(exam_name,exam_category_id,level_id,exam_type_id,customer_id,question_categories,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/exammst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Exam_Mst obj = new Models.Exam_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_name = jsonArr.exam_name;
            int exam_category_id = jsonArr.exam_category_id;
            int level_id = jsonArr.level_id;
            int exam_type_id = jsonArr.exam_type_id;
            int customer_id = jsonArr.customer_id;
            string question_categories = jsonArr.question_categories;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditExam(id, exam_name, exam_category_id, level_id, exam_type_id, customer_id, question_categories, user_id);

            return output;
        }

        // DELETE: api/exammst/5
        public string Delete(int id)
        {
            Models.Exam_Mst obj = new Models.Exam_Mst();

            string output = obj.DeleteExam(id);

            return output;
        }
    }
}