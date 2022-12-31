#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>

///Highlight Menu with 1 employee.

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


struct Employee
{
    int ID, Age;
    char Gender ,Name[100] , Address[200];
    double Salary, OverTime, Deduct; //Deduct = tax
};

struct Employee E;

void printScreen ()
{


    int i , current =0 , ExitFlag =0;
    char Form[8][10] = {"ID" ,"Name" ,"Salary", "Tax" , "Address", "Age", "Gender", "OverTime"} , ch;

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

void newEmp ()
{
    gotoxy(15,5);
    _flushall();
    scanf("%i" , &E.ID);

    gotoxy(15,5+(3*1));
    _flushall();
    gets(E.Name);

    gotoxy(15,5+(3*2));
    _flushall();
    scanf("%lf" , &E.Salary);

    gotoxy(15,5+(3*3));
    _flushall();
    scanf("%lf" , &E.Deduct);

    gotoxy(15,5+(3*4));
    _flushall();
    gets(E.Address);

    gotoxy(50,5);
    _flushall();
    scanf("%i" , &E.Age);

    gotoxy(50,5+(3*1));
    _flushall();
    scanf("%c" , &E.Gender);

    gotoxy(50,5+(3*2));
    _flushall();
    scanf("%lf" , &E.OverTime);
}


void displayEmp ()
{
    system("cls");

    printf("Employee ID : %i\n" , E.ID);
    printf("Employee Name : %s\n" , E.Name);
    printf("Employee Gender : %c\n" , E.Gender);
    printf("Employee Age : %i\n" , E.Age);
    printf("Employee Address : %s\n" , E.Address);
    printf("Employee Salary : %lf\n" , E.Salary +E.OverTime - E.Deduct);
}

int main()
{
    printScreen();
    newEmp();
    displayEmp();
    return 0;
}
