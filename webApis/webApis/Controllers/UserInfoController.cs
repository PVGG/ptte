using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class UserInfoController : ApiController
    {
        // POST: api/userinfo/5
        public string Get(int id)
        {
            Models.User_Info obj = new Models.User_Info();

            string output = obj.GetUserInfo(id);

            return output;

        }

        // POST: api/userinfo
        public string Get()
        {
            Models.User_Info obj = new Models.User_Info();

            string output = obj.GetAllUserInfo();

            return output;
        }

        // POST: api/userinfo
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.User_Info obj = new Models.User_Info();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string user_code = jsonArr.user_code;
            string user_name = jsonArr.user_name;
            string user_full_name = jsonArr.user_full_name;
            string password = jsonArr.password;
            int user_role_id = jsonArr.user_role_id;
            string user_email = jsonArr.user_email;
            string user_mobile_no = jsonArr.user_mobile_no;
            string user_photo = jsonArr.user_photo;
            int is_approved = jsonArr.is_approved;
            int is_locked = jsonArr.is_locked;
            int user_failed_password_attempt_count = jsonArr.user_failed_password_attempt_count;
            int parent_id = jsonArr.parent_id;
            int customer_id = jsonArr.customer_id;
            string locked_reason = jsonArr.locked_reason;
            int user_id = jsonArr.user_id;


            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddUserInfo(user_code,user_name,user_full_name, password,user_role_id,user_email,user_mobile_no,user_photo,is_approved,is_locked,user_failed_password_attempt_count,parent_id,customer_id,locked_reason,user_id);
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/userinfo/5
        public string Put(int id, [FromBody]string value)
        {
            Models.User_Info obj = new Models.User_Info();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string user_code = jsonArr.user_code;
            string user_name = jsonArr.user_name;
            string user_full_name = jsonArr.user_full_name;
            string password = jsonArr.password;
            int user_role_id = jsonArr.user_role_id;
            string user_email = jsonArr.user_email;
            string user_mobile_no = jsonArr.user_mobile_no;
            string user_photo = jsonArr.user_photo;
            int is_approved = jsonArr.is_approved;
            int is_locked = jsonArr.is_locked;
            int user_failed_password_attempt_count = jsonArr.user_failed_password_attempt_count;
            int parent_id = jsonArr.parent_id;
            int customer_id = jsonArr.customer_id;
            string locked_reason = jsonArr.locked_reason;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditUserInfo(id,user_code, user_name, user_full_name, password, user_role_id, user_email, user_mobile_no, user_photo, is_approved, is_locked, user_failed_password_attempt_count, parent_id, customer_id, locked_reason, user_id);

            return output;
        }

        // DELETE: api/userinfo/5
        public string Delete(int id)
        {
            Models.User_Info obj = new Models.User_Info();

            string output = obj.DeleteUserInfo(id);

            return output;
        }
    }
}