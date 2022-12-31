#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#define NormalPen 0x07
#define HighlightPen 0xc0
#define Enter 0x0D
#define ESC 27
#define UP 72
#define Dwon 80
#define Home 71
#define End 79

///Highlight Menu with 3 employees.

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

  void textattr( int i)
  {
      SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE) , i);
  }

struct Employee
  {
      int ID , Age ;
      char Name[100] , Address[200] , Gender ;
      double Salary , OverTime , Deduct ;
  } ;

  struct Employee E[3];

  void getEmp ()
  {
     int i ;
     int j ;
     char EMPArr1[8][12]= {
                            "ID       :"  ,
                            "Name     :"  ,
                            "Salary   :"  ,
                            "Deduct   :"  ,
                            "Address  :"  ,
                            "Age      :"  ,
                            "Gender   :"  ,
                            "OverTime :"  ,
                         };
  for(j =0 ; j<3 ; j++){
       printf("Enter Data For Employee Number # %i\n\n\n\n",j+1);
   for( i=0 ; i<8 ; i++ )
    {
        gotoxy(10,5+(2*i));
        printf("%s",EMPArr1[i]);
    }


    gotoxy(22,5);
    scanf("%i" , &E[j].ID) ;

    gotoxy(22,7);
    scanf("%s" , &E[j].Name) ;

    gotoxy(22,9);
    scanf("%i" , &E[j].Salary) ;

    gotoxy(22,11);
    scanf("%i" , &E[j].Deduct) ;

    gotoxy(22,13);
    scanf("%s" , &E[j].Address) ;
//---------------------------------
    gotoxy(22,15);
    scanf("%i" , &E[j].Age) ;

    gotoxy(22,17);
    scanf("%s" , &E[j].Gender) ;

    gotoxy(22,19);
    scanf("%i" ,&E[j].OverTime) ;

     system("cls");
     }
}

void display(){
    for(int i=0;i<3;i++){
        struct Employee Temp=E[i];
        printf(" Data For Employee Number #%i is : \n",i+1);
        printf(" ID is : %d\n",Temp.ID);
        printf(" Name : %s \n" , Temp.Name);
        printf(" Net Salary Is : $%d\n",  Temp.Salary + Temp.OverTime - Temp.Deduct);
    }
}
int main()
{
    char Menu[3][8] = {"New ","Display","Exit"};
    char ch ;
    int i  , Current = 0 , ExitFlag = 0 ;

    do
    {
     textattr(NormalPen);
    system("cls"); // Clear Screan

    for( i=0 ; i<3 ; i++ )
    {
        if ( Current == i )
            textattr(HighlightPen);
        else
            textattr(NormalPen);
        gotoxy(15,10+(3*i));
        printf("%s",Menu[i]);
    }

    char Name[10];
    ch = _getch ();
    switch (ch)
    {
    case Enter :
        switch(Current)
        {
        case 0:  //New
            system("cls");
            getEmp();
             _getch();
            break;
        case 1:  //Display
            system("cls");
            display();
            _getch();
            break;
        case 2:  //Exit
            ExitFlag = 1 ;
            break;
        }
        break ;
    case ESC :
         ExitFlag = 1;
        break ;
    case -32 : // Extented Key

        ch = _getch();  // Get Second Byte From Buffer

        switch (ch)
        {
        case UP:
           Current--;
           if (Current < 0 )
            Current = 2 ;
            break;
        case Dwon :
            Current++;
            if(Current>2)
                Current =0 ;
            break;
        case Home :
            Current = 0 ;
            break;
        case End :
            Current = 2 ;
            break;

        }
        break ;
    }

    } while( !ExitFlag ) ; // ExitFlag = 0


    return 0;
}

