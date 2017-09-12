var taskService = function () {
    var getTasks = function (webServerUri) {
        return {
            url: webServerUri + "api/tasks",
            type: "GET",
            dataSrc: "",
            dataType: "json"
        }
    }

    return {
        getTasks: getTasks
    }
}();