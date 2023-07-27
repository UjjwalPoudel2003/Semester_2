#!/bin/bash

echo -n "Enter the Velocity of Wind: "; read velocity

# Using If statement
if [ "$velocity" -gt 65 ];
then
	echo "Run Away it's a --> Hurricane <--"
elif [ "$velocity" -le 65 ] && [ "$velocity" -ge 48 ]; then
	echo "Find the cover, it's a --> Storm <--"
elif [ "$velocity" -le 47 ] && [ "$velocity" -ge 30 ]; then
	echo "Watch out, it's a --> Gale <--"
elif [ "$velocity" -le 29 ] && [ "$velocity" -ge 6 ]; then
	echo "Chill, it's just a --> Breeze <--"
elif [ "$velocity" -le 5 ] && [ "$velocity" -ge 1 ]; then
	echo "It's a --> Light Air <--"
else
	echo "It's a --> Calm <-- Air"
fi
