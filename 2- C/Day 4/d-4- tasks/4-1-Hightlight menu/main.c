#include <stdio.h>
#include <stdlib.h>

#include <conio.h>
#include <string.h>

#include <windows.h>

#define normalpen 0x0f
#define highlightpen 0xf0
// you might need to write them in capital letters.
#define enter 0x0d
#define esc 27

/*#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 27*/


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


  void textattr(int i)
{


	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}



int main()
{
        /*  Task 4-1 : Highlight Menu.
        Creating a menu using the lecture's code
        where it does the following:
        1-takes the keyboard inputs
        2- moves up and down
         -- the trick is highlighting the case which we inputed
            which gives the illusion of going up and down.

        3- clear the screen and shows a new screen when pressing (save)
            -- this is going to be important in the next projects.

        */


    char menu [3][5] = {"new", "Save",  "Exit" };

    int i , current = 0 , exitflag = 0, ch ;

    // We will have everything inside a do- while
    // that will exit when the flag is met.


do{
    // check this part.
    textattr(normalpen);


    // this clear is important when u want to clear the new window
    // and get back to the main menu !!!


    system("cls"); // Command to clear screen , based on the textattr() you have.


    //1-  THIS PART WILL : print out the menu and highlight only the first choice.
    for ( i = 0; i < 3; i++)
    {
        // this will highlight the first word only
        // when i = 0 , same as current = 0.
        if (current == i)
            textattr(highlightpen);
        else
        textattr(normalpen);

        gotoxy(15,10+(3*i));
        /* test run:
        (15,10)
        (15, 10*3 ) --- (15, 30 )
        (15, 10* 6 )
        */

        // note how the 2-d array is printed when it contain words.

        printf("%s",menu[i]);
    }

    // we take a user input from _getch()
    // store it in ch
    // input ch to a switch st

    // put a break point here for tracing.

    // 2-  THIS PART: Where we start analysing (user input) and changing the highlighted
    //                based on it.  and based on currently highligted we will do an option.
    ch = _getch();

    switch (ch)
    {
        case enter:
            switch (current)
            {
                /*if currennt is 0 , it means it's highlighting (new)
                 and by pressing enter, we want a function to be done.

                 1- so new will clear the screen as if you you have a new window
                 2- then you can enter the name of your project before breaking out
                 */
                case 0: // new

                    // this clear, clears the window from the main menu
                    // before writing something related to (new)
                     system("cls");
                     printf("Enter new data :");
                     _getch();
                break;

                case 1: // save
                break;

                case 2: // exit
                    exitflag = 1 ;
                break;
            }
            break;

        case esc:
            exitflag = 1;
            break;

        // if it's not (enter ) or (esc), check the following

        case 224 : // extended key   //0xfffffeo I wrote it wrong, search for it.



            // we look for the second byte after finding the an extended key.

            ch = _getch();
            switch(ch)
            {
                case 72 : //up

                    // as the current number increase going down for the menu
                    // if we want to go up we have to decrease it.
                    current --;

                    // this if condition to make sure if we go out of limit
                    // it loops the selection to the highest in the menu
                    if (current < 0) current = 2;
                    break;


                case 80 : // down
                    current ++;
                    if(current >2) current = 0;
                    break;


                case 71: //home

                    // (home) takes u to the most upper value.
                    current = 0;
                    break;

                case 79: // end

                    // (end) takes u to the most lower value.
                    current = 2;
                    break;
            }
            break;
    }

} while(exitflag == 0);

}
