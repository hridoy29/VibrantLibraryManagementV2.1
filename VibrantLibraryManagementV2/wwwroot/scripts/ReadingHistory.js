let isDragging = false;
let startX;
let scrollLeft;

window.initializeCarousel = function () {
    var carousel = document.getElementById("readingHistoryCarouselContainer");

    // Touch event handlers for swiping
    carousel.addEventListener("touchstart", function (e) {
        isDragging = true;
        startX = e.touches[0].pageX;
        scrollLeft = carousel.scrollLeft;
    });

    carousel.addEventListener("touchmove", function (e) {
        if (!isDragging) return;
        let moveX = e.touches[0].pageX - startX;
        carousel.scrollLeft = scrollLeft - moveX;
    });

    carousel.addEventListener("touchend", function () {
        isDragging = false;
    });

    // Mouse event handlers for dragging (desktop)
    carousel.addEventListener("mousedown", function (e) {
        isDragging = true;
        startX = e.pageX;
        scrollLeft = carousel.scrollLeft;
    });

    carousel.addEventListener("mousemove", function (e) {
        if (!isDragging) return;
        let moveX = e.pageX - startX;
        carousel.scrollLeft = scrollLeft - moveX;
    });

    carousel.addEventListener("mouseup", function () {
        isDragging = false;
    });

    // Prevent text selection while dragging
    carousel.addEventListener("dragstart", function (e) {
        e.preventDefault();
    });
}

window.moveSlideleftright = function (direction) {
    var carousel = document.getElementById("readingHistoryCarouselContainer");
    carousel.scrollLeft += direction * 400;
}