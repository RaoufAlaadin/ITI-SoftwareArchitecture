#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0b
#define HighLightPen 0xb0
#define Enter 0x0D
#define ESC 27

#define size 3
///Highlight Menu with 3 employees.

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

struct Employee EmpArr[size];

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

void newEmp (int n)
{
    gotoxy(15,5);
    _flushall();
    scanf("%i" , &EmpArr[n].ID);

    gotoxy(15,5+(3*1));
    _flushall();
    gets(EmpArr[n].Name);

    gotoxy(15,5+(3*2));
    _flushall();
    scanf("%lf" , &EmpArr[n].Salary);

    gotoxy(15,5+(3*3));
    _flushall();
    scanf("%lf" , &EmpArr[n].Deduct);

    gotoxy(15,5+(3*4));
    _flushall();
    gets(EmpArr[n].Address);

    gotoxy(50,5);
    _flushall();
    scanf("%i" , &EmpArr[n].Age);

    gotoxy(50,5+(3*1));
    _flushall();
    scanf("%c" , &EmpArr[n].Gender);

    gotoxy(50,5+(3*2));
    _flushall();
    scanf("%lf" , &EmpArr[n].OverTime);
}


void displayEmp (int n)
{
        printf("Employee %i INFO ::\n" , n+1);
        printf("----------------------\n");
        printf("Employee ID : %i\n" , EmpArr[n].ID);
        printf("Employee Name : %s\n" , EmpArr[n].Name);
        printf("Employee Gender : %c\n" , EmpArr[n].Gender);
        printf("Employee Age : %i\n" , EmpArr[n].Age);
        printf("Employee Address : %s\n" , EmpArr[n].Address);
        printf("Employee Salary : %lf\n" , EmpArr[n].Salary +EmpArr[n].OverTime - EmpArr[n].Deduct);
        printf("===================\n");
}

int main()
{
    char Menu[3][8] = {"New " , "Display" , "Exit"} , ch;
    int i , current =0 , ExitFlag =0;

    do
    {
        textattr(NormalPen);
        system("cls");
    for(i =0 ; i <3 ; i++)
    {
        if (current == i)
            textattr(HighLightPen);
        else
            textattr(NormalPen);
        gotoxy(15,10+(3*i));
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
            for (i =0; i <size ; i++)
            {
                system("cls");
                printScreen();
                newEmp(i);
            }
            _getch();
            break;
        case 1: ///Display
            system("cls");
            for (i =0 ; i< size; i++)
            {
                displayEmp(i);
            }
            _getch();
            break;
        case 2: ///Exit
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
            if(current <0) current =2;
            break;
        case 80: //Down
            current++;
            if(current >2) current =0;
            break;
        case 71: //Home
            current=0;
            break;
        case 79: //End
            current=2;
            break;
        }
        break;
        }
    }while(!ExitFlag); //ExitFlag=0 (false)


    _getch();


    return 0;
}
