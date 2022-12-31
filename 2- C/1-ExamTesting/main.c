#include <stdio.h>
#include <stdlib.h>

struct point
   {
       int XPos;

       int YPos;
   };


int main()
{

    /*struct point * P;

    P = (struct point *) malloc (sizeof(struct point));

    P[0].XPos = 10 ; P[0].YPos = 20;

    printf(" %d", P->XPos+ P->YPos);

    free(P);*/

    for (int i = 0; i < 6; i++)
     {
         for (int j = 0; j < i+1; j++)
    {
        printf("*");

    }
    printf("\n");


     }
}

