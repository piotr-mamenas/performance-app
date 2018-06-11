var WidgetService = function (routing) {

    var createWidget = function (widget, done, fail) {
        console.log(JSON.stringify(widget));
        $.ajax({
            url: routing.getApiUri("Widget"),
            type: "POST",
            method: "POST",
            data: JSON.stringify(widget),
            dataType: "json",
            contentType: "application/json"
        }).done(done)
            .fail(fail);
    };

    return {
        createWidget: createWidget
    };
}(Routing)