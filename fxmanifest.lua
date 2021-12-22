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
    './html/static/css/login.css',
    './html/static/js/login.js',
    './html/login.html',
}
