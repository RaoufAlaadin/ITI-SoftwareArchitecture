#include <stdio.h>
#include <stdlib.h>

        /* task 5-3:  1- Array of 10 employees
                      2- new : here it will only take one employee,
                                you would need to press it again to enter
                                more employees.....

                                OR !! we could ask the user for the number of employees he want to enter
                                    and then view the number of the forms that he asked for, one by one.

                        BOUNS: check if the id already have data..
                                and ask the user if he wants to override ??? or Enter a new index to store in.


                     3- Display: Ask for employee's ID
                            if ( ID == e[i].id)
                                printf(" Emp id : ... ,Name : ... ,Net Salary);
                            else
                                printf("No data found on that id

                        I think it would  need
                                a- for loops
                                b- flag
                                c- return statements as it's going to be a function.
                                d- the use of linear search.

                        ** without the use of external data structure. ****




                     4- Display all:
                     this  function will display all the employees data, that I have entered
                     WITHOUT !!!!  displaying garbage employees !!!!

                     Ex. any employee that has their data not entered will have an id of (zero).

                    5- Delete by id

                    6- delete by name.
                        this will use strcmp i guess.

                    7- exit.

               summary : menu + struct + functions.




               While development notes:

               1-  We could have added  _getche() and press enter if you want to go back as a function
                    instead of using sleep.


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

employee e [10] = {0};


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


int add_employee()
{
    int id_temp = 0 , id_flag = 0;
    system("cls");

    printf("Please enter an Empolyee ID betweeen 1 and 10 \n");
    printf("Note: it should not have been used before !!!! \n");
    printf(" ID is #  ");
    scanf("%i",&id_temp);

    // this is to be able to use the number inside arrays from 0 to 9
    // to represent 1 to 10.
    id_temp = id_temp -1;

    // this makes sure the number is in the range
    // we could have added redirection to try again, but later.
    if (id_temp < 0 || id_temp > 9)
    {
        system("cls");
        return 0;
    }

    // now check if the id have been (used or not).
    for (int i = 0 ; i < 10; i++)
    {   // if  the person with that index has age stored
        // then the values will be equaled.
        if (e[id_temp].age > 0)
        {
            system("cls");
            // gotoxy (position horizontally, position vertically )
            gotoxy(40,12);
            printf(" The ID has been used before !!!\n");

            gotoxy(35,15);
            textattr(bluepen);
            printf(" Want to override the employees data on # %i ? ", id_temp+1);
            textattr(normalpen);
            gotoxy(40,18);
            printf(" if yes press 'y' else press 'n' ");

            int ch = _getche();

            // override check.
            if (ch == 'n')
                {
                    system("cls");

                    gotoxy(18,15);
                    textattr(yellowpen);
                    printf(" ***** You will get redirected to the (main menu) again in 5 seconds *** ");
                    textattr(normalpen);
                    sleep(5);

                    // usleep( millli-second)

                    system("cls");

                    return 0;
                }
            else if ( ch == 'y')
                { break;}



        }

    }

    system("cls");
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
    e[id_temp].id = id_temp +1;

    printf("%i",e[id_temp].id);


    gotoxy(15,6);
    scanf("%i",&e[id_temp].age);

    // it's important to use _flushall

    _flushall();
    gotoxy(15,9);
    scanf("%c",&e[id_temp].gender);

    _flushall();

    gotoxy(15,12);
    gets(e[id_temp].name);


    gotoxy(15,15);
    gets(e[id_temp].city);

    gotoxy(15,18);
    scanf("%lf",&e[id_temp].salary);

    gotoxy(15,21);
    scanf("%lf",&e[id_temp].overtime);

    gotoxy(15,24);
    scanf("%lf",&e[id_temp].deduct);


//        sleep(10);


    system("cls");






}

int disp_id()
 {
    int id_temp = 0 , id_flag = 0;
    system("cls");

    printf("Please enter an Empolyee ID betweeen 1 and 10 \n");
    printf("Note: Be sure that you already registered it..... \n");
    printf(" ID is #  ");
    scanf("%i",&id_temp);

    // this is to be able to use the number inside arrays from 0 to 9
    // to represent 1 to 10.
    id_temp = id_temp -1;

    // this part to check if the number is correct
    // and if it's already stored or not

        if (id_temp < 0 || id_temp > 9)
        {
        system("cls");
        return 0;
        }

     for (int i = 0 ; i < 10; i++)
    {
        // if  the person with that index has age stored
        // then the values will be equaled.


        // note we have nested if's
        if (e[id_temp].age == 0)
        {
            system("cls");
            // gotoxy (position horizontally, position vertically )

//            gotoxy(40,12);
//            printf(" The ID has no data !!! Want to register it ? \n");

            gotoxy(35,15);
            textattr(bluepen);
            printf(" The ID # %i has no data !!! Want to register it ? ", id_temp+1);
            textattr(normalpen);
            gotoxy(40,18);
            printf(" if yes press 'y' else press 'n' ");

            int ch = _getche();

            // override check.
            if (ch == 'n')
                {
                    system("cls");

                    gotoxy(18,15);
                    textattr(yellowpen);
                    printf(" ***** You will get redirected to the (main menu) again in 5 seconds *** ");
                    textattr(normalpen);
                    sleep(5);

                    // usleep( millli-second)

                    system("cls");

                    return 0;
                }
            else if ( ch == 'y')
                { add_employee();}



            }
        }

        system("cls");

        e[id_temp].id = id_temp +1;

        double net = e[id_temp].salary + e[id_temp].overtime - e[id_temp].deduct;

    printf(" ID: %i , Name: %s , Net.Salary : %0.02lf \n",e[id_temp].id, e[id_temp].name, net);

    printf("------------------------------------ \n");

    printf("press any key to go back");

    _getch();


    system("cls");


 }



disp_all()
{
    // we have to print only the ones that have data !!

    system("cls");


    // now we will need the flag..
    // to check for the case that we don't have any data to show.



    int id_flag = 0 ;




     for (int i = 0 ; i < 10; i++)
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

int delete_id()
{

    int id_temp = 0 , id_flag = 0;
    system("cls");

    printf("Please enter an Empolyee ID betweeen 1 and 10 \n");
    printf("Note: Be sure that you already registered it..... \n");
    printf(" ID is #  ");
    scanf("%i",&id_temp);

    // this is to be able to use the number inside arrays from 0 to 9
    // to represent 1 to 10.
    id_temp = id_temp -1;

    // this part to check if the number is correct
    // and if it's already stored or not

        if (id_temp < 0 || id_temp > 9)
        {
        system("cls");
        return 0;
        }

        for (int i = 0 ; i < 10; i++)
        {
        // if  the person with that index has age stored
        // then the values will be equaled.


        // note we have nested if's
            if (e[id_temp].age != 0)
            {
                e[id_temp].age = 0;

                printf(" \n ID #%i has been deleted. \n", id_temp+1);
                printf("------------------------------------ \n");

            // becuase this mean we found at least one employee.
            id_flag = 1;

            }

        }

       if (id_flag == 0)
       {
           printf("no empolyee data with this id.... \n");
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







delete_name()
{
     char name[50];

    int id_flag = 0;

    system("cls");

    printf("Please enter an Empolyee name to be deleted \n");
    printf("Note: Be sure that you already registered it..... \n");
    printf(" Enter employee name:   ");

    _flushall();
    gets(name);

    // this is to be able to use the number inside arrays from 0 to 9
    // to represent 1 to 10.


    // this part to check if the number is correct
    // and if it's already stored or not



    for(int i = 0; i < 10; i++)
    {


        if( strcmp(name,e[i].name) == 0)
        {
            e[i].age = 0 ;
            id_flag = 1;

            printf("the user %s with id %i has been deleted",e[i].name,e[i].id);

        }


    }




       if (id_flag == 0)
       {
           printf("no data found to be deleted..... \n");
          printf("press any key to go back");

        _getch();
        system("cls");

       }
       else{

         printf("\n press any key to go back");

        _getch();
        system("cls");

       }
}


int main()
{

    // 6 options
    char menu [6][30] = {"new", "display by ID",  "display all" , "delete by id", "delete by name", "Exit" };

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
    for ( i = 0; i < 6; i++)
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

                case 1: // Display by id
                    disp_id();
                break;

                case 2: // Display all
                    disp_all();
                break;

                case 3: // delete by id
                    delete_id();
                break;

                case 4: // delete by name
                    delete_name();
                break;

                case 5: // exit
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
                    if (current < 0) current = 5;
                    break;


                case 80 : // down
                    current ++;
                    if(current >5) current = 0;
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

