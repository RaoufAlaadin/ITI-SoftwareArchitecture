#include <windows.h>
#define NormalPen 0x07
#define HighlightPen 0xc0
#define Enter 0x0D
#define ESC 27
#define UP 72
#define DOWN 80
#define HOME 71
#define END 79



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
struct Employee
  {
      int ID , Age ;
      char Name[100] , Address[200] , Gender ;
      double Salary , OverTime , Deduct ;
  };

struct Employee E[3];
  void textattr( int i)
  {
      SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE) , i);
  }

void insert_Data()
{



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
//the outer loop to loop 3 times to inset data for 3 employees when we enter New input from the menu screen in the switch case                              };
for(int j=0;j<3;j++){

        printf("Enter Data For Employee Number # %i\n\n\n\n",j+1);
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
    scanf("%i" , &E[j].ID) ;

    gotoxy(17,7);
    scanf("%s" , &E[j].Name) ;

    gotoxy(19,9);
    scanf("%i" , &E[j].Salary) ;

    gotoxy(19,11);
    scanf("%i" , &E[j].Deduct) ;

    gotoxy(20,13);
    scanf("%s" , &E[j].Address) ;
//---------------------------------
    gotoxy(56,5);
    scanf("%i" , &E[j].Age) ;

    gotoxy(59,7);
    scanf("%s" , &E[j].Gender) ;

    gotoxy(61,9);
    scanf("%i" , &E[j].OverTime) ;
    system("cls");
}

}
void display_data(){

    for(int i=0;i<3;i++){
        //using temp variable to act as a pointer to be able to print the data for the actual employee
        //did not using pointers because we still have not taken the pointer lecture yet!!!
        struct Employee temp2=E[i];
        printf("\nThe Data For Employee Number #%i is : \n\n",i+1);
        printf("Your ID is : %d\n",temp2.ID);
        printf("Your Name : %s \n" , temp2.Name);
        printf("Your Net Salary Is : $%d\n",  temp2.Salary + temp2.OverTime - temp2.Deduct);
    }

}
int main()
{
    struct Employee e[3];
    char Menu[3][5] = {"New ","Dis","Exit"};
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

    ch = _getch ();
    switch (ch)
    {
    case Enter :

        switch(Current)
        {
        case 0:  //New
             system("cls");
             insert_Data();
             _getch();
            break;
        case 1:  //Display
            display_data();
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
        case DOWN:
            Current++;
            if(Current>2)
                Current =0 ;
            break;
        case HOME:
            Current = 0 ;
            break;
        case END:
            Current = 2 ;
            break;

        }
        break ;
    }

    } while( !ExitFlag ) ; // ExitFlag = 0


    return 0;
}
