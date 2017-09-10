var navbarController = function() {

    var init = function() {
        $("[data-toggle=collapse]").click(function (e) {

            var targetSubNav = $($(this).data("target"));
            console.log(targetSubNav);

            $("#subnavbar").children("ul").slideUp(function() {
                targetSubNav.slideDown(1000);
            });

            $("[data-toggle=collapse]").parent("li").removeClass("active");

            $(this).parent("li").toggleClass("active");
        });
    }

    var hide

    return {
        init: init
    }
}();