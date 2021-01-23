$(document).ready(function () {
    //alert("Hello");
    country_list();
    state_list();
    city_list();
    area_list();
    company_info_list();

    $("#btnSave").click(function () {

        var comp_name = /^[a-zA-Z]+$/;
        var comp_add = /^[a-zA-Z0-9]+$/;
        var comp_em = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if (!comp_name.test($("#txtCompany_Name").val())) {
            alert("Enter valid Company Name...!");
        }
        else if (!comp_add.test($("#txtCompany_Address").val())) {
            alert("Enter valid Company Address...!");
        }
        else if (!comp_em.test($("#txtCompany_Email").val())) {
            alert("Enter valid Company Email Address...!");
        }
        else {

            var requestData = '[{"company_name":"' + $("#txtCompany_Name").val() + '","company_address":"' + $("#txtCompany_Address").val() + '","company_pincode":"' + $("#txtCustomer_Pincode").val() + '","company_country_id":"' + $("#cmboCountryList").val() + '","company_state_id":"' + $("#cmboStateList").val() + '","company_city_id":"' + $("#cmboCityList").val() + '","company_area_id":"' + $("#cmboAreaList").val() + '","company_email":"' + $("#txtCompany_Email").val() + '","company_contact_person":"' + $("#txtCompany_Contact_Person").val() + '","company_contact_no":"' + $("#txtCompany_Contact_No").val() + '","company_fax_no":"' + $("#txtCompany_Fax_No").val() + '","company_pan_no":"' + $("#txtCompany_Pan_No").val() + '","company_registration_no":"' + $("#txtCompany_Registration_No").val() + '","company_gstin_no":"' + $("#txtCompany_GST_In").val() + '","company_logo":"' + $("#txtCompany_Logo").val() + '","company_bank_id":"' + $("#txtCompany_Bank_Id").val() + '","company_bank_branch_id":"' + $("#txtCompany_Bank_Branch_Id").val() + '","company_bank_ifsc":"' + $("#txtCompany_Branch_IFSC").val() + '","company_account_no":"' + $("#txtCompany_Account_No").val() + '","company_cin_no":"' + $("#txtCompany_CIN_No").val() + '","company_cst_no":"' + $("#txtCompany_CST_No").val() + '","user_id":"11"}]';

            $.ajax({
                type: "POST",
                url: "https://trial.spyderxindia.com/api/companyinfo",
                data: JSON.stringify(requestData),
                contentType: "application/json",
                //datatype: "json",
                success: function (responseFromServer) {
                    alert(responseFromServer);
                    company_info_list();
                }
            });
        }
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"company_name":"' + $("#txtCompany_Name").val() + '","company_address":"' + $("#txtCompany_Address").val() + '","company_pincode":"' + $("#txtCustomer_Pincode").val() + '","company_country_id":"' + $("#cmboCountryList").val() + '","company_state_id":"' + $("#cmboStateList").val() + '","company_city_id":"' + $("#cmboCityList").val() + '","company_area_id":"' + $("#cmboAreaList").val() + '","company_email":"' + $("#txtCompany_Email").val() + '","company_contact_person":"' + $("#txtCompany_Contact_Person").val() + '","company_contact_no":"' + $("#txtCompany_Contact_No").val() + '","company_fax_no":"' + $("#txtCompany_Fax_No").val() + '","company_pan_no":"' + $("#txtCompany_Pan_No").val() + '","company_registration_no":"' + $("#txtCompany_Registration_No").val() + '","company_gstin_no":"' + $("#txtCompany_GST_In").val() + '","company_logo":"' + $("#txtCompany_Logo").val() + '","company_bank_id":"' + $("#txtCompany_Bank_Id").val() + '","company_bank_branch_id":"' + $("#txtCompany_Bank_Branch_Id").val() + '","company_bank_ifsc":"' + $("#txtCompany_Branch_IFSC").val() + '","company_account_no":"' + $("#txtCompany_Account_No").val() + '","company_cin_no":"' + $("#txtCompany_CIN_No").val() + '","company_cst_no":"' + $("#txtCompany_CST_No").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/companyinfo/" + $("#txtCompanyId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                company_info_list();

            }
        });
    });



});



function company_info_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/companyinfo/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/companyinfo",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Company Name</th><th>Company Address</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].company_name;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].company_address;
                tbl += "</td>";
                tbl += "<td>";
                tbl += "<i type='button' class='fa fa-trash btn-danger'  onclick='del(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "<td>";
                tbl += "<i type='button' class='fa fa-edit btn-warning' onclick='update(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstCompanyList").html(tbl);

        }
    });

}

function area_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/areamst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].area_name;
                cmbOptions += "</option>";
            }
            $("#cmboAreaList").html(cmbOptions);

        }
    });

}

function city_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/citymst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].city_name;
                cmbOptions += "</option>";
            }
            $("#cmboCityList").html(cmbOptions);

        }
    });

}

function state_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/statemst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].state_name;
                cmbOptions += "</option>";
            }
            $("#cmboStateList").html(cmbOptions);

        }
    });

}

function country_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/countrymst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].country_name;
                cmbOptions += "</option>";
            }
            $("#cmboCountryList").html(cmbOptions);

        }
    });

}


function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/companyinfo/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/companyinfo/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtCompanyId").val(jsonData[0].index_id);
                $("#txtCompany_Name").val(jsonData[0].company_name);
                $("#txtCompany_Address").val(jsonData[0].company_address);
                $("#txtCustomer_Pincode").val(jsonData[0].company_pincode);
                $("#txtCompany_Email").val(jsonData[0].company_email);
                $("#txtCompany_Contact_Person").val(jsonData[0].company_contact_person);
                $("#txtCompany_Contact_No").val(jsonData[0].company_contact_no);
                $("#txtCompany_Fax_No").val(jsonData[0].company_fax_no);
                $("#txtCompany_Pan_No").val(jsonData[0].company_pan_no);
                $("#txtCompany_Registration_No").val(jsonData[0].company_registration_no);
                $("#txtCompany_GST_In").val(jsonData[0].company_gstin_no);
                $("#txtCompany_Logo").val(jsonData[0].company_logo);
                $("#txtCompany_Bank_Id").val(jsonData[0].company_bank_id);
                $("#txtCompany_Bank_Branch_Id").val(jsonData[0].company_bank_branch_id);
                $("#txtCompany_Branch_IFSC").val(jsonData[0].company_bank_ifsc);
                $("#txtCompany_Account_No").val(jsonData[0].company_account_no);
                $("#txtCompany_CIN_No").val(jsonData[0].company_cin_no);
                $("#txtCompany_CST_No").val(jsonData[0].company_cst_no);
            }
            company_info_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/companyinfo/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/companyinfo/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                company_info_list();


            }
        });
    }

}