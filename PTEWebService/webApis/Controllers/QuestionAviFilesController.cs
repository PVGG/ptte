using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class QuestionAviFilesController : ApiController
    {
        // GET: api/questionavifiles/5
        public string Get(int id)
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();

            string output = obj.GetQuestionAviFile(id);

            return output;

        }

        // GET: api/questionavifiles
        public string Get()
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();

            string output = obj.GetAllQuestionAviFile();

            return output;
        }

        // GET: api/questionavifiles/5/0
        public string Get(int question_id, int flage = 0)
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();

            string output = obj.GetQuestionAviFileByQuestionId(question_id);

            return output;

        }

        // POST: api/questionavifiles
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //  int index_id = jsonArr.index_id;
            int question_id = jsonArr.question_id;
            int file_type=jsonArr.file_type;
            string avi_file_url = jsonArr.avi_file_url;
            string av_url = jsonArr.av_url;
            int user_id = jsonArr.user_id;

            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddQuestionAviFile(question_id,file_type,avi_file_url,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/questionavifiles/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //string module_name = jsonArr.module_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");
            //int index_id = jsonArr.index_id;
            int question_id = jsonArr.question_id;
            int file_type = jsonArr.file_type;
            string avi_file_url = jsonArr.avi_file_url;
            string av_url = jsonArr.av_url;
            int user_id = jsonArr.user_id;
            
            string output = obj.EditQuestionAviFile(id,question_id,file_type,avi_file_url,user_id);

            return output;
        }

        // DELETE: api/questionavifiles/5
        public string Delete(int id)
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();

            string output = obj.DeleteQuestionAviFile(id);

            return output;
        }
    }
}
