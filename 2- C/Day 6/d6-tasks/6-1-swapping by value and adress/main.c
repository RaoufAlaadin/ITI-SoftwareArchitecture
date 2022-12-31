#include <stdio.h>
#include <stdlib.h>


        /* Task 6-1 - swaping 2 ints ,, one time by (value) and then doing it by (address)
                    just have them in the same code and repeat asking for entries.
                */

swapValue(int x, int y)
{



    int temp;

    temp = x;

    x = y;

    y = temp;


}

swapAd(int *x, int *y)
{

    // you can look at the input like this

    // int *x = &a;
    // int *y = &b;

    // use * with (x) or (y) everytime you want to,
    // access the value located at the address.

    int temp;

    temp = *x;

    *x = *y;

    *y = temp;


}

int main()
{
    int a,b;

    printf("Enter number (a): ");
    scanf("%i", &a);

    printf("Enter number (b): ");
    scanf("%i",&b);

    printf(" \n \n ");



    // passsing by value
    swapValue(a,b);

     printf(" By value --->  a = %i , b = %i \n \n",a,b);

    // passsing by addresss
    //we are passing the address of the first and second element.

    swapAd(&a,&b);

     printf(" By Address ---> a = %i , b = %i",a,b);

       printf(" \n \n ");


}
