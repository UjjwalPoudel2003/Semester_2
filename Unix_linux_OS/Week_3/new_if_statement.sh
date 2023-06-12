#!/bin/bash

read -p "Please enter the value of 'a': " a

if ["$a"=="httpd"]
then
	echo "you have selected httpd"
elif ["$a"=="vsftpd"]
then
	echo "you selected vsftpd service"
elif ["$a"=="samba"]
then
	echo "you have selected the samba service"
else
	echo "You have not selected httpd"
fi
