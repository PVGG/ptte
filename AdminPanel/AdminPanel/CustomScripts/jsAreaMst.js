﻿$(document).ready(function () {
    //alert("Hello");
    country_list();
    zone_list();
    state_list();
    city_list();
    area_list();

    $("#btnSave").click(function () {
        var requestData = '[{"country_id":"' + $("#cmboCountryList").val() + '","zone_id":"' + $("#cmboZoneList").val() + '","state_id":"' + $("#cmboStateList").val() + '","city_id":"' + $("#cmboCityList").val() + '","area_name":"' + $("#txtAreaName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/areamst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                area_list();
            }
        });
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{ "country_id":"' + $("#cmboCountryList").val() + '", "zone_id": "' + $("#cmboZoneList").val() + '","state_id": "' + $("#cmboStateList").val() + '", "city_id": "' + $("#cmboCityList").val() + '", "area_name":"' + $("#txtAreaName").val() + '","user_id": "11" }]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/areamst/" + $("#txtAreaId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                area_list();

            }
        });
    });



});





function area_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/citymst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/areamst",
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
                tbl += jsonData[iCount].area_name;
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
            $("#lstAreaList").html(tbl);

        }
    });

}

function city_list() {
    $.ajax({
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/citymst",
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
                cmbOptions += jsonData[iCount].city_name;
                cmbOptions += "</option>";
            }
            $("#cmboCityList").html(cmbOptions);

        }
    });

}

function state_list() {
    $.ajax({
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
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].state_name;
                cmbOptions += "</option>";
            }
            $("#cmboStateList").html(cmbOptions);

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
        //url: "https://trial.spyderxindia.com/api/citymst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/areamst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtAreaId").val(jsonData[0].index_id);
                $("#txtAreaName").val(jsonData[0].area_name);


            }
            area_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/citymst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/areamst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            area_list();


        }
    });

}