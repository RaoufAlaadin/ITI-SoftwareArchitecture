#include <windows.h>
#define NormalPen 0x07
#define HighlightPen 0xb3
#define Enter 0x0D
#define ESC 27
#define UP 72
#define DOWN 80
#define HOME 71
#define END 79
#include <stdbool.h>
#include <string.h>

///Highlight Menu with 10 employees.

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

int j=0;
int counter=0;
struct Employee E[10];
int SaveARR[10];
void textattr( int i)
  {
      SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE) , i);
  }
int CheckIndex(int Arr_Index){

    for(int i=0;i<10;i++){
        if(SaveARR[i]==Arr_Index){
            return 1;
        }

    }
return 0;
}
void Get_Data(int Arr2_Index)
{
    SaveARR[j]=Arr2_Index;
            ++j;
            ++counter;
    int i ;
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
void New_Data(int Arr2_Index)
{
    int flag;
    if(!(CheckIndex(Arr2_Index))&&(Arr2_Index>=0)&&(Arr2_Index<10)){
          Get_Data(Arr2_Index);

    }else{

        if((CheckIndex(Arr2_Index))){
            printf("There Is An Employee In This Index If You Want To Override Press 1,If You Don't Press 0 \n");
            scanf("%i",&flag);

            if(flag==1){
                Get_Data(Arr2_Index);
            }
            else{
                printf("You Can't Override \n");
            }
        }
        else{
            printf("You Have Entered Wrong Index\n");
        }
    }
}
void Display_ID(int DEL_ID){
    for(int i=0;i<=counter;i++){
        struct Employee Tep_Emp=E[(SaveARR[i])];
        if(Tep_Emp.ID==DEL_ID){
        printf("\nThe Data For Employee Number #%i is : \n\n",DEL_ID);
        printf("Your ID is : %d\n",Tep_Emp.ID);
        printf("Your Name : %s \n" , Tep_Emp.Name);
        printf("Your Net Salary Is : $%d\n",  Tep_Emp.Salary + Tep_Emp.OverTime - Tep_Emp.Deduct);
        }else{
            printf("No Employee Founded With This ID  \n");
        }
    }

}



void display_data(){
    for(int i=0;i<counter;i++){
        struct Employee temp2=E[(SaveARR[i])];
        printf("\nThe Data For Employee Number #%i is : \n\n",i+1);
        printf("Your ID is : %d\n",temp2.ID);
        printf("Your Name : %s \n" , temp2.Name);
        printf("Your Net Salary Is : $%d\n",  temp2.Salary + temp2.OverTime - temp2.Deduct);
    }
    if(counter==0){
        printf("\nNo Data Found\n");
    }
}



void DeleteBYID(int ID){

    for(int i=0;i<counter;i++){
        if(ID==E[(SaveARR[i])].ID){
            E[(SaveARR[i])].ID=0;
        }
    }

counter--;
printf("\n deleted\n");
}

void Delete_BY_Name(char Name_For_Delete[]){
    int flag;
    for(int i=0;i<10;i++){
      flag=strcmp(Name_For_Delete,E[i].Name);
        if(flag==0){
            E[(SaveARR[i])].ID=0;
            for(i; i<10-1; i++)
            {
                E[i].ID=0;
                E[i] = E[i + 1];
            }
        }
    }
printf("\nThe data was deleted\n");
}


int main()
{
    //struct Employee e[3];
    char Menu[6][15] = {"New ","DisplayBy ID" ,"DisplayAll" , "Delete By ID" ,"Delete By Name","Exit"};
    char ch;
    int i, Current = 0 , ExitFlag = 0 ;
    do
    {
       textattr(NormalPen);
    system("cls"); // Clear Screan

    for( i=0 ; i<6 ; i++ )
    {
        if ( Current == i )
            textattr(HighlightPen);
        else
            textattr(NormalPen);
        gotoxy(15,7+(3*i));
        printf("%s",Menu[i]);
    }

    ch = _getch ();
    char Name[20];
    int value;
    int ID_value;
    int ID_value_Delete;
    char Name_Value_Delete[20];
    switch (ch)
    {
    case Enter :

        switch(Current)
        {
        case 0:  //New
            system("cls");
            printf("Enter The Index of Employee to Insert Data  : ");
            scanf("%i",&value);
            New_Data(value);

            break;
        case 1://Display By ID
            system("cls");
            printf("\nEnter ID To Display Data\n");
            scanf("%i",&ID_value);
            Display_ID(ID_value);
            _getch();
            break;
        case 2:  //Display All
            system("cls");
            display_data();
            _getch();
            break;
        case 3:  //Delete By ID
            system("cls");
            printf("\n Enter The ID To Delete Employee \n");
            scanf("%i",&ID_value_Delete);
            DeleteBYID(ID_value_Delete);
            _getch();
            break;
        case 4:  //Delete By Name
            system("cls");
            printf("\n Enter The Name You Want To Delete\n");
            scanf("%s",Name_Value_Delete);
            Delete_BY_Name(Name_Value_Delete);
            _getch();
            break;
        case 5:  //Exit
            system("cls");
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
            Current = 5 ;
            break;
        case DOWN:
            Current++;
            if(Current>5)
                Current =0 ;
            break;
        case HOME:
            Current = 0 ;
            break;
        case END:
            Current = 5 ;
            break;
        }
        break ;
    }

    } while( !ExitFlag ) ; // ExitFlag = 0


    return 0;
}
