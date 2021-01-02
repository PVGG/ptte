﻿$(document).ready(function () {
    //alert("Hello");
    country_list();
    zone_list();
    state_list();

    $("#btnSave").click(function () {
        var requestData = '[{"country_id":"' + $("#cmboCountryList").val() + '","zone_id":"' + $("#cmboZoneList").val() + '","state_name":"' + $("#txtStateName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/statemst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                state_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"country_id":"' + $("#cmboCountryList").val() + '","zone_id":"' + $("#cmboZoneList").val() + '","state_name":"' + $("#txtStateName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/statemst/" + $("#txtStateId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                state_list();

            }
        });
    });



});





function state_list() {
    
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/zonemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/statemst",
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
                tbl += jsonData[iCount].state_name;
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
            $("#lstStateList").html(tbl);

        }
    });

}


function zone_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/zonemst",
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
                cmbOptions += jsonData[iCount].zone_name;
                cmbOptions += "</option>";
              }
            $("#cmboZoneList").html(cmbOptions);

        }
    });

}

function country_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/countrymst",
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
                cmbOptions += jsonData[iCount].country_name;
                cmbOptions += "</option>";
            }
            $("#cmboCountryList").html(cmbOptions);

        }
    });

}


function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/zonemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/statemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtStateId").val(jsonData[0].index_id);
                $("#txtStateName").val(jsonData[0].state_name);
                

            }
            state_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/zonemst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/statemst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
           state_list();


        }
    });

}