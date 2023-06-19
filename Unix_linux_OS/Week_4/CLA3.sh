#!/bin/bash

clear
echo
echo "Script to take the input from a seperate file"
echo "+++++++++++++++++++++++++++++++++++++++++++++"

file=data.txt #data for the file for execution

echo
while read -r line
do
	echo $line
done <"$file"

echo
