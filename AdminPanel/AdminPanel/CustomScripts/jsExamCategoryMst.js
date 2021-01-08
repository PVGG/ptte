﻿$(document).ready(function () {
    //alert("Hello");
    exam_category_list();

    $("#btnSave").click(function () {
        var requestData = '[{"exam_category_name":"' + $("#txtExam_Category_Name").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/examcategarymst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                exam_category_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"exam_category_name":"' + $("#txtExam_Category_Name").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/examcategarymst/" + $("#txtExam_Category_Id").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                exam_category_list();

            }
        });
    });



});


function exam_category_list() {
    //alert("Hello");
    //var num = '[{"country_name":"Newmm","user_id":"11"}]';
    /* $.ajax({
         type: "POST",
         //crossOrigin: true,
         //url: "http://localhost:50148/api/examcategarymst",
         url: "https://trial.spyderxindia.com/api/examcategarymst",
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
        //url: "https://trial.spyderxindia.com/api/examcategarymst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/examcategarymst",
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
                tbl += jsonData[iCount].exam_category_name;
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
            $("#lstExam_Category_List").html(tbl);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/examcategarymst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/examcategarymst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtExam_Category_Id").val(jsonData[0].index_id);
                $("#txtExam_Category_Name").val(jsonData[0].exam_category_name);


            }
            exam_category_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/examcategarymst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/examcategarymst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            exam_category_list();


        }
    });

}