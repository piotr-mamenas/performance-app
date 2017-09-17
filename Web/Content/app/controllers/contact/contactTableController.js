var contactTableController = function (service) {
    var editButtonClicked = false;

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
                    return "<a href=\"" + data + "\" class=\"btn btn-default btn-block\"><span class='fa fa-pencil'></span></div>";
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

    var init = function () {
        service.getContacts(initializeDatatable, function() {
            console.log("Failed");
        });
        //initializeDatatable(service.getContacts());
    }

    return {
        init: init
    };

}(contactService)