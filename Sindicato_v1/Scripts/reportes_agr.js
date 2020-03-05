$(document).ready(function () {

    $("#btnLoadReport_Agr").click(function () {
        ReportManagerAg.LoadReportAg();
    });
});

var ReportManagerAg = {
    LoadReportAg: function () {
        var jsonParam = "";
        var serviceUrl = "../ReportAgremiado/GetAgremiadosReport";
        ReportManagerAg.GetReportAg(serviceUrl, jsonParam, onFailed)
        function onFailed(error) {
            alert("Found Error");
        }
    },

    GetReportAg: function (serviceUrl, jsonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.open("../Reportes/ReportViewerAgr.aspx", 'newtab');
            },
            error: errorCallback
        });
    }
}
