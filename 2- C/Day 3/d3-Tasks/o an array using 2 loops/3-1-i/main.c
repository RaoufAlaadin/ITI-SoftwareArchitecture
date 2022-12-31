#include <stdio.h>
#include <stdlib.h>

int main()
{
    //Task 3-1 :
    // input and output an array using 2 for loops
    // we will make it an array of 5 numbers

    int a[5],x;

    for(int i = 0; i < 5; i++)
    {
        printf("Enter Element number %i : ", i+1);
        scanf("%i",&a[i]);
    }

    for (int i = 0; i < 5; i++)
    {
        printf(" %i, ",a[i]);
    }
}
