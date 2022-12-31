#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

void gotoxy(int column , int line){
    COORD coord;
    coord.X=column;
    coord.Y=line;
    SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),coord);
}

struct Employee
  {
      int ID , Age ;
      char Name[100] , Address[200] , Gender ;
      double Salary , OverTime , Deduct ;
  };

int main()
{
    struct Employee E;
    int i ;
    char EMPArr1[5][12]= {
                            "ID :"  ,
                            "Name :"  ,
                            "Salary :  "  ,
                            "Deduct :"  ,
                            "Address :"
                         };

    char EMPArr2[3][11]=     {
                               "Age :"  ,
                               "Gender :" ,
                               "OverTime :"  ,
                             };

    for( i=0 ; i<5 ; i++ )
    {
        gotoxy(10,5+(2*i));
        printf("%s",EMPArr1[i]);
    }

    for( i=0 ; i<3 ; i++ )
    {
        gotoxy(50,5+(2*i));
        printf("%s",EMPArr2[i]);
    }


    gotoxy(15,5);
    scanf("%i" , &E.ID) ;

    gotoxy(17,7);
    scanf("%s" , &E.Name) ;

    gotoxy(19,9);
    scanf("%i" , &E.Salary) ;

    gotoxy(19,11);
    scanf("%i" , &E.Deduct) ;

    gotoxy(20,13);
    scanf("%s" , &E.Address) ;
//---------------------------------
    gotoxy(56,5);
    scanf("%i" , &E.Age) ;

    gotoxy(59,7);
    scanf("%s" , &E.Gender) ;

    gotoxy(61,9);
    scanf("%i" , &E.OverTime) ;
    system("cls");
   // _getch();
  //gotoxy(5,15);
    printf("Your ID is : %d\n",E.ID);
    printf("Your Name : %s \n" , E.Name);
    printf("Your Net Salary Is : $%d\n",  E.Salary + E.OverTime - E.Deduct);

    return 0;
}
