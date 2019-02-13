var PortfolioSelectionTableController = function(service) {
    var table;
    var selectedRow;

    var initializeDatatable = function(result) {
        table = $("#portfolioSelectionTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Id"
                },
                {
                    data: "Name"
                },
                {
                    data: "Number"
                }
            ],
            language: {
                emptyTable: "No records at present."
            },
            paging: false,
            searching: false
        });
    };

    var selectRow = function() {
        selectedRow = $(this);
        var selectedPortfolioId = table.row(selectedRow).data().Id;
        if (!selectedRow.hasClass("active")) {
            table.$("tr.active").removeClass("active");
            selectedRow.addClass("active");
            PortfolioReturnsTableController.init(selectedPortfolioId);
        }
    };

    var init = function() {
        service.getPortfolios(initializeDatatable, initializeDatatable);
        $("#portfolioSelectionTable tbody").on("click", "tr", selectRow);
    };

    return {
        init: init
    };

}(PortfolioService);