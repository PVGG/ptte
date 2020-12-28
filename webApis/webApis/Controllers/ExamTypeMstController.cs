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
    public class ExamTypeMstController : ApiController
    {
        // POST: api/examtypemst/5
        public string Get(int id)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            string output = obj.GetExamType(id);

            return output;

        }

        // POST: api/examtypemst
        public string Get()
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            string output = obj.GetAllExamType();

            return output;
        }

        // POST: api/examtypemst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_type_name = jsonArr.exam_type_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddExamType(exam_type_name, user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/examtypemst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string exam_type_name = jsonArr.exam_type_name;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditExamType(id, exam_type_name, user_id);

            return output;
        }

        // DELETE: api/examtypemst/5
        public string Delete(int id)
        {
            Models.Exam_Type_Mst obj = new Models.Exam_Type_Mst();

            string output = obj.DeleteExamType(id);

            return output;
        }
    }
}
