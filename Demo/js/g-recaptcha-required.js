$('#forms').on('submit', function (e) {
    var rs = $('#g-recaptcha-response').val();
    if (rs) {
        $('#recaptcha-required').hide();
    } else {
        $('#recaptcha-required').show();
        return false;
    }
});