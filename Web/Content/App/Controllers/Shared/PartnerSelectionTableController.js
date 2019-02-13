var PartnerSelectionTableController = function(service) {

    var initializeDatatable = function(result) {
        $("#partnerSelectionTable").DataTable({
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

    $("#partnerSelectionTable tbody").on("click", "tr", function () {
        $(this).toggleClass("active");
    });

    var init = function() {
        service.getPartners(initializeDatatable, initializeDatatable);
    };

    return {
        init: init
    };

}(PartnerService);