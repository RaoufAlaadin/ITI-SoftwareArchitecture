#include <stdio.h>
#include <stdlib.h>

int main()
{
    // Task 3-5 - multiplication of two 2-d arrays (hard coded)
    // 3*2  2*1
    // to multiply 2 matrices, (the column of the first MUST EQUAL rows of the second matrix)
    // i -- row , j -- column

    int a[3][2] = {{1,2},{3,4},{5,6}};

    int b[2][1] = {{2},{3}};

    int c[3][1] = {0};

    int temp = 0;

  for (int i = 0; i < 3; i++)
    {
        for(int j = 0; j < 1 ; j++)
        {
            for(int z = 0; z < 2; z++)
            {
                c[i][j] += a[i][z] * b[z][j];
            }
        }
    }

    for(int x = 0; x < 3; x++)
    {
        // we just made the first column to be printed as (1), just to look more read-able !!!
        // BUT in reality the first column is (0)

        printf("element c[%i][1] = %i \n", x+1 , c[x][0]);
    }




}
