var taskTableController = function (service) {
    var table;

    var initializeDatatable = function (result) {
        table = $("#taskTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Description"
                },
                {
                    data: "Type.Name"
                },
                {
                    data: "StartTimestamp"
                },
                {
                    data: "EndTimestamp"
                },
                {
                    data: "Progress"
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var init = function () {
        service.getTaskRunsByTask(initializeDatatable, initializeDatatable);
    }

    return {
        init: init
    };

}(taskService)