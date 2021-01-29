﻿$(document).ready(function () {
    //alert("Hello");
    subscription_plan_list();

    $("#btnSave").click(function () {

        var re = /^[a-zA-Z]+$/;
        if (!re.test($("#txtSubscriptionPlanName").val())) {

            alert("Enter valid Subscription Plan name...!");

        }
        else {

            var requestData = '[{"subscription_plan_name":"' + $("#txtSubscriptionPlanName").val() + '","subscription_period":"' + $("#txtSubscriptionPeriod").val() + '","subscription_amount":"' + $("#txtSubscriptionAmount").val() + '","notes":"' + $("#txtnotes").val() + '","subscription_plan_type_id":"' + $("#txtSubscription_Plan_Type_Id").val() + '","user_id":"11"}]';
            $.ajax({
                type: "POST",
                url: "https://trial.spyderxindia.com/api/subscriptionplanmst",
                data: JSON.stringify(requestData),
                contentType: "application/json",
                //datatype: "json",
                success: function (responseFromServer) {
                    alert(responseFromServer);
                    subscription_plan_list();
                }
            });
        }
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"subscription_plan_name":"' + $("#txtSubscriptionPlanName").val() + '","subscription_period":"' + $("#txtSubscriptionPeriod").val() + '","subscription_amount":"' + $("#txtSubscriptionAmount").val() + '","notes":"' + $("#txtnotes").val() + '","subscription_plan_type_id":"' + $("#txtSubscription_Plan_Type_Id").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/subscriptionplanmst/" + $("#txtSubscriptionId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                subscription_plan_list();

            }
        });
    });



});


function subscription_plan_list() {
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/subscriptionplanmst",
         url: "https://trial.spyderxindia.com/api/subscriptionplanmst",
         data: JSON.stringify(num),
         contentType: "application/json",
         //datatype: "json",
         success: function (responseFromServer) {
             alert(responseFromServer);
             var jsonData = val('(' + responseFromServer + ')');
             alert(jsonData[0].index_id);
             for (var iCount = 0; iCount < jsonData.length; iCount++) {
 
             }
             
         }
     });*/

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/subscriptionplanmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/subscriptionplanmst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            if (responseFromServer != "") {

                var jsonData = eval('(' + responseFromServer + ')');
                //alert(jsonData[0].index_id);
                var tbl = "<table width='100%'>";
                tbl += "<tr><th>Id</th><th>Sub Plan Name</th><th>Period</th><th>Amount</th><th>Notes</th><th>Plan Type Name</th><th>Delete</th><th>Update</th></tr>";
                for (var iCount = 0; iCount < jsonData.length; iCount++) {
                    tbl += "<tr>";
                    tbl += "<td>";
                    tbl += iCount + 1;
                    tbl += "</td>";
                    tbl += "<td>";
                    tbl += jsonData[iCount].subscription_plan_name;
                    tbl += "</td>";
                    tbl += "<td>";
                    tbl += jsonData[iCount].subscription_period;
                    tbl += "</td>";
                    tbl += "<td>";
                    tbl += jsonData[iCount].subscription_amount;
                    tbl += "</td>";
                    tbl += "<td>";
                    tbl += jsonData[iCount].notes;
                    tbl += "</td>";
                    tbl += "<td>";
                    tbl += jsonData[iCount].subscription_plan_type_id;
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
                $("#lstSubscription_Plan_List").html(tbl);
            }
        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/subscriptionplanmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/subscriptionplanmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            // alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            // alert(jsonData[0].index_id);
            //var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtSubscriptionId").val(jsonData[0].index_id);
                $("#txtSubscriptionPlanName").val(jsonData[0].subscription_plan_name);
                $("#txtSubscriptionPeriod").val(jsonData[0].subscription_period);
                $("#txtSubscriptionAmount").val(jsonData[0].subscription_amount);
                $("#txtnotes").val(jsonData[0].notes);
                $("#txtSubscription_Plan_Type_Id").val(jsonData[0].subscription_plan_type_id);

            }
            subscription_plan_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/subscriptionplanmst/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/subscriptionplanmst/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                subscription_plan_list();


            }
        });
    }
}