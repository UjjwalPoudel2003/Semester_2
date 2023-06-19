#!/bin/bash

# Command Line arguments

# $0 - to indicaate the script name
# $1-$n - Positional Arguments
# $@ - to hold the values of each argument
# $* - To print all the arguments in the single parameter
# $! - To hld the Process ID of the recent command
# $$ - This will hold the PID of the current shell
clear
echo "#####################################################"
echo "shell script to understand the command line arguments"
echo "#####################################################"
echo "The first argument is: $1"
echo 
echo "The second argument is: $2"
echo
echo "The thied argument is: $3"
echo "######################################"

sum=$(($1+$2+$3))
echo "The sum is $sum"
