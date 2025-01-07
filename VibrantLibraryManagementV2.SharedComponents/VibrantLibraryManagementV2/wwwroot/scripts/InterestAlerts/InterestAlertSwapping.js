window.initializeInterestAlertsCarousel = function () {
    var carousel = document.getElementById("carouselContainer-interest-alerts");
    var leftButton = document.getElementById("prev-interest-alerts");
    var shade = document.getElementById("blur-wrapper");
    var shadeRight = document.getElementById("blur-wrapper-right");
    var rightButton = document.getElementById("next-interest-alerts");

    window.isDragging = false;
    let startX;
    let scrollLeft;
    let functionExecuted = false;

    function addTransition() {
        carousel.style.transition = "scroll-left 0.3s ease-in-out";
    }
    
    function removeTransition() {
        setTimeout(function () {
            carousel.style.transition = "";
        }, 300);
    }

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
            if (leftToScroll > 100) {
                if (!functionExecuted) {
                    addTransition();
                    carousel.scrollLeft = scrollLeft + 205;
                    functionExecuted = true;
                    removeTransition();
                }
            }
        } else {
            if (!functionExecuted) {
                addTransition();
                carousel.scrollLeft = scrollLeft - 205;
                functionExecuted = true;
                removeTransition();
            }
        }

        updateButtonAndShadeDisplay();
    });

    carousel.addEventListener("touchend", function () {
        window.isDragging = false;
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
            if (leftToScroll > 300) {
                if (!functionExecuted) {
                    addTransition();
                    carousel.scrollLeft = scrollLeft + 205;
                    functionExecuted = true;
                    removeTransition();
                }
            }
        } else {
            if (!functionExecuted) {
                addTransition();
                carousel.scrollLeft = scrollLeft - 205;
                functionExecuted = true;
                removeTransition();
            }
        }

        updateButtonAndShadeDisplay();
    });

    carousel.addEventListener("mouseup", function () {
        window.isDragging = false;
    });

    carousel.addEventListener("dragstart", function (e) {
        e.preventDefault();
    });
    
    function updateButtonAndShadeDisplay() {
        leftButton.style.display = "block";
        shade.style.display = "block";

        if (carousel.scrollLeft === 0) {
            leftButton.style.display = "none";
            shade.style.display = "none";
        }

        var isAtRight = carousel.scrollLeft + carousel.clientWidth === carousel.scrollWidth;

        if (isAtRight) {
            rightButton.style.display = "none";
            shadeRight.style.display = "none";
        } else {
            rightButton.style.display = "block";
            shadeRight.style.display = "block";
        }
    }
};
