$(document).ready(function () {
    //alert("Hello");
    country_list();
    subscription_plan_list();
    customer_list();
    subscription_list();

    $("#btnSave").click(function () {
        var requestData = '[{"country_id":"' + $("#cmboCountryList").val() + '","plan_id":"' + $("#cmboSubscriptionPlanList").val() + '","subscription_date":"' + $("#txtSubscription_Date").val() + '","subscription_expire_date":"' + $("#txtSubscription_Expire_Date").val() + '","customer_id":"' + $("#cmboCustomerList").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/subscriptionmst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                subscription_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"country_id":"' + $("#cmboCountryList").val() + '","plan_id":"' + $("#cmboSubscriptionPlanList").val() + '","subscription_date":"' + $("#txtSubscription_Date").val() + '","subscription_expire_date":"' + $("#txtSubscription_Expire_Date").val() + '","customer_id":"' + $("#cmboCustomerList").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/subscriptionmst/" + $("#txtSubscription_Id").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                subscription_list();

            }
        });
    });



});





function subscription_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/subscriptionmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/subscriptionmst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Country Name</th><th>Plan Name</th><th>Sub Date</th><th>Sub Expire Date</th><th>Customer Name</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].country_name;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].plan_id;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].subscription_date;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].subscription_expire_date;
                tbl += "</td>";
                tbl += "<td>";
                tbl += jsonData[iCount].customer_id;
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
            $("#lstSubscriptionList").html(tbl);

        }
    });

}

function customer_list() {
    $.ajax({
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
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].customer_name;
                cmbOptions += "</option>";
            }
            $("#cmboCustomerList").html(cmbOptions);

        }
    });

}

function subscription_plan_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/subscriptionplanmst",
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
                cmbOptions += jsonData[iCount].subscription_plan_name;
                cmbOptions += "</option>";
            }
            $("#cmboSubscriptionPlanList").html(cmbOptions);

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
        //url: "https://trial.spyderxindia.com/api/subscriptionmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/subscriptionmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtSubscriptionId").val(jsonData[0].index_id);
                $("#txtCountryName").val(jsonData[0].country_name);


            }
            subscription_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/subscriptionmst/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/subscriptionmst/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                subscription_list();


            }
        });
    }
}