#include <stdio.h>
#include <stdlib.h>

// C++ headers
#include <iostream>

using namespace std;


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



typedef struct EmpNode
{
    // this part is all considered data
    int id,age;
    char gender, name[100],city[200];
    double salary, overtime, deduct;

    // we have to type struct here, as the typedef was not yet declared for it.
   struct EmpNode* PNext;
   struct EmpNode* PPrev;

}EmpNode;


EmpNode* PStart;
EmpNode* PLast;





//1- NEW NODE FN.

EmpNode* NewNode(int D )
    {
        EmpNode* PNew = new EmpNode();
        if ( PNew == NULL) exit(0);

        PNew ->id = D;

        PNew ->PNext = NULL;
        PNew ->PPrev = NULL;


        return PNew;

    }

// 2- Adding Emploee Data

int add_employee()
{
    int id_temp = 0 , id_flag = 0;
    system("cls");

    printf("Please enter an Empolyee ID betweeen 1 and 10 \n");
    printf("Note: it should not have been used before !!!! \n");
    printf(" ID is #  ");
    scanf("%i",&id_temp);


    if (id_temp < 1 || id_temp > 10)
    {
        system("cls");
        return 0;
    }

     EmpNode* PNew = NewNode(id_temp);

    // here we continue adding the data.

    if (PLast == NULL)
        PLast = PStart = PNew;
    else
    {


       PLast->PNext = PNew;
       PNew->PPrev = PLast;
       PLast = PNew;
    }

    // node was created. now we add the values to it.

    char add_menu [8][30] = {"ID", "age", "gender" , "name", "city", "salary" ,"overtime", "deduct" };

    int i , current = 0 , exitflag = 0, ch ;

    system("cls");

    for ( i = 0; i < 8; i++)
        {
            gotoxy(5,3+(3*i));

            printf("%s",add_menu[i]);


        }

      gotoxy(15,3);
    printf("%i",PNew->id);


    gotoxy(15,6);
    scanf("%i",&PNew->age);

    // it's important to use _flushall

    _flushall();
    gotoxy(15,9);
    scanf("%c",&PNew->gender);

    _flushall();

    gotoxy(15,12);
    gets(PNew->name);


    gotoxy(15,15);
    gets(PNew->city);

    gotoxy(15,18);
    scanf("%lf",&PNew->salary);

    gotoxy(15,21);
    scanf("%lf",&PNew->overtime);

    gotoxy(15,24);
    scanf("%lf",&PNew->deduct);



    system("cls");


}


// 3- the standared search fn, used implicitly
EmpNode* SearchList(int key)
{
    // gets the Psearch to point to the node at the start of the linked list.
    EmpNode* Psearch = PStart;

    while(Psearch != NULL)
    {
        if (Psearch ->id == key)
        {
            cout<<"==============================" <<endl;
            cout<< "Founded the Employee  !! \n";
            cout<<"==============================" <<endl;
            // gets us out of the while loop.
            break;
        }

        // moves us to the next node.
        Psearch = Psearch ->PNext;
    }

    return Psearch;
}


// 4- only a True or false search
int Search()
 {
    int id_temp = 0 , id_flag = 0;
    system("cls");

    printf("Please enter an Empolyee ID betweeen 1 and 10 \n");
    printf("Note: Be sure that you already registered it..... \n");
    printf(" ID is #  ");
    scanf("%i",&id_temp);


        if (id_temp < 1 || id_temp > 10)
        {
        system("cls");
        return 0;
        }


        system("cls");

        /////////////////////////////////

          EmpNode* pDisplay = SearchList(id_temp);

            if (pDisplay == NULL)

                {
                    cout<<"==============================" <<endl;
                    cout<< "the Specific employee was Not found" << endl;
                    cout<<"==============================" <<endl;
                }

     /////////////////////////////

    printf(" \n \n press any key to go back");

    _getch();


    system("cls");


 }


// 5- Display by ID
int disp_id()
 {
    int id_temp = 0 , id_flag = 0;
    system("cls");

    printf("Please enter an Empolyee ID betweeen 1 and 10 \n");
    printf("Note: Be sure that you already registered it..... \n");
    printf(" ID is #  ");
    scanf("%i",&id_temp);


        if (id_temp < 1 || id_temp > 10)
        {
        system("cls");
        return 0;
        }


        system("cls");

        /////////////////////////////////

          EmpNode* pDisplay = SearchList(id_temp);

            if (pDisplay == NULL)

                 {
                    cout<<"==============================" <<endl;
                    cout<< "the Specific employee was Not found" << endl;
                    cout<<"==============================" <<endl;
                }
            else
                {
                    cout<<"==============================" <<endl;

                    double net = pDisplay->salary + pDisplay->overtime - pDisplay->deduct;

                    printf(" ID: %i , Name: %s , Net.Salary : %0.02lf \n",pDisplay->id, pDisplay->name, net);

                    printf("------------------------------------ \n");
                }

     /////////////////////////////

    printf(" \n \n press any key to go back");

    _getch();


    system("cls");


 }


// 6- Display ALL
void disp_all()
{
    system("cls");

    EmpNode* pDisplay = PStart;

    cout<<"==============================" <<endl;

    while( pDisplay != NULL)
    {
            double net = pDisplay->salary + pDisplay->overtime - pDisplay->deduct;

            printf(" ID: %i , Name: %s , Net.Salary : %0.02lf \n",pDisplay->id, pDisplay->name, net);

            printf("------------------------------------ \n");
        // then we move the pointer to the next node.

        pDisplay = pDisplay ->PNext;

    }

    printf(" \n \n press any key to go back");

        _getch();
    system("cls");
}



// 7- Delete By ID

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


    // this part to check if the number is correct
    // and if it's already stored or not

        if (id_temp < 1 || id_temp > 10)
        {
        system("cls");
        return 0;
        }

        EmpNode* pDelete = SearchList(id_temp);

    // Case 1- if pDelete points to nothing, then the SearchList didn't find our object.
    if ( pDelete == NULL)
    {
        cout<<"==============================" <<endl;
        cout << "Employee was not found, Try again." << endl;
        cout<<"==============================" <<endl;
    }
    else
    {

        if (PStart == PLast)
        {

            PStart = PLast = NULL;


        }
        // Case 3- if the node at the start of the linked list
        else if ( pDelete == PStart)
        {
            // point to the 2nd node
            PStart = PStart->PNext;
            // set the PPrev for the 2nd node to be null, As we are going to delete the 1st node.
            PStart->PPrev = NULL;
        }
        // Case 4- node at the end
        else if(pDelete == PLast)
        {
            // same as case 2, but doing it at the end.
            PLast = PLast->PPrev;
            PLast ->PNext = NULL;
        }
        else
        {   // Case 5 - (General Case) - a node in the middle of a big list

           pDelete->PPrev->PNext = pDelete->PNext;
           pDelete ->PNext->PPrev = pDelete->PPrev;
        }

            cout<<"==============================" <<endl;
         cout << "Employee with the id : "<< pDelete->id << " has been deleted" << endl;
         cout<<"==============================" <<endl;
        delete pDelete;

    }



        printf("\n \n press any key to go back");

        _getch();
        system("cls");





}



// 8- Delete ALL
delete_all()
{

    system("cls");

    EmpNode* pDelete;

    while (PStart != NULL)
    {
        pDelete = PStart;
        // this will set Pstart = NUll at the last node.
        PStart = PStart ->PNext;
        delete  pDelete;
    }



    PLast = NULL;

    cout<<"==============================" <<endl;
    cout<<"Everything was deleted" <<endl;
    cout<<"==============================" <<endl;

         printf("\n \n press any key to go back");

        _getch();
        system("cls");


}


int main()
{

    // 6 options
    char menu [7][30] = {"Add Node", "Search" , "Display by ID",  "Display all" , "Delete Node", "Delete all", "Exit" };

    int i , current = 0 , exitflag = 0, ch ;


do{
    // check this part.
    textattr(normalpen);



    for ( i = 0; i < 7; i++)
    {
        // this will highlight the first word only
        // when i = 0 , same as current = 0.
        if (current == i)
            textattr(highlightpen);
        else
        textattr(normalpen);



        gotoxy(5,3+(3*i));

        printf("%s",menu[i]);
    }

    ch = _getch();

    switch (ch)
    {
        case enter:
            switch (current)
            {

                case 0: // new

                     add_employee();
                break;

                case 1: // seaarch

                     Search();
                break;

                case 2: // Display by id
                    disp_id();
                break;

                case 3: // Display all
                    disp_all();
                break;

                case 4: // delete by id
                    delete_id();
                break;

                case 5: // delete by name
                    delete_all();
                break;

                case 6: // exit
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
                    if (current < 0) current = 6;
                    break;


                case 80 : // down
                    current ++;
                    if(current >6) current = 0;
                    break;


                case 71: //home

                    // (home) takes u to the most upper value.
                    current = 0;
                    break;

                case 79: // end

                    // (end) takes u to the most lower value.
                    current = 6;
                    break;
            }
            break;
    }

}
while(exitflag == 0);



}

