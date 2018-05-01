var ContactTableController = function (service) {
    var button;
    var table;

    var initializeDatatable = function (result) {
        table = $("#contactTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "FirstName"
                },
                {
                    data: "LastName"
                },
                {
                    data: "Email"
                },
                {
                    data: "PhoneNumber"
                },
                {
                    data: "Partner.Name"
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<a href=\"" + "update/" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-pencil'></span>";
                    }
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<button href=\"#\" data-contact-id=\"" + data + "\" class=\"btn btn-default btn-block contact-delete-contact\"><span class='fa fa-trash'></span></button>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var deleteSelectedRow = function (e) {
        button = $(e.currentTarget);

        service.deleteContact(button.attr("data-contact-id"),
            function () {
                table.row(button.parents("tr"))
                    .remove()
                    .draw();
            },
            function () {
                alert("Unexpected Error");
            });
    };

    var openDeletePrompt = function (e) {

        bootbox.confirm({
            title: "Delete contact?",
            message: "Are you sure you want to delete this contact? This cannot be undone.",
            buttons: {
                cancel: {
                    label: "<i class=\"fa fa-times\"></i> Cancel"
                },
                confirm: {
                    label: "<i class=\"fa fa-check\"></i> Confirm"
                }
            },
            callback: function (isConfirmed) {
                if (isConfirmed === true) {
                    deleteSelectedRow(e);
                }
            }
        });
    };

    var init = function () {

        var loadDatatable = function (result) {
            initializeDatatable(result);
            $("button.contact-delete-contact").on("click", openDeletePrompt);
        }
        service.getContacts(loadDatatable, loadDatatable);
    };

    return {
        init: init
    };

}(ContactService);