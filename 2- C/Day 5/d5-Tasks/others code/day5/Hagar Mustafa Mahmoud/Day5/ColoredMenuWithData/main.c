#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0D
#define ESC 27



static int j;
double Net;
char ch;

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


//Struct Intialization
struct Employee
{
    int Id ,Age;
    char Name[100] , Address[200] , Gender;
    double Salary , OverTime , Detuct;
};
struct Employee Emp[10];




void NewInputs ()
{
            system("cls");
            printf("Enter Index : ");
            scanf("%d", &j);
            system("cls");
            printf("Enter Employee #%d",j);

}


// Print Inputs
void PrintInputs()
 {
     int i;
     char Inputs[8][60] =
     {
         "ID:" ,
         "Age:",
         "Name:",
         "Gender:",
         "Address:",
         "Salary:",
         "OverTime:",
         "Detuct:"
     };

    for(i=0 ; i< 4 ; i++)
   {
    gotoxy(15,5 + 3*i);
    printf("%s",Inputs[i]);
   }
     for( i=4 ; i< 8 ; i++)
   {
    gotoxy(50,5 +3*(i-4));
    printf("%s",Inputs[i]);
   }

 }


// Intering Data
void ScanData(int k)
{

       int i=0;
    gotoxy(25 , 5+3*i++);
    scanf("%d", &Emp[k].Id);

    _flushall();
    gotoxy(25 , 5+3*i++);
    scanf("%d", &Emp[k].Age);

    _flushall();
    gotoxy(25 , 5+3*i++);
    gets(Emp[k].Name);

    _flushall();
    gotoxy(25 , 5+3*i++);
    scanf("%c", &Emp[k].Gender);

    _flushall();
    gotoxy(60,5+3*(i++ -4));
    gets(Emp[k].Address);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp[k].Salary);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp[k].OverTime);

    gotoxy(60,5+3*(i++ -4));
    _flushall();
    scanf("%lf",&Emp[k].Detuct);


}

// Printing Data
void PrintData(int k)
{
    printf("Data for the Employee NO. %d\n\n",k);
    printf("iD :%d\n",Emp[k].Id );
    printf("Age:%d\n", Emp[k].Age);
    printf("Name:%s\n", Emp[k].Name);
    printf("Gender:%c\n", Emp[k].Gender);
    printf("Address:%s\n", Emp[k].Address);
    printf("Salary=\t%lf\n", Emp[k].Salary);
    printf("OverTime=\t%lf\n", Emp[k].OverTime);
    printf("Detuuct=\t%lf\n", Emp[k].Detuct);
    Net = Emp[k].Salary + Emp[k].OverTime -Emp[k].Detuct ;
    printf("Net Salary = \t%lf\n" , Net);
    printf("____________________________________________\n");

   }


// Display By ID function
   void DisplayByID ()
   {
       system("cls");

            int id;
            printf("Enter Employee Id:\n ");
            _flushall();
            scanf("%d", &id);
            getch();
            int i;
            for(i=0 ; i<10 ; i++)
            {

                if(Emp[i].Id == id)
                {
                    PrintData(i);
                    getch();
                    break;
                }
                else
                {
                    continue ;
                }

                if(i== 10)
                {
                    printf("No Data For This User");
                    getch();
                }
            }

   }


//DeletE By Name Function
  void DeleteByName ()
   {
       system("cls");

            char Namee[100];
            printf("Enter Employee Name:\n ");
            _flushall();
            gets(Namee);
            getch();

            int i;
            for(i=0 ; i<10 ; i++)
            {
                if(strcmp( Emp[i].Name,Namee)==0)
                {
                   Emp[i].Id =0;

                   printf("deleted");
                   getch();
                    break;
                }
                else
                {
                    continue ;
                }


            }
 if(i== 10)
                {
                    printf("No Data For This User");
                    getch();
                }
   }


  //DisplayAll Employees Function
   void DisplayAll()
   {

       system("cls");
     int i;
            for(i=0 ; i<10 ; i++)
            {
                if(Emp[i].Id!=0)
                PrintData(i);


            }
            getch();
     }


// Delete By ID
void DeleteByID()
{
            system("cls");

            int ID;
            printf("Enter Employee ID:\n ");
            _flushall();
            scanf("%d",&ID);
            getch();

            int i;
            for(i=0 ; i<10 ; i++)
            {
                if(Emp[i].Id == ID)
                {
                   Emp[i].Id =0;

                   printf("deleted");
                   getch();
                    break;
                }
                else
                {
                    continue ;
                }


            }
 if(i== 10)
                {
                    printf("No Data For This User");
                    getch();
                }
   }

int main()
{
    char Menu [6][20]={"New" , "Display By ID" ,"Display All", "Delete By ID","Delete By Name","Exit"} , ch;
    int i, Current = 0 , ExitFlag=0 ;

    do
    {
        textattr(NormalPen);
        system("cls");

    for(i=0 ; i<6 ; i++)
    {
        if (Current == i)
            textattr(HighLightPen);

        else
            textattr(NormalPen);
        gotoxy(5,2+(3*i));
        printf("%s", Menu[i]);
    }
    ch = _getch();

    switch (ch)
    {
    case Enter:
        switch(Current)
        {
        case 0 : //NEW


            NewInputs();
            PrintInputs();
            ScanData(j);
            system("cls");
            PrintData(j);
            getch();

            break;

        case 1: //Display By ID

            DisplayByID();

            break;

            case 2: //Display All

           DisplayAll();
               break;

            case 3: //Delete By ID

             DeleteByID();


                break;

            case 4://Delete By Name

                 DeleteByName();

                 break;

           case 5: //EXIT
            ExitFlag=0;
                  break;
        }

        break;


     case -32: //Extended key

         ch=_getch();

         switch(ch)
         {
         case 72: //UP
             Current-- ;
             if(Current < 0)
                Current =5;
            break;

         case 80: //Down
             Current++ ;
             if(Current > 5)
                Current = 0;
            break;

         case 71: //Home
             Current = 0;
            break;

         case 79: //End
             Current = 5;
            break;
         }

        break;

    }
} while(!ExitFlag);
}
