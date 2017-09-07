var navbarController = function() {

    var init = function() {
        $(".collapse").on("shown.bs.collapse",
            function(e) {
                $(".collapse").not(this).removeClass("in");
            });

        $("[data-toggle=collapse]").click(function(e) {
            $("[data-toggle=collapse]").parent("li").removeClass("active");
            $(this).parent("li").toggleClass("active");
        });
    }

    return {
        init: init
    }
}();