$(document).ready(function () {
    //alert("Hello");
    log_detail_list();

    $("#btnSave").click(function () {
        var requestData = '[{"login_date_time":"' + $("#txtLogin").val() + '","logout_date_time":"' + $("#txtLogout").val() + '","created_by_id":"8","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/logdetails",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                log_detail_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"login_date_time":"' + $("#txtLogin").val() + '","logout_date_time":"' + $("#txtLogout").val() + '","created_by_id":"8","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/logdetails/" + $("#txtLogId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                log_detail_list();

            }
        });
    });



});


function log_detail_list() {
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/logdetails",
         url: "https://trial.spyderxindia.com/api/logdetails",
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
        //url: "https://trial.spyderxindia.com/api/logdetails/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/logdetails",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Login Date Time</th><th>Logout Date Time</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td width='10%'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += jsonData[iCount].login_date_time;
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += jsonData[iCount].logout_date_time;
                tbl += "</td>";
                tbl += "<td width='20%'>";
                tbl += "<i type='button' class='fa fa-trash btn-danger' onclick='del(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "<td width='20%'>";
                tbl += "<i type='button' class='fa fa-edit btn-warning' onclick='update(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstLogList").html(tbl);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/logdetails/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/logdetails/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtLogId").val(jsonData[0].index_id);
                $("#txtLogin").val(jsonData[0].login_date_time);
                $("#txtLogout").val(jsonData[0].logout_date_time);
                //$("#txtCreated_By_Id").val(jsonData[0].created_by_id);

            }
            log_detail_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/logdetails/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/logdetails/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                log_detail_list();


            }
        });
    }
}