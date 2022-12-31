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

/* Task 3 BOUNS and deleteById and diplayAll and displayById
 @ Author : Mohaned Saudi   20/10/2022  11.25 pm
 *
**/

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

void displyMenue()
{
    char Menue[6][25] = {"New", "displayById","displayAll","deleteById","deleteByName", "Exit"};
    for(int i = 0; i < 6; i++)
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



struct Employee
{
    int Id, Age;
    char  Gender, Name[50], Adress[100];
    double Salary, OverTime, Tax;

};

struct Employee emp[10];


void displayAll()
{
    int lastEmpIdx = getLastValidEmployeeIndex();
    if(lastEmpIdx != -1)
    {
        for(int i = 0; i <= lastEmpIdx; i++)
        {
            printEmployeeData(&emp[i]);
        }
    }
    else
    {
        printf("Sorry, there is no exist any data, please enter data of employees first!!!");
    }
}

void displayById(int id)
{
    int idx = isEmployeeExist(id);
    if(idx != -1)
        printEmployeeData(&emp[idx]);
    else
        printf("Sorry, there is no exist an Empolyee with this ID  : %d.\n", id);
}

int getLastValidEmployeeIndex()
{
    int i;
    // if found -1 in first it return -1 so we ask user to fill Emp data
    // if found -1 not in first it return i - 1 => last index
    for( i = 0; i < 10; i++)
        if(emp[i].Id == -1)
            return i - 1;
    // if not found -1 this mean that last idx is last
    return i - 1;
};


void fillEmployeeData()
{
    char ch;
    for(int i = 0; i < 10; i++)
    {
        addEmployee(i);
        system("cls");
        printf("\nDo you want to enter data for another employee (y/n)? ");
        scanf(" %c", &ch);
        if(ch == 'n' || ch == 'N')
            break;
    }
}

void addEmployee(int idx)
{
    char ch;
    input_employee_data(&emp[idx]);
    for(int i = 0; i < 10; i++ )
    {
        if(i != idx && emp[i].Id == emp[idx].Id )
        {
            system("cls");
            printf("\nWarning this employee with this ID : %d is exist, Do you want to override (y/n)?\n", emp[idx].Id);
            scanf(" %c", &ch);
            // ch = _getch();
            if(ch == 'n' || ch == 'N')
            {
                removeById(emp[idx].Id);
                break;
            }
            else
            {
                emp[i] = emp[idx];
                removeById(emp[idx].Id);
                break;
            }
        }
    }
}

void removeByName(char name[])
{
    int idx = -1;
    for(int i=0; i< 10; i++)
    {
        if(strcmp(emp[i].Name, name) == 0)
        {
            idx = i;
            break;
        }
    }
    if(idx == 9)
     //   emp[idx]->Name = "";
    if(idx != -1)
    {
        for(int i = idx; i < 9; i++)
        {
            emp[i] = emp[i + 1];
        }
    }
    else
    {
        printf("Sorry, there is no exist an Empolyee with this Name : %s.\n", name);
    }
}

void removeById(int id)
{
    int idx = -1;
    for(int i=0; i< 10; i++)
    {
        if(emp[i].Id == id)
        {
            idx = i;
            break;
        }
    }
    if(idx == 9)
        emp[idx].Id =-1;
    if(idx != -1)
    {
        for(int i = idx; i < 9; i++)
        {
            emp[i] = emp[i + 1];
        }
    }
    else
    {
        printf("Sorry, there is no exist an Empolyee with this id : %d.\n", id);
    }

}

int isEmployeeExist(int id)
{
    for(int i = 0; i < 10; i++)
        if(emp[i].Id == id)
            return i;
    return -1;
}

double netSalary(struct Employee emp)
{
    return emp.Salary + emp.OverTime - emp.Tax;
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
    scanf("%s", &emp->Adress);

    gotoxy(55, 5 + (j++ * 3));
    scanf("%lf", &emp->Salary);

    gotoxy(55, 5 + (j++ * 3));
    scanf("%lf", &emp->OverTime);

    gotoxy(55, 5 + (j++ * 3));
    scanf("%lf", &emp->Tax);

}

void printEmployeeData(struct Employee* emp)
{

    printf("Details of Employee \n");
    printf("********************************\n");

    printf("ID            \t\t: %d ", emp->Id);

    printf("\nName        \t\t: %s ", emp->Name);

    printf("\nAge         \t\t: %d ", emp->Age);

    printf("\nGender      \t\t: %ch ", emp->Gender);

    printf("\nAdress      \t\t: %s ", emp->Adress);

    printf("\nSalary      \t\t: %.2lf ", emp->Salary);

    printf("\nOver Time   \t\t: %.2lf ", emp->OverTime);

    printf("\nTax         \t\t: %.2lf ", emp->Tax);

    printf("\n\n \t_______________Net Salary :  %.2lf _________________ ", netSalary(*emp));
    printf("\n********************************\n");
}

int main()
{
    for(int i = 0; i < 10; i++)
    {
        emp[i].Id = -1;
    }

    int exitFlag = 0;
    char ch, name[20];
    int id;
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
                fillEmployeeData();
                _getch();
                break;
            case 1:
                system("cls");
                scanf("%d", &id);
                displayById(id);
                _getch();
                break;
            case 2:  // disp
                system("cls");
                displayAll();
                _getch();
                break;

            case 3:  // removeById
                system("cls");
                scanf("%d", &id);
                removeById(id);
                _getch();
                break;

            case 4:  // removeByName
                system("cls");
                scanf("%s", &name);
                removeByName(name);
                _getch();
                break;

            case 5:  // Exit
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
                if(current < 0) current = 5;
                break;
            case DOWN:  //Down
                current++;
                if(current > 5) current = 0;
                break;
            case HOME:  // Home
                current = 0;
                break;
            case END: // End
                current = 5;
                break;
            }
            break;
        }
    }
    while(!exitFlag);


    return 0;
}



