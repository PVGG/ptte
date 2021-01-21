using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PTEWebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE")]
    public class QuestionMstController : ApiController
    {
        // GET: api/questionmst/5
        public string Get(int id)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            string output = obj.GetQuestion(id);

            return output;

        }

        // GET: api/questionmst/5/0
        public string Get(int id, int flage)
        {
            Models.Question_Mst obj = new Models.Question_Mst();

            string output = obj.GetQuestionByCategaryId(id);

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
            Models.CommonFunction objCommon = new Models.CommonFunction();
            string max_id = objCommon.getMaxCount("Max", "question_mst", "index_id");
            int max_inr_id = Int16.Parse(max_id) + 1;
            string file_name = "QM_" + Convert.ToString(max_inr_id);

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string filePath = "";
            if (Convert.ToString(jsonArr.avi_file_url) != "")
            {
                string root_dir = System.Web.HttpContext.Current.Server.MapPath("~/question_mst_avi_file");


                try
                {
                    string baseData = Convert.ToString(jsonArr.avi_file_url);
                    string base64 = baseData.Split(',')[1];
                    string content_data = baseData.Split(',')[0];
                    string content_type_info = content_data.Split(';')[0];
                    string content_type = content_type_info.Split('/')[1];
                    if (content_type.Equals("avi"))
                    {
                        filePath = file_name + "." + "avi";
                    }
                    else if(content_type.Equals("mpeg"))
                    {
                        filePath = file_name + "." + "mp3";
                    }
                    else
                    {
                        filePath = file_name + "." + content_type;
                    }



                    byte[] bytes = Convert.FromBase64String(base64);

                    File.WriteAllBytes(root_dir + "/" + filePath, Convert.FromBase64String(base64));

                    /* using (Image image = Image.FromStream(new MemoryStream(bytes)))
                     {
                         image.Save(root_dir + "/" + filePath, ImageFormat.Png);  // Or Png
                     }
                     */
                    //string ff = jsonArr.av_url;

                    //File.WriteAllBytes(root_dir + "/" + filePath, Convert.FromBase64String(jsonArr.av_url));

                }
                catch (Exception exx)
                {

                }
            }


            //  int index_id = jsonArr.index_id;
            int module_id = jsonArr.module_id;
            int question_category_id = jsonArr.question_category_id;
            int customer_id = jsonArr.customer_id;
            int level_id = jsonArr.level_id;
            string avi_file_url = filePath;
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

            string output = obj.AddQuestion(module_id, question_category_id, customer_id, level_id, avi_file_url, record_begin_time, recording_time, wait_time, excerpt, instruction, description, question, answer, user_id);
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

            Models.CommonFunction objCommon = new Models.CommonFunction();
            string av_url_file_name = objCommon.getValueById("Select", "question_mst", "avi_file_url", "index_id", id.ToString());
            if (av_url_file_name.Equals("") && Convert.ToString(jsonArr.avi_file_url) != "")
            {
                av_url_file_name = "QM_" + id.ToString();
            }


            string filePath = av_url_file_name;
            if (Convert.ToString(jsonArr.avi_file_url) != "")
            {
                string root_dir = System.Web.HttpContext.Current.Server.MapPath("~/question_mst_avi_file");


                try
                {
                    string baseData = Convert.ToString(jsonArr.av_url);
                    string base64 = baseData.Split(',')[1];
                    string content_data = baseData.Split(',')[0];
                    string content_type_info = content_data.Split(';')[0];
                    string content_type = content_type_info.Split('/')[1];
                    if (content_type.Equals("avi"))
                    {
                        string file_name = av_url_file_name.Split('.')[0];
                        filePath = file_name + "." + "avi";
                    }
                    else
                    {
                        string file_name = av_url_file_name.Split('.')[0];
                        filePath = file_name + "." + content_type;
                    }


                    byte[] bytes = Convert.FromBase64String(base64);

                    File.WriteAllBytes(root_dir + "/" + filePath, Convert.FromBase64String(base64));

                    /* using (Image image = Image.FromStream(new MemoryStream(bytes)))
                     {
                         image.Save(root_dir + "/" + filePath, ImageFormat.Png);  // Or Png
                     }
                     */
                    //string ff = jsonArr.av_url;

                    //File.WriteAllBytes(root_dir + "/" + filePath, Convert.FromBase64String(jsonArr.av_url));

                }
                catch (Exception exx)
                {

                }
            }



            int module_id = jsonArr.module_id;
            int question_category_id = jsonArr.question_category_id;
            int customer_id = jsonArr.customer_id;
            int level_id = jsonArr.level_id;
            string avi_file_url = filePath;
            int record_begin_time = jsonArr.record_begin_time;
            int recording_time = jsonArr.recording_time;
            int wait_time = jsonArr.wait_time;
            string excerpt = jsonArr.excerpt;
            string instruction = jsonArr.instruction;
            string description = jsonArr.description;
            string question = jsonArr.question;
            string answer = jsonArr.answer;
            int user_id = jsonArr.user_id;

            string output = obj.EditQuestion(id, module_id, question_category_id, customer_id, level_id, avi_file_url, record_begin_time, recording_time, wait_time, excerpt, instruction, description, question, answer, user_id);

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
