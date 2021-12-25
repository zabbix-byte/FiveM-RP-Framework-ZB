window.addEventListener('message', function (event) {
    var item = event.data;
    if (item.showLoginMenu == true) {
        document.getElementsByTagName("body")[0].style.display = "block";
    } else {
        document.getElementsByTagName("body")[0].style.display = "none";
    }
});