// People.cshtml - JavaScript Code (I would put it in People.cshtml but the footer is a partial view)
$(document).ready(function () {
    // Initialize the jQuery UI tabs widget on the element with the ID 'tabs'.
    // This converts the specified element into a functional tabbed interface.
    $("footer").removeClass("rit-footer-margin-class");

    // Initialize the jQuery UI tabs widget on the element with the ID 'tabs'
    $("#tabs").tabs();
});
$("#HideMePlease").fadeIn(800);