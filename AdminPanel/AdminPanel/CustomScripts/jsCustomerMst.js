$(document).ready(function () {
    //alert("Hello");
    country_list();
    zone_list();
    state_list();
    city_list();
    area_list();
    customer_list();

    $("#btnSave").click(function () {

        var cust_name = /^[a-zA-Z]+$/;
        var cust_add = /^[a-zA-Z0-9]+$/;
        var cust_em = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        if (!cust_name.test($("#txtCustomer_Name").val())) {
            alert("Enter valid Customer Name...!");
        }
        else if (!cust_add.test($("#txtCustomer_Address").val())) {
            alert("Enter valid Customer Address...!");
        }
        else if (!cust_em.test($("#txtCustomer_Email").val())) {
            alert("Enter valid Customer Email Address...!");
        }
        else {

            var requestData = '[{"customer_name":"' + $("#txtCustomer_Name").val() + '","customer_address":"' + $("#txtCustomer_Address").val() + '","customer_contact_no":"' + $("#txtCustomer_Contact_No").val() + '","customer_pincode":"' + $("#txtCustomer_Pincode").val() + '","customer_email":"' + $("#txtCustomer_Email").val() + '","customer_contact_person":"' + $("#txtCustomer_Contact_Person").val() + '","customer_registration_no":"' + $("#txtCustomer_Registration_No").val() + '","customer_gstin":"' + $("#txtCustomer_GST_In").val() + '","customer_logo":"' + $("#txtCustomer_Logo").val() + '","customer_bank_id":"' + $("#txtCustomer_Bank_Id").val() + '","customer_bank_branch_id":"' + $("#txtCustomer_Bank_Branch_Id").val() + '","customer_branch_ifsc":"' + $("#txtCustomer_Branch_IFSC").val() + '","customer_account_no":"' + $("#txtCustomer_Account_No").val() + '","customer_first_subscription_date":"' + $("#txtCustomer_First_Subscription_Date").val() + '","parent_id":"' + $("#txtParent_Id").val() + '","customer_country_id":"' + $("#cmboCountryList").val() + '","customer_zone_id":"' + $("#cmboZoneList").val() + '","customer_state_id":"' + $("#cmboStateList").val() + '","customer_city_id":"' + $("#cmboCityList").val() + '","customer_area_id":"' + $("#cmboAreaList").val() + '","user_id":"11"}]';

            $.ajax({
                type: "POST",
                url: "https://trial.spyderxindia.com/api/customermst",
                data: JSON.stringify(requestData),
                contentType: "application/json",
                //datatype: "json",
                success: function (responseFromServer) {
                    alert(responseFromServer);
                    customer_list();
                }
            });
        }
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"customer_name":"' + $("#txtCustomer_Name").val() + '","customer_address":"' + $("#txtCustomer_Address").val() + '","customer_contact_no":"' + $("#txtCustomer_Contact_No").val() + '","customer_pincode":"' + $("#txtCustomer_Pincode").val() + '","customer_email":"' + $("#txtCustomer_Email").val() + '","customer_contact_person":"' + $("#txtCustomer_Contact_Person").val() + '","customer_registration_no":"' + $("#txtCustomer_Registration_No").val() + '","customer_gstin":"' + $("#txtCustomer_GST_In").val() + '","customer_logo":"' + $("#txtCustomer_Logo").val() + '","customer_bank_id":"' + $("#txtCustomer_Bank_Id").val() + '","customer_bank_branch_id":"' + $("#txtCustomer_Bank_Branch_Id").val() + '","customer_branch_ifsc":"' + $("#txtCustomer_Branch_IFSC").val() + '","customer_account_no":"' + $("#txtCustomer_Account_No").val() + '","customer_first_subscription_date":"' + $("#txtCustomer_First_Subscription_Date").val() + '","parent_id":"' + $("#txtParent_Id").val() + '","customer_country_id":"' + $("#cmboCountryList").val() + '","customer_zone_id":"' + $("#cmboZoneList").val() + '","customer_state_id":"' + $("#cmboStateList").val() + '","customer_city_id":"' + $("#cmboCityList").val() + '","customer_area_id":"' + $("#cmboAreaList").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/customermst/" + $("#txtCustomerId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                customer_list();

            }
        });
    });
});



function customer_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/customermst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/customermst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Customer Name</th><th>Customer Address</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].customer_name;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].customer_address;
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
            $("#lstCustomerList").html(tbl);

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

function zone_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/zonemst",
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
                cmbOptions += jsonData[iCount].zone_name;
                cmbOptions += "</option>";
            }
            $("#cmboZoneList").html(cmbOptions);

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
        //url: "https://trial.spyderxindia.com/api/customermst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/customermst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtCustomerId").val(jsonData[0].index_id);
                $("#txtCustomer_Name").val(jsonData[0].customer_name);
                $("#txtCustomer_Address").val(jsonData[0].customer_address);
                $("#txtCustomer_Contact_No").val(jsonData[0].customer_contact_no);
                $("#txtCustomer_Pincode").val(jsonData[0].customer_pincode);
                $("#cmboCountryList").val(jsonData[0].customer_country_name);
                $("#txtCustomer_Email").val(jsonData[0].customer_email);
                $("#txtCustomer_Contact_Person").val(jsonData[0].customer_contact_person);
                $("#txtCustomer_Registration_No").val(jsonData[0].customer_registration_no);
                $("#txtCustomer_GST_In").val(jsonData[0].customer_gstin);
                $("#txtCustomer_Logo").val(jsonData[0].customer_logo);
                $("#txtCustomer_Bank_Id").val(jsonData[0].customer_bank_id);
                $("#txtCustomer_Bank_Branch_Id").val(jsonData[0].customer_bank_branch_id);
                $("#txtCustomer_Branch_IFSC").val(jsonData[0].customer_branch_ifsc);
                $("#txtCustomer_Account_No").val(jsonData[0].customer_account_no);
                $("#txtCustomer_First_Subscription_Date").val(jsonData[0].customer_first_subscription_date);
                $("#txtParent_Id").val(jsonData[0].parent_id);
               
            }
            customer_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/customermst/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/customermst/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                customer_list();


            }
        });
    }
}