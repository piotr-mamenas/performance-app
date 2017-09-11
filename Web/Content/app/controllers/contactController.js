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

    //TODO: Incorporate the EditURL
    var init = function (webServiceUri, editUrl) {
        
        var requestedData = service.getContacts(webServiceUri);

        contactListView.init("#contactTable", setColumns(editUrl), requestedData);

        onEditButtonClick("#contactTable tbody");
        onRowClick("#contactTable tbody");
        
    }

    return {
        init: init
    };

}(contactService, listViewComponent)