$(document).ready(function(){
    // back-end request
    $(document).on('click', 'button', $.get("/genPasscode", function(res){
        console.log(res);
    }));
});