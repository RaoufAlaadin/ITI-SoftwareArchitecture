#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

typedef struct Employee
{
    int ID, Age;
    char Gender, Name[100], Address[200];
    double Salary, OverTime, Deduct;
} Employee;

/*
    function to colorize output
*/
void textattr (int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

/*
    function to move cursor to x, y
*/
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

int main()
{
    Employee emp;
    char formEntries[8][12] = {"ID        :", "Age       :", "Gender M/F:", "Name      :", \
                               "Address   :", "Salary    :", "Over  Time:", "Deduct    :"
                              };

    // print form
    for (int i = 0; i < 8; i++)
    {
        gotoxy((i/6)*35+3, (i%6)*3+3);
        puts(formEntries[i]);
    }

    // get form enteries from user
    int i = 0;
    gotoxy((i++/6)*35+15, (i%6)*3+3);
    scanf("%i", &emp.ID);

    gotoxy((i++/6)*35+15, (i%6)*3+3);
    scanf("%i", &emp.Age);

    // get gender, make sure it's M or F
    do
    {
        gotoxy((i/6)*35+15, (i%6)*3+3);
        printf("                   ");
        gotoxy((i/6)*35+15, (i%6)*3+3);
        scanf("%c", &emp.Gender);
    }
    while (emp.Gender != 'M' && emp.Gender != 'F');
    i++;

    _flushall();

    gotoxy((i++/6)*35+15, (i%6)*3+3);
    gets(emp.Name);

    gotoxy((i++/6)*35+15, (i%6)*3+3);
    gets(emp.Address);

    gotoxy((i++/6)*35+15, (i%6)*3+3);
    scanf("%lf", &emp.Salary);

    gotoxy((i++/6)*35+15, (i%6)*3+3);
    scanf("%lf", &emp.OverTime);

    gotoxy((i++/6)*35+15, (i%6)*3+3);
    scanf("%lf", &emp.Deduct);

    // clear screen
    system("cls");

    // display Employee info
    printf("%i. %s, $%lf", emp.ID, emp.Name, emp.Salary + emp.OverTime - emp.Deduct);

    gotoxy(0, 20);
    return 0;
}
