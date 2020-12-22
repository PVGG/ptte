using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class QuestionCategaryMstController : ApiController
    {
        // GET: api/questioncategarymst/5
        public string Get(int id)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            string output = obj.GetQuestionCategary(id);

            return output;

        }

        // GET: api/questioncategarymst
        public string Get()
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            string output = obj.GetAllQuestionCategary();

            return output;
        }

        // POST: api/questioncategarymst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

          //  int index_id = jsonArr.index_id;
            int module_id = jsonArr.module_id;
            string question_category_name = jsonArr.question_category_name;
            string av_url = jsonArr.av_url;
            string notes = jsonArr.notes;
            string instructions = jsonArr.instructions;
            int user_id = jsonArr.user_id;

            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddQuestionCategary(module_id,question_category_name,av_url,notes,instructions,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/questioncategarymst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //string module_name = jsonArr.module_name;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");
            //int index_id = jsonArr.index_id;
            int module_id = jsonArr.module_id;
            string question_category_name = jsonArr.question_category_name;
            string av_url = jsonArr.av_url;
            string notes = jsonArr.notes;
            string instructions = jsonArr.instructions;
            int user_id = jsonArr.user_id;



            string output = obj.EditQuestionCategary(id, module_id, question_category_name, av_url, notes, instructions, user_id);

            return output;
        }

        // DELETE: api/questioncategarymst/5
        public string Delete(int id)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            string output = obj.DeleteQuestionCategary(id);

            return output;
        }
    }
}
