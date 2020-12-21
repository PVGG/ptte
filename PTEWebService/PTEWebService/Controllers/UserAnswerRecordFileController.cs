using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class UserAnswerRecordFileController : ApiController
    {
        // POST: api/useranswerrecordfile/5
        public string Get(int id)
        {

            Models.User_Answer_Record_File obj = new Models.User_Answer_Record_File();

            string output = obj.GetUserAnswerRecordFile(id);

            return output;

        }

        // POST: api/useranswerrecordfile
        public string Get()
        {
            Models.User_Answer_Record_File obj = new Models.User_Answer_Record_File();

            string output = obj.GetAllUserAnswerRecordFile();

            return output;
        }

        // POST: api/useranswerrecordfile
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.User_Answer_Record_File obj = new Models.User_Answer_Record_File();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int exam_id = jsonArr.exam_id;
            int question_id = jsonArr.question_id;
            int user_id = jsonArr.user_id;
            string av_file_url = jsonArr.av_file_url;
            int duration_of_file = jsonArr.duration_of_file;
            string recorded_date_time = jsonArr.recorded_date_time;
            int created_by_id = jsonArr.created_by_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddUserAnswerRecordFile(exam_id, question_id, user_id, av_file_url, duration_of_file, recorded_date_time, created_by_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/useranswerrecordfile/5
        public string Put(int id, [FromBody]string value)
        {
            Models.User_Answer_Record_File obj = new Models.User_Answer_Record_File();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int exam_id = jsonArr.exam_id;
            int question_id = jsonArr.question_id;
            int user_id = jsonArr.user_id;
            string av_file_url = jsonArr.av_file_url;
            int duration_of_file = jsonArr.duration_of_file;
            string recorded_date_time = jsonArr.recorded_date_time;
            int created_by_id = jsonArr.created_by_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditUserAnswerRecordFile(id, exam_id, question_id, user_id, av_file_url, duration_of_file, recorded_date_time, created_by_id);

            return output;
        }

        // DELETE: api/useranswerrecordfile/5
        public string Delete(int id)
        {
            Models.User_Answer_Record_File obj = new Models.User_Answer_Record_File();

            string output = obj.DeleteUserAnswerRecordFile(id);

            return output;
        }
    }
}