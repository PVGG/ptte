//var url_path ="http://localhost:50148/api/questionmst/";
$(document).ready(function () {
    //alert("Hello");
    module_list();
    question_category_list();
    customer_list();
    level_list();
    question_list();

    $("#btnSave").click(function () {
        var requestData = '[{"module_id":"' + $("#cmboModuleList").val() + '","question_category_id":"' + $("#cmboQuestionCategaryList").val() + '","customer_id":"' + $("#cmboCustomerList").val() + '","level_id":"' + $("#cmboLevelList").val() + '","avi_file_url":"' + $("#base64").val()+'","record_begin_time":"' + $("#txtRecordBeginTime").val() + '","recording_time":"' + $("#txtRecordingTime").val() + '","wait_time":"' + $("#txtWaitTime").val() + '","excerpt":"' + $("#txtExcerpt").val() + '","instruction":"' + $("#txtInstruction").val() + '","description":"' + $("#txtDescription").val() + '","question":"' + $("#txtQuestion").val() + '","answer":"' + $("#txtAnswer").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
           url: "https://trial.spyderxindia.com/api/questionmst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                question_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"module_id":"' + $("#cmboModuleList").val() + '","question_category_id":"' + $("#cmboQuestionCategaryList").val() + '","customer_id":"' + $("#cmboCustomerList").val() + '","level_id":"' + $("#cmboLevelList").val() + '","avi_file_url":"' + $("#base64").val() +'","record_begin_time":"' + $("#txtRecordBeginTime").val() + '","recording_time":"' + $("#txtRecordingTime").val() + '","wait_time":"' + $("#txtWaitTime").val() + '","excerpt":"' + $("#txtExcerpt").val() + '","instruction":"' + $("#txtInstruction").val() + '","description":"' + $("#txtDescription").val() + '","question":"' + $("#txtQuestion").val() + '","answer":"' + $("#txtAnswer").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/questionmst/" + $("#txtQuestionId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                question_list();

            }
        });
    });



});


function encodeFiletoBase64(element) {
    alert("BASE64");
    var img = element.files[0];

    var reader = new FileReader();

    reader.onloadend = function () {

        // $("#convertImg").attr("href", reader.result);

        $("#base64").val(reader.result);
    }
    reader.readAsDataURL(img);
}



function question_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/questionmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/questionmst",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%' border='1px'>";
            tbl += "<tr><th>Sr No</th><th>Record Begin Time</th><th>Recording Time</th><th>Wait Time</th><th>Excerpt</th><th align='center'>Instuctions</th><th>Description</th><th align='center'>Question</th><th>Answer</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "";
                tbl += "<tr>";                
                tbl += "<td valign='top'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].record_begin_time;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].recording_time;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].wait_time;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].excerpt;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].instruction;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].description;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].question;
                tbl += "</td>";
                tbl += "<td valign='top'>";
                tbl += jsonData[iCount].answer;
                tbl += "</td>";
                tbl += "<td valign='top' align='center'>";
                tbl += "<i type='button' class='fa fa-trash btn-danger'  onclick='del(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "<td valign='top' align='center'>";
                tbl += "<i type='button' class='fa fa-edit btn-warning' onclick='update(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstQuestionList").html(tbl);

        }
    });

}

function level_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/levelmst",
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
                cmbOptions += jsonData[iCount].level_name;
                cmbOptions += "</option>";
            }
            $("#cmboLevelList").html(cmbOptions);

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

function question_category_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/questioncategarymst",
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
                cmbOptions += jsonData[iCount].question_category_name;
                cmbOptions += "</option>";
            }
            $("#cmboQuestionCategaryList").html(cmbOptions);

        }
    });

}

function module_list() {
    $.ajax({
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
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].module_name;
                cmbOptions += "</option>";
            }
            $("#cmboModuleList").html(cmbOptions);

        }
    });

}


function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/questionmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/questionmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtQuestionId").val(jsonData[0].index_id);
                $("#txtRecordBeginTime").val(jsonData[0].record_begin_time);
                $("#txtRecordingTime").val(jsonData[0].recording_time);
                $("#txtWaitTime").val(jsonData[0].wait_time);
                $("#txtExcerpt").val(jsonData[0].excerpt);
                $("#txtInstruction").val(jsonData[0].instruction);
                $("#txtDescription").val(jsonData[0].description);
                $("#txtQuestion").val(jsonData[0].question);
                $("#txtAnswer").val(jsonData[0].answer);

            }
            question_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "http://localhost:50148/api/questionmst/"+ id,
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/questionmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            question_list();


        }
    });

}