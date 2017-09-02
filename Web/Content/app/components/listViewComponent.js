var listViewComponent = function() {
    var listViewObject;
    var clickedRowData;
    var listViewSelector;

    var registerRowClickEvent = function() {
        $(listViewSelector + "tbody").on("click", "tr", function() {
                clickedRowData = listViewObject.row(this).data();
            });
    }

    var init = function(selector, columns, requestedData) {
        listViewSelector = selector;
        listViewObject = $(listViewSelector).DataTable({
            ajax: requestedData,
            columns: columns,
            language: {
                emptyTable: "No records at present."
            }
        });
        registerRowClickEvent();
    }

    return {
        init: init,
        clickedRowData: clickedRowData,
        listViewObject: listViewObject,
        listViewSelector: listViewSelector
    }
}();