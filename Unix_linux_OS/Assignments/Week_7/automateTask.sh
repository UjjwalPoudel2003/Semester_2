#!/bin/bash

#global variables
website="ujjwalpoudel.me"
host="google.com"
option=0

# First Question
user_id=$(whoami)
echo "##### Welcome $user_id #####"
echo


second_question() {
	# Second Question
	result=$(ping -c 3 $website)
	echo "Ping result for: $website"
	echo "$result"
	echo
}

third_question() {
	# Third Question
	information=$(ifconfig -a)
	echo "##### IFCONFIG INFORMATION #####"
	echo "$information"
	echo

	information_eth0=$(ifconfig eth0)
	#Extracting Mac Address
	mac_address=$(echo "$information_eth0" | awk '/ether/{print $2}')
	echo "Mac Address: $mac_address"

	#Extracting IP Address
	ip=$(echo "$information_eth0" | awk '/inet /{print $2}')
	echo "IP Address: $ip"

	#Extracting MTU
	mtu=$(echo "$information_eth0" | awk '/mtu/{print $4}')
	echo "MTU: $mtu"

	#Extracting LAN Interface
	lan=$(echo "$information_eth0" | awk '{if ($1 ~ /^[a-zA-Z0-9]+:/) {print $1}}')
	echo "LAN Interface: $lan"
	echo
}

forth_question() {
	# Forth Question
	route=$(traceroute $host)
	echo "Route to $host"
	echo "$route"
	echo
}

fifth_question() {
	# Fifth Question
	dns_records=$(dig $website)
	echo "DNS Records for $website"
	echo "$dns_records"
}
check_opion(){	
	while true; do
        	main
        	if [ $option==0 ]; then
                	exit
        	elif [ $option==1 ]; then
                	second_question
        	elif [ $option==2 ]; then
                	third_question
        	elif [ $option==3 ]; then
                	forth_question
        	elif [ $option==4 ]; then
                	fifth_question
        	else
                	echo "Please enter value as per the instructions"
        	fi
	done

}

main() {
	echo "1. Ping result"
	echo "2. IP Information"
	echo "3. Routes and Hops"
	echo "4. DNS Records"
	echo "0. Quit the program"
	echo "Your Option: " 
	read opt
	$option=$opt
	check_option
}
main
