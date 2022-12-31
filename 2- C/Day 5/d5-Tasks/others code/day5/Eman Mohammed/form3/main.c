#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0b
#define HighLightPen 0xb0
#define Enter 0x0D
#define ESC 27

#define size 10
#define itemsNumber 6
#define itemLength 20

///Highlight Menu with 10 employees.

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

  void textattr (int i)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

struct Employee
{
    int ID, Age;
    char Gender ,Name[100] , Address[200];
    double Salary, OverTime, Deduct; //Deduct = tax
};

struct Employee EmpArr[size] ;
int i;

///Print Employee INFO
void printEmployee (int choice)
{
    printf("Employee %i INFO ::\n" , choice+1);
    printf("------------------\n");
    printf("Employee ID : %i\n" , EmpArr[choice].ID);
    printf("Employee Name : %s\n" , EmpArr[choice].Name);
    printf("Employee Gender : %c\n" , EmpArr[choice].Gender);
    printf("Employee Age : %i\n" , EmpArr[choice].Age);
    printf("Employee Address : %s\n" , EmpArr[choice].Address);
    printf("Employee Salary : %lf\n" , EmpArr[choice].Salary +EmpArr[choice].OverTime - EmpArr[choice].Deduct);
    printf("===================\n");
}

///Print Form Screen
void printScreen (int choice)
{
    int current =0 , ExitFlag =0;
    char Form[8][10] = {"ID" ,"Name" ,"Salary", "Tax" , "Address", "Age", "Gender", "OverTime"} , ch;

    printf("Employee #%i : " , choice);
    printf("\n");
    for(i =0 ; i <5 ; i++)
    {
        gotoxy(5,5+(3*i));
        printf("%s : " , Form[i]);
    }
    //_flushall();
    for(i =0; i <5 ; i++)
    {
        gotoxy(40,5+(3*i));
        if ( i < 3)
            printf("%s : " , Form[i+5]);
        else
            printf("\n");
    }
    gotoxy(15,5);
    ch = _getch();

}

///create new employee
void newEmp (int choice)
{



    gotoxy(15,5);
    _flushall();
    scanf("%i" , &EmpArr[choice-1].ID);

    gotoxy(15,5+(3*1));
    _flushall();
    gets(EmpArr[choice-1].Name);

    gotoxy(15,5+(3*2));
    _flushall();
    scanf("%lf" , &EmpArr[choice-1].Salary);

    gotoxy(15,5+(3*3));
    _flushall();
    scanf("%lf" , &EmpArr[choice-1].Deduct);

    gotoxy(15,5+(3*4));
    _flushall();
    gets(EmpArr[choice-1].Address);

    gotoxy(50,5);
    _flushall();
    scanf("%i" , &EmpArr[choice-1].Age);

    gotoxy(50,5+(3*1));
    _flushall();
    scanf("%c" , &EmpArr[choice-1].Gender);

    gotoxy(50,5+(3*2));
    _flushall();
    scanf("%lf" , &EmpArr[choice-1].OverTime);

}

///display all employees
void displayEmp ()
{
    int n , count = 0;
    for (n =0 ; n< size; n++)
    {
        if(EmpArr[n].ID == 0)
            count++;
            continue;
    }
    if (count == size)
    {
        printf("There are no Employees");
    }
    else
    {
        printEmployee(n);
    }
}

///Display Employee By ID
void DisplayByID (int choice)
{
    system("cls");
    char ch;

    while(EmpArr[choice-1].ID == 0)
    {
        printf("Employee #%i not Found \nEnter another Index : " , choice );
        ch = _getch();
        if (ch == ESC)
        {
            break;
        }
        scanf("%i" , &choice);
    }
    if (ch != ESC)
    {
    printEmployee(choice-1);
    }

}

///Delete Employee By ID
void DeleteByID (int choice)
{
    system("cls");
    char ch;

    while(EmpArr[choice-1].ID == 0)
    {
        printf("Employee #%i not Found \nEnter another Index : " , choice );
        ch = _getch();
        if (ch == ESC)
        {
            break;
        }
        scanf("%i" , &choice);
    }
    if (ch != ESC)
    {
    printf("Employee #%i is Deleted" , choice );
    EmpArr[choice-1].ID = 0;
    }

}

///Delete Employee By Name
void DeleteByName (char choice [])
{
    system("cls");
    int n, deleteFlag =0 , ExitFlag =0;
    char ch;

    do
    {
        for(n =0 ; n< size; n++)
        {
            if (strcmp(EmpArr[n].Name ,choice)==0 && EmpArr[n].ID != 0)
            {
                printf("Employee %s is Deleted" , choice );
                EmpArr[n].ID = 0;
                strcpy(EmpArr[n].Name , "");
                deleteFlag = 1;
                break;
            }
        }
       if(!deleteFlag)
        {
            printf("Employee %s not Found \nEnter another Name : " , choice );
            ch = _getch();
            if (ch == ESC)
            {
                break;
            }
            gets(choice);
            _flushall();
        }
    }while(!deleteFlag );
}

int main()
{
    char Menu[itemsNumber][itemLength] = {"New " , "Display By ID", "Display All" ,"Delete By ID" ,"Delete By Name" , "Exit"} , ch, nameUser[100];
    int current =0 , ExitFlag =0 , index;

    for ( i=0 ; i< size ; i++)
    {
        EmpArr[i].ID = 0;
        strcpy(EmpArr[i].Name , "");
    }

    do
    {
        textattr(NormalPen);
        system("cls");

    for(i =0 ; i <itemsNumber ; i++)
    {
        if (current == i)
            textattr(HighLightPen);
        else
            textattr(NormalPen);
        gotoxy(15,5+(3*i));
        printf("%s" , Menu[i]);
    }
    ch = _getch();
    switch(ch)
    {
    case Enter:
        switch(current)
        {
        case 0: ///New
            system("cls");
            printf("Enter Index : ");
            scanf("%i" , &index);
            system("cls");
            while(EmpArr[index-1].ID != 0)
            {
                printf("Employee #%i is already exists \nEnter another Index : " , index );
                scanf("%i" , &index);
            }
            system("cls");
            printScreen(index);
            newEmp(index);
            _getch();
            break;
        case 1: ///Display By ID
            system("cls");
            printf("Enter Index : ");
            scanf("%i" , &index);
            DisplayByID (index);
            _getch();
            break;
        case 2: ///Display
            system("cls");
            displayEmp();
            _getch();
            break;
        case 3: ///Delete By ID
            system("cls");
            printf("Enter Index : ");
            scanf("%i" , &index);
            DeleteByID (index);
            _getch();
            break;
        case 4: ///Delete By Name
            system("cls");
            puts("Enter Name : ");
            gets(nameUser);
            _flushall();
            DeleteByName (nameUser);
            _getch();
            break;

        case 5: ///Exit
            ExitFlag =1;
            break;
        }
        break;
    case ESC:
        ExitFlag =1;
        break;
    case -32: //0xFFFFFFE0 //extended key
        ch = _getch(); ///get second byte from buffer
        switch(ch)
        {
        case 72: //UP
            current--;
            if(current <0) current =5;
            break;
        case 80: //Down
            current++;
            if(current >5) current =0;
            break;
        case 71: //Home
            current=0;
            break;
        case 79: //End
            current=5;
            break;
        }
        break;
        }
    }while(!ExitFlag); //ExitFlag=0 (false)


    _getch();


    return 0;
}
