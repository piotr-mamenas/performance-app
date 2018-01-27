var PortfolioPartnersTableController = function(service) {
    var table;

    var initializeDatatable = function(result) {
        table = $("#portfolioPartnersTable").DataTable({
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
    };

    var init = function(accountId, callback) {
        service.getPartnersByAccounts(accountId, initializeDatatable, initializeDatatable);
        callback();
    };

    return {
        init: init
    };

}(PartnerService);