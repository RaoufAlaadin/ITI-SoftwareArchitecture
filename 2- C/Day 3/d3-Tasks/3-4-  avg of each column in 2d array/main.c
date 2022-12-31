#include <stdio.h>
#include <stdlib.h>

int main()
{

    // Task 3-4 - Calculate avg of each Column in 2D array.

    int a[3][3] = {{1,2,3},{4,5,6},{7,8,9}};

    // we will get the sum of each column
    // then we divide that by the number of rows.

    // i -- rows
    // j -- columns

    int sum [3] = {0};

    for(int j = 0; j < 3; j++)
    {
        for(int i = 0; i < 3; i++)
        {
          // you have to set sum to j , because to keep adding to that cell.
            sum[j] += a[i][j];
        }


    }

    // now, We print the values of sum[i]
    // ALWAYS REMEMBER THAT:
    // when we put 3 as an end counter, this would still give us 3 rounds 0,1,2
    // always remember that we start from 0 !!!


    for (int i = 0; i < 3; i++)
    {
        // we divide by the number of rows, to get the avg.

        // we will write the sum and the avg in the same line
        // just to visualize it.
        printf("for column %i the sum:  %i and the avg: %i \n",i+1, sum[i], sum[i]/3);
    }
    return 0;
}
