using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTEWebService.Controllers
{
    public class CompanyInfoController : ApiController
    {
        // POST: api/companyinfo/5
        public string Get(int id)
        {
            Models.Company_Info obj = new Models.Company_Info();

            string output = obj.GetCompany(id);

            return output;

        }

        // POST: api/companyinfo
        public string Get()
        {
            Models.Company_Info obj = new Models.Company_Info();

            string output = obj.GetAllCompany();

            return output;
        }

        // POST: api/companyinfo
        //public string GetValss(int id,string value)
        //public string Post([FromBody]string value)
        public string Post([FromBody]string value)
        {
            Models.Company_Info obj = new Models.Company_Info();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            //string role_name = jsonArr.role_name;


            string company_name = jsonArr.company_name;
            string company_address = jsonArr.company_address;
            string company_pincode = jsonArr.company_pincode;
            int company_country_id = jsonArr.company_country_id;
            int company_state_id = jsonArr.company_state_id;
            int company_city_id = jsonArr.company_city_id;
            int company_area_id = jsonArr.company_area_id;
            string company_email = jsonArr.company_email;
            string cucompany_contact_person = jsonArr.cucompany_contact_person;
            string company_contact_no = jsonArr.company_contact_no;
            string company_fax_no = jsonArr.company_fax_no;
            string company_pan_no = jsonArr.company_pan_no;
            string company_registration_no = jsonArr.company_registration_no;
            string company_gstin_no = jsonArr.company_gstin_no;
            string company_logo = jsonArr.company_logo;
            int company_bank_id = jsonArr.company_bank_id;
            int company_bank_branch_id = jsonArr.company_bank_branch_id;
            string company_bank_ifsc = jsonArr.company_bank_ifsc;
            string company_account_no = jsonArr.company_account_no;
            string company_cin_no = jsonArr.company_cin_no;
            string company_cst_no = jsonArr.company_cst_no;
            int user_id = jsonArr.user_id;



            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.AddCompany(
                  company_name,
         company_address,
         company_pincode,
         company_country_id,
         company_state_id,
         company_city_id,
         company_area_id,
         company_email,
         cucompany_contact_person,
         company_contact_no,
         company_fax_no,
         company_pan_no,
         company_registration_no,
         company_gstin_no,
         company_logo,
         company_bank_id,
         company_bank_branch_id,
         company_bank_ifsc,
         company_account_no,
         company_cin_no,
         company_cst_no,
         user_id
                );
            //return id.ToString();
            return output;
            //return value;
        }

        // PUT: api/companyinfo/5
        public string Put(int id, [FromBody]string value)
        {
            Models.Company_Info obj = new Models.Company_Info();

            dynamic jsonArrs = JArray.Parse(value);

            dynamic jsonArr = jsonArrs[0];

            string company_name = jsonArr.company_name;
            string company_address = jsonArr.company_address;
            string company_pincode = jsonArr.company_pincode;
            int company_country_id = jsonArr.company_country_id;
            int company_state_id = jsonArr.company_state_id;
            int company_city_id = jsonArr.company_city_id;
            int company_area_id = jsonArr.company_area_id;
            string company_email = jsonArr.company_email;
            string cucompany_contact_person = jsonArr.cucompany_contact_person;
            string company_contact_no = jsonArr.company_contact_no;
            string company_fax_no = jsonArr.company_fax_no;
            string company_pan_no = jsonArr.company_pan_no;
            string company_registration_no = jsonArr.company_registration_no;
            string company_gstin_no = jsonArr.company_gstin_no;
            string company_logo = jsonArr.company_logo;
            int company_bank_id = jsonArr.company_bank_id;
            int company_bank_branch_id = jsonArr.company_bank_branch_id;
            string company_bank_ifsc = jsonArr.company_bank_ifsc;
            string company_account_no = jsonArr.company_account_no;
            string company_cin_no = jsonArr.company_cin_no;
            string company_cst_no = jsonArr.company_cst_no;
            int user_id = jsonArr.user_id;
            //int index_id = jsonArr.index_id;
            //JSONArray ja_data = json.getJSONArray("data");

            string output = obj.EditCompany(id,
                company_name,
         company_address,
         company_pincode,
         company_country_id,
         company_state_id,
         company_city_id,
         company_area_id,
         company_email,
         cucompany_contact_person,
         company_contact_no,
         company_fax_no,
         company_pan_no,
         company_registration_no,
         company_gstin_no,
         company_logo,
         company_bank_id,
         company_bank_branch_id,
         company_bank_ifsc,
         company_account_no,
         company_cin_no,
         company_cst_no,
         user_id
                );

            return output;
        }

        // DELETE: api/companyinfo/5
        public string Delete(int id)
        {
            Models.Company_Info obj = new Models.Company_Info();

            string output = obj.DeleteCompany(id);

            return output;
        }
    }
}