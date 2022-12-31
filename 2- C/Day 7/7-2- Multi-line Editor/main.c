#include <stdio.h>

// the <stdlib.h> includes atoi() and atof()
#include <stdlib.h>

        /* task 6-3:  1- ِAddin a line editor to an  Array of 10 employees
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

#define highlightpen 224

// this is yellow background with red text
#define yellowpen 192

// not really blue , it' close to the reddish yellow one.
#define bluepen 176
// you might need to write them in capital letters.
#define enter 13
#define esc 27
#define Tab 9
//arrow keys
#define leftArrow 75
#define rightArrow 77
#define backSpace 8
#define UpArrow 72
#define DownArrow 80

#define home 71
#define end 79

typedef struct employee
{int id,age;
    char gender[3], name[100],city[200];
    double salary, overtime, deduct;

    // net = (salary + overtime ) - deduct.
    // we will use this formula everytime we want the net. salary !!

}employee;

/*  if u write a number it might give it to the first element
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

 // our line editor. it will replace all the scanf() in our code.
char* line_editor(int xPos, int yPos,char sCh, char eCh)
{

    /* 1- input:
                a- it takes the xpos and ypos of gotoxy
                    to know where to print the values.
                b- it takes the start and the end of the range
                    of the type of char we want to write

                    -- if we are writing a string or an integer.
                    ( getch() gets called from inside of the fn.)

        2- inside the fn:

                a- it calls getch(); so you are able to enter a character
                b- it then checks if the char you entered suits the range inputed or not

                    -- so the fn only have something like this


                    if ( ch >= sch && ch <= ech )
                    {
                        // if we get here, then the char suits the range.
                        // we tell it the index that it gonne store it in the array


                    }


            3- output:
                    we output a pointer to a char




    */


     /* dynamic alocation is a must !!
     because if you try to return the array. it will be emptied from the stack
     and this will result in null */


    char* ptr;

    // this ptr will be treated as an array of char size(30) later on.
    ptr = (char*) malloc(30*sizeof(char));

    int exitFlag = 0;

    /*      why *pcurrent and *pend ?!
            1- *pcurrent ---> to be able to go back using arrows to replace a char or insert something
            2-  *pend ---> to always the cell we ended typing at, to place a '\0' afterwards

        why do we need '\0' ? ---> because when we use a library fn. like  strcpy(), it will only
                                    stop copying from the array of char when it meets a '\0'

        Scanf() did all of that for us before, now we have to do it manually....

    */

    // we set both of them to --->  the start of the array.
    // Here at intilization. I am de-refrencing the pCurrent and storing the value of ptr
    // the value of ptr is the address it's pointing at.
    // and so now both of them point at the same address.

    char *pCurrent = ptr,*pEnd = ptr;

    // note that we we will be taking everything as a char
    char ch;



    /* we HAVE to use getch() to NOT preview the letter when writing it.
        this give us the chance to check if it suits the range.
        without needing to clear it from the screen with a space ' ' to
        hide it from the user.
    */



    do{
            /*  You must put gotoxy before the _getch() !!!!!!!!!!!!
                to know the actual place that wants you to input something
                before pressing anything....
                other than that the cursor would be going crazy. */
            gotoxy(xPos,yPos); // this is important for the movement of cursor
            ch = _getch();
//            textattr(highlightpen);




            switch (ch)
            {
                case enter: // we want to end the text and return it
                    pEnd++;
                    *pEnd = '\0';
                    // this (return statement) is how i get out of the while loop.
                    return ptr;
                    break;

                case leftArrow:
                    if(pCurrent > ptr)
                    {
                        --pCurrent;
                        --xPos;
                    }

                break;

                case rightArrow:
                    if(pCurrent < pEnd)
                    {
                        ++pCurrent;
                        ++xPos;
                    }
                break;

                case home:
                    /* we always have to think of both the screen and memory views.
                      the order of lines is important.. to use the distance between pointers
                      before setting pCurrent to the same location as ptr */

                      // order of lines is IMPORTANT
                    xPos = xPos - (pCurrent - ptr);
                    pCurrent = ptr;
                    break;

                case end:
                    xPos = xPos + (pEnd - pCurrent);
                    pCurrent = pEnd;
                    break;

                case esc:
                    gotoxy(0,30);
                    exit(1);


                default:  // the default makes it like we don't have a switch statement
                          // but if the switch cases are met "sometimes" then they are useful.

                    if (ch >= sCh && ch <= eCh  || ch =='.' || ch == ' ')
                    {
                    /* we have to 2 sides, screen view and memory view.
                        1- screen view: this is done using printf() if the condition is met.
                        2- memory view: you keep storing all the values in the allocated space
                                then after you press Enter --> '\0' is inputed.
                                and you return the ptr to the array as a fn output
                               */

                            /* it's fine printing is as a char --- > ex: '1' is 49 in ascii----- BUT !!
                                when we store it in memory it has be an integar not a char
                                to be able to do calculations on it.
                            because the char '1' is actually 49 numerically not 1
                        */
                    printf("%c",ch);

                    // de-referencing the location I am pointing at
                    // then storing the value of ch inside of it.
                    *pCurrent = ch ;

                    /* this check is important to make sure pEnd isn't pushed
                     when pCurrent returns to the middle of the text to edit it. */

                    if(pCurrent == pEnd)
                    {
                        pEnd++;
                    }

                    pCurrent++;

                    xPos++ ; // this will move the cursor in the horitzonatl postion.

//                    printf(" this is what stored in memory : %c", *ptr);

//                    ptr[i] = ch;  don't use this because it won't be as flexiable later on.

                    }



            }

//        textattr(normalpen);




    }while (exitFlag == 0);


  }



char** Multi_LineEditor(int c, int *size, int* xPos, int* yPos,char* sChar, char* eChar)
{
    // c -- number of lines ( also means no. of rows )
    // int *size --- pointer to an array that hold char array sizes in order.

     /*  Very impotrant !!!

            ptr : int** --> pointer to a pointer

            ptr[i]: int* --> pointer to a start of an array

            ptr[i][j]: int --> the value of an element inside the array.

     */


    int i , k = 0 , exitFlag = 0;
    char ch;

    // 1- creating the array of pointers
    char** ptr = (char**) malloc(c * sizeof(char*));

    // array of pointers to just point at the char arrays allocated by ptr in the for loop.
    char** pCurrent = (char**) malloc(c * sizeof(char*));
    char** pEnd = (char**) malloc(c * sizeof(char*));

    for(i = 0; i < c; i++)
    {
        // 2- creating an array linked to each of the pointers array.
        ptr[i] = (char*) malloc(size[i] *sizeof(char));

        //intilizing the pointers.
        pCurrent[i] = ptr[i];
        pEnd[i] = ptr[i];
    }



   /*  inside this function we still have :

                    1- array of xpos
                    2- array of ypos
                    3- array of start char
                    4- array of end char*/
    do{

            gotoxy(xPos[k],yPos[k]); // this is important for the movement of cursor
            ch = _getch();


            switch (ch)
            {
                case DownArrow:

                    if (k < 7)
                    {
                        k++;
                    }
                    else{ k = 0;}
                    break;

                case UpArrow:
                   if (k > 0)
                    {
                        k--;
                    }
                    else{ k = 7;}
                    break;

                case Tab:
                    if (k < 7)
                    {
                        k++;
                    }
                    else{ k = 0;}
                    break;

                case enter: // we want to end the text and return it
                    for(int i = 0; i < c; i++)
                    {
                        *(pEnd[i]+1) = '\0';
                    }

                    // this (return statement) is how i get out of the while loop.
                    return ptr;
                    break;

                case leftArrow:
                    if(pCurrent[k] > ptr[k])
                    {
                        --pCurrent[k];
                        --xPos[k];
                    }
                    break;

                case rightArrow:
                    if(pCurrent[k] < pEnd[k])
                    {
                        ++pCurrent[k];
                        ++xPos[k];
                    }
                    break;

                case home:


                      // order of lines is IMPORTANT
                    xPos[k] = xPos[k] - (pCurrent[k] - ptr[k]);
                    pCurrent[k] = ptr[k];
                    break;

                case end:
                    xPos[k] = xPos[k] + (pEnd[k] - pCurrent[k]);
                    pCurrent[k] = pEnd[k];
                    break;

                case esc:
                    gotoxy(0,30);
                    exit(1);


                default:  // the default makes it like we don't have a switch statement
                          // but if the switch cases are met "sometimes" then they are useful.

                    if (ch >= sChar[k] && ch <= eChar[k]  || ch =='.' || ch == ' ')
                    {


                            printf("%c",ch);
                            *(pCurrent[k]) = ch ;



                            if(pCurrent[k] == pEnd[k])
                            {
                                pEnd[k]++;
                            }

                            pCurrent[k]++;

                            xPos[k]++ ; // this will move the cursor in the horitzonatl postion.

                    }

            }





    }while (exitFlag == 0);

    free(pCurrent);
    free(pEnd);

}

add_employee()
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

        // defining input arrays

        int c = 8;

        int size[]={3,3,2,20,20,10,10,10};

        int x []={15,15,15,15,15,15,15,15};
        int y []={3,6,9,12,15,18,21,24};

        char sChar[] ={'0','0','a','a','a','0','0','0'};
        char eChar[] ={'9','9','z','z','z','9','9','9'};

        char ** Data;

        Data = Multi_LineEditor(c, size, x, y, sChar, eChar);

        int id_temp = 0 , id_flag = 0;

    id_temp = atoi(Data[0]) ;



//     this is to be able to use the number inside arrays from 0 to 9
//     to represent 1 to 10.
    id_temp = id_temp -1;



        // memory storing.

        // 1- ID
    e[id_temp].id = atoi(Data[0]);

    // 2- AGE
    e[id_temp].age = atoi(Data[1]);


    // 3-storing Gender !! (special case) -- because we only want one char.

    // note: I forget to make the gender as  ( char gender[3]) and had it like ( char gender)
    //          which cannot be used with strcpy.... that's why I was getting that error.
    strcpy(e[id_temp].gender,Data[2]);


    // 4- Name

    strcpy(e[id_temp].name,Data[3]);


    // 5- city

   strcpy(e[id_temp].city,Data[4]);

    // 6- salary

    e[id_temp].salary = atof(Data[5]);

    // 7- overtime


    e[id_temp].overtime = atof(Data[6]);

    // 8- deduct

    e[id_temp].deduct = atof(Data[7]);


//        sleep(10);

    for(int i = 0; i < c; i++)
    {
        free(Data[i]);
    }

    free(Data);

    system("cls");



}

 disp_id()
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
        return;
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

                    return;
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

delete_id()
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
        return;
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

//    char line [11] = malloc(sizeof(char)*11);

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

