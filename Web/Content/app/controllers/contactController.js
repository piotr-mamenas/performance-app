var contactController = function (service, contactListView, contactDetailView) {
    var editButtonClicked = false;

    var setColumns = function () {
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
                data: name,
                render: function () {
                    return "<div id=\"hideButton\" class=\"btn btn-default\">Edit</div>";
                }
            }
        ];
    }

    var onEditButtonClick = function (editButtonSelector) {
        $(editButtonSelector).on("click", "tr .btn", function () {
            editButtonClicked = true;
            if (contactDetailView.detailViewVisible === false) {
                contactDetailView.showDetailView();
                contactDetailView.detailViewVisible = true;
            }
        });
    }

    var onRowClick = function (rowSelector) {
        $(rowSelector).on("click", "tr", function () {
            if (editButtonClicked) {
                contactDetailView.detailViewVisible = true;
                editButtonClicked = false;
                contactDetailView.showDetailView();
            }
        });
    }
    
    var init = function (webServiceUri) {
        
        var requestedData = service.getContacts(webServiceUri);

        contactListView.init("#contactTable", setColumns(), requestedData);
        contactDetailView.init("div#contactDetailView", "button#hideButton");

        onEditButtonClick("#contactTable tbody");
        onRowClick("#contactTable tbody");
        
    }

    return {
        init: init
    };

}(contactService, listViewComponent, detailViewComponent)