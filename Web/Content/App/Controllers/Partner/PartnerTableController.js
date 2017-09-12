var partnerTableController = function (service) {
    var editButtonClicked = false;

    var initializeDatatable = function (uri, editButtonUrl) {
        $("#partnerTable").DataTable({
            ajax: service.getPartners(uri),
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

    $("#partnerTable tbody").on("click", "tr .btn", function () {
        editButtonClicked = true;
    });

    $("#partnerTable tbody").on("click", "tr", function () {
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

}(partnerService)