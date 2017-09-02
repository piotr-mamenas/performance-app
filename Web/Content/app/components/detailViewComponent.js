var detailViewComponent = function() {
    var detailViewVisible;
    var detailViewSelector;
    var detailViewHandlerSelector;

    var showDetailView = function() {
        $(detailViewSelector).slideDown(1000,
            function() {
                detailViewVisible = true;
            });
    }

    var hideDetailView = function() {
        $(detailViewHandlerSelector).click(function() {
            $(detailViewSelector).slideUp(1000,
                function() {
                    detailViewVisible = false;
                });
        });
    }

    var init = function(selector, hideEventSelector) {
        detailViewHandlerSelector = hideEventSelector;
        detailViewSelector = selector;

        showDetailView();
        hideDetailView();
    }

    return {
        init: init,
        detailViewVisible: detailViewVisible,
        detailViewHandlerSelection: detailViewHandlerSelector,
        showDetailView: showDetailView,
        hideDetailView: hideDetailView
    }
}();