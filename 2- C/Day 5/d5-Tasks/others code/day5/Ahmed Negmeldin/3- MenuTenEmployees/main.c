#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>
#include <string.h>

#define MenuCount 6
#define EmpCount 10

#define NotFound "\nThis employee wasn't found.\n"

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

/*
    go to the place where user will enters input number i
*/
void gotoIInput(int i)
{
    gotoxy((i/6)*35+15, (i%6)*3+3);
}

/*
    function to prints new employee form and gets information from user
*/
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

    _flushall();

    // get form enteries from user
    int i = 0;
    gotoIInput(i++);
    scanf("%i", &emp.ID);

    gotoIInput(i++);
    scanf("%i", &emp.Age);

    // get gender, make sure it's M or F
    do
    {
        gotoIInput(i);
        printf("                   ");
        gotoIInput(i);
        scanf("%c", &emp.Gender);
    }
    while (emp.Gender != 'M' && emp.Gender != 'F');
    i++;

    _flushall();

    // get name, make sure it's not empty
    do
    {
        gotoIInput(i);
        printf("                   ");
        gotoIInput(i);
        gets(emp.Name);
    }
    while (strcmp(emp.Name, "") == 0);
    i++;

    gotoIInput(i++);
    gets(emp.Address);

    _flushall();

    gotoIInput(i++);;
    scanf("%lf", &emp.Salary);

    gotoIInput(i++);
    scanf("%lf", &emp.OverTime);

    gotoIInput(i++);
    scanf("%lf", &emp.Deduct);

    _flushall();

    return emp;
}

/*
    prints employee summary using its index in the emp array
*/
void displayEmployeeIndex(Employee *emp, int i)
{
    printf("\n%i. %s, $%.2lf\n\n", emp[i].ID, emp[i].Name, emp[i].Salary + emp[i].OverTime - emp[i].Deduct);
}

/*
    displays all employees from emp array
*/
void displayEmployees(Employee *emp)
{
    // records if the list empty or not
    int empty = 0;
    for (int i = 0; i < EmpCount; i++)
    {
        // display Employee info if exists
        if (strcmp("", emp[i].Name) != 0)
        {
            empty++;
            displayEmployeeIndex(emp, i);
        }
    }

    if (!empty)
        printf("There are no employees, yet");
}

/*
    displays an employee from the emp Arr using its ID
*/
void displayEmployeeID(Employee *emp, int id)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // display Employee info if the ID matches
        if (id == emp[i].ID && strcmp("", emp[i].Name) != 0)
        {
            displayEmployeeIndex(emp, i);
            return;
        }
    }

    printf(NotFound);
}

/*
    delete an employee from the emp Arr using its index, and shift all other elements left
    up to currentEmp
*/
void deleteEmployeeIndex(Employee *emp, int index, int currentEmp)
{
    currentEmp = currentEmp == EmpCount ? currentEmp - 1 : currentEmp;

    for (int i = index; i < currentEmp - 1; i++)
    {
        emp[i] = emp[i+1];
    }

    emp[currentEmp - 1].ID = -1;
    strcpy(emp[currentEmp - 1].Name, "");
}

/*
    confirms from the user to delete an employee from the emp Arr using its index,
    and shift all other elements left up to currentEmp
*/
int areYouSureDelete(Employee *emp, int index, int currentEmp)
{
    displayEmployeeIndex(emp, index);
    char sure;
    do
    {
        printf("Are you sure you want to delete this employee? (y/n)\n");
        scanf("%c", &sure);
    }
    while (sure != 'y' && sure != 'n');

    if (sure == 'y')
    {
        deleteEmployeeIndex(emp, index, currentEmp);
        return 1;
    }
    else
    {
        return 0;
    }
}

/*
    delete an employee from the emp Arr using its ID, and shift all other elements left
    up to currentEmp
*/
int deleteEmployeeID(Employee *emp, int id, int currentEmp)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // delete Employee info if the ID matches
        if (id == emp[i].ID && strcmp("", emp[i].Name) != 0)
        {
            // ask the user if he is sure to delete this emp
            return areYouSureDelete(emp, i, currentEmp);
        }
    }

    printf(NotFound);

    return 0;
}


/*
    delete an employee from the emp Arr using its Name, and shift all other elements left
    up to currentEmp
*/
int deleteEmployeeName(Employee *emp, char name[100], int currentEmp)
{
    for (int i = 0; i < EmpCount; i++)
    {
        // delete Employee info if the name matches
        if (strcmp(name, emp[i].Name) == 0 && strcmp("", emp[i].Name) != 0)
        {
            // ask the user if he is sure to delete this emp
            return areYouSureDelete(emp, i, currentEmp);
        }
    }

    printf(NotFound);

    return 0;
}

/*
    returns the first index of emp having the same id, returns -1 if not found
*/
int findId(Employee *emp, int id)
{
    for (int i = 0; i < EmpCount; i++)
    {
        if (emp[i].ID == id && strcmp("", emp[i].Name) != 0)
        {
            return i;
        }
    }

    return -1;
}

/*
    halts until user press any key
*/
void waitKey()
{
    _flushall();
    printf("\n\n\n(press any key to continue)");
    _getch();
    _flushall();
}

int main()
{
    // menu stores entry options, key stores user input
    // nameTemp stores employee name to be deleted
    char menu[MenuCount][15] = {"New", "Display By ID", "Display All",
                                "Delete By ID", "Delete By Name", "Exit"},
         key, nameTemp[100];
    // current highlighted option, exitFlag when ESC or Exit
    int current = 0, exitFlag = 0, empIndex = 0, ID;
    // array of employees
    Employee emp[EmpCount] = {}, empTemp = {};

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


            gotoxy(5, 3+3*i);
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
                // if there is a place for a new emp
                if (empIndex < EmpCount)
                {
                    // get emp info
                    empTemp = getEmployee();

                    // checks if the ID already exists
                    int found = findId(emp, empTemp.ID);

                    // if not found
                    if (found == -1)
                        emp[empIndex++] = empTemp;
                    else // if found, ask the user to be replaced
                    {
                        char replace;

                        system("cls");

                        _flushall();

                        do
                        {
                            printf("\nThis ID exists:");
                            displayEmployeeIndex(emp, found);
                            printf("Do you want to replace him/her? (y/n)\n");
                            scanf("%c", &replace);
                        }
                        while(replace != 'y' && replace != 'n');

                        _flushall();

                        if (replace == 'y')
                            emp[found] = empTemp;

                        waitKey();
                    }
                }
                else // there is no empty place for a new emp
                {
                    printf("You've entered all three employees.");
                    waitKey();
                }
                break;

            case 1: // display by ID
                system("cls");
                _flushall();
                printf("Please enter the employee ID to be displayed: ");
                scanf("%i", &ID);
                _flushall();
                displayEmployeeID(emp, ID);
                waitKey();
                break;

            case 2: // display all
                system("cls");
                displayEmployees(emp);
                waitKey();
                break;

            case 3: // delete by ID
                system("cls");
                printf("Please enter the employee ID to be DELETED: ");
                _flushall();
                scanf("%i", &ID);
                _flushall();
                if (deleteEmployeeID(emp, ID, empIndex))
                    empIndex--;
                waitKey();
                break;

            case 4: // delete by Name
                system("cls");
                printf("Please enter the employee Name to be DELETED: ");
                _flushall();
                gets(nameTemp);
                if (deleteEmployeeName(emp, nameTemp, empIndex))
                    empIndex--;
                waitKey();
                break;

            case 5: // exit
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
