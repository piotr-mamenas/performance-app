var reportTableController = function (service) {
    var editButtonClicked = false;

    var initializeDatatable = function (uri, editButtonUrl) {
        $("#reportTable").DataTable({
            ajax: service.getReports(uri),
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

    $("#reportTable tbody").on("click", "tr .btn", function () {
        editButtonClicked = true;
    });

    $("#reportTable tbody").on("click", "tr", function () {
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

}(reportService)