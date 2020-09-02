$(document).ready(function(){
    $('#weusecookie').fadeIn(500);
});
$('.cookie a').click(function(){
    $(this).parent().parent().fadeOut()
});