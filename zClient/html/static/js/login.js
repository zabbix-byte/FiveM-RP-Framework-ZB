
var resourceName = "ZombiLand";

$(function () {
    window.addEventListener('message', function (event) {
        if (event.data.type == "initdata") {
            resourceName = event.data.name;
        }
        else if (event.data.type == "enableui") {
            if (event.data.enable == "True") {
                document.getElementById("banking").style.display = "block";
            }
            else {
                document.getElementById("banking").style.display = "none";
            }
        }
    });

    document.onkeyup = function (data) {
        if (data.which == 27) {
            $.post(`http://${resourceName}/escape`, JSON.stringify({}));
        }
    };
});