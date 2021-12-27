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


ui_pages {
    './zClient/html/auth.html',
}

files {
    './config.ini',
    './zClient/html/auth.html',    
    './zClient/html/static/css/auth.css',
    './zClient/html/static/js/auth.js'
}
