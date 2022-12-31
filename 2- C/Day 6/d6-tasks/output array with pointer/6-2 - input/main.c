#include <stdio.h>
#include <stdlib.h>

        /* Task 6-2 - input and output an array using pointer

            a- use the pointer to store the address of each element one at a time
            b- print out that value by derefrencing the address inside the pointer
            c- repeat

            */

int main()
{
    /* 1- reading from an array using a pointer


    int arr[] = {5,3,4,8} ;

    int *ptr = arr;

    // now the pointer is like the array's name
    printf("%i", ptr[5]);
    */

    int arr[5];

    // the array's name holds the address of the first element

    int *ptr = arr;

    for (int i = 0; i < 5; i++)
    {
        printf("Enter Element no. (%i) = ", i+1);
        scanf("%i",&ptr[i]);

    }

      printf(" --------------------------------- \n");
      printf("Resulting array is: ");

      printf("\n \n ");

     for (int i = 0; i < 5; i++)
        printf("%i,",  ptr[i]);



        printf("\n \n ");


}
