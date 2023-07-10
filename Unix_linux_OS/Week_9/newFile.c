#include<stdio.h>

int main() 
{
int n1, n2, sum;
printf("Enter the two numbers: ");
scanf("%d %d", &n1, &n2);
sum = n1 + n2;
printf("The sum of %d and %d", n1, n2);

printf("is %d", sum);
return 0;
}
