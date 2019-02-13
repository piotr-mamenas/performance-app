var WidgetService = function(routing) {

    var createWidget = function(widget, done, fail) {
        $.ajax({
                url: routing.getApiUri("Widget"),
                type: "POST",
                method: "POST",
                data: JSON.stringify(widget),
                dataType: "json",
                contentType: "application/json",
                xhrFields: { withCredentials: true }
            }).done(done)
            .fail(fail);
    };

    return {
        createWidget: createWidget
    };
}(Routing);