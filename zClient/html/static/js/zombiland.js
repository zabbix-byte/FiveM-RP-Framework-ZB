$(function () {
    window.addEventListener('message', function (event) {
        var item = event.data;

        if (item.message) {
            this.document.getElementById("message_error").innerHTML = item.message;
            console.log(1);
        }
        if (item.showLoginMenu == true) {
            document.getElementsByClassName("showLoginMenu")[0].style.display = "block";
            document.getElementsByTagName("body")[0].style.display = "block";
            console.log(2);
        } else if (item.showcharacterDressNui == true) {
            document.getElementsByClassName("showcharacterDressNui")[0].style.display = "block";
            document.getElementsByTagName("body")[0].style.display = "block";
            document.getElementsByTagName("body")[0].style.backgroundColor = "transparent";
            console.log(4);
        }
        else {
            document.getElementsByClassName('showLoginMenu')[0].style.display = "none";
            document.getElementsByClassName('showcharacterDressNui')[0].style.display = "none";
            document.getElementsByTagName("body")[0].style.display = "none";
            console.log(3);
        } 

    });

    $("#submit_register").click(function () {
        var user = $("#register_username").val();
        var mail = $("#register_email").val();
        var pass = $("#register_password").val();

        fetch(`https://ZombiLand/register_nui`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                username: user,
                email: mail,
                password: pass
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
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

    $("#submit_character").click(function () {
        var width = $("#nose_width").val();
        var peak = $("#nose_peak").val();
        var length = $("#nose_length").val();
        var bone = $("#nose_bone").val();
        var tip = $("#nose_tip").val();
        var bone_twist = $("#nose_bone_twist").val();

        fetch(`https://ZombiLand/editcharacter_nui`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                nose_width: width,
                nose_peak: peak,
                nose_length: length,
                nose_bone: bone,
                nose_tip: tip,
                nose_bone_twist: bone_twist,
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


   
    


