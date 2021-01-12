$(document).ready(function () {
    //alert("Hello");
    plan_type_list();

    $("#btnSave").click(function () {
        var requestData = '[{"plan_type_name":"' + $("#txtPlan_Type_Name").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/plantypemst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_type_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"plan_type_name":"' + $("#txtPlan_Type_Name").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/plantypemst/" + $("#txtPlan_Type_Id").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_type_list();

            }
        });
    });



});


function plan_type_list() {
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/plantypemst",
         url: "https://trial.spyderxindia.com/api/plantypemst",
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
        //url: "https://trial.spyderxindia.com/api/plantypemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plantypemst",
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
                tbl += jsonData[iCount].plan_type_name;
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
            $("#lstPlan_Type_List").html(tbl);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plantypemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plantypemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtPlan_Type_Id").val(jsonData[0].index_id);
                $("#txtPlan_Type_Name").val(jsonData[0].plan_type_name);


            }
            plan_type_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plantypemst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plantypemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            plan_type_list();


        }
    });

}