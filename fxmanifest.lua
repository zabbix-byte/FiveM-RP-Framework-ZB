fx_version 'cerulean'
game 'gta5'

author 'Ichim Ovidiu Vasile https://github.com/zabbix-byte'
description 'Zomby Land Framework'
version '0.0.1'

client_scripts {
    './zClient/bin/Release/zClient.net.dll',
}

server_scripts {
    './zServer/bin/Release/zServer.net.dll',
}

files {
    './config.ini',
    './zClient/html/static/css/login.css',
    './zClient/html/static/js/login.js',
    './zClient/html/login.html',
}
