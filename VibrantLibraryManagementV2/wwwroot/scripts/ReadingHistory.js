window.moveSlideleftright = function (direction) {
    var carousel = document.getElementById("readingHistoryCarouselContainer");
    var readingHistoryLeftButton = document.getElementById("reading-history-left-button");
    var radingHistoryRightButton = document.getElementById("next-reading-history");
    var leftToScroll = carousel.scrollWidth - carousel.scrollLeft;

    if (carousel) {
        if (direction === 1) {
            if (leftToScroll > 300) {
                carousel.scrollLeft += direction * 340;
            }
        } else {
            carousel.scrollLeft += direction * 340;
        }
    }

    if (carousel.scrollLeft === 0) {
        readingHistoryLeftButton.style.display = "none";
    } else {
        readingHistoryLeftButton.style.display = "block";
    }

    var isAtRight = carousel.scrollLeft + carousel.clientWidth >= carousel.scrollWidth - 200;

    if (isAtRight) {
        radingHistoryRightButton.style.display = "none";
    } else {
        radingHistoryRightButton.style.display = "block";
    }
}