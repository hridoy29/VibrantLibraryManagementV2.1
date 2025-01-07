window.ReadingHistorySwapping = function () {

    var carousel = document.getElementById("readingHistoryCarouselContainer");
    var prevButton = document.getElementById("reading-history-left-button");
    var nextButton = document.getElementById("next-reading-history");

    window.isDragging = false;
    let startX;
    let scrollLeft;
    let functionExecuted = false;
    carousel.addEventListener("dragstart", function (e) {
        e.preventDefault();
    });

    carousel.addEventListener("mousedown", function (e) {
        window.isDragging = true;
        startX = e.pageX;
        scrollLeft = carousel.scrollLeft;
        functionExecuted = false;
    });

    carousel.addEventListener("mousemove", function (e) {
        if (!window.isDragging) return;

        let moveX = e.pageX - startX;

        if (moveX < 0) {
            var leftToScroll = carousel.scrollWidth - carousel.scrollLeft;
            if (leftToScroll > 500) {
                if (!functionExecuted) {
                    carousel.scrollLeft = scrollLeft + 340;
                    functionExecuted = true;
                }
            }
        } else {
            if (!functionExecuted) {
                carousel.scrollLeft = scrollLeft - 340;
                functionExecuted = true;
            }
        }

        if (carousel.scrollLeft === 0) {
            prevButton.style.display = "none";
        } else {
            prevButton.style.display = "block";
        }

        var isAtRight = carousel.scrollLeft + carousel.clientWidth >= carousel.scrollWidth - 100;
        if (isAtRight) {
            nextButton.style.display = "none";
        } else {
            nextButton.style.display = "block";
        }
    });

    carousel.addEventListener("mouseup", function () {
        window.isDragging = false;
    });

    carousel.addEventListener("touchstart", function (e) {
        window.isDragging = true;
        startX = e.touches[0].pageX;
        scrollLeft = carousel.scrollLeft;
        functionExecuted = false;
    });

    carousel.addEventListener("touchmove", function (e) {
        if (!window.isDragging) return;

        let moveX = e.touches[0].pageX - startX;

        if (moveX < 0) {
            var leftToScroll = carousel.scrollWidth - carousel.scrollLeft;
            if (leftToScroll > 500) {
                if (!functionExecuted) {
                    carousel.scrollLeft = scrollLeft + 340;
                    functionExecuted = true;
                }
            }
        } else {
            if (!functionExecuted) {
                carousel.scrollLeft = scrollLeft - 340;
                functionExecuted = true;
            }
        }

        if (carousel.scrollLeft === 0) {
            prevButton.style.display = "none";
        } else {
            prevButton.style.display = "block";
        }

        var isAtRight = carousel.scrollLeft + carousel.clientWidth >= carousel.scrollWidth - 100;
        if (isAtRight) {
            nextButton.style.display = "none";
        } else {
            nextButton.style.display = "block";
        }
    });

    carousel.addEventListener("touchend", function () {
        window.isDragging = false;
    });
};