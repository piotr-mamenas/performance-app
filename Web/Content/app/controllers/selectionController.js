var selectionController = function () {

    var activateTab = function (buttonSelector, tabSelector) {
        if (!$(tabSelector).is(":animated")) {
            $("#js-select-partner").parent("li").removeClass("active");
            $("#js-select-portfolio").parent("li").removeClass("active");
            $("#js-select-container").parent("li").removeClass("active");

            $(buttonSelector).parent("li").addClass("active");

            $("div#byPartner").slideUp().hide();
            $("div#byPortfolio").slideUp().hide();
            $("div#byContainer").slideUp().hide();

            $(tabSelector).slideDown(400).show();
        }
    }

    var displaySelectionByPartner = function () {
        $("#js-select-partner").click(function () {
            activateTab("#js-select-partner", "div#byPartner");
        });
    }();

    var displaySelectionByPortfolio = function () {
        $("#js-select-portfolio").click(function () {
            activateTab("#js-select-portfolio", "div#byPortfolio");
        });
    }();

    var displaySelectionByContainer = function() {
        $("#js-select-container").click(function() {
            activateTab("#js-select-container","div#byContainer");
        });
    }();

    var init = function () {
    }

   return {
       init: init
   } 
}()