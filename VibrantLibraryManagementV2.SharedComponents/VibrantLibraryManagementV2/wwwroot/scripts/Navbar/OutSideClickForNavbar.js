window.OutSideClickForMobileMenu = function (dotnetHelper) {
    var mobileMenu = document.getElementById("navabarMobile");
    var Humberger = document.getElementById("humbergerMenu");

    document.addEventListener("click", function (event) {
        if (Humberger && mobileMenu && !mobileMenu.contains(event.target) && !Humberger.contains(event.target)) {
            dotnetHelper.invokeMethodAsync('OutsideClickOfMobileMenu');
        }
    });
};

window.OutSideClickForOptionBox = function (dotnetHelper) {
    var optionBoxButton = document.getElementById("optionBoxButton");
    var optionBoxButtonLI = document.getElementById("optionBoxLI");
    var optionsBox = document.getElementById("optionsBox");

    document.addEventListener("click", function (event) {
        if (optionBoxButtonLI && !optionBoxButtonLI.contains(event.target) && optionBoxButton && optionsBox && !optionsBox.contains(event.target) && !optionBoxButton.contains(event.target)) {
            dotnetHelper.invokeMethodAsync('OutSideClickedOfOptionBox');
        }
    });
};