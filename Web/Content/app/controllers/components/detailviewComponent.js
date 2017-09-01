var detailViewComponent = function () {
    var detailViewVisible;
    var detailViewSelector;
    var detailViewHandlerSelection;

    var showDetailView = function () {
        $(detailViewSelector).slideDown(1000, function () {
            detailViewVisible = true;
        });
    }

    var hideDetailView = function () {
        $(detailViewHandlerSelection).click(function () {
            $(detailViewSelector).slideUp(1000, function () {
                detailViewVisible = false;
            });
        });
    }

    var init = function (selector, hideEventSelector) {
        detailViewHandlerSelection = hideEventSelector;
        detailViewSelector = selector;
        $(detailViewSelector).hide();

        showDetailView();
        hideDetailView();
    }

    return {
        init: init,
        detailViewVisible: detailViewVisible,
        detailViewHandlerSelection: detailViewHandlerSelection,
        showDetailView: showDetailView,
        hideDetailView: hideDetailView
    };
}