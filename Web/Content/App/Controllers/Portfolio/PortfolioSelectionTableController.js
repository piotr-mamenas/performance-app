var PortfolioSelectionTableController = function (service) {
    var table;
    var selectedRow;

    var initializeDatatable = function (result) {
        table = $("#portfolioSelectionTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Number"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var selectRow = function (e) {
        selectedRow = $(e.currentTarget);
        console.log(selectedRow);
        if (selectedRow.hasClass("active")) {
            selectedRow.removeClass("active");
        } else {
            table.$("tr.active").removeClass("active");
            selectedRow.addClass("active");
        }
    };

    var init = function () {
        service.getPortfolios(initializeDatatable, initializeDatatable);

        $("#portfolioSelectionTable tbody").on("click", "tr", selectRow);
        PortfolioReturnsTableController.init(0);
    }

    return {
        init: init
    };

}(PortfolioService)