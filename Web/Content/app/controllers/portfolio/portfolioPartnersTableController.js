var portfolioPartnersTableController = function (service) {
    var table;

    var initializeDatatable = function (result) {
        table = $("#portfolioPartnersTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: ""
                },
                {
                    data: "Account.Number"
                },
                {
                    data: "Account.Partner.Name"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function () {
        service.getPortfolioPartners(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(portfolioService)