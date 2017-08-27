var ContactController = function (service) {

    var startDatatable = function(request) {
        $('#contactTable').DataTable({
            ajax: request,
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
        var request = service.getContacts(webServiceUri);
        startDatatable(request);
    }

    return {
        init: init
    };
}(ContactService);