window.initializeInterestAlertsCarousel = function () {
    setTimeout(() => {
        if (typeof window.isDragging === 'undefined') {
            window.isDragging = false;
            let startX;
            let scrollLeft;

            var carousel = document.getElementById("carouselContainer-interest-alerts");
            var leftButton = document.getElementById("prev-interest-alerts");
            var shade = document.getElementById("blur-wrapper");
            var shadeRight = document.getElementById("blur-wrapper-right");
            carousel.addEventListener("touchstart", function (e) {
                window.isDragging = true;
                startX = e.touches[0].pageX;
                scrollLeft = carousel.scrollLeft;
            });

            carousel.addEventListener("touchmove", function (e) {
                if (!window.isDragging) return;
                let moveX = e.touches[0].pageX - startX;
                carousel.scrollLeft = scrollLeft - moveX;

                leftButton.style.display = "block";
                shade.style.display = "block";

                if (carousel.scrollLeft === 0) {
                    leftButton.style.display = "none";
                    shade.style.display = "none";
                }

                var isAtRight = carousel.scrollLeft + carousel.clientWidth === carousel.scrollWidth;

                if (isAtRight) {
                    var rightButton = document.getElementById("next-interest-alerts");
                    rightButton.style.display = "none";
                    shadeRight.style.display = "none";
                } else {
                    var rightButton = document.getElementById("next-interest-alerts");
                    rightButton.style.display = "block";
                    shadeRight.style.display = "block";
                }
            });

            carousel.addEventListener("touchend", function () {
                window.isDragging = false;
            });

            carousel.addEventListener("mousedown", function (e) {
                window.isDragging = true;
                startX = e.pageX;
                scrollLeft = carousel.scrollLeft;
            });

            carousel.addEventListener("mousemove", function (e) {
                if (!window.isDragging) return;
                let moveX = e.pageX - startX;
                carousel.scrollLeft = scrollLeft - moveX;

                leftButton.style.display = "block";
                shade.style.display = "block";

                if (carousel.scrollLeft === 0) {
                    leftButton.style.display = "none";
                    shade.style.display = "none";
                }

                var isAtRight = carousel.scrollLeft + carousel.clientWidth === carousel.scrollWidth;

                if (isAtRight) {
                    var rightButton = document.getElementById("next-interest-alerts");
                    rightButton.style.display = "none";
                    shadeRight.style.display = "none";
                } else {
                    var rightButton = document.getElementById("next-interest-alerts");
                    rightButton.style.display = "block";
                    shadeRight.style.display = "block";
                }
            });

            carousel.addEventListener("mouseup", function () {
                window.isDragging = false;
            });

            carousel.addEventListener("dragstart", function (e) {
                e.preventDefault();
            });
        }
    }, 100);
};