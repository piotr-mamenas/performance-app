var ContactController = function (service) {
    var editButtonClicked = false;
    var contactDetailView;
    var contactListView;

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
                    return "<div class=\"btn btn-default\">Edit</div>";
                }
            }
        ];
    }

    var onEditButtonClick = function () {
        $(listviewSelector + "tbody").on("click", "tr .btn", function () {
            editButtonClicked = true;
            if (detailViewVisible === false) {
                contactDetailView.showDetailView();
                contactDetailView.detailViewVisible = true;
            }
        });
    }

    var onRowClick = function () {
        $(listviewSelector + "tbody").on("click", "tr", function () {
            if (editButtonClicked && contactDetailView.detailViewVisible === true) {
                contactDetailView.detailViewVisible = true;
                editButtonClicked = false;
                contactDetailView.showDetailView();
            }        
        });
    }
    
    var init = function (webServiceUri) {
        
        var requestedData = service.getContacts(webServiceUri);
        contactListView = listViewComponent;
        contactListView.init("#contactTable", setColumns(), requestedData);

        contactDetailView = detailViewComponent;
        contactDetailView.init("div#contactDetailview","button#hideButton");

        onEditButtonClick();
        onRowClick();
    }

    return {
        init: init
    };

}(ContactService);