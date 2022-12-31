#include <stdio.h>
#include <stdlib.h>

int main()
{
    int x;

    printf("Enter the number for the dish u want: \n ");
    scanf("%i",&x);

    switch(x)
    {
    case 1 :
        printf("dish number 1 \n");
        break;
    case 2 :
        printf("dish number 2 \n");
        break;
    case 3 :
        printf("dish number 3 \n");
        break;

    default:
        printf(" wrong dish number \n ");
        break;
    }
}
