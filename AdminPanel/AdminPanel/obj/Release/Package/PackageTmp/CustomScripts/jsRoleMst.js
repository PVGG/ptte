$(document).ready(function () {
    //alert("Hello");
    role_list();

    $("#btnSave").click(function () {
        var requestData = '[{"role_name":"' + $("#txtRoleName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/rolemst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                role_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"role_name":"' + $("#txtRoleName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/rolemst/" + $("#txtRoleId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                role_list();

            }
        });
    });



});


function role_list() {
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/rolemst",
         url: "https://trial.spyderxindia.com/api/rolemst",
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
        //url: "https://trial.spyderxindia.com/api/rolemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/rolemst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td width='10%'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td width='40%'>";
                tbl += jsonData[iCount].role_name;
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += "<button type='button' class='btn btn-danger'  onclick='del(" + jsonData[iCount].index_id + ")'>DELETE</button>";
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += "<button type='button' class='btn btn-warning' onclick='update(" + jsonData[iCount].index_id + ")'>UPDATE</button>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstRoleList").html(tbl);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/rolemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/rolemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtRoleId").val(jsonData[0].index_id);
                $("#txtRoleName").val(jsonData[0].role_name);


            }
            role_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/rolemst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/rolemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            role_list();


        }
    });

}