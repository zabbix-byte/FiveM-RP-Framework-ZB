-- zabbix | https://github.com/zabbix-byte --

					--						ZombiLand DATABASE Script			--

-- Creating DATABASE
CREATE DATABASE ZombiLand;

-- Selecting the DATABASE
USE ZombiLand;

-- Creating a user (change the password please)
CREATE USER 'zombiland'@'localhost' IDENTIFIED BY '123456789';
GRANT ALL PRIVILEGES ON * . * TO 'zombiland'@'localhost';
FLUSH PRIVILEGES;

-- users TABLE
CREATE TABLE `users` (
	 -- database id
	`id` int NOT NULL AUTO_INCREMENT,

	-- user basic data
	`username` varchar(50) ,
	`password` varchar(100),
	`email` varchar(100),
	`group` varchar(100),
	`character_is_configured` boolean DEFAULT 0,

	-- fivem id
	`temporal_id` int,

	CONSTRAINT `unique_username` UNIQUE(`username`),
	CONSTRAINT `unique_email` UNIQUE(`email`) ,

	-- pkey
	primary key(`id`)
)ENGINE=INNODB;

-- character aparience
CREATE TABLE `character` (
	`user` int NOT NULL AUTO_INCREMENT,
	`nose_width` int NOT NULL DEFAULT 50,
	`nose_peak` int NOT NULL DEFAULT 50,
	`nose_length` int NOT NULL DEFAULT 50,
	`nose_bone` int NOT NULL DEFAULT 50,
	`nose_tip` int NOT NULL DEFAULT 50,
	`nose_bone_twist` int NOT NULL DEFAULT 50,

	-- fKey
	CONSTRAINT `users_character`
    FOREIGN KEY (`user`) 
        REFERENCES users(`id`)
) ENGINE=INNODB;

