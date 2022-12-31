#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

int i ;
double  Net;


struct Employee
{
    int Id ,Age;
    char Name[100] , Address[200] , Gender;
    double Salary , OverTime , Detuct;
};
struct Employee Emp ;

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
void ScanData()
{
    int i =0 ;
    gotoxy(25 , 5+3*i++);
    scanf("%d", &Emp.Id);

    _flushall();
    gotoxy(25 , 5+3*i++);
    scanf("%d", &Emp.Age);

    _flushall();
    gotoxy(25 , 5+3*i++);
    gets(Emp.Name);

    _flushall();
    gotoxy(25 , 5+3*i++);
    scanf("%c", &Emp.Gender);

    _flushall();
    gotoxy(60,5+3*(i++ -4));
    gets(Emp.Address);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp.Salary);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp.OverTime);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp.Detuct);
}

 // Print Data Function
void PrintData()
{
    system("cls");
    printf("iD :%d\n", Emp.Id);
    printf("Age:%d\n", Emp.Age);
    printf("Name: %s\n", Emp.Name);
    printf("Gender: %c\n", Emp.Gender);
    printf("Address: %s\n", Emp.Address);
    printf("Salary:%lf\n", Emp.Salary);
    printf("%OverTime:%lf\n", Emp.OverTime);
    printf("%Detuct:%lf\n", Emp.Detuct);
    Net = Emp.Salary + Emp.OverTime -Emp.Detuct;
    printf("Net Salary = %lf\n" , Net);


}

int main()
{
  PrintInputs();
  ScanData();
  PrintData();
}
