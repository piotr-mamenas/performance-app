jQuery.validator.setDefaults({
    success: "valid",
    highlight: function (element, errorClass, validClass) {
        if (element.type === "radio") {
            this.findByName(element.name).addClass(errorClass).removeClass(validClass);
        } else {
            $(element).closest(".form-group").removeClass("has-success has-feedback").addClass("has-error has-feedback");
            $(element).closest(".form-group").find("i.fa").remove();
            $(element).closest(".form-group").append('<i class="fa fa-exclamation form-control-feedback"></i>');
        }
    },
    unhighlight: function (element, errorClass, validClass) {
        if (element.type === "radio") {
            this.findByName(element.name).removeClass(errorClass).addClass(validClass);
        } else {
            $(element).closest(".form-group").removeClass("has-error has-feedback").addClass("has-success has-feedback");
            $(element).closest(".form-group").find("i.fa").remove();
            $(element).closest(".form-group").append('<i class="fa fa-check form-control-feedback"></i>');
        }
    }
});