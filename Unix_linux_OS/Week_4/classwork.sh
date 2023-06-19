#!/bin/bash

clear
echo

#To print the CLA - My college is Centennial College
echo "$1 $2 $3 $4 $5"

echo
#Print the PID of the current code
echo "The PID of the current code is $$"

echo
#Print the total arguments (Positional Arguments)
echo "The total number of arguments is -$*-"

echo
#Total No. of arguments
echo "The total number of arguments is $#"

echo
#Input the side of a cube and print the Area.
echo "Enter the side of a cube"
read length

area=$length /* $length

echo "The base area of the cube is $length\*$length"
