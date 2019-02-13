var InstitutionSelectionTableController = function(service) {

    var initializeDatatable = function(result) {
        $("#institutionSelectionTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    };

    $("#institutionSelectionTable tbody").on("click",
        "tr",
        function() {
            $(this).toggleClass("active");
        });

    var init = function() {
        service.getInstitutions(initializeDatatable, initializeDatatable);
    };

    return {
        init: init
    };

}(InstitutionService);