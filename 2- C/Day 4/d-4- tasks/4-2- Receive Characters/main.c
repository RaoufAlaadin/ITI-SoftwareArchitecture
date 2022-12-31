#include <stdio.h>
#include <stdlib.h>

//#include <string.h>

//#include <conio.h>

int main()
{
    /*Task 4-2 : 1- Receive character by character
                2- and then place the string terminator (\0) upon pressing enter,
                3- then display the string.
                */
    int n = 0 , i = 0;

    // taking the user input on (n)
    printf("Enter the number of characters: \n");
    scanf("%i",&n);

    char name[n], ch ;


    // 1- Receiving the characters one by one

    for ( i = 0; i < n; i++)
    {
        // we are going to use getche() instead of getch(), to view if we entered something.
        // also we are usinga _getche() not getche(), because it's the newer version
        // so it should be less buggy with code-blocks

        printf("\nChar %i: " , i);
        ch = _getche();

        // as soon as u enter a char, it will ask for the next char.

        // DO NOT PRESS ENTER until you completed the the string !!!

        if (ch == 0x0d)
        {

            // 2- placing a delimiter and breaking out
            name[i] = '\0';
            break; // break will go straight to the for loop and terminate it !!

        }
        else
        {
            name[i] = ch;
        }

        // we want to keep writing until facing an enter, so we check the ch input first.
    }

    //3- displaying the string.

    /*  We don't know for how long to loop, because we might have entered a long or short word
        and that have gave '\0' a random position.......

        So we can't use a for loop ..... We must use a while loop !!!

        and the while loop should stop when it face the (delimiter ) */

        printf(" \n \n the resulting text is : \n");
        printf(" \n Hello  ");
        i = 0 ;
        while(name[i] != '\0')
        {
            // note that:  because we wrote it as a post-increament,
            // we were able to use it in the same line,
            // because it's going to printf then increase (i) by (1).
            //          i++;

            printf("%c",name[i++]);



        }




    return 0;
}
