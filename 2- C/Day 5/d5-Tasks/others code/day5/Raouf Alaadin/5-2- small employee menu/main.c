#include <stdio.h>
#include <stdlib.h>

        /* task 5-2:  1- integrate employee with menu
                      2- array of 3 employees
                      3 - new : Enter data for 3 employees
                            a- the screen will have all the data tags and the cursor will move
                            b- to a writing point each time you press enter
                            c- it clears the screen afterwards and loads another form
                                to let you write the next employee's data

                    4- display : this function will display the following
                                a- id
                                b- name
                                c- net salary
                        ** idk if we should show each employee in a different screens or just one screen**
                        ** if it's just one screen, we would need to squeeze the data in coloumns**


                          note: What if i want to only read the data of one employee ?
                          ---->  This is is what we need in task 5-3  !!!!!


                    5- exit : it's the just the same, it ends the program.


        */
#include <conio.h>
#include <string.h>

#include <windows.h>

// this library gives ---> sleep(seconds) to pause your program !!!
#include <unistd.h>

#define normalpen 0x0f
//#define highlightpen 0xf0

#define highlightpen 180

// this is yellow background with red text
#define yellowpen 100

// not really blue , it' close to the reddish yellow one.
#define bluepen 70
// you might need to write them in capital letters.
#define enter 0x0d
#define esc 27

typedef struct employee
{int id,age;
    char gender, name[100],city[200];
    double salary, overtime, deduct;

    // net = (salary + overtime ) - deduct.
    // we will use this formula everytime we want the net. salary !!

}employee;

/*

    if u write a number it might give it to the first element
    and the set everything else to zero. but it's a bit random !!

     the rule is: just give any one value, and it will set all elements to zero.

     */



employee e [3] = {0};


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


add_employee()
{

    for (int k = 0; k < 3; k++)
    {


    // 8 data about each employee...
    char add_menu [8][30] = {"ID", "age", "gender" , "name", "city", "salary" ,"overtime", "deduct" };

    int i , current = 0 , exitflag = 0, ch ;

    system("cls");

        for ( i = 0; i < 8; i++)
        {
            gotoxy(5,3+(3*i));

            printf("%s",add_menu[i]);


        }

      gotoxy(15,3);



      // this line is important to store the input
    e[k].id = k+1;

    printf("%i",k+1);

    gotoxy(15,6);
    scanf("%i",&e[k].age);

    // it's important to use _flushall

    _flushall();
    gotoxy(15,9);
    scanf("%c",&e[k].gender);

    _flushall();

    gotoxy(15,12);
    gets(e[k].name);


    gotoxy(15,15);
    gets(e[k].city);

    gotoxy(15,18);
    scanf("%lf",&e[k].salary);

    gotoxy(15,21);
    scanf("%lf",&e[k].overtime);

    gotoxy(15,24);
    scanf("%lf",&e[k].deduct);


//        sleep(10);


    system("cls");



    }







}




disp_all()
{
    // we have to print only the ones that have data !!

    system("cls");


    // now we will need the flag..
    // to check for the case that we don't have any data to show.



    int id_flag = 0 ;




     for (int i = 0 ; i < 3; i++)
    {
        // if  the person with that index has age stored
        // then the values will be equaled.


        // note we have nested if's
        if (e[i].age != 0)
        {
            double net = e[i].salary + e[i].overtime - e[i].deduct;

            printf(" ID: %i , Name: %s , Net.Salary : %0.02lf \n",e[i].id, e[i].name, net);

            printf("------------------------------------ \n");

            // becuase this mean we found at least one employee.
            id_flag = 1;

        }

    }

       if (id_flag == 0)
       {
           printf("no empolyee data has been entered previously.... \n");
          printf("press any key to go back");

            _getch();

            system("cls");

       }
       else{

        printf("press any key to go back");

        _getch();
        system("cls");

       }




}


int main()
{

    // 3 options
    char menu [3][30] = {"new", "display all" , "Exit" };

    int i , current = 0 , exitflag = 0, ch ;

    // We will have everything inside a do- while
    // that will exit when the flag is met.

                //1- creating an array of 10 employees
                //and intializing every input to (zero)

    // we don't need struct, because we used (typedef)





// printf("test array : %i ", e[5].id);



do{
    // check this part.
    textattr(normalpen);


    // this clear is important when u want to clear the new window
    // and get back to the main menu !!!


//    system("cls"); // Command to clear screen , based on the textattr() you have.


    //1-  THIS PART WILL : print out the menu and highlight only the first choice.
    for ( i = 0; i < 3; i++)
    {
        // this will highlight the first word only
        // when i = 0 , same as current = 0.
        if (current == i)
            textattr(highlightpen);
        else
        textattr(normalpen);

//        gotoxy(15,10+(3*i));

        gotoxy(5,3+(3*i));
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

                     add_employee();
                break;



                case 1: // Display all
                    disp_all();
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
                    current = 5;
                    break;
            }
            break;
    }

}
while(exitflag == 0);



}

