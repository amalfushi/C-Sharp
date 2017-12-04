$(document).ready(function(){
    // back-end request
    $(document).on('click', 'button', $.get("/genPasscode"))
})