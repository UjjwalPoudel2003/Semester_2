#!/bin/bash

# User Input
echo -n "Enter the amount: ";read amount

limit=500

max_discount=25
min_tax=2

min_discount=10
max_tax=35
# Checking the Statements
if [ $amount -ge $limit ]
then
	discount=$((amount * max_discount / 100))
	discounted_amount=$((amount - discount))
	tax=$((discounted_amount * min_tax / 100))
	total=$((discounted_amount + tax))
else
	 discount=$((amount * min_discount / 100))
        discounted_amount=$((amount - discount))
        tax=$((discounted_amount * max_tax / 1000))
        total=$((discounted_amount + tax))
fi

echo
# Final Invoice
echo "========== Invoice ==========="
echo "      Item Cost:   $amount"
echo "      Discount:    $discount"
echo "      Tax Amount:  $tax"
echo "------------------------------"
echo "      Total Paid:  $total"
echo
echo "*** Please Come Back Again ***"
