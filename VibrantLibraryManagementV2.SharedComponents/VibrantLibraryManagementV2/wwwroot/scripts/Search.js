$(document).ready(function () {
    $(".nav-item").draggable({
        axis: "x",
        containment: "#myTab", 
        cursor: "move",
        helper: "clone",
        start: function (event, ui) {
            $(this).addClass("dragging");
        },
        stop: function (event, ui) {
            $(this).removeClass("dragging");
        }
    });
});