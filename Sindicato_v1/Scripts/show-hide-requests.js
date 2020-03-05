$(document).ready(function () {
    $("#hide_btn").click(function () {
        $("div.class_show").hide(function () {
            document.getElementById("show_btn").style.display = "initial";

        });
    });
    $("#hide_btn").click(function () {
        $("div.class_hide").show(function () {
            document.getElementById("show_btn").style.display = "initial";

        });
    });
});
$(document).ready(function () {
    $("#show_btn").click(function () {
        $("div.class_show").show(function () {
            document.getElementById("show_btn").style.display = "none";
        });
    });

    $("#show_btn").click(function () {
        $("div.class_hide").hide(function () {
            document.getElementById("show_btn").style.display = "none";

        });
    });
});