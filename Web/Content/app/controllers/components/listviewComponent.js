var listViewComponent = function() {
    var listviewObject;
    var clickedRowData;
    var listviewSelector;

    var registerRowClickEvent = function () {
        $(listviewSelector + "tbody").on("click", "tr", function () {
            clickedRowData = listviewObject.row(this).data();
        });
    }

    var init = function (selector, columns, requestedData) {
        listviewSelector = selector;
        listviewObject = $(listviewSelector).DataTable({
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
        listviewObject: listviewObject,
        listviewSelector: listviewSelector
    };
}