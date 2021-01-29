$(document).ready(function () {

    $('#linkclose').click(function () {
        $('#divError').hide('fade');
    });

    $('#btnlogin').click(function () {
        $.ajax({
            url: '/Module_Mst.html',
            method: 'POST',
            data: {
                username: $('#txtUsername').val(),
                Password: $('#txtPassword').val()
            },
            success: function () {
                $
            }
        })
    }
        )
        
        )
}
    )