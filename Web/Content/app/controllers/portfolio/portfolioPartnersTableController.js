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
                    data: "Number"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function (accountId) {
        service.getPartnersByAccounts(accountId, initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(partnerService)