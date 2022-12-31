#include <stdio.h>
#include <stdlib.h>

int main()
{

    // Task 3-3 - Calculate sum of each row in 2D array.

    int a[3][3] = {{1,2,3},{4,5,6},{7,8,9}};

    // The sum array will store the value for each row.
    // while the temp is used for the calculations.

    int sum [3] = {0};

    for(int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 3; j++)
        {
            sum[i] += a[i][j];
        }


    }

    // now, We print the values of sum[i]
    // ALWAYS REMEMBER THAT:
    // when we put 3 as an end counter, this would still give us 3 rounds 0,1,2
    // always remember that we start from 0 !!!


    for (int i = 0; i < 3; i++)
    {
        printf("Sum of row %i is : %i \n",i+1, sum[i]);
    }
    return 0;
}
