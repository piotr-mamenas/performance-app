var TaskService = function (routing) {

    var getTaskRunsByTask = function (taskId, done, fail) {
        $.ajax({
                url: routing.getApiUri("Task") + taskId + "/runs",
                type: "GET",
                dataSrc: "",
                dataType: "json"
            }).done(done)
            .fail(fail);
    };

    return {
        getTaskRunsByTask: getTaskRunsByTask
    }
}(Routing);