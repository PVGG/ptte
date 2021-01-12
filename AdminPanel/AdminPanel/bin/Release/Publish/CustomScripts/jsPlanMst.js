var jsonFormatedData = "";
$(document).ready(function () {
    //alert("Hello");
    plan_type_list();
    plan_list();

    $("#btnSubmit").click(function () {
        var requestData = '[{"plan_type_id":"' + $("#cmboPlan_Type_List").val() + '","plan_name":"' + $("#txtPlanName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "POST",
            url: "https://trial.spyderxindia.com/api/planmst",
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
               // alert(responseFromServer);
                $("#txtPlanId").val(responseFromServer);
                jsonFormatedData = "";
                $('#tblData tr').each(function () {
                    var value = $(this).find("td").eq(0).html();
                    var price = $(this).find("td").eq(1).html();
                    var notes = $(this).find("td").eq(2).html();

                    var requestData = '{"plan_id":"' + $("#txtPlanId").val() + '","value":"' + value + '","price":"' + price + '","notes":"' + notes + '","user_id":"11"}';
                    if (jsonFormatedData == "") {
                        jsonFormatedData += requestData;
                    }
                    else {
                        jsonFormatedData += "," + requestData;
                    }


                    //alert(value + "/" + price + "/" + notes);
                });


                jsonFormatedData = "[" + jsonFormatedData + "]";
               // alert(jsonFormatedData);

                if (true) {
                    $.ajax({
                        type: "POST",
                        url: "https://trial.spyderxindia.com/api/plandetails",
                        data: JSON.stringify(jsonFormatedData),
                        contentType: "application/json",
                        //datatype: "json",
                        success: function (responseFromServer) {
                            alert(responseFromServer);
                            // plan_details_list();
                        }
                    });
                }

                plan_list();
            }
        });
    });



    $("#btnCancel").click(function () {
        $("#txtPlanName").val("");
        $("#value").val("");
        $("#price").val("");
        $("#notes").val("");
        $("#tblData").html("");
    });



    $("#btnUpdate").click(function () {

        var requestData = '[{"plan_type_id":"' + $("#cmboPlan_Type_List").val() + '","plan_name":"' + $("#txtPlanName").val() + '","user_id":"11"}]';
        $.ajax({
            type: "PUT",
            url: "https://trial.spyderxindia.com/api/planmst/" + $("#txtPlanId").val(),
            data: JSON.stringify(requestData),
            contentType: "application/json",
            //datatype: "json",
            success: function (responseFromServer) {
                alert(responseFromServer);
                plan_list();

            }
        });
    });


    $("#btnAdd").click(function () {
        var tbl = "";
        tbl += "<tr>";
        tbl += "<td>";
        tbl += $("#value").val();
        tbl += "</td>";
        tbl += "<td>";
        tbl += $("#price").val();
        tbl += "</td>";
        tbl += "<td>";
        tbl += $("#notes").val();
        tbl += "</td>";
        tbl += "</tr>";
        $("#tblData").append(tbl);
        
        //alert(jsonFormatedData);


       

        
    });





});





function plan_list() {

    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plantypemst/3",
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
            var tbl = "<table width='100%'>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                tbl += "<tr>";
                tbl += "<td width='10%'>";
                tbl += iCount + 1;
                tbl += "</td>";
                tbl += "<td width='40%'>";
                tbl += jsonData[iCount].plan_name;
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
            $("#lstPlan_List").html(tbl);

        }
    });

}


function plan_type_list() {
    $.ajax({
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
            var cmbOptions = "";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                cmbOptions += "<option value=" + jsonData[iCount].index_id + ">";
                cmbOptions += jsonData[iCount].plan_type_name;
                cmbOptions += "</option>";
            }
            $("#cmboPlan_Type_List").html(cmbOptions);

        }
    });

}




function update(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plantypemst/3",
        type: "GET",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/planmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            var jsonData = eval('(' + responseFromServer + ')');
            alert(jsonData[0].index_id);
            //var tbl = "<table>";
            for (var iCount = 0; iCount < jsonData.length; iCount++) {
                $("#txtPlanId").val(jsonData[0].index_id);
                $("#txtPlanName").val(jsonData[0].plan_name);


            }
            plan_list();


        }
    });

}


function del(id) {
    $.ajax({
        //url: "https://trial.spyderxindia.com/api/plantypemst/3",
        type: "DELETE",
        //crossOrigin: true,
        url: "https://trial.spyderxindia.com/api/planmst/" + id,
        //data: JSON.stringify(num),
        contentType: "application/json",
        //datatype: "json",
        success: function (responseFromServer) {
            alert(responseFromServer);
            plan_list();


        }
    });

}