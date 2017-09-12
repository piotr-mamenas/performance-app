var selectionController = function () {

    var activateTab = function (buttonSelector, tabSelector) {
        if (!$(tabSelector).is(":animated") && $(tabSelector).is(":hidden")) {

            $(buttonSelector).parent("li").parent("ul").children("li").removeClass("active");
            $(buttonSelector).parent("li").addClass("active");

            $(tabSelector).parent("div").children("div").slideUp().hide();
            $(tabSelector).slideDown(400).show();
        }
    }

    $("#selection-js-select-partner").click(function () {
            activateTab("#selection-js-select-partner", "div#selection-by-partner");
    });

    $("#selection-js-select-portfolio").click(function () {
            activateTab("#selection-js-select-portfolio", "div#selection-by-portfolio");
    });

    $("#selection-js-select-container").click(function() {
            activateTab("#selection-js-select-container","div#selection-by-container");
    });

    $("#selection-search-button").click(function () {
            console.log("hello");
    });

    var init = function () {
    }

   return {
       init: init
   } 
}()