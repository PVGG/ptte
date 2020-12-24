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

            Models.User_Answer obj = new Models.User_Answer();

            string output = obj.GetUserAnswer(id);

            return output;

        }

        // POST: api/useranswer
        public string Get()
        {
            Models.User_Answer obj = new Models.User_Answer();

            string output = obj.GetAllUserAnswer();

            return output;
        }

        // POST: api/useranswer
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.User_Answer obj = new Models.User_Answer();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int exam_id = jsonArr.exam_id;
            int question_id = jsonArr.question_id;
            int user_id = jsonArr.user_id;
            string answer = jsonArr.answer;
            int total_record_time = jsonArr.total_record_time;
            string answer_submitted_date_time = jsonArr.answer_submitted_date_time;
            int created_by_id = jsonArr.created_by_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddUserAnswer(exam_id,question_id,user_id,answer,total_record_time,answer_submitted_date_time,created_by_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/useranswer/5
        public string Put(int id, [FromBody]string value)
        {
            Models.User_Answer obj = new Models.User_Answer();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int exam_id = jsonArr.exam_id;
            int question_id = jsonArr.question_id;
            int user_id = jsonArr.user_id;
            string answer = jsonArr.answer;
            int total_record_time = jsonArr.total_record_time;
            string answer_submitted_date_time = jsonArr.answer_submitted_date_time;
            int created_by_id = jsonArr.created_by_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditUserAnswer(id, exam_id, question_id, user_id, answer, total_record_time, answer_submitted_date_time, created_by_id);

            return output;
        }

        // DELETE: api/useranswer/5
        public string Delete(int id)
        {
            Models.User_Answer obj = new Models.User_Answer();

            string output = obj.DeleteUserAnswer(id);

            return output;
        }
    }
}
