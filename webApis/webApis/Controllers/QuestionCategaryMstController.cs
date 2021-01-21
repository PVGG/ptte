using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PTEWebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE")]
    public class QuestionCategaryMstController : ApiController
    {
        // GET: api/questioncategarymst/5
        public string Get(int id)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            string output = obj.GetQuestionCategary(id);

            return output;

        }

        // GET: api/questioncategarymst/5/0
        public string Get(int id,int flage)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();

            string output = obj.GetQuestionCategaryByModuleId(id);

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
        public string Post([FromBody]string value)
        {
            Models.Question_Category_Mst obj = new Models.Question_Category_Mst();
            Models.CommonFunction objCommon = new Models.CommonFunction();
            string max_id = objCommon.getMaxCount("Max", "question_category_mst", "index_id");
            int max_inr_id = Int16.Parse(max_id) + 1;
            string file_name = "QCM_" + Convert.ToString(max_inr_id);

            dynamic jsonArrs = JArray.Parse(value);
            dynamic jsonArr = jsonArrs[0];

            string filePath = "";
            if (Convert.ToString(jsonArr.av_url) != "")
            {
                string root_dir = System.Web.HttpContext.Current.Server.MapPath("~/categary_av_file");


                try
                {
                    string baseData = Convert.ToString(jsonArr.av_url);
                    string base64 = baseData.Split(',')[1];
                    string content_data = baseData.Split(',')[0];
                    string content_type_info = content_data.Split(';')[0];
                    string content_type = content_type_info.Split('/')[1];
                    if (content_type.Equals("avi"))
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
            int module_id = jsonArr.module_id;
            string question_category_name = jsonArr.question_category_name;
            string av_url = filePath;
            string notes = jsonArr.notes;
            string instructions = jsonArr.instructions;
            int user_id = jsonArr.user_id;

            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddQuestionCategary(module_id, question_category_name, av_url, notes, instructions, user_id);
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

            Models.CommonFunction objCommon = new Models.CommonFunction();
            string av_url_file_name = objCommon.getValueById("Select", "question_category_mst", "av_url","index_id", id.ToString());
            if (av_url_file_name.Equals("") && Convert.ToString(jsonArr.av_url) != "")
            {
                av_url_file_name = "QCM_" + id.ToString();
            }

            string filePath = av_url_file_name;
            if (Convert.ToString(jsonArr.av_url) != "")
            {
                string root_dir = System.Web.HttpContext.Current.Server.MapPath("~/categary_av_file");


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
            string question_category_name = jsonArr.question_category_name;
            string av_url = filePath;
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
