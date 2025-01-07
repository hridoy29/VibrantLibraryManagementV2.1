window.moveSlide2 = function (direction) {
    setTimeout(function () {
        var carousel = document.getElementById("slider-display");
        var prevButton = document.getElementById("mightintrest-prev-button");
        var nextButton = document.getElementById("mightintrest-next-button");

        var leftToScroll = carousel.scrollWidth - carousel.scrollLeft;
        if (carousel) {
            if (direction === 1) {
                if (leftToScroll > 700) {
                    carousel.scrollLeft += direction * 566;
                    scrollAnother(direction);
                }
            } else {
                carousel.scrollLeft += direction * 566;
                scrollAnother(direction);
            }
        }

        var isAtRight = carousel.scrollLeft + carousel.clientWidth >= carousel.scrollWidth - 465;

        if (carousel.scrollLeft === 0) {
            prevButton.style.display = "none";
        } else {
            prevButton.style.display = "block";
        }

        if (isAtRight) {
            nextButton.style.display = "none";
        } else {
            nextButton.style.display = "block";
        }
    }, 100);
}

window.scrollAnother = function (direction) {
    var items = document.getElementById("carousel-items-interested");
    if (items) {
        items.scrollLeft += direction * 194;
    }
}
