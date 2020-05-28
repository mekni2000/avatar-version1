// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
	// Smooth scroll to element. Not necessary but provides a bit of delight
	$(".nav-header ").click(function () {
		// This prevents the default 'jump to' behaviour if JavaScript is enabled,
		// whilst keeping the functionality there for when JavaScript isn't enabled
		event.preventDefault();
		$("html, body").animate({ scrollTop: $($(this).attr('href')).offset().top }, 500);
		return true;

	});
	$(".loading").delay(5000).fadeOut(6000);
});
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image_upload_preview').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
        $(".drag").hide();
    }
}

$(".inputFile").change(function () {
    readURL(this);

});