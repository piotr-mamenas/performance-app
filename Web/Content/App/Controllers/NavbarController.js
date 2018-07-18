var NavbarController = function (routing, toasty) {

    var presetNavbar = function (currentPage) {
        if (currentPage !== null) {
            var currentNavbarTab = $("ul" + currentPage + ".nav");

            $("#subnavbar").children("ul").not(":hidden").slideUp(0).hide(0);
            currentNavbarTab.show(0).slideDown(400);

            $("[data-target=" + currentPage + "]").parent("li").toggleClass("active");            
        }
    };

    $("[data-toggle=collapse]").click(function () {
        var targetSubNav = $($(this).data("target"));
        routing.setCurrentPage("#" + targetSubNav.attr("id"));

        $("#subnavbar").children("ul").not(":hidden").slideUp(0).hide(0);
        targetSubNav.show(0).slideDown(400);

        $("[data-toggle=collapse]").parent("li").removeClass("active");
        $(this).parent("li").toggleClass("active");

    });

    var init = function () {
        presetNavbar(routing.getCurrentPage());
    }

    return {
        init: init
    }
}(Routing, ToastNotification);