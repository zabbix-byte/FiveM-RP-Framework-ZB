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
    './zClient/html/zombiland.html'
}

files {
    './config.ini',

    './zClient/html/zombiland.html',    
    './zClient/html/static/js/zombiland.js',
    
    './zClient/html/static/css/login.css',
    './zClient/html/static/css/create_character.css',
}
