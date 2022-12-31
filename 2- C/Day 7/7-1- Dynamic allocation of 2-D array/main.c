#include <stdio.h>
#include <stdlib.h>

        /* Task 7-1 - Pointer to an array of pointers.

                    a) Calculating the sum of marks for each student (row)
                    b) Calculating the avg of marks for each subject,
                        which is the sum of a column then dividing it by the
                        number of students.

        */



int main()
{
   int      **Marks, // pointer to an array of pointers.
            StdN,SubN,  // no. of students and no. of subjects
            i,j, // i --> rows , j ---> columns
            *Sum, *Avg; //

   printf("Enter the number of students :");
   scanf("%i",&StdN);

   printf("\n");

   _flushall();

   printf("Enter the number of Subjects :");
   scanf("%i",&SubN);

   // dynamic memory allocation
   Marks = (int**) malloc(StdN * sizeof(int*));

   for (i = 0; i < StdN; i++)
   {
       // creating the rows where we will store actual data.
       Marks[i] = (int*) malloc(SubN * sizeof(int));
   }

   Sum = (int*) malloc(StdN * sizeof(int));
   Avg = (int*) malloc(SubN * sizeof(int));


   // intilizing values to 0 , We could have used calloc()
   for(i=0; i < StdN; i++)
        Sum[i] = 0;

    for(j=0; j < SubN; j++)
        Avg[j] = 0;


    for (i = 0; i < StdN; i++)
    {
        for(j = 0; j < SubN; j++)
        {
            // Ask for user input to fill the 2-D array.

            printf("Enter marks for Student (%i) on subject (%i)  : ", i+1, j+1);
            scanf("%i",&Marks[i][j]);

            Sum[i] += Marks[i][j];

            // avg here will only hold the sum of each column.
            // we still need to divide it by the student no.
            Avg[j] += Marks[i][j];

        }

        printf("\n");
    }


    // getting the actual avg values.

    for(j = 0; j < SubN; j++ )
    {
        Avg[j] /= StdN;
    }


    // printing the 2-D array.

    for (i = 0; i < StdN; i++)
    {
        for(j = 0; j < SubN; j++)
        {
            // Ask for user input to fill the 2-D array.

            printf("%i   ",Marks[i][j]);

        }

        printf("\n");
    }

    for(i=0; i < StdN; i++)
        {
            printf("Sum of marks for student (%i) is : %i \n", i+1, Sum[i]);
        }


        printf("\n");

    for(j=0; j < SubN; j++)
    {
        printf("Avg mark of subject (%i) is : %i  \n", j+1, Avg[j]);
    }



        for(i = 0; i < StdN; i++)
            free(Marks[i]);

        free(Marks);




}
