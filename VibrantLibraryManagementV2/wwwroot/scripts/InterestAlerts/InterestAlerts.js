//Carousel left-right buttons functionalities
window.moveSlide = function (direction) {
    setTimeout(() => {
        var carousel = document.getElementById("carouselContainer-interest-alerts");

        var shade = document.getElementById("blur-wrapper");
        var shadeRight = document.getElementById("blur-wrapper-right");
        shade.style.display = "block";

        carousel.style.scrollBehavior = "smooth";
        carousel.scrollLeft += direction * 205;

        var leftButton = document.getElementById("prev-interest-alerts");
        leftButton.style.display = "block";

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
    }, 50);
}