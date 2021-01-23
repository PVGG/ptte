$(document).ready(function () {
    // Name can't be blank
    $('.validate_name').on('input', function () {
        var input = $(this);
        var re = /^[a-zA-Z]+$/;
        var is_name = re.test(input.val());
        if (is_name) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    // Email must be an email
    $('.validate_email').on('input', function () {
        var input = $(this);
        var re = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
        var is_email = re.test(input.val());
        if (is_email) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    // Number must be an email
    $('.validate_number').on('input', function () {
        var input = $(this);
        var re = /^[0-9-+()]*$/;
        var is_number = re.test(input.val());
        if (is_number) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    // Website must be a website
    $('.validate_website').on('input', function () {
        var input = $(this);
        if (input.val().substring(0, 4) == 'www.') { input.val('http://www.' + input.val().substring(4)); }
        var re = /(http|ftp|https):\/\/[\w-]+(\.[\w-]+)+([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])?/;
        var is_url = re.test(input.val());
        if (is_url) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    // Message can't be blank
    $('.validate_message').keyup(function (event) {
        var input = $(this);
        var message = $(this).val();
        console.log(message);
        if (message) { input.removeClass("invalid").addClass("valid"); }
        else { input.removeClass("valid").addClass("invalid"); }
    });

    // After Form Submitted Validation
    $(".validate_submit button").click(function (event) {
        var form_data = $("#validate").serializeArray();
        var error_free = true;
        for (var input in form_data) {
            var element = $("#validate_" + form_data[input]['name']);
            var valid = element.hasClass("valid");
            var error_element = $("span", element.parent());
            if (!valid) { error_element.removeClass("error").addClass("error_show"); error_free = false; }
            else { error_element.removeClass("error_show").addClass("error"); }
        }
        if (!error_free) {
            event.preventDefault();
        }
        else {
            alert('No errors: Form will be submitted');
        }
    });
});