var PartnerTableController = function(service) {
    var button;
    var table;

    var initializeDatatable = function(result) {
        table = $("#partnerTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Number"
                },
                {
                    data: "TypeName"
                },
                {
                    data: "Id",
                    render: function(data) {
                        return "<a href=\"" +
                            "update/" +
                            data +
                            "\" class=\"btn btn-default btn-block\"><span class='fa fa-pencil'></span>";
                    }
                },
                {
                    data: "Id",
                    render: function(data) {
                        return "<button href=\"#\" data-partner-id=\"" +
                            data +
                            "\" class=\"btn btn-default btn-block partner-delete-partner\"><span class='fa fa-trash'></span></button>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    };

    var deleteSelectedRow = function(e) {
        button = $(e.currentTarget);

        service.deletePartner(button.attr("data-partner-id"),
            function() {
                table.row(button.parents("tr"))
                    .remove()
                    .draw();
            },
            function(result) {
                bootbox.alert(result.responseJSON.Message);
            });
    };

    var openDeletePrompt = function(e) {

        bootbox.confirm({
            title: "Delete partner?",
            message: "Are you sure you want to delete this partner? This cannot be undone.",
            buttons: {
                cancel: {
                    label: "<i class=\"fa fa-times\"></i> Cancel"
                },
                confirm: {
                    label: "<i class=\"fa fa-check\"></i> Confirm"
                }
            },
            callback: function(isConfirmed) {
                if (isConfirmed === true) {
                    deleteSelectedRow(e);
                }
            }
        });
    };

    var init = function() {
        var loadDatatable = function(result) {
            initializeDatatable(result);
            $(".partner-delete-partner").on("click", openDeletePrompt);
        }
        service.getPartners(loadDatatable, loadDatatable);
    };

    return {
        init: init
    };

}(PartnerService);