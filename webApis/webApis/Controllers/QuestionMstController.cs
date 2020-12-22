using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class QuestionMstController : ApiController
    {
        // GET: api/questionmst/5
        public string Get(int id)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            string output = obj.GetQuestion(id);

            return output;

        }

        // GET: api/questionmst
        public string Get()
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            string output = obj.GetAllQuestion();

            return output;
        }

        // GET: api/questionmst/5/0
       /* public string Get(int question_id, int flage = 0)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            string output = obj.GetQuestionAviFileByQuestionId(question_id);

            return output;

        }*/

        // POST: api/questionavifiles
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //  int index_id = jsonArr.index_id;
            int module_id = jsonArr.module_id;
            int question_category_id = jsonArr.question_category_id;
            int customer_id = jsonArr.customer_id;
            int level_id = jsonArr.level_id;
            string avi_file_url = jsonArr.avi_file_url;
            int record_begin_time = jsonArr.record_begin_time;
            int recording_time = jsonArr.recording_time;
            int wait_time = jsonArr.wait_time;
            string excerpt = jsonArr.excerpt;
            string instruction = jsonArr.instruction;
            string description = jsonArr.description;
            string question = jsonArr.question;
            string answer = jsonArr.answer;
            int user_id = jsonArr.user_id;

            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddQuestion(module_id,question_category_id,customer_id,level_id,avi_file_url,record_begin_time,recording_time,wait_time,excerpt,instruction,description,question,answer,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/questionavifiles/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int module_id = jsonArr.module_id;
            int question_category_id = jsonArr.question_category_id;
            int customer_id = jsonArr.customer_id;
            int level_id = jsonArr.level_id;
            string avi_file_url = jsonArr.avi_file_url;
            int record_begin_time = jsonArr.record_begin_time;
            int recording_time = jsonArr.recording_time;
            int wait_time = jsonArr.wait_time;
            string excerpt = jsonArr.excerpt;
            string instruction = jsonArr.instruction;
            string description = jsonArr.description;
            string question = jsonArr.question;
            string answer = jsonArr.answer;
            int user_id = jsonArr.user_id;

            string output = obj.EditQuestion(id, module_id,question_category_id,customer_id,level_id,avi_file_url,record_begin_time,recording_time,wait_time,excerpt,instruction,description,question,answer,user_id);

            return output;
        }

        // DELETE: api/questionmst/5
        public string Delete(int id)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            string output = obj.DeleteQuestion(id);

            return output;
        }
    }
}
