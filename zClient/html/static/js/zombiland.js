$(function() {
    window.addEventListener('message', function(event) {
        var item = event.data;

        if (item.message) {
            this.document.getElementById("message_error").innerHTML = item.message;
        }
        if (item.showLoginMenu == true) {
            document.getElementsByClassName("showLoginMenu")[0].style.display = "block";
            document.getElementsByTagName("body")[0].style.display = "block";
        } else if (item.showcharacterDressNui == true) {
            document.getElementsByClassName("showcharacterDressNui")[0].style.display = "block";
            document.getElementsByTagName("body")[0].style.display = "block";
            document.getElementsByTagName("body")[0].style.backgroundColor = "transparent";
        } else {
            document.getElementsByClassName('showLoginMenu')[0].style.display = "none";
            document.getElementsByClassName('showcharacterDressNui')[0].style.display = "none";
            document.getElementsByTagName("body")[0].style.display = "none";
        }

    });

    $("#submit_register").click(function() {
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


    $("#submit_login").click(function() {
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
        }).then(resp => resp.json()).then(resp => console.log(JSON.stringify(resp)));

    });


    // previews character
    document.getElementById('nose_width').onchange = function() {
        var value = $("#nose_width").val();

        fetch(`https://ZombiLand/previewcharacter`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                value: value,
                type: "nose_width"
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    };

    document.getElementById('nose_peak').onchange = function() {
        var value = $("#nose_peak").val();

        fetch(`https://ZombiLand/previewcharacter`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                value: value,
                type: "nose_peak"
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    };

    document.getElementById('nose_length').onchange = function() {
        var value = $("#nose_length").val();

        fetch(`https://ZombiLand/previewcharacter`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                value: value,
                type: "nose_length"
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    };

    document.getElementById('nose_bone').onchange = function() {
        var value = $("#nose_bone").val();

        fetch(`https://ZombiLand/previewcharacter`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                value: value,
                type: "nose_bone"
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    };

    document.getElementById('nose_tip').onchange = function() {
        var value = $("#nose_tip").val();

        fetch(`https://ZombiLand/previewcharacter`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                value: value,
                type: "nose_tip"
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    };


    document.getElementById('nose_bone_twist').onchange = function() {
        var value = $("#nose_bone_twist").val();

        fetch(`https://ZombiLand/previewcharacter`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify({
                value: value,
                type: "nose_bone_twist"
            })
        }).then(resp => resp.json()).then(resp => console.log(resp));
    };
    //


    $("#submit_character").click(function() {
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

    $("#rotate_l").click(function() {
        fetch(`https://ZombiLand/rotateplus`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }
        }).then(resp => resp.json()).then(resp => console.log(resp));
    });

    $("#rotate_r").click(function() {
        fetch(`https://ZombiLand/rotateminus`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }
        }).then(resp => resp.json()).then(resp => console.log(resp));
    });

    $("#close_character").click(function() {

        fetch(`https://ZombiLand/editcharacter_nui_close`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }
        }).then(resp => resp.json()).then(resp => console.log(resp));


    });

    $("#zoom_face").click(function() {

        fetch(`https://ZombiLand/zoomface`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }
        }).then(resp => resp.json()).then(resp => console.log(resp));


    });

    $("#min_face").click(function() {

        fetch(`https://ZombiLand/minface`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            }
        }).then(resp => resp.json()).then(resp => console.log(resp));


    });



});




window.onload = function() {
    const register_buttom = document.getElementById("register_buttom");
    const login_buttom = document.getElementById("login_buttom");


    const zoom_btn = document.getElementById("zoom_face");
    const min_btn = document.getElementById("min_face");


    zoom_btn.addEventListener('click', function registerWindow() {
        zoom_btn.style.display = "none";
        min_btn.style.display = "block";

    });

    min_btn.addEventListener('click', function registerWindow() {
        min_btn.style.display = "none";
        zoom_btn.style.display = "block";

    });

    register_buttom.addEventListener('click', function registerWindow() {
        document.getElementsByClassName("login")[0].style.display = "none";
        document.getElementsByClassName("register")[0].style.display = "block";

    });

    login_buttom.addEventListener('click', function registerWindow() {
        document.getElementsByClassName("login")[0].style.display = "block";
        document.getElementsByClassName("register")[0].style.display = "none";

    });
}