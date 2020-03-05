$(document).ready(function () {

    $("#btnLoadSoli").click(function () {
        ReportManagerSoli.LoadSolicitud();
    });
});

var ReportManagerSoli = {
    LoadSolicitud: function () {
        var jsonParam = "";
        var serviceUrl = "../Solicitud/GetSolicitud";
        ReportManagerSoli.GetSoli(serviceUrl, jsonParam, onFailed)
        function onFailed(error) {
            alert("Se produjo un error.");
        }
    },

    GetSoli: function (serviceUrl, jsonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + jsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.open("../Reportes/ReportViewerSoli.aspx", 'newtab');
            },
            error: errorCallback
        });
    }
}