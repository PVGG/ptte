using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class ExamQuestionMstController : ApiController
    {
        // POST: api/examquestionemst/5
        public string Get(int id)
        {
            Models.Exam_Question_Mst obj = new Models.Exam_Question_Mst();

            string output = obj.GetExamQuestion(id);

            return output;

        }

        // POST: api/examquestionemst
        public string Get()
        {
            Models.Exam_Question_Mst obj = new Models.Exam_Question_Mst();

            string output = obj.GetAllExamQuestion();

            return output;
        }

        // POST: api/examquestionemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Exam_Question_Mst obj = new Models.Exam_Question_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //string exam_type_name = jsonArr.exam_type_name;
            //JSONArray ja_data = json.getJSONArray("data");
            int exam_id = jsonArr.exam_id;
            int module_id = jsonArr.module_id;
            int question_category_id = jsonArr.question_category_id;
            int question_id = jsonArr.question_id;
            int user_id = jsonArr.user_id;


            string output = obj.AddExamQuestion(exam_id,module_id,question_category_id,question_id,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/examquestionemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Exam_Question_Mst obj = new Models.Exam_Question_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //String exam_type_name = jsonArr.exam_type_name;

            int exam_id = jsonArr.exam_id;
            int module_id = jsonArr.module_id;
            int question_category_id = jsonArr.question_category_id;
            int question_id = jsonArr.question_id;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditExamQuestion(id, exam_id, module_id, question_category_id, question_id, user_id);

            return output;
        }

        // DELETE: api/examquestionemst/5
        public string Delete(int id)
        {
            Models.Exam_Question_Mst obj = new Models.Exam_Question_Mst();

            string output = obj.DeleteExamQuestion(id);

            return output;
        }
    }
}
