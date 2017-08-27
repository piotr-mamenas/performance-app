var ContactController = function (service) {

    var startDatatable = function(tableData) {
        $('#contactTable').DataTable({
            data: tableData,
            columns: [
                {
                    data: 'Name'
                },
                {
                    data: 'FirstName'
                },
                {
                    data: 'LastName'
                },
                {
                    data: 'Email'
                },
                {
                    data: 'PhoneNumber'
                },
                {
                    data: 'Partner.Name'
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function (webServiceUri) {
        var contacts = service.getContacts(webServiceUri);
        startDatatable(contacts);
    }

    var done = function() {

    };

    var fail = function() {

    };

    return {
        init: init
    };
}(ContactService);