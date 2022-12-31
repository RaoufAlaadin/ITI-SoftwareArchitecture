#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0d
#define ESC 27
#include <windows.h>

struct Employee
{
    int id;
    char name[100];
    double salary;
};
struct Employee employeesData[3];

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
void textattr (int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void drawMenu(int current)
{

    char menu[3][8]= {"new","display","exit"};
    textattr(NormalPen);
    system("cls");
    for(int i=0; i<3; i++)
    {
        if(i == current)
        {
            textattr(HighLightPen);
        }
        else
        {
            textattr(NormalPen);
        }
        gotoxy(5,10+(3*i));
        printf("%s",menu[i]);  //string make it 1D array not 2D
    }
}
struct Employee drawEmployeeMenu()
{
    system("cls");
    struct Employee E;
    gotoxy(5,10);
    printf("ID:\n");

    gotoxy(5,13);
    printf("Name:\n");

    gotoxy(5,16);
    printf("Salary\n");



    gotoxy(12,10);
    scanf("%d",&E.id);

    gotoxy(12,13);
    scanf("%s",E.name);

    gotoxy(12,16);
    scanf("%d",&E.salary);



    return E;


}

void displayEmployee(int index)
{
    system("cls");

      gotoxy(5,10);
    printf("ID:\n");
    gotoxy(8, 10);
    printf("%d", employeesData[index].id);
    gotoxy(5,13);
    printf("Name:\n");
    gotoxy(10,13);
     printf("%d",employeesData[index].name);
    gotoxy(5,16);
    printf("Salary\n");
    gotoxy(12,16);
    printf("%d",employeesData[index].salary);
    gotoxy(20,20);
    printf("press any key to continue\n");
    if(getch())
        drawMenu(0);
}



int main()
{


    int current =0;
    char ch;




    drawMenu(current);
                int index;
    do
    {
        ch=getch();     // non extended keys
        switch(ch)
        {
        case Enter:
            switch(current)
            {
            case 0:
                for(int i=0; i<3; i++)
                {
                    employeesData[i] = drawEmployeeMenu() ;
                }
                 drawMenu(current);
                break;
            case 1:
                system("cls");
                printf("plz enter the index of the employee\n");
                scanf("%d",&index);
                displayEmployee(index);

                break;
            case 2:
                ch=ESC;

                break;
            }



            break;
        case -32:   // extended keys
            ch=getch();

            switch(ch)
            {
            case 72:  //up
                if(current==0)
                {
                    current=2;
                    drawMenu(current);
                }
                else
                {
                    current--;
                    drawMenu(current);
                }
                break;
            case 80:    //down
                if(current==2)
                {
                    current=0;
                    drawMenu(current);
                }
                else
                {
                    current++;
                    drawMenu(current);
                }
                break;
            case 79:      //end
                current=3;
                drawMenu(current);
                break;


            }
            break;



        }
    }
    while(ch!=ESC);


    return 0;
}

