window.MightBeInterestedSwapping = function () {
  var carousel = document.getElementById("slider-display");
  var prevButton = document.getElementById("mightintrest-prev-button");
  var nextButton = document.getElementById("mightintrest-next-button");

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
      if (leftToScroll > 700) {
        if (!functionExecuted) {
          carousel.scrollLeft = scrollLeft + 566;
          debounceScroll(1);
          functionExecuted = true;
        }
      } else {
        nextButton.style.display = "none";
      }
    } else {
      if (!functionExecuted) {
        carousel.scrollLeft = scrollLeft - 566;
        debounceScroll(-1);
        functionExecuted = true;
      }
    }

    if (carousel.scrollLeft === 0) {
      prevButton.style.display = "none";
    } else {
      prevButton.style.display = "block";
    }

    var isAtRight =
      carousel.scrollLeft + carousel.clientWidth >= carousel.scrollWidth - 465;
    if (isAtRight) {
      nextButton.style.display = "none";
    } else {
      nextButton.style.display = "block";
    }
  });

  carousel.addEventListener("mouseup", function () {
    window.isDragging = false;
  });
  carousel.addEventListener("mouseleave", function () {
    isDragging = false;
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
      if (leftToScroll > 700) {
        if (!functionExecuted) {
          carousel.scrollLeft = scrollLeft + 566;
          debounceScroll(1);
          functionExecuted = true;
        }
      } else {
        nextButton.style.display = "none";
      }
    } else {
      if (!functionExecuted) {
        carousel.scrollLeft = scrollLeft - 566;
        debounceScroll(-1);
        functionExecuted = true;
      }
    }

    if (carousel.scrollLeft === 0) {
      prevButton.style.display = "none";
    } else {
      prevButton.style.display = "block";
    }

    var isAtRight =
      carousel.scrollLeft + carousel.clientWidth >= carousel.scrollWidth - 465;
    if (isAtRight) {
      nextButton.style.display = "none";
    } else {
      nextButton.style.display = "block";
    }
  });

  carousel.addEventListener("touchend", function () {
    window.isDragging = false;
  });

  function debounceScroll(direction) {
    var items = document.getElementById("carousel-items-interested");
    if (items) {
      items.scrollLeft += direction * 194;
    }
  }
};
