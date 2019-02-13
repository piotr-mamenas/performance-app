var ReportTableController = function(service) {
    var button;
    var table;

    var initializeDatatable = function(result) {
        table = $("#reportTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Description"
                },
                {
                    data: "Id",
                    render: function(data) {
                        return "<a href=\"" +
                            service.getDownloadUri(data) +
                            "\" data-report-id=\"" +
                            data +
                            "\" class=\"btn btn-default btn-block report-download-report\"><span class='fa fa-download'></span></button>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    };

    var init = function() {
        service.getReports(initializeDatatable, initializeDatatable);
    };

    return {
        init: init
    };

}(ReportService);