#include <stdio.h>
#include <stdlib.h>
#include <windows.h>



void gotoxy( int column, int line )
  {
  COORD coord;
  coord.X = column;
  coord.Y = line;
  SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
  }

int main()
{
    int i,r,c,n;

    // the n represents the size of the desired matrix
    // we are talking about an empty box where we will choose the locations
    // where we will set the numbers at.

    /* Title: magic box

             NOTE: use #include <window.h> to use the goto fn.
        Rules:
        1- sum of each row or column or diagonal is the same.
        2- the sum depends on the size n using this formula
                sum = n(n2+1)/2
            Ex: n=3  ----> sum = 15 !!
        3- we keep counting numbers starting from (1)
        and there is a formula for it's place.

        TODO: check the formula , also note if we number our columns
             and rows starting from (1) instead of (0).

            We would need to increase the location by (1)

        4- for every number we have see the remainder by (n)
                 if  (i % n == 0 )
                    then no remainder and we move up a row
                    note : if no more rows
    */

    n = 3;

     // we have +1 because we will number our columns and rows
     // starting from 1 instead of 0
    r = 1, c = n/2 +1 ;

    for (i=1 ; i<10; i++)
    {
        // the gotoxy() will move to a certain position
        // in the screen,it sets the console cursor position
        // so we can printf on that place.

        gotoxy(c,r);
        printf("%i",i);

        /*

        now what is the next co-ordinates ?!
        we check our current number (i) and see if it gives a remainder
        when taken by the size.

        */

        if ( (i % n) == 0 )
        {
            // this case there is no remainder, we move to the next row

            r++;
            if ( r >= n+1 )
            {
                r = 1 ;
            }


        }
        else
        {
            // here we get a remainder !!!
            // decrease the row and columns !!

            r--;
            c--;

            if ( r <= 0)
            {
                r = n ;
            }

            if ( c <= 0 )
            {
                c = n ;
            }


        }



    }
}



