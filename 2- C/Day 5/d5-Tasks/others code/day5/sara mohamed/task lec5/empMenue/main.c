#include <windows.h>
#include <conio.h>
#include <string.h>
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 27
#define up 72
#define down 80
int o,j,k,q;
j=0;
o=0;
k=0;
q=0;
//function to display first part of form
void displayLabel()
{


    gotoxy(5,7+(o*2));
    o=o+2;


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








struct employee
{

    int id,age;
    char gender,name[100],adress[20];
    double salary, overTime,deduct;



};
// to calc net
double net(double salary,double overTime,double deduct)
{
    return ((salary+overTime)-deduct) ;
}
struct employee arr[3]  ;
// display data for 3 employee
void display(int number)
{
    int i;
    for(i=0; i<number; i++)
    {

        system("cls");

        printf(" data about Employee %i\n*****************\nemployee ID : %i\nemployee Name :%s\nemployee Net :%d\n************click Enter****************\n",i+1,arr[i].id,arr[i].name,net(arr[i].salary,arr[i].overTime,arr[i].deduct));
        getch();


    }


}




// form and enter data
void addEmployee(int number)
{
    int i;
    for(i=0; i<number; i++)
    {
        system("cls");
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
        enterData1();
        _flushall();
        scanf("%i",&arr[i].id);
        _flushall();
        enterData1();
        scanf("%c",&arr[i].gender);
        _flushall();
        enterData1();
        scanf("%s",&arr[i].name);
        enterData1();
        _flushall();
        scanf("%s",&arr[i].adress);
        _flushall();
        enterData2();
        scanf("%if",&arr[i].salary);
        _flushall();
        enterData2();
        scanf("%if",&arr[i].overTime);
        _flushall();
        enterData2();
        scanf("%if",&arr[i].deduct);
        getch();
        system("cls");
        o=0;
        k=0;
        j=0;
        q=0;

    }

}






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

// to style
void textattr (int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}


int main()

{





    char c,ch;
    char name[5]= {0};
    int i,current=0,flag=0;
    char menu [3][8]= {"New","display","Exit"};
    do
    {

        textattr(NormalPen); // to avoid problem of highlight screan
        system("cls");

        for(i=0; i<3; i++)
        {
            if(current==i)
            {
                textattr(HighLightPen);
            }
            else
            {
                textattr(NormalPen);
            }
            gotoxy(20,10+(3*i));
            printf("%s\n",menu[i]);
        }
        c=getch();
        switch(c)
        {
        case Enter:
            switch(current)
            {
            case 0:           // for new
                system("cls");
                addEmployee(3);
                break;
            case 1:// for display all
                display(3);
                break;
            case 2: // for exite
                flag=1;
                break;
            }



            break;
        case ESC: // for exite
            flag=1;
            break;
        case -32: // for arrow

            ch=getch();
            switch(ch)
            {
            case up: // up button
                current--;
                if(current==-1)
                    current=2;
                break;
            case down: //down button
                current++;
                if(current==3)
                    current=0;
                break;

            }




        }






    }
    while(!flag);



    return 0;
}

