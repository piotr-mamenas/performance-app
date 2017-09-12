var contactController = function (service, contactListView) {
    var editButtonClicked = false;

    var setColumns = function (editUrl) {
        
        return [
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
                    return "<a href=\"" + editUrl + "/" + data + "\" class=\"btn btn-default\">Edit</div>";
                }
            }
        ];
    }

    var onBackButtonClick = $("#contact-newcontact-previousstep").click(function() {
            console.log("Previous");
    });

    var onBackButtonClick = $("#contact-newcontact-nextstep").click(function () {
        console.log("Next");
    });

    var onEditButtonClick = function (editButtonSelector) {
        $(editButtonSelector).on("click", "tr .btn", function () {
            editButtonClicked = true;
        });
    }

    var onRowClick = function (rowSelector) {
        $(rowSelector).on("click", "tr", function () {
            if (editButtonClicked) {
                editButtonClicked = false;
            }
        });
    }

    var init = function (webServiceUri, editUrl) {
        
        var requestedData = service.getContacts(webServiceUri);
        console.log(editUrl);
        contactListView.init("#contactTable", setColumns(editUrl), requestedData);

        onEditButtonClick("#contactTable tbody");
        onRowClick("#contactTable tbody");
        
    }

    return {
        init: init
    };

}(contactService, listViewComponent)