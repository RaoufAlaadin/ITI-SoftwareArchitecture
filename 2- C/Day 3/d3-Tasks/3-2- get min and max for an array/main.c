#include <stdio.h>
#include <stdlib.h>

int main()
{
    //Task 3-2 :
    // Get the max and min numbers out of an array.

    int a[5], x, max, min;

    for(int i = 0; i < 5; i++)
    {
        printf("Enter Element number %i : ", i+1);
        scanf("%i",&a[i]);
    }

    //NOTE:  we will only need 4 runs !! ( 0,1,2,3)
    //      to not get out of ranging when doing the last compare.


    // This part is really important !!!!
    // you put them in the compare, and adjust their value inside of the if condition !!!
    max = a[0] , min = a[0];

    for (int i = 0; i < 4; i++)
    {
        if ( max < a[i+1])
        {
            // check the note I wrote above about max,min
            max = a[i+1];
        }
    }
     for (int i = 0; i < 4; i++)
    {
        if ( min > a[i+1])
        {
            min = a[i+1];
        }
    }

    printf(" \nMax number is : %i \nMin number is: %i",max,min);


}
