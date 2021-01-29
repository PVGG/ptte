$(document).ready(function () {
    //alert("Hello");
    plan_list();
    plan_detail_list();
    exam_list();
    plan_exam_list();

    $("#btnSave").click(function () {
        var requestData = '[{"exam_id":"' + $("#cmboExamList").val() + '","plan_id":"' + $("#cmboplanList").val() + '","value":"' + $("#value").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/planexamdetails",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_exam_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"exam_id":"' + $("#cmboExamList").val() + '", "plan_id":"' + $("#cmboPlanList").val() + '","value": "' + $("#value").val() + '","user_id": "11" }]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/planexamdetails/" + $("#txtPlanExamId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_exam_list();

            }
        });
    });



});





function plan_exam_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/planexamdetails/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/planexamdetails",
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            //alert(jsonData[0].index_id);
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Question Name</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td width='10%'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td width='40%'>";
                tbl += jsonData[iCount].plan_exam_name;
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
            $("#lstPlanExamList").html(tbl);

        }
    });

}

function plan_detail_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/plandetails",
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
                cmbOptions += jsonData[iCount].value;
                cmbOptions += "</option>";
            }
            $("#value").html(cmbOptions);

        }
    });

}



function plan_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/planmst",
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
                cmbOptions += jsonData[iCount].plan_name;
                cmbOptions += "</option>";
            }
            $("#cmboPlanList").html(cmbOptions);

        }
    });

}

function exam_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/exammst",
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
                cmbOptions += jsonData[iCount].exam_name;
                cmbOptions += "</option>";
            }
            $("#cmboExamList").html(cmbOptions);

        }
    });

}


function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/planexamdetails/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/planexamdetails/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            //alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
           // alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtPlanExamId").val(jsonData[0].index_id);
                $("#cmboExamList").val(jsonData[0].exam_name);


            }
            plan_exam_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/planexamdetails/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/planexamdetails/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_exam_list();


            }
        });
    }

}