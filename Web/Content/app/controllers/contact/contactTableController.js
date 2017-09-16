var contactTableController = function (service) {
    var editButtonClicked = false;

    var initializeDatatable = function (uri, editButtonUrl) {
        $("#contactTable").DataTable({
        ajax: service.getContacts(uri),
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
                    return "<a href=\"" + editButtonUrl + "/" + data + "\" class=\"btn btn-default btn-block\">Edit</div>";
                }
            }
        ],
        language: {
            emptyTable: "No records at present."
        }
        });
    }

    $("#contactTable tbody").on("click", "tr .btn", function () {
        editButtonClicked = true;
    });

    $("#contactTable tbody").on("click", "tr", function () {
        if (editButtonClicked) {
            editButtonClicked = false;
        }

    });

    var init = function (webServiceUri, editUrl) {
        initializeDatatable(webServiceUri, editUrl);
    }

    return {
        init: init
    };

}(contactService)