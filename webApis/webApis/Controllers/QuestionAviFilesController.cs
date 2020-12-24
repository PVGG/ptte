using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public string Post([FromBody]string value)
        {
            Models.Question_Avi_Files obj = new Models.Question_Avi_Files();
            Models.CommonFunction objCommon = new Models.CommonFunction();
            string max_id = objCommon.getMaxCount("Max", "question_avi_files", "index_id");
            int max_inr_id = Int16.Parse(max_id) + 1;
            string file_name = "QAVF_" + Convert.ToString(max_inr_id);

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string filePath = "";
            if (Convert.ToString(jsonArr.avi_file_url) != "")
            {
                string root_dir = System.Web.HttpContext.Current.Server.MapPath("~/question_avi_file");


                try
                {
                    string baseData = Convert.ToString(jsonArr.av_url);
                    string base64 = baseData.Split(',')[1];
                    string content_data = baseData.Split(',')[0];
                    string content_type_info = content_data.Split(';')[0];
                    string content_type = content_type_info.Split('/')[1];
                    if (content_type.Equals("x-msvideo"))
                    {
                        filePath = file_name + "." + "avi";
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
            int question_id = jsonArr.question_id;
            int file_type = jsonArr.file_type;
            string avi_file_url = filePath;
            // string av_url = jsonArr.av_url;
            int user_id = jsonArr.user_id;

            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddQuestionAviFile(question_id, file_type, avi_file_url, user_id);
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

            Models.CommonFunction objCommon = new Models.CommonFunction();
            string av_url_file_name = objCommon.getValueById("Select", "question_avi_files", "avi_file_url", "index_id", id.ToString());
            if (av_url_file_name.Equals("") && Convert.ToString(jsonArr.avi_file_url) != "")
            {
                av_url_file_name = "QAVF_" + id.ToString();
            }


            string filePath = av_url_file_name;
            if (Convert.ToString(jsonArr.avi_file_url) != "")
            {
                string root_dir = System.Web.HttpContext.Current.Server.MapPath("~/question_avi_file");


                try
                {
                    string baseData = Convert.ToString(jsonArr.av_url);
                    string base64 = baseData.Split(',')[1];
                    string content_data = baseData.Split(',')[0];
                    string content_type_info = content_data.Split(';')[0];
                    string content_type = content_type_info.Split('/')[1];
                    if (content_type.Equals("x-msvideo"))
                    {
                        string file_name = av_url_file_name.Split('.')[0];
                        filePath = file_name + "." + "avi";
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


            int question_id = jsonArr.question_id;
            int file_type = jsonArr.file_type;
            string avi_file_url = filePath;
            //string av_url = jsonArr.av_url;
            int user_id = jsonArr.user_id;

            string output = obj.EditQuestionAviFile(id, question_id, file_type, avi_file_url, user_id);

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
