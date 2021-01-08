$(document).ready(function () {
    //alert("Hello");
    subscription_list();

    $("#btnSave").click(function () {
        var requestData = '[{"plan_id":"' + $("#txtPlan_Id").val() + '","subscription_date":"' + $("#txtSubscription_Date").val() + '","subscription_expire_date":"' + $("#txtSubscription_Expire_Date").val() + '","customer_id":"' + $("#txtCustomer_Id").val() + '","user_id":"11"}]';
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

        var requestData = '[{"plan_id":"' + $("#txtPlan_Id").val() + '","subscription_date":"' + $("#txtSubscription_Date").val() + '","subscription_expire_date":"' + $("#txtSubscription_Expire_Date").val() + '","customer_id":"' + $("#txtCustomer_Id").val() + '","user_id":"11"}]';
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
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/subscriptionmst",
         url: "https://trial.spyderxindia.com/api/subscriptionmst",
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
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td>";
                tbl += iCount + 1;
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
                tbl += "<input type='button' value='DELETE' onclick='del(" + jsonData[iCount].index_id + ")'>";
                tbl += "</td>";
                tbl += "<td>";
                tbl += "<input type='button' value='UPDATE' onclick='update(" + jsonData[iCount].index_id + ")'>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstSubscriptionList").html(tbl);

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
                $("#txtSubscription_Id").val(jsonData[0].index_id);
                $("#txtPlan_Id").val(jsonData[0].plan_id);
                $("#txtSubscription_Date").val(jsonData[0].subscription_date);
                $("#txtSubscription_Expire_Date").val(jsonData[0].subscription_expire_date);
                $("#txtCustomer_Id").val(jsonData[0].customer_id);

            }
            subscription_list();


        }
    });

}


function del(id) {
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