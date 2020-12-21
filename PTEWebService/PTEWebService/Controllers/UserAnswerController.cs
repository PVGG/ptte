using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class UserAnswerController : ApiController
    {
        // POST: api/useranswer/5
        public string Get(int id)
        {
            
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            string output = obj.GetExamType(id);

            return output;

        }

        // POST: api/useranswer
        public string Get()
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            string output = obj.GetAllExamType();

            return output;
        }

        // POST: api/useranswer
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_type_name = jsonArr.exam_type_name;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddExamType(exam_type_name);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/useranswer/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_type_name = jsonArr.exam_type_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditExamType(id, exam_type_name);

            return output;
        }

        // DELETE: api/useranswer/5
        public string Delete(int id)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            string output = obj.DeleteExamType(id);

            return output;
        }
    }
}
