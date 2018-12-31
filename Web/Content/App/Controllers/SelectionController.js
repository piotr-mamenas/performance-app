var SelectionController = function() {

    var activateTab = function(buttonSelector, tabSelector) {
        if (!$(tabSelector).is(":animated") && $(tabSelector).is(":hidden")) {

            $(buttonSelector).parent("li").parent("ul").children("li").removeClass("active");
            $(buttonSelector).parent("li").addClass("active");

            $(tabSelector).parent("div").children("div").slideUp().hide();
            $(tabSelector).slideDown(400).show();
        }
    };

    var displayPartnerSelection = function() {
        activateTab("#selection-js-select-partner", "div#selection-by-partner");
    };

    var displayPortfolioSelection = function() {
        activateTab("#selection-js-select-portfolio", "div#selection-by-portfolio");
    };

    var displayContainerSelection = function() {
        activateTab("#selection-js-select-container", "div#selection-by-container");
    };

    var showSelectionPopup = function() {
        bootbox.dialog({
            title: "Selection Dialog",
            message: "<p>Not Yet Implemented</p>",
            buttons: {
                cancel: {
                    label: "<i class='fa fa-times'></i> Cancel",
                    className: "btn btn-default",
                    callback: function() {
                    }
                },
                ok: {
                    label: "<i class='fa fa-check'></i> OK",
                    className: "btn btn-primary",
                    callback: function() {
                    }
                }
            }
        });
    };

    var init = function() {
        $("#selection-search-button").on("click", showSelectionPopup);
        $("#selection-js-select-container").on("click", displayContainerSelection);
        $("#selection-js-select-portfolio").on("click", displayPortfolioSelection);
        $("#selection-js-select-partner").on("click", displayPartnerSelection);
    };

    return {
        init: init
    };
}();