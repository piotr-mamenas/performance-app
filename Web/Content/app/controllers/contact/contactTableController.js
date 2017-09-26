var contactTableController = function (service, routing) {
    var button;

    var initializeDatatable = function (result) {
        $("#contactTable").DataTable({
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
                    return "<a href=\"" + "update/" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-pencil'></span></div>";
                }
            },
            {
                data: "Id",
                render: function(data) {
                    return "<a href=\"#\" data-contact-id=\"" + data + "\" class=\"btn btn-default btn-block js-delete-contact\"><span class='fa fa-trash'></span></div>";
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

        var contactId = button.attr("data-contact-id");

        console.log("hello " + contactId);
    }
    var init = function () {
        service.getContacts(initializeDatatable, initializeDatatable);
        $(".js-delete-contact").on("click", deleteSelectedRow);
    }

    return {
        init: init
    };

}(contactService, routing)