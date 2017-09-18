var contactTableController = function (service, routing) {

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
                    return "<a href=\"" + "edit/" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-pencil'></span></div>";
                }
            },
            {
                data: "Id",
                render: function(data) {
                    return "<a href=\"" + routing.getApiUri("Contact") + "delete/" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-trash'></span></div>";
                }
            }
        ],
        language: {
            emptyTable: "No records at present."
        }
        });
    }

    var init = function () {
        service.getContacts(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(contactService, routing)