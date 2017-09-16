var newContactWizardController = function () {
    var getCurrentStep = function () {
        return $(".contact-newcontact-currentstep").data("current-step");
    }

    var setCurrentStep = function (step) {
        if ($(".contact-newcontact-form").valid()) {
            $(".contact-newcontact-form").children("fieldset").hide();

            console.log("first step: " + $(".contact-newcontact-firststep"));
            console.log("second step: " + $(".contact-newcontact-secondstep"));
            console.log("third step: " + $(".contact-newcontact-finalstep"));
            console.log("previousstep: " + $(".contact-newcontact-previousstep"));
            console.log("nextstep: " + $(".contact-newcontact-nextstep"));

            switch (Number(step)) {
                case 1:
                    $(".contact-newcontact-secondstep").hide();
                    $(".contact-newcontact-previousstep").hide();
                    $(".contact-newcontact-firststep").show();
                    break;
                case 2:
                    $(".contact-newcontact-firststep").hide();
                    $(".contact-newcontact-finalstep").hide();
                    $(".contact-newcontact-secondstep").show();
                    $(".contact-newcontact-previousstep").show();
                    $(".contact-newcontact-wizardcontrol").show();
                    break;
                case 3:
                    $(".contact-newcontact-secondstep").hide();
                    $(".contact-newcontact-wizardcontrol").hide();
                    $(".contact-newcontact-finalstep").show();
                    $(".contact-newcontact-submitbutton").show();
                break;
            }
            $(".contact-newcontact-currentstep").data("current-step", step);
        }
    }

    $(".contact-newcontact-previousstep").click(function () {

        switch (Number(getCurrentStep())) {
            case 2:
                setCurrentStep(1);
                break;
            case 3:
                setCurrentStep(2);
                break;
        }
    });

    $(".contact-newcontact-nextstep").click(function () {

        switch (Number(getCurrentStep())) {
            case 1:
                setCurrentStep(2);
                break;
            case 2:
                setCurrentStep(3);
                break;
        }

    });

    $(".contact-newcontact-form").on("keypress", function (e) {
        return e.which !== 13;
    });

    var init = function() {
        $(".contact-newcontact-currentstep").data("current-step", 1);
        $.validator.unobtrusive.parse($(".contact-newcontact-form"));
    }

    return {
        init: init
    };
}()