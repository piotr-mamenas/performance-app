var ContactController = function (service) {

    var tableObject;
    var clickedRowData;
    var detailviewActive = false;
    var editClicked = false;

    var onEditButtonClick = function () {
        $("#contactTable tbody").on("click", "tr .btn", function () {
            editClicked = true;
        });
    }

    var switchToDetailview = function () {
        $("div#contactDetailview").show();
        console.log($("#contactDetailview").find("input#firstName.form-control").innerHTML);
    }
    var onRowClick = function () {
        $("#contactTable tbody").on("click", "tr", function () {
            console.log("onRow");
            clickedRowData = tableObject.row(this).data();
            console.log(tableObject.row(this).data());

            if (editClicked) {
                detailviewActive = true;
                editClicked = false;
                switchToDetailview();
            }
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
        $("div#contactDetailview").hide();
        var request = service.getContacts(webServiceUri);
        startDatatable(request);
        onEditButtonClick();
        onRowClick();
    }

    return {
        init: init
    };
}(ContactService);