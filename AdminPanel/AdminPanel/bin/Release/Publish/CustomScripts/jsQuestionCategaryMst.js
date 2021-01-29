$(document).ready(function () {
    //alert("Hello");
    module_list();
    question_categary_list();

    $("#btnSave").click(function () {
        var requestData = '[{"module_id":"' + $("#cmboModuleList").val() + '","question_category_name":"' + $("#txtCategaryName").val() + '","av_url":"' + $("#base64").val() + '","notes":"' + $("#txtNotes").val() + '","instructions":"' + $("#txtInstructions").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/questioncategarymst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                question_categary_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"module_id":"' + $("#cmboModuleList").val() + '","question_category_name":"' + $("#txtCategaryName").val() + '","av_url":"' + $("#base64").val() + '","notes":"' + $("#txtNotes").val() + '","instructions":"' + $("#txtInstructions").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/questioncategarymst/" + $("#txtCategaryId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                question_categary_list();

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




function question_categary_list() {
    
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/modulemst/3",
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
            var tbl = "<table width='100%'>";
            tbl += "<tr><th>Id</th><th>Question Category Name</th><th>Delete</th><th>Update</th></tr>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td width='10%'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td width='40%'>";
                tbl += jsonData[iCount].question_category_name;
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
            $("#lstQuestionCategaryList").html(tbl);

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
        //url: "https://trial.spyderxindia.com/api/modulemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/questioncategarymst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
           // alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
           // alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtCategaryId").val(jsonData[0].index_id);
                $("#txtCategaryName").val(jsonData[0].question_category_name);
                $("#txtNotes").val(jsonData[0].notes);
                $("#txtInstructions").val(jsonData[0].instructions);


            }
            question_categary_list();


        }
    });

}


function del(id) {
    if (confirm('Are you sure ?')) {
        $.ajax({
            //url: "https://trial.spyderxindia.com/api/modulemst/3",
            type: "DELETE",
            //crossOrigin: true,
            url: "https://trial.spyderxindia.com/api/questioncategarymst/" + id,
            //data: JSON.stringify(num),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                question_categary_list();


            }
        });
    }
}