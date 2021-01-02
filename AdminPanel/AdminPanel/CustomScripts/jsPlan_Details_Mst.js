$(document).ready(function () {
    //alert("Hello");
    plan_details_list();

    $("#btnSave").click(function () {
        var requestData = '[{"plan_details_name":"' + $("#txtPlan_Details_Name").val() + '","plan_id":"' + $("#plan_Id").val() + '","value":"' + $("#value").val() + '","price":"' + $("#price").val() + '","notes":"' + $("#notes").val() + '",user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/plandetailsmst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_details_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"plan_details_name":"' + $("#txtPlan_Details_Name").val() + '","plan_id":"' + $("#plan_Id").val() + '","value":"' + $("#value").val() + '","price":"' + $("#price").val() + '","notes":"' + $("#notes").val() + '",user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/plandetailsmst/" + $("#txtPlan_Details_Id").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_details_list();

            }
        });
    });



});


function plan_details_list() {
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/plandetailsmst",
         url: "https://trial.spyderxindia.com/api/plandetailsmst",
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
        //url: "https://trial.spyderxindia.com/api/plandetailsmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plandetailsmst",
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
                tbl += jsonData[iCount].plan_details_name;
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
            $("#lstPlan_Details_List").html(tbl);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plandetailsmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plandetailsmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtPlan_Details_Id").val(jsonData[0].index_id);
                $("#txtPlan_Details_Name").val(jsonData[0].plan_details_name);
                $("#plan_Id").val(jsonData[0].plan_id);
                $("#value").val(jsonData[0].value);
                $("#price").val(jsonData[0].price);
                $("#notes").val(jsonData[0].notes);

            }
            plan_details_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plandetailsmst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plandetailsmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            plan_details_list();


        }
    });

}