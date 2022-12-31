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

int index,id;
char name [10];




struct employee
{

    int id,age;
    char gender,name[100],adress[20];
    double salary, overTime,deduct;



};
struct employee arr[10]  ;



//if(i==10){
// printf("NO Data Found");
// }




//}




double net(double salary,double overTime,double deduct)
{
    return ((salary+overTime)-deduct) ;
}

void displayByID()
{
    system("cls");
    int idd;
    printf("enter Id\n");
    _flushall();
    scanf("%d",&idd);
    // getch();
    int i;
    for(i=0; i<10; i++)
    {
        //  system("cls");
        if(arr[i].id==idd)
        {


        printf(" data about Employee\n*****************\nemployee ID : %i\nemployee Name :%s\nemployee Net :%d\n************click Enter****************\n",arr[i].id,arr[i].name,net(arr[i].salary,arr[i].overTime,arr[i].deduct));
            getch();
            break;

        }
        else
        {
            continue;
        }



    }
    if(i==10)
    {
        printf("no data found");
        getch();
    }
}


void display()
{
    int i;
    for(i=0; i<10; i++)
    {
        if(arr[i].id!=0)
        {
            system("cls");

        printf(" data about Employee %i\n*****************\nemployee ID : %i\nemployee Name :%s\nemployee Net :%d\n************click Enter****************\n",i+1,arr[i].id,arr[i].name,net(arr[i].salary,arr[i].overTime,arr[i].deduct));
            getch();
        }



    }


}


void form (int index)
{
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
    scanf("%i",&arr[index].id);
    _flushall();
    enterData1();
    scanf("%c",&arr[index].gender);
    _flushall();
    enterData1();
    scanf("%s",&arr[index].name);
    enterData1();
    _flushall();
    scanf("%s",&arr[index].adress);
    _flushall();
    enterData2();
    scanf("%if",&arr[index].salary);
    _flushall();
    enterData2();
    scanf("%if",&arr[index].overTime);
    _flushall();
    enterData2();
    scanf("%if",&arr[index].deduct);
    o=0;
    k=0;
    j=0;
    q=0;



}

//  to check first if you want to do over ride or  no and display form
void addEmployee(int index)
{
    system("cls");
    int i;
    int opinion;
    for(i=0; i<10; i++)
    {

        if(arr[index].id!=0)
        {
            printf("do you want to over ride write 1 for yes or 2 for no\n");
            scanf("%i",&opinion);
            if(opinion!=1)
            {
                printf("thank you");
                getch();
                break;
            }
            else
            {
                system("cls");
                form(index);
            }
        }
        else
        {
            system("cls");
            form(index);
        }


        getch();
        break;

    }
}


// detete using id
int deleteById(int empid)
{

    int i;
    for(i=0; i<10; i++)
    {

        if(arr[i].id == empid)
        {
            arr[i].id=0;
            printf("deleted\n");
            getch();
            break;
        }
        else
        {

            continue;


        }


    }

    printf("this id not found\n");

}
// delet use name
int deleteByName(char name[10])
{

    int i,result;
    for(i=0; i<10; i++)
    {
        result=strcmp(arr[i].name, name);
        if(result==0)
        {
            arr[i].id=0;
            printf("deleted\n");
            getch();
            break;
        }
        else
        {

            continue;


        }


    }

    printf("this name not found\n");

}








// to control the place of display
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
// for style
void textattr (int i)
{
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}


int main()

{





    char c,ch;
    char name[5]= {0};
    int i,current=0,flag=0;
    char menu [6][15]= {"New","display","disply By Id","delete BY Name","delete BY id","Exit"};
    do
    {

        textattr(NormalPen);
        system("cls");

        for(i=0; i<6; i++)
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
            case 0://new
                system("cls");
                printf("enter index\n");
                scanf("%i",&index);
                addEmployee(index);
                //counter++;
                break;
            case 1: // dispay all
                display();
                break;
            case 2:// display by iD

                displayByID();

                break;
            case 3: // delet by name
                system("cls");
                printf("enter name\n");
                scanf("%s",&name);
                deleteByName(name);
                break;
            case 4: // delet by id
                system("cls");
                printf("enter id\n");
                scanf("%i",&id);
                deleteById(id);



                break;


            case 5: // to exite
                flag=1;
                break;
            }



            break;
        case ESC: // to exite
            flag=1;
            break;
        case -32: // about arrow

            ch=getch();
            switch(ch)
            {
            case up: //up button
                current--;
                if(current==-1)
                    current=5;
                break;
            case down: // down button
                current++;
                if(current==7)
                    current=0;
                break;

            }




        }






    }
    while(!flag);



    return 0;
}

