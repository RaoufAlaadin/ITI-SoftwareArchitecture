#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
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

struct employee
{
    int ID,Age;
    char Gender,Name[100],Adress[100];
    double Salary,Overtime,Deduct;
};


int main()
{
    struct employee E;

    gotoxy(5,10);
    printf("ID:\n");
    gotoxy(5,13);
    printf("Age:\n");
    gotoxy(5,16);
    printf("gender:\n");
    gotoxy(5,19);
    printf("Name:\n");
    gotoxy(5,22);
    printf("Address:\n");
    gotoxy(5,25);
    printf("Salary\n");
    gotoxy(5,28);
    printf("Overtime\n");
    gotoxy(5,31);
    printf("Deduct\n");


    gotoxy(12,10);
    scanf("%d",&E.ID);
    gotoxy(12,13);
    scanf("%d",&E.Age);
    gotoxy(12,16);
    E.Gender=_getche();
    gotoxy(12,19);
    scanf("%s",E.Name);
    gotoxy(12,22);
    scanf("%s",E.Adress);
    gotoxy(12,25);
    scanf("%d",&E.Salary);
    gotoxy(12,28);
    scanf("%d",&E.Overtime);
    gotoxy(12,31);
    scanf("%d",&E.Deduct);



    gotoxy(20,33);

    printf("netsalary= %d",(E.Salary+E.Overtime)-E.Deduct);














    return 0;
}
