using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PTEWebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST,PUT,DELETE")]
    public class CustomerMstController : ApiController
    {
        // POST: api/customermst/5
        public string Get(int id)
        {
            Models.Customer_Mst obj = new Models.Customer_Mst();

            string output = obj.GetCustomer(id);

            return output;

        }

        // POST: api/customermst
        public string Get()
        {
            Models.Customer_Mst obj = new Models.Customer_Mst();

            string output = obj.GetAllCustomer();

            return output;
        }

        // POST: api/customermst
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Customer_Mst obj = new Models.Customer_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //string role_name = jsonArr.role_name;


            string customer_name = jsonArr.customer_name;
            string customer_address = jsonArr.customer_address;
            string customer_contact_no = jsonArr.customer_contact_no;
            string customer_pincode = jsonArr.customer_pincode;
            int customer_country_id = jsonArr.customer_country_id;
            int customer_state_id = jsonArr.customer_state_id;
            int customer_city_id = jsonArr.customer_city_id;
            int customer_zone_id = jsonArr.customer_zone_id;
            int customer_area_id = jsonArr.customer_area_id;
            string customer_email = jsonArr.customer_email;
            string customer_contact_person = jsonArr.customer_contact_person;
            string customer_registration_no = jsonArr.customer_registration_no;
            string customer_gstin = jsonArr.customer_gstin;
            string customer_logo = jsonArr.customer_logo;
            int customer_bank_id = jsonArr.customer_bank_id;
            int customer_bank_branch_id = jsonArr.customer_bank_branch_id;
            string customer_branch_ifsc = jsonArr.customer_branch_ifsc;
            string customer_account_no = jsonArr.customer_account_no;
            string customer_first_subscription_date = jsonArr.customer_first_subscription_date;
            int parent_id = jsonArr.parent_id;
            int user_id = jsonArr.user_id;



            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddCustomer(
                 customer_name,
         customer_address,
         customer_contact_no,
         customer_pincode,
         customer_country_id,
         customer_state_id,
         customer_city_id,
         customer_zone_id,
         customer_area_id,
         customer_email,
         customer_contact_person,
         customer_registration_no,
         customer_gstin,
         customer_logo,
         customer_bank_id,
         customer_bank_branch_id,
         customer_branch_ifsc,
         customer_account_no,
         customer_first_subscription_date,
         parent_id,
          user_id
                );
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/customermst/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Customer_Mst obj = new Models.Customer_Mst();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string customer_name = jsonArr.customer_name;
            string customer_address = jsonArr.customer_address;
            string customer_contact_no = jsonArr.customer_contact_no;
            string customer_pincode = jsonArr.customer_pincode;
            int customer_country_id = jsonArr.customer_country_id;
            int customer_state_id = jsonArr.customer_state_id;
            int customer_city_id = jsonArr.customer_city_id;
            int customer_zone_id = jsonArr.customer_zone_id;
            int customer_area_id = jsonArr.customer_area_id;
            string customer_email = jsonArr.customer_email;
            string customer_contact_person = jsonArr.customer_contact_person;
            string customer_registration_no = jsonArr.customer_registration_no;
            string customer_gstin = jsonArr.customer_gstin;
            string customer_logo = jsonArr.customer_logo;
            int customer_bank_id = jsonArr.customer_bank_id;
            int customer_bank_branch_id = jsonArr.customer_bank_branch_id;
            string customer_branch_ifsc = jsonArr.customer_branch_ifsc;
            string customer_account_no = jsonArr.customer_account_no;
            string customer_first_subscription_date = jsonArr.customer_first_subscription_date;
            int parent_id = jsonArr.parent_id;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditCustomer(id,
                customer_name,
         customer_address,
         customer_contact_no,
         customer_pincode,
         customer_country_id,
         customer_state_id,
         customer_city_id,
         customer_zone_id,
         customer_area_id,
         customer_email,
         customer_contact_person,
         customer_registration_no,
         customer_gstin,
         customer_logo,
         customer_bank_id,
         customer_bank_branch_id,
         customer_branch_ifsc,
         customer_account_no,
         customer_first_subscription_date,
         parent_id,
          user_id
                );

            return output;
        }

        // DELETE: api/customermst/5
        public string Delete(int id)
        {
            Models.Customer_Mst obj = new Models.Customer_Mst();

            string output = obj.DeleteCustomer(id);

            return output;
        }
    }
}