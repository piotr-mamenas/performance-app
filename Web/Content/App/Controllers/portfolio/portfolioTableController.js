var portfolioTableController = function (service) {

    var initializeDatatable = function (result) {
        $("#portfolioTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Number"
                },
                {
                    data: "Account.Number"
                },
                {
                    data: "Account.Partner.Name"
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<a href=\"" + "details/" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-search'></span>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function () {
        service.getPortfolios(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(portfolioService)