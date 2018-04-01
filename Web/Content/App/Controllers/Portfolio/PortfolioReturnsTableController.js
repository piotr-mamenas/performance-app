var PortfolioReturnsTableController = function(service) {
    var table;
    var calculateAssetButton;
    var calculationPeriods = [];
    var numberOfPeriods = 1;

    var initializeDatatable = function (result) {
        if (table != null) {
            table.destroy();
        }
        table = $("#portfolioReturnsTable").DataTable({
            data: result,
            columns: [
                {
                    data: "Name"
                },
                {
                    data: "Class"
                },
                {
                    data: "Isin"
                },
                {
                    data: "Id",
                    render: function (data) {
                        return "<button href=\"#\" data-asset-id=\"" + data + "\" class=\"btn btn-default btn-block btn-portfolio-calculate-asset-returns\"><span class='fa fa-calculator'></span></button>";
                    }
                }
            ],
            language: {
                emptyTable: "No records at present."
            }
        });
    }

    var onCalculateAssetClick = function(e) {
        calculateAssetButton = $(e.currentTarget);
        numberOfPeriods = 1;

        bootbox.dialog({
            title: "Enter Calculation Periods",
            message:
                "<form role=\"form\">" +
                "<div class=\"form-group row\">" +
                    "<div class=\"col-md-6 calculation-date-from\">" +
                        "<label class=\"label label-default\">Date From</label>" +
                        "<input type=\"date\" class=\"date form-control calculation-date-from-row\" placeholder=\"DD / MM / YYYY\" />" +
                    "</div>" +
                    "<div class=\"col-md-6 calculation-date-to\">" +
                        "<label class=\"label label-default\">Date To</label>" +
                        "<input type=\"date\" class=\"date form-control calculation-date-to-row\" placeholder=\"DD / MM / YYYY\" />" +
                    "</div>" +
                "</div>" + 
                "</form>"
            ,
            buttons: {
                cancel: {
                    label: "<i class=\"fa fa-times\"></i> Cancel",
                    className: "btn-danger"
                },
                confirm: {
                    label: "<i class=\"fa fa-check\"></i> Confirm",
                    className: "btn-primary",
                    callback: function() {
                        $(".calculation-date-from-row").each(function (index, value) {
                            console.log(value);
                            calculationPeriods.push({
                                dateFrom: value,
                                dateTo: null
                            });
                        });
                        
                        $(".calculation-date-to-row").each(function (index, value) {
                            
                            calculationPeriods[index].dateFrom = value.val();
                        });
                        console.log(calculationPeriods);
                    }
                },
                addPeriod: {
                    label: "<i class=\"fa fa-plus\"></i> Add Period",
                    callback: function () {
                        if (numberOfPeriods > 10) {
                            var periodButton = $("[data-bb-handler='addPeriod']");
                            periodButton.html("MAXIMUM PERIODS REACHED");
                            periodButton.css("font-size", 8);
                            periodButton.css("color", "#F00");
                            periodButton.prop("disabled", true);
                        } else {
                            numberOfPeriods++;
                            $(".calculation-date-from").append("<input type=\"date\" class=\"date form-control calculation-date-from-row\" placeholder=\"dd-mm - yy\" />");                            
                            $(".calculation-date-to").append("<input type=\"date\" class=\"date form-control calculation-date-to-row\" placeholder=\"dd-mm - yy\" />");
                        }
                        return false;
                    }
                }
            }
        });
    };

    var init = function(id) {
        var loadDatatable = function (result) {
            initializeDatatable(result);
            $(".btn-portfolio-calculate-asset-returns").on("click", onCalculateAssetClick);
        }
        service.getAssetsByPortfolios(id, loadDatatable, loadDatatable);
    }

    return {
        init: init
    };

}(AssetService);