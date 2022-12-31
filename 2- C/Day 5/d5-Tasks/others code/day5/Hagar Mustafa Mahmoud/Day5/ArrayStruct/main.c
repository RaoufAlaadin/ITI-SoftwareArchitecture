#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define Enter 0x0D



int i ;
double Net;
char ch;


struct Employee
{
    int Id ,Age;
    char Name[100] , Address[200] , Gender;
    double Salary , OverTime , Detuct;
};
struct Employee Emp[3];

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


 // Print Inputs Function
 void PrintInputs()
 {
     char Inputs[8][60] =
     {
         "ID:" ,
         "Age:",
         "Name:",
         "Gender:",
         "Address:",
         "Salary:",
         "OverTime:",
         "Detuct:"
     };

    for(i=0 ; i< 4 ; i++)
   {
    gotoxy(15,5 + 3*i);
    printf("%s",Inputs[i]);
   }
     for( i=4 ; i< 8 ; i++)
   {
    gotoxy(50,5 +3*(i-4));
    printf("%s",Inputs[i]);
   }

 }



 // Scan Data Function
void ScanData(int k)
{

       int i=0;
    gotoxy(25 , 5+3*i++);
    scanf("%d", &Emp[k].Id);

    _flushall();
    gotoxy(25 , 5+3*i++);
    scanf("%d", &Emp[k].Age);

    _flushall();
    gotoxy(25 , 5+3*i++);
    gets(Emp[k].Name);

    _flushall();
    gotoxy(25 , 5+3*i++);
    scanf("%c", &Emp[k].Gender);

    _flushall();
    gotoxy(60,5+3*(i++ -4));
    gets(Emp[k].Address);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp[k].Salary);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp[k].OverTime);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp[k].Detuct);


}


 // Print Data Function
void PrintData(int k)
{



    printf("Data for the Employee NO. %d\n\n",k);
    printf("iD :%d\n",Emp[k].Id );
    printf("Age:%d\n", Emp[k].Age);
    printf("Name:%s\n", Emp[k].Name);
    printf("Gender:%c\n", Emp[k].Gender);
    printf("Address:%s\n", Emp[k].Address);
    printf("Salary=\t%lf\n", Emp[k].Salary);
    printf("OverTime=\t%lf\n", Emp[k].OverTime);
    printf("Detuuct=\t%lf\n", Emp[k].Detuct);
    Net = Emp[k].Salary + Emp[k].OverTime -Emp[k].Detuct;
    printf("Net Salary = \t%lf\n" , Net);
    printf("____________________________________________\n");

   }





int main()
{
    int j , r;

    for(j=0 ; j<3 ; j++)
    {
        PrintInputs();
        ScanData(j);
        system("cls");

    }

    system("cls");


for (r=0 ;r<3 ; r++)
{
    PrintData(r);
}








}


