#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <conio.h>
//calc net for employee
double net(double salary,double overTime,double deduct)
{
    return ((salary+overTime)-deduct) ;
}
// go to position in console
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
//struct for employee
struct employee
{

    int id,age;
    char gender,name[100],adress[20];
    double salary, overTime,deduct;



};
int i,j,k,q;
j=0;
i=0;
k=0;
q=0;
//function to display first part of form
void displayLabel()
{


    gotoxy(5,7+(i*2));
    i=i+2;


}
//function to display second part of form
void displayLabel2()
{


    gotoxy(40,7+(j*2));
    j=j+2;


}

//function to enter first part of data
void enterData1()
{


    gotoxy(25,7+(k*2));
    k=k+2;


}
//function to enter second part of data
void enterData2()
{


    gotoxy(60,7+(q*2));
    q=q+2;


}


int main()
{



    struct employee e1;
    //display form
    gotoxy(20,5);
    printf("enter new Data");
    displayLabel();
    printf("employee Id :");
    displayLabel();
    printf("employee gender :");
    displayLabel();
    printf("employee Name :");
    displayLabel();
    printf("employee address :");

    printf("\n");
    displayLabel2();
    printf("employee salary :");
    displayLabel2();
    printf("employee Over Time :");
    displayLabel2();
    printf("employee Deduct :");
    printf("\n");
    // enter data
    enterData1();
    scanf("%i",&e1.id);
    _flushall();
    enterData1();
    scanf("%c",&e1.gender);
    _flushall();
    enterData1();
    scanf("%s",&e1.name);
    enterData1();
    _flushall();
    scanf("%s",&e1.adress);
    _flushall();
    enterData2();
    scanf("%if",&e1.salary);
    _flushall();
    enterData2();
    scanf("%if",&e1.overTime);
    _flushall();
    enterData2();
    scanf("%if",&e1.deduct);

    // display data
    system("cls");

    printf("about employee\n********************\nemployee ID : %i\nemployee Name :%s\nemployee Net :%d\n",e1.id,e1.name,net(e1.salary,e1.overTime,e1.deduct));
    return 0;
}
