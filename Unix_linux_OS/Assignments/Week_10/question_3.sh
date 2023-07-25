#!/bin/bash

userid="ujjwal"
passkey="COMP301"

echo -n "Enter Username: "; read username
echo -n "Enter Password: "; read password

if [[ "$username" = "$userid" ]];
then
	if [[ "$password" = "$passkey" ]];
	then
		echo "user --> $userid <-- is valid!"
	else
		echo "Incorrect Password! for --> $userid <--"
	fi
else
	echo "Invalid User ID! Try Again"
fi
