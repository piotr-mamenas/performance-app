var selectionController = function () {

    var activateTab = function (buttonSelector, tabSelector) {
        if (!$(tabSelector).is(":animated") && $(tabSelector).is(":hidden")) {
            $("#selection-js-select-partner").parent("li").removeClass("active");
            $("#selection-js-select-portfolio").parent("li").removeClass("active");
            $("#selection-js-select-container").parent("li").removeClass("active");

            $(buttonSelector).parent("li").addClass("active");

            $("div#selection-by-partner").slideUp().hide();
            $("div#selection-by-portfolio").slideUp().hide();
            $("div#selection-by-container").slideUp().hide();

            $(tabSelector).slideDown(400).show();
        }
    }

    var displaySelectionByPartner = function () {
        $("#selection-js-select-partner").click(function () {
            activateTab("#selection-js-select-partner", "div#selection-by-partner");
        });
    }();

    var displaySelectionByPortfolio = function () {
        $("#selection-js-select-portfolio").click(function () {
            activateTab("#selection-js-select-portfolio", "div#selection-by-portfolio");
        });
    }();

    var displaySelectionByContainer = function () {
        $("#selection-js-select-container").click(function() {
            activateTab("#selection-js-select-container","div#selection-by-container");
        });
    }();

    var onSearchButtonClick = function() {
        $("#selection-search-button").click(function () {
            console.log("hello");
        });
    }();

    var init = function () {
    }

   return {
       init: init
   } 
}()