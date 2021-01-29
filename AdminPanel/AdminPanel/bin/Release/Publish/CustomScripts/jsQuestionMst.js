//var url_path ="http://localhost:50148/api/questionmst/";
$(document).ready(function () {




    $("#txtQuestion").cleditor({
        width: 620, // width not including margins, borders or padding
        height: 250, // height not including margins, borders or padding
        controls: // controls to add to the toolbar
            "bold italic underline strikethrough subscript superscript | font size " +
            "style | color highlight removeformat | bullets numbering | outdent " +
            "indent | alignleft center alignright justify | undo redo | " +
            "rule image link unlink | cut copy paste pastetext | print source",
        colors: // colors in the color popup
            "FFF FCC FC9 FF9 FFC 9F9 9FF CFF CCF FCF " +
            "CCC F66 F96 FF6 FF3 6F9 3FF 6FF 99F F9F " +
            "BBB F00 F90 FC6 FF0 3F3 6CC 3CF 66C C6C " +
            "999 C00 F60 FC3 FC0 3C0 0CC 36F 63F C3C " +
            "666 900 C60 C93 990 090 399 33F 60C 939 " +
            "333 600 930 963 660 060 366 009 339 636 " +
            "000 300 630 633 330 030 033 006 309 303",
        fonts: // font names in the font popup
            "Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
            "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS,Verdana",
        sizes: // sizes in the font size popup
            "1,2,3,4,5,6,7",
        styles: // styles in the style popup
            [["Paragraph", "<p>"], ["Header 1", "<h1>"], ["Header 2", "<h2>"],
            ["Header 3", "<h3>"], ["Header 4", "<h4>"], ["Header 5", "<h5>"],
            ["Header 6", "<h6>"]],
        useCSS: false, // use CSS to style HTML when possible (not supported in ie)
        docType: // Document type contained within the editor
            '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">',
        docCSSFile: // CSS file used to style the document contained within the editor
            "",
        bodyStyle: // style to assign to document body contained within the editor
            "margin:4px; font:10pt Arial,Verdana; cursor:text"
    });



   
    //alert("Hello");
    module_list();
    question_category_list();
    customer_list();
    level_list();
    question_list();


    $("#cmboQuestionCategaryList").change(function () {
        //alert($("#cmboQuestionCategaryList").text());
        var selectedCountry = $(this).children("option:selected").text();
        if (selectedCountry.toString() == "Read Aloud") {
            $("#divAVIFile").hide();
            $("#divQuestion").show();
            $("#divAnswer").show();

        }
        else {
            $("#divAVIFile").show();
            $("#divQuestion").hide();
            $("#divAnswer").hide();
        }

        //alert("You have selected the country - " + selectedCountry);
       
    });

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
            // alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            // alert(jsonData[0].index_id);
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
    if (confirm('Are you sure ?')) {
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
}