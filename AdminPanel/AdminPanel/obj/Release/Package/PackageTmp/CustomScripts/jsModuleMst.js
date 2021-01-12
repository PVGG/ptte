$(document).ready(function () {
    //alert("Hello");
    module_list();

    $("#btnSave").click(function () {
        var requestData = '[{"module_name":"' + $("#txtModuleName").val()+'","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/modulemst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                module_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"module_name":"' + $("#txtModuleName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/modulemst/" + $("#txtModuleId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                module_list();

            }
        });
    });



});


function module_list() {
    //alert("Hello");
    //var num = '[{"module_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/modulemst",
         url: "https://trial.spyderxindia.com/api/modulemst",
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
        //url: "https://trial.spyderxindia.com/api/modulemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/modulemst",
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
                tbl += iCount+1;
                tbl += "</td>";
                tbl += "<td width='40%'>";
                tbl += jsonData[iCount].module_name;
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += "<button type='button' class='btn btn-danger'  onclick='del(" + jsonData[iCount].index_id +")'>DELETE</button>";
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += "<button type='button' class='btn btn-warning' onclick='update(" + jsonData[iCount].index_id + ")'>UPDATE</button>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstModuleList").html(tbl);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/modulemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/modulemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtModuleId").val(jsonData[0].index_id);
                $("#txtModuleName").val(jsonData[0].module_name);

              
            }
            module_list();
            

        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/modulemst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/modulemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            module_list();


        }
    });

}