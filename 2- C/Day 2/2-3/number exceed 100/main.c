#include <stdio.h>
#include <stdlib.h>

int main()
{
    int x, sum = 0 ;


    do {
            printf ("please enter a number :");
            scanf("%i", &x);

            sum += x;

    }
    while( sum < 100 );

        printf("sum exceeds 100");
}
