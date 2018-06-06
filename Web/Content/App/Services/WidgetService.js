var WidgetService = function (routing) {

    var createWidget = function (widget, done, fail) {
        $.ajax({
            url: routing.getApiUri("Widget"),
            type: "POST",
            data: JSON.stringify(widget),
            dataType: "json",
            contentType: "text"
        }).done(done)
            .fail(fail);
    };

    return {
        createWidget: createWidget
    };
}(Routing)