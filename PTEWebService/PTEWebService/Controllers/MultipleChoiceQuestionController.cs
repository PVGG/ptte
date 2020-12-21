using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class MultipleChoiceQuestionController : ApiController
    {
        // POST: api/multiplechoicequestion/5
        public string Get(int id)
        {
            Models.Multiple_Choice_Question obj = new Models.Multiple_Choice_Question();

            string output = obj.GetMultipleChoiceQuestion(id);

            return output;

        }

        // POST: api/multiplechoicequestion
        public string Get()
        {
            Models.Multiple_Choice_Question obj = new Models.Multiple_Choice_Question();

            string output = obj.GetAllMultipleChoiceQuestion();

            return output;
        }

        // POST: api/multiplechoicequestion
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Multiple_Choice_Question obj = new Models.Multiple_Choice_Question();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //string role_name = jsonArr.role_name;
            int question_id = jsonArr.question_id;
            string option_one = jsonArr.option_one;
            string option_two = jsonArr.option_two;
            string option_three = jsonArr.option_three;
            string option_four = jsonArr.option_four;
            int correct_option = jsonArr.correct_option;
            int user_id = jsonArr.user_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddMultipleChoiceQuestion(question_id,option_one,option_two,option_three,option_four,correct_option,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/multiplechoicequestion/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Multiple_Choice_Question obj = new Models.Multiple_Choice_Question();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            int question_id = jsonArr.question_id;
            string option_one = jsonArr.option_one;
            string option_two = jsonArr.option_two;
            string option_three = jsonArr.option_three;
            string option_four = jsonArr.option_four;
            int correct_option = jsonArr.correct_option;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditMultipleChoiceQuestion(id, question_id, option_one, option_two, option_three, option_four, correct_option, user_id);

            return output;
        }

        // DELETE: api/multiplechoicequestion/5
        public string Delete(int id)
        {
            Models.Multiple_Choice_Question obj = new Models.Multiple_Choice_Question();

            string output = obj.DeleteMultipleChoiceQuestion(id);

            return output;
        }
    }
}