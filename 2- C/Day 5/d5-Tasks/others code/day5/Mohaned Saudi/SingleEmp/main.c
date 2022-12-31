#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <windows.h>

/* Task 1 get emp data and print it
 @ Author : Mohaned Saudi
 *
**/

struct Employee
{
    int Id, Age;
    char  Gender, Name[50], Adress[100];
    double Salary, OverTime, Tax;

};


void gotoxy(int x, int y)
{
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),coord);

};

double netSalary(struct Employee emp)
{
    return emp.Salary + emp.OverTime - emp.Tax;
}

void input_employee_data(struct Employee* emp)
{

    printf("Enter details of Employee \n");
    display_employee_data();

    int j=0;
    gotoxy(20, 5 + (j++ * 3));
    scanf("%d", &emp->Id);

    gotoxy(20, 5 + (j++ * 3));
    scanf("%s", emp->Name);

    gotoxy(20, 5 + (j++ * 3));
    scanf("%d", &emp->Age);

    gotoxy(20, 5 + (j++ * 3));
    scanf(" %c", &emp->Gender);

    j = 0;
    gotoxy(55, 5 + (j++ * 3));
    scanf("%s", emp->Adress);

    gotoxy(55, 5 + (j++ * 3));
    scanf("%lf", &emp->Salary);

    gotoxy(55, 5 + (j++ * 3));
    scanf("%lf", &emp->OverTime);

    gotoxy(55, 5 + (j++ * 3));
    scanf("%lf", &emp->Tax);

}


void display_employee_data()
{
    char menue[8][20] =
    {
        "ID : ",
        "Name : ",
        "Age :",
        "Gender : ",
        "Adress :",
        "Salary : ",
        "over Time : ",
        "Tax : "
    };

    printf("****************************************************");
    int j;
    for (j = 0; j < 4; j++ )
    {
        gotoxy(10, 5 + (3 * j));
        printf("%s", menue[j]);
    }

    for ( ; j < 8; j++ )
    {
        gotoxy(40, 5 + 3 * (j - 4));
        printf("%s", menue[j]);
    }
    printf("\n****************************************************");

}

void printEmployeeData(struct Employee emp)
{

    printf("Details of Employee \n");
    printf("********************************\n");

    printf("ID            \t\t: %d ", emp.Id);

    printf("\nName        \t\t: %s ", emp.Name);

    printf("\nAge         \t\t: %d ", emp.Age);

    printf("\nGender      \t\t: %ch ", emp.Gender);

    printf("\nAdress      \t\t: %s ", emp.Adress);

    printf("\nSalary      \t\t: %.2lf ", emp.Salary);

    printf("\nOver Time   \t\t: %.2lf ", emp.OverTime);

    printf("\nTax         \t\t: %.2lf ", emp.Tax);

    printf("\n\n \t_______________Net Salary :  %.2lf _________________ ", netSalary(emp));
    printf("\n********************************\n");
}
int main()
{
    struct Employee emp;
    char ch;
    input_employee_data(&emp);
    ch = _getch();
    system("cls");
    printEmployeeData(emp);

    return 0;
}
