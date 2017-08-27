var ContactController = function (service) {

    var tableObject;

    var renderButton = function () {
        $("#contactTable tbody").on("click", "tr", function () {
            console.log(tableObject.row(this).data());
        });
    }
    var startDatatable = function(request) {
        tableObject = $("#contactTable").DataTable({
            ajax: request,
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
                    data: name,
                    render: function() {
                        return "<div class=\"btn btn-default\">Edit</div>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function (webServiceUri) {
        var request = service.getContacts(webServiceUri);
        startDatatable(request);
        renderButton();
    }

    return {
        init: init
    };
}(ContactService);