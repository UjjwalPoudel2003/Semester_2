#!/bin/bash

# Limit
limit=500

# Tax Variables
max_tax=0.035
min_tax=0.02

# Discount Variables
max_discount=0.25
min_discount=0.1

# User Input
echo -n "Enter the amount: "; read amount

# Calculation Variables
max_discount_amount=$amount*$max_discount # Amount greater than 500
min_discount_amount=$amount*$min_discount # Amount lesser than 500

max_tax_amount=$amount*$max_tax #Amount lesser than 500
min_tax_amount=$amount*$min_tax #Amount greater than 500

# Checking the Statements
if [ $amount -ge $limit]
then
	$amount-=$max_discount_amount
	$amount+=$min_tax_amount
else
	$amount-=$min_discount_amount
	$amount+=$max_tax_amount
fi

# Final Invoice
echo "^^^^^^Invoice Generator^^^^^^"
echo "\t Discount: $max_discount_amount"
echo "\t Tax: $min_tax_amount"
echo "\t-------------------------"
echo "\t Total: $amount"	
