var contactTableController = function (service) {
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
                render: function(data) {
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
        button = $(e.target);

        service.deleteContact(button.attr("data-contact-id"),
            function() {
                table.row(button.parents("tr"))
                    .remove()
                    .draw();
            },
            function() {
                alert("Something went wrong");
            });
    };

    var init = function () {

        var loadDatatable = function (result) {
            initializeDatatable(result);
            $(".contact-delete-contact").on("click", deleteSelectedRow);
        }
        service.getContacts(loadDatatable, loadDatatable);
    }

    return {
        init: init
    };

}(contactService)