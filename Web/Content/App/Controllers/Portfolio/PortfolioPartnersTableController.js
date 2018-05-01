var PortfolioPartnersTableController = function(service) {
    var table;
    var afterLoadCallback;

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
        afterLoadCallback();
    };

    var init = function(accountId, callback) {
        service.getPartnersByAccounts(accountId, initializeDatatable, initializeDatatable);
        afterLoadCallback = callback;
    };

    return {
        init: init
    };

}(PartnerService);