var init = function() {

    var init = function() {
        bootbox.confirm("Hello",
            function() {
                console.log("Hello");
            });
    }

    return {
        Init: init
    }
}();