#include <stdio.h>
#include <stdlib.h>

int main()
{
    // WARNING: you must set these initial values !!! or else you will get weird errors !!
    // also the debugger will not work until you do that !!

    // it's something related to dynamic memory allocation !!
    // it should be explained later on ....


    // Questions
    // 1- is there a way to quickly initialize (c) to all zeros ? without 2 nested loops.
    // 2-  why do I have to set big values for n,m,k at first ?
    //      despite the program taking the smaller inputs later on
    //      BUT, if tried to make a big matrix while I gave small numbers at first
    //      it would give an error

    int n = 9,m = 9,k = 9;


    // where n*m * m*k = n*k
    // m is the no. of columns for (a)
    // m is also the no. rows for (b)
    //c[n][k]= {0}{0}

    int a[n][m], b[m][k] , c[n][k];

    // matrix (a)
    printf("Please enter size of matrix (a) \n");
    printf("number of rows are: ");
    scanf("%i",&n);
    printf("number of columns are: ");
    scanf("%i",&m);

        // fill the matrix
    for( int i = 0; i <n; i++)
    {
        for(int j = 0; j < m; j++)
        {
            printf("Enter element a[%i][%i] : ",i+1,j+1);
            scanf("%i",&a[i][j]);
        }
    }
     // preview a
     for (int i = 0; i < n; i++)
    {
        for(int j =0; j < m; j++)
        {
            printf("   %i",a[i][j]);
        }

        printf("\n");
    }
///////////////////////
    // matrix (b)
    printf("\nPlease enter size of matrix (b) \n");
    printf(" *** You only need to enter the no. of columns for the second matrix.*** \n");

    // we won't ask for the number of rows
    // because it's also going to be (m)

    printf("number of columns are: ");
    scanf("%i",&k);

         // fill the matrix

        for( int i = 0; i <m; i++)
        {

            for(int j = 0; j < k; j++)
            {
            printf("Enter element b[%i][%i] : ",i+1,j+1);
            scanf("%i",&b[i][j]);
            }
        }

        // preview b
         for (int i = 0; i < m; i++)
    {
        for(int j =0; j < k; j++)
        {
            printf("   %i",b[i][j]);
        }

        printf("\n");
    }

///////////////////////////
    // fill matrix c with zeros

    // is there a better way ????????
    // check the array .docs


        for( int i = 0; i <n; i++)
        {

            for(int j = 0; j < k; j++)
            {
                c[i][j] = 0;
            }
        }


    printf(" n= %i m= %i k=%i  \n ",n,m,k);

// Matrices multiplication

    for (int i = 0; i < n; i++)
    {
        for(int j = 0; j < k ; j++)
        {
            for(int z = 0; z < m; z++)
            {
                c[i][j] += a[i][z] * b[z][j];


            }
        }
    }

    // printing out the new matrix (C) , that will have dimensions of n*k

    printf(" Resulting matrix (c) will be : \n");

   for (int i = 0; i < n; i++)
    {
        for(int j =0; j < k; j++)

        {
            printf("   %i",c[i][j]);
        }

        printf("\n");
    }

    return 0 ;
}
