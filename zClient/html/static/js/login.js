$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;
        if (item.message) {
            this.document.getElementById("message_error").innerHTML = item.message;
        }
        if (item.showLoginMenu == true) {
            document.getElementsByTagName("body")[0].style.display = "block";
        } else {
            document.getElementsByTagName("body")[0].style.display = "none";
        }
    });


    $("#submit_login").click(function () {
        var user = $("#login_username").val();
        var pass = $("#login_password").val();

        fetch(`https://ZombiLand/login_nui`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                username: user,
                password: pass
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    });

});


window.onload = function () {
    const register_buttom = document.getElementById("register_buttom");
    const login_buttom = document.getElementById("login_buttom");

    register_buttom.addEventListener('click', function registerWindow() {
        document.getElementsByClassName("login")[0].style.display = "none";
        document.getElementsByClassName("register")[0].style.display = "block";

    });

    login_buttom.addEventListener('click', function registerWindow() {
        document.getElementsByClassName("login")[0].style.display = "block";
        document.getElementsByClassName("register")[0].style.display = "none";

    });
}


   
    


