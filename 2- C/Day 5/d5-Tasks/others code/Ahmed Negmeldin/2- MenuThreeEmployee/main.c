#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>
#include <string.h>

#define MenuCount 3
#define EmpCount 3
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 27
#define SpecialIndicator -32
#define Up 72
#define Down 80
#define Home 71
#define End 79


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

Employee getEmployee()
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

    return emp;
}

void displayEmployees(Employee *emp)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // display Employee info
        if (strcmp("", emp[i].Name) != 0)
            printf("%i. %s, $%.2lf\n\n", emp[i].ID, emp[i].Name, emp[i].Salary + emp[i].OverTime - emp[i].Deduct);
    }
}

void waitKey()
{
    printf("\n\n\n(press any key to continue)");
    _getch();
    _flushall();
}

int main()
{

    // menu stores entry options, key stores user input
    // data stores saved text, dataTemp cashes user data
    char menu[MenuCount][8] = {"New    ", "Display", "Exit   "}, key;
    // current highlighted option, exitFlag when ESC or Exit
    int current = 0, exitFlag = 0, empIndex = 0;
    // array of employees
    Employee emp[EmpCount] = {};

    // print menu after each key stroke, until user exits
    do
    {
        system("cls");

        // print menu entries
        for (int i = 0; i < MenuCount; i++)
        {
            // highlight current
            if (current == i)
                textattr(HighLightPen);


            gotoxy(5, 10+3*i);
            // print this entry
            puts(menu[i]);
            // reset text color
            textattr(NormalPen);
        }

        // get user input
        key = _getch();

        // react to user input
        switch (key)
        {
        case ESC:
            exitFlag = 1;
            break;

        case Enter:
            // do current entry
            switch (current)
            {
            case 0: // new
                system("cls");
                if (empIndex < EmpCount)
                {
                    emp[empIndex++] = getEmployee();
                }
                else
                {
                    printf("You've entered all three employees.");
                    waitKey();
                }
                break;

            case 1: // display
                system("cls");
                displayEmployees(emp);
                waitKey();
                break;

            case 2: // exit
                exitFlag = 1;
                break;
            }

            break;

        case SpecialIndicator: // extended keys

            // read from buffer
            key = _getch();

            // perform key
            switch (key)
            {
            case Up:
                current = !current ? MenuCount-1 : current - 1;
                break;

            case Down:
                current = current == MenuCount-1 ? 0 : current + 1;
                break;

            case Home:
                current = 0;
                break;

            case End:
                current = MenuCount-1;
                break;
            }

            break;
        }
    }
    while (!exitFlag);

    return 0;
}
