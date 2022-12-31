#include <windows.h>
#define NormalPen 0x07
#define HighlightPen 0xc0
#define Enter 0x0D
#define ESC 27
#define UP 72
#define DOWN 80
#define HOME 71
#define END 79
#include <stdbool.h>
#include <string.h>

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


// j variable to use it for the saved_index array !!!
int j=0;

//counter to count how many employees we have inserted!!!
int counter=0;


struct Employee E[10];


//array to save the index of employee we have Entered
//ONE!!!:to handle the override property
//TWO!!!:to print just the employees that we have inserted their data not all the employees
int Saved_Index[10];
  void textattr( int i)
  {
      SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE) , i);
  }
int CheckIndex(int Arr_Index){

    for(int i=0;i<10;i++){
        if(Saved_Index[i]==Arr_Index){
            return 1;
        }

    }
return 0;
}




//function to insert the employee data
//i separated the insertion function into to function because i will use this one two times to handle the override property!!!
void Insert_Data(int Arr2_Index)
{
    Saved_Index[j]=Arr2_Index;
            ++j;
            ++counter;
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
    scanf("%i" , &E[Arr2_Index].ID) ;

    gotoxy(17,7);
    scanf("%s" , &E[Arr2_Index].Name) ;

    gotoxy(19,9);
    scanf("%i" , &E[Arr2_Index].Salary) ;

    gotoxy(19,11);
    scanf("%i" , &E[Arr2_Index].Deduct) ;

    gotoxy(20,13);
    scanf("%s" , &E[Arr2_Index].Address) ;
//---------------------------------
    gotoxy(56,5);
    scanf("%i" , &E[Arr2_Index].Age) ;

    gotoxy(59,7);
    scanf("%s" , &E[Arr2_Index].Gender) ;

    gotoxy(61,9);
    scanf("%i" , &E[Arr2_Index].OverTime) ;
    system("cls");
}

//The second function to complete the insertion
//using the upper function
void New_Data(int Arr2_Index)
{
    int flag;
    if(!(CheckIndex(Arr2_Index))&&(Arr2_Index>=0)&&(Arr2_Index<10)){
          Insert_Data(Arr2_Index);

    }

     else{   if(E[Arr2_Index].ID!=0){
            printf("There Is An Employee In This Index If You Want To Override Press 1,If You Don't Press 0 \n");
            scanf("%i",&flag);

            if(flag==1){
                Insert_Data(Arr2_Index);
            }
            else{
                printf("You Can't Override \n");
            }
        }
     else{   if(E[Arr2_Index].ID==0){
            Insert_Data(Arr2_Index);
        }
     else{printf("\nYou Have Entered Wrong Number \n");}

}
}
}


//Display employee data by his ID
//NOTE!!! I used another Temp Employee as a pointer to the main employee to be able to print the data
//Without using the pointers!!!we haven't taken the pointer lecture yet
void Display_ID(int ID_VAL){
    for(int i=0;i<10;i++){
        struct Employee temp3=E[i];
        if(temp3.ID==ID_VAL){
        printf("\nThe Data For Employee Number #%i is : \n\n",ID_VAL);
        printf("Your ID is : %d\n",temp3.ID);
        printf("Your Name : %s \n" , temp3.Name);
        printf("Your Net Salary Is : $%d\n",  temp3.Salary + temp3.OverTime - temp3.Deduct);
        }
    }
printf("Did Not Found Employee With This ID \n");
}




//just displaying only the employees i have Entered by checking the ID for each employee
void display_data(){
    for(int i=0;i<10;i++){
        struct Employee temp2=E[i];
        if(E[i].ID!=0){
        printf("\nThe Data For Employee Number #%i is : \n\n",i);
        printf("Your ID is : %d\n",temp2.ID);
        printf("Your Name : %s \n" , temp2.Name);
        printf("Your Net Salary Is : $%d\n",  temp2.Salary + temp2.OverTime - temp2.Deduct);
        }
    }
    if(counter==0){
        printf("\nNo Data Found\n");
    }
}




//Delete an Employee by shifting the Array of Employees
//Also delete the id for all the next indexes to handle the override Property
//in the new insertion
void Delete_BY_ID(int ID_For_Delete){

    for(int i=0;i<10;i++){
        if(ID_For_Delete==E[(Saved_Index[i])].ID){
            E[(Saved_Index[i])].ID=0;
            for(i; i<10-1; i++)
            {

                E[i].ID=0;
                E[i] = E[i + 1];
            }
        }
    }
printf("\nThe data was deleted\n");
}

//Delete an Employee by shifting the Array of Employees
//Also delete the id for all the next indexes to handle the override Property
//in the new insertion
void Delete_BY_Name(char Name_For_Delete[]){
    int flag;
    for(int i=0;i<10;i++){
      flag=strcmp(Name_For_Delete,E[i].Name);
        if(flag==0){
            E[(Saved_Index[i])].ID=0;
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


    //variables to use them in the switch case
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
            printf("Enter The Index You Want \n");
            scanf("%i",&value);
            New_Data(value);
            _getch();
            break;
        case 1://Display By ID

            printf("\nEnter The ID\n");
            scanf("%i",&ID_value);
            Display_ID(ID_value);
            _getch();
            break;
        case 2:  //Display All
            display_data();
            _getch();
            break;
        case 3:  //Delete By ID
            printf("\nEnter The ID To Delete\n");
            scanf("%i",&ID_value_Delete);
            Delete_BY_ID(ID_value_Delete);
            _getch();
            break;
        case 4:  //Delete By Name
            printf("\n Enter The Name You Want To Delete\n");
            scanf("%s",Name_Value_Delete);
            Delete_BY_Name(Name_Value_Delete);
            _getch();
            break;
        case 5:  //Exit
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

