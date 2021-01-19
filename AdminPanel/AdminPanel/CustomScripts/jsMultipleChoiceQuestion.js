$(document).ready(function () {
    //alert("Hello");
    question_list();
    multiple_choice_question_list();

    $("#btnSave").click(function () {
        var requestData = '[{"question_id":"' + $("#cmboQuestionList").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/multiplechoicequestion",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                multiple_choice_question_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"question_id":"' + $("#cmboQuestionList").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/multiplechoicequestion/" + $("#txtMultipleChoiceQuestionId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                multiple_choice_question_list();

            }
        });
    });



});





function multiple_choice_question_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/questionmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/multiplechoicequestion",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Zone Name</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td width='10%'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td width='40%'>";
                tbl += jsonData[iCount].question;
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += "<i type='button' class='fa fa-trash btn-danger'  onclick='del(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "<td width='25%'>";
                tbl += "<i type='button' class='fa fa-edit btn-warning' onclick='update(" + jsonData[iCount].index_id + ")'></i>";
                tbl += "</td>";
                tbl += "</tr>";
            }
            tbl += "</table>";
            $("#lstMultipleChoiceQuestionList").html(tbl);

        }
    });

}


function question_list() {
    $.ajax({
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
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].question;
                cmbOptions += "</option>";
            }
            $("#cmboQuestionList").html(cmbOptions);

        }
    });

}



function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/questionmst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/multiplechoicequestion/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            //var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtMultipleChoiceQuestionId").val(jsonData[0].index_id);
                $("#cmboQuestionList").val(jsonData[0].question);


            }
            multiple_choice_question_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/questionmst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/multiplechoicequestion/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            multiple_choice_question_list();


        }
    });

}