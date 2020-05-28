
$(document).ready(function () {
    // Smooth scroll to element. Not necessary but provides a bit of delight
    $(".nav-header ").click(function () {
        // This prevents the default 'jump to' behaviour if JavaScript is enabled,
        // whilst keeping the functionality there for when JavaScript isn't enabled
        event.preventDefault();
        $("html, body").animate({ scrollTop: $($(this).attr('href')).offset().top }, 500);
        return true;

    });
    $(".loading").delay(5000).fadeOut(3000);
   
});
$('.carousel').carousel({
    interval: 4000,
    pause: false
})
//function readURL(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();

//        reader.onload = function (e) {
//            $('#image_upload_preview').attr('src', e.target.result);
//        }

//        reader.readAsDataURL(input.files[0]);
//        $(".drag").hide();
//    }
//}

//$(".inputFile").change(function () {
//    readURL(this);

//});
