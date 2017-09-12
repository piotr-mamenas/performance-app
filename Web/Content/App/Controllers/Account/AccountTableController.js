var accountTableController = function (service) {
    var editButtonClicked = false;

    var initializeDatatable = function (uri, editButtonUrl) {
        $("#accountTable").DataTable({
            ajax: service.getAccounts(uri),
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
                        return "<a href=\"" + editButtonUrl + "/" + data + "\" class=\"btn btn-default\">Edit</div>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    $("#accountTable tbody").on("click", "tr .btn", function () {
        editButtonClicked = true;
    });

    $("#accountTable tbody").on("click", "tr", function () {
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

}(accountService)