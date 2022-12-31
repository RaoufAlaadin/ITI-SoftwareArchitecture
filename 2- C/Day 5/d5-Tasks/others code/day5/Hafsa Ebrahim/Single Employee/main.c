#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include<windows.h>

void gotoxy(int x, int y)
{
    COORD coord= {0,0};
    coord.X = x;
    coord.Y = y;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}

struct employee
{
    int id, age;
    char gender, address[200], name[100];
    double salary, overtime, deduct;
};

int main()
{
    struct employee emp;

    gotoxy(10, 6);
    printf("ID:");
    gotoxy(10, 8);
    printf("Name:");
    gotoxy(10, 10);
    printf("Age:");
    gotoxy(10, 12);
    printf("Salary: \n");
    gotoxy(40, 6);
    printf("Address:");
    gotoxy(40, 8);
    printf("Gender:");
    gotoxy(40, 10);
    printf("Overtime:");
    gotoxy(40, 12);
    printf("Tax: \n");


    gotoxy(14,6);
    scanf("%i", &emp.id);

    gotoxy(14,8);
    scanf("%s", emp.name);

    return 0;
}
