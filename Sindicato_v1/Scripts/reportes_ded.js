$(document).ready(function () {

    $("#btnLoadReport_Ded").click(function () {
        ReportManagerDed.LoadReportDed();
    });
});

var ReportManagerDed = {
    LoadReportDed: function () {
        var jsonParam = "";
        var serviceUrl = "../ReportDeducciones/GetDeduccionesReport";
        ReportManagerDed.GetReportDed(serviceUrl, jsonParam, onFailed)
        function onFailed(error) {
            alert("Found Error");
        }
    },

    GetReportDed: function (serviceUrl, jsonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.open("../Reportes/ReportViewerDed.aspx", 'newtab');
            },
            error: errorCallback
        });
    }
}
