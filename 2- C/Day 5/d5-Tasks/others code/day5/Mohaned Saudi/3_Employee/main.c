#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include <windows.h>

#define NORMAL_PEN 0x07
#define HIGHLIGHT_PEN 0x70
#define ENTER 0x0D
#define EXTEND_KEY -32
#define ESC 27
#define HOME 71
#define END 79
#define UP 72
#define DOWN 80

int current = 0;

void textattr(int i)
{

    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
};

void gotoxy(int x, int y)
{
    COORD coord;
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),coord);

};

struct Employee
{
    int Id, Age;
    char  Gender, Name[50], Adress[100];
    double Salary, OverTime, Tax;

};


void displyMenue()
{
    char Menue[3][10] = {"New", "display", "Exit"};
    for(int i = 0; i < 3; i++)
    {
        if (current == i)
        {
            textattr(HIGHLIGHT_PEN);
        }
        else
        {
            textattr(NORMAL_PEN);
        }
        gotoxy(15, 10 + (3 * i));
        printf(Menue[i],"\n");
    }
}


double netSalary(struct Employee emp)
{
    return emp.Salary + emp.OverTime - emp.Tax;
}

void input_employee_data(struct Employee emp[])
{

    for(int i = 0; i < 3; i++ )
    {
        printf("Enter details of Employee %d\n", i+1);
        display_employee_data();

        int j=0;
        gotoxy(20, 5 + (j++ * 3));
        scanf("%d", &emp[i].Id);

        gotoxy(20, 5 + (j++ * 3));
        scanf("%s", emp[i].Name);

        gotoxy(20, 5 + (j++ * 3));
        scanf("%d", &emp[i].Age);

        gotoxy(20, 5 + (j++ * 3));
        scanf(" %c", &emp[i].Gender);

        j = 0;
        gotoxy(55, 5 + (j++ * 3));
        scanf("%s", emp[i].Adress);

        gotoxy(55, 5 + (j++ * 3));
        scanf("%lf", &emp[i].Salary);

        gotoxy(55, 5 + (j++ * 3));
        scanf("%lf", &emp[i].OverTime);

        gotoxy(55, 5 + (j++ * 3));
        scanf("%lf", &emp[i].Tax);

        printf("\n********************************\n");

        system("cls");

    }
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

void printEmployeeData(struct Employee emp[])
{

    for(int i = 0; i < 3; i++ )
    {
        // system("cls");
        printf("Details of Employee %d\n", i+1);
        printf("********************************\n");

        printf("ID            \t\t: %d ", emp[i].Id);

        printf("\nName        \t\t: %s ", emp[i].Name);

        printf("\nAge         \t\t: %d ", emp[i].Age);

        printf("\nGender      \t\t: %ch ", emp[i].Gender);

        printf("\nAdress      \t\t: %s ", emp[i].Adress);

        printf("\nSalary      \t\t: %.2lf ", emp[i].Salary);

        printf("\nOver Time   \t\t: %.2lf ", emp[i].OverTime);

        printf("\nTax         \t\t: %.2lf ", emp[i].Tax);

        printf("\n\n \t_______________Net Salary :  %.2lf _________________ ", netSalary(emp[i]));
        printf("\n********************************\n");
    }
}
int main()
{
    struct Employee emp[3];
    int exitFlag = 0;
    char ch;

    do
    {
        textattr(NORMAL_PEN);
        system("cls"); // clear screen

        displyMenue();

        ch = _getch();

        switch(ch)
        {
        case ENTER:
            switch(current)
            {
            case 0:  //New
                system("cls");
                // display_employee_data();
                input_employee_data(emp);

                _getch();
                break;
            case 1:
                 system("cls");
                // display_employee_data(emp);
                printEmployeeData(emp);
                _getch();
                break;
            case 2:  // Exit
                exitFlag = 1;
                textattr(NORMAL_PEN);
                break;
            }
            break;
        case ESC:
            exitFlag = 1;
            break;

        case EXTEND_KEY:   //0xFFFFFFE0  // Extended Key
            ch = _getch();  // Get Second Byte from Buffer
            switch(ch)
            {
            case UP:  // up
                current--;
                if(current < 0) current = 2;
                break;
            case DOWN:  //Down
                current++;
                if(current > 2) current = 0;
                break;
            case HOME:  // Home
                current = 0;
                break;
            case END: // End
                current = 2;
                break;
            }
            break;
        }
    }
    while(!exitFlag);


    return 0;
}
