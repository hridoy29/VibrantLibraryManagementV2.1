window.ReadingHistorySwapping = function () {

    var carousel = document.getElementById("readingHistoryCarouselContainer");
    var prevButton = document.getElementById("reading-history-left-button");
    var nextButton = document.getElementById("next-reading-history");

    window.isDragging = false;
    let startX;
    let scrollLeft;
    carousel.addEventListener("dragstart", function (e) {
        e.preventDefault();
    });

    carousel.addEventListener("mousedown", function (e) {
        window.isDragging = true;
        startX = e.pageX;
        scrollLeft = carousel.scrollLeft;
    });

    carousel.addEventListener("mousemove", function (e) {
        if (!window.isDragging) return;

        let moveX = e.pageX - startX;
        setTimeout(() => {
            var leftToScroll = carousel.scrollWidth - carousel.scrollLeft;
            if (leftToScroll > 300) {
                carousel.scrollLeft = scrollLeft - moveX;
            } else {
                nextButton.style.display = "none";
            }
        }, 10);


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
    });

    carousel.addEventListener("touchmove", function (e) {
        if (!window.isDragging) return;

        let moveX = e.touches[0].pageX - startX;
        carousel.scrollLeft = scrollLeft - moveX;

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