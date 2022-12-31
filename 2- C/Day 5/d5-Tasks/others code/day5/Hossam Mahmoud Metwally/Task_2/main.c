#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0F
#define HighLightPen 0xc0

struct emp
{
    int id,age;
    double salary,over_tm,tax;
    char name[100],address[100],Gen;
};
struct emp e[3];

void textattr (int i){
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
}

void gotoxy( int column, int line ){
  COORD coord;
  coord.X = column;
  coord.Y = line;
  SetConsoleCursorPosition(
    GetStdHandle( STD_OUTPUT_HANDLE ),
    coord
    );
}

void Print_small_trinagle(int x,int y){     //45   8

    gotoxy(x,y);
    printf("%c",201);
    for(int i=0;i<2;i++)
    {
        gotoxy(x,y+1+i);
        printf("%c",186);
    }
    gotoxy(x,y+2);
    printf("%c",200);

    //first row =
    for(int i=0;i<19;i++)
    {
        gotoxy(x+1+i,y);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<19;i++)
    {
        gotoxy(x+1+i,y+2);
        printf("%c",205);
    }


    gotoxy(x+20,y);
    printf("%c",187);
    for(int i=0;i<1;i++)
    {
        gotoxy(x+20,y+1+i);
        printf("%c",186);
    }
    gotoxy(x+20,y+2);
    printf("%c",188);
    gotoxy(0,23);

}

void print_first_trinagle(){
    //first col =
    gotoxy(40,5);
    printf("%c",201);
    for(int i=0;i<16;i++)
    {
        gotoxy(40,6+i);
        printf("%c",186);
    }
    gotoxy(40,21);
    printf("%c",200);

    //first row =
    for(int i=0;i<30;i++)
    {
        gotoxy(41+i,5);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<30;i++)
    {
        gotoxy(41+i,21);
        printf("%c",205);
    }


    gotoxy(70,5);
    printf("%c",187);
    for(int i=0;i<16;i++)
    {
        gotoxy(70,6+i);
        printf("%c",186);
    }
    gotoxy(70,21);
    printf("%c",188);
    gotoxy(0,23);

}

void print_last_trinagle(){
    //first col =
    gotoxy(20,5);
    printf("%c",201);
    for(int i=0;i<19;i++)
    {
        gotoxy(20,6+i);
        printf("%c",186);
    }
    gotoxy(20,25);
    printf("%c",200);

    //first row =
    for(int i=0;i<80;i++)
    {
        gotoxy(21+i,5);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<80;i++)
    {
        gotoxy(21+i,25);
        printf("%c",205);
    }


    gotoxy(100,5);
    printf("%c",187);
    for(int i=0;i<19;i++)
    {
        gotoxy(100,6+i);
        printf("%c",186);
    }
    gotoxy(100,25);
    printf("%c",188);
    gotoxy(0,23);

}

void Load_Bar(){



    char firstName[8]="LOADING ",LastName[8]="NOTEPAD ";
    /*                               print all colors
    gotoxy(40,2);
    for(int i=0;i<50;i++)
    {
        SetColor(i);
        printf("%c",254);
    }
    */


    int sm=254,bi=219;                 //small and big char for print
    printf("\n");
    //
    //1<----------------------------------->       For first "H"
    gotoxy(49,10);
    textattr(22);
    printf(" H ");
    textattr(NormalPen);


    textattr(97);                                  //For last H in the begging
    printf(" H ");
    textattr(NormalPen);
    //1<----------------------------------->

    //2<----------------------------------->       print Loading
    Sleep(80);
    gotoxy(52,10);
    printf(" ");
    for(int i=0;i<8;i++)
    {
        textattr(97);
        gotoxy(52+i+1,10);
        printf(" H ");
        Sleep(80);
        gotoxy(52+i+1,10);
        textattr(6);
        printf("%c",firstName[i]);
    }
    textattr(97);
    printf(" H ");
    Sleep(80);
    //2<----------------------------------->

    //3<----------------------------------->       print NotePAD
    gotoxy(98,10);
    textattr(NormalPen);
    printf(" ");
    for(int i=0;i<8;i++)
    {
        textattr(97);
        gotoxy(60+i+1,10);
        printf(" H ");
        Sleep(80);
        gotoxy(60+i+1,10);
        textattr(9);
        printf("%c",LastName[i]);
    }
    gotoxy(69,10);
    textattr(97);
    printf(" H ");
    textattr(NormalPen);
    //3<----------------------------------->

    {
    /*
        //2<----------------------------------->       Print The words
        textattr(6);
        printf(" LOADING");
        textattr(15);
        printf(" ");
        textattr(9);
        printf("NOTEPAD ");
        textattr(15);
        //2<----------------------------------->

        //3<----------------------------------->       For Last "H"
        textattr(97);
        printf(" H ");
        textattr(NormalPen);
        //3<----------------------------------->

    */
    }

    //4<------------------------------------>      first print
    gotoxy(20,12);
    textattr(8);
    for(int i=0;i<80;i++)
    {
        printf("%c",sm);
    }
    //4<----------------------------------->

    //5<------------------------------------>      overWrite in the print and restore it
    gotoxy(20,12);
    for(int i=0;i<80;i++)
    {
        textattr(9);
        printf("%c",bi);
        Sleep(50);
        gotoxy(20+i,12);
        textattr(6);
        printf("%c",sm);
        //textattr(NormalPen);
    }
    textattr(9);
    printf("%c",bi);
    textattr(NormalPen);

    textattr(9);
    Print_small_trinagle(50,15);
    textattr(NormalPen);

    gotoxy(54,16);
    textattr(97);
    printf("    START    ");
    textattr(NormalPen);
    gotoxy(0,0);

    char c=getch();
    system("cls");
}

void Draw_table_data(int i,int option)
{
    system("cls");
    textattr(8);
    print_last_trinagle();
    Print_small_trinagle(50,1);                //Employee number
    Print_small_trinagle(35,8);                //id
    Print_small_trinagle(35,12);               //name
    Print_small_trinagle(35,16);               //salary
    Print_small_trinagle(35,20);               //adress
    Print_small_trinagle(75,8);                //Age
    Print_small_trinagle(75,12);               //Gen
    Print_small_trinagle(75,16);               //Tax
    Print_small_trinagle(75,20);               //OverT

    if(option==1)
    {
        Print_small_trinagle(50,26);               //Back
        gotoxy(55,27);
        textattr(6);
        printf("   Back    ");
        gotoxy(53,2);
    }
    else
    {
        Print_small_trinagle(80,26);               //next
        gotoxy(85,27);
        textattr(6);
        if(i<2)
            printf("    NEXT   ");
        else
            printf("    OK     ");
    }
    gotoxy(52,2);
    print_number_of_emplyee(i,52);


    textattr(6);
    gotoxy(25,9);
    printf("ID     : ");
    gotoxy(25,13);
    printf("NAME   : ");
    gotoxy(25,17);
    printf("Salary : ");
    gotoxy(25,21);
    printf("Addres : ");
    gotoxy(64,9);
    printf("Age     : ");
    gotoxy(64,13);
    printf("Gen     : ");
    gotoxy(64,17);
    printf("Tax     : ");
    gotoxy(64,21);
    printf("over TM : ");

    gotoxy(0,0);
    textattr(NormalPen);

}

void Enter_Data()
{
    for(int i=0;i<3;i++)
    {
        system("cls");
        Draw_table_data(i,0);
        textattr(3);

        gotoxy(37,9);
        scanf("%d",&e[i].id);

        gotoxy(37,13);
        scanf("%s",&e[i].name);

        gotoxy(37,17);
        scanf("%lf",&e[i].salary);

        gotoxy(37,21);
        scanf("%s",&e[i].address);

        gotoxy(77,9);
        scanf("%d",&e[i].age);

        gotoxy(77,13);
        scanf("\n");
        scanf("%c",&e[i].Gen);

        gotoxy(77,17);
        scanf("%lf",&e[i].tax);

        gotoxy(77,21);
        scanf("%lf",&e[i].over_tm);


        gotoxy(85,27);
        textattr(HighLightPen);
        if(i<2)
            printf("    NEXT   ");
        else
            printf("    OK     ");
        textattr(NormalPen);
        gotoxy(0,0);

        char ch = getch();
    }
}

void print_number_of_emplyee(int i,int pi)
{
    switch(i)
    {
    case 0:
        {
            textattr(HighLightPen);
            printf(" First Employee  ");
            textattr(NormalPen);
            break;
        }
    case 1:
        {
            gotoxy(pi,2);
            textattr(HighLightPen);
            printf(" Second Employee ");
            textattr(NormalPen);
            break;
        }
    case 2:
        {
            textattr(HighLightPen);
            printf(" Third Employee  ");
            textattr(NormalPen);
            break;
        }
    }
}
void diplay_data_of_i_emplyee_small_info(i)
{


    textattr(3);
    gotoxy(57,8);
    printf("%i",e[i].id);
    gotoxy(57,12);
    printf("%s",e[i].name);
    gotoxy(57,16);
    printf("%-10.2lf",(e[i].salary)+(e[i].over_tm)-(e[i].tax));
    gotoxy(0,0);
    textattr(NormalPen);
    gotoxy(48,2);
    print_number_of_emplyee(i,48);
    gotoxy(0,0);


}

void display_full_info(int i)
{
    Draw_table_data(i,1);
    textattr(3);
    gotoxy(37,9);
    printf("%i",e[i].id);
    gotoxy(37,13);
    printf("%s",e[i].name);
    gotoxy(37,17);
    printf("%-10.2lf",e[i].salary);
    gotoxy(37,21);
    printf("%s",e[i].address);
    gotoxy(77,9);
    printf("%d",e[i].age);
    gotoxy(77,13);
    printf("%c",e[i].Gen);
    gotoxy(77,17);
    printf("%-10.2lf",e[i].tax);
    gotoxy(77,21);
    printf("%-10.2lf",e[i].over_tm);

    gotoxy(55,27);
    textattr(HighLightPen);
    printf("   Back    ");
    textattr(NormalPen);
    gotoxy(0,0);
}
void Show_Data()
{
    char ch,current=0,ex=1,i=0;
    //for(int i=1;i<=3;i++)
//    {
    diplay_data_of_i_emplyee_small_info(i);
    print_small_structure_info();
    print_small_content_info(current);
    do{

        ch=getch();
        switch(ch)
        {
        case 13:
            {
                switch(current)
                {
                case 0:
                    {
                        i=(i+2)%3;
                        diplay_data_of_i_emplyee_small_info(i);
                        break;
                    }
                case 1:
                    {
                        display_full_info(i);
                        ch=getch();
                        system("cls");
                        diplay_data_of_i_emplyee_small_info(i,current);
                        print_small_structure_info();
                        print_small_content_info(current);
                        break;
                    }
                case 2:
                    {
                        i=(i+1)%3;
                        diplay_data_of_i_emplyee_small_info(i,current);
                        break;
                    }
                case 3:
                    {
                        ex=0;
                        break;
                    }
                }
                break;
            }


        case -32:
            {
                gotoxy(0,0);
                ch=getch();
                switch(ch)
                {
                case 72:                            //UP
                    {
                        current=1;
                        print_small_content_info(current);
                        break;
                    }
                case 80:                            //down
                    {
                        current=3;
                        print_small_content_info(current);
                        break;
                    }
                case 77:                            //right
                    {
                        current=(current+1)%4;
                        print_small_content_info(current);
                        break;
                    }
                case 75:                             //left
                    {
                        current=(current+3)%4;;
                        print_small_content_info(current);
                        break;
                    }
                }
                break;
            }

        }

    }while(ex);

}

//}


void print_small_structure_info(){
    //first col =
    textattr(8);
    gotoxy(30,4);
    printf("%c",201);
    for(int i=0;i<16;i++)
    {
        gotoxy(30,5+i);
        printf("%c",186);
    }
    gotoxy(30,20);
    printf("%c",200);

    //first row =
    for(int i=0;i<50;i++)
    {
        gotoxy(31+i,4);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<50;i++)
    {
        gotoxy(31+i,20);
        printf("%c",205);
    }


    gotoxy(80,4);
    printf("%c",187);
    for(int i=0;i<16;i++)
    {
        gotoxy(80,5+i);
        printf("%c",186);
    }
    gotoxy(80,20);
    printf("%c",188);
    gotoxy(0,0);


    textattr(8);
    Print_small_trinagle(46,1);         //Emp name
    Print_small_trinagle(55,7);
    Print_small_trinagle(55,11);
    Print_small_trinagle(55,15);
    Print_small_trinagle(45,22);         //INFO
    Print_small_trinagle(70,22);         //NEXT
    Print_small_trinagle(20,22);         //BACK
    Print_small_trinagle(45,26);         //END


}
void print_small_content_info(int current_arrow){
    gotoxy(49,23);
    textattr(6);
    printf("     INFO    ");
    gotoxy(74,23);
    textattr(6);
    printf("     NEXT    ");

    gotoxy(24,23);
    textattr(6);
    printf("    BACK    ");

    gotoxy(50,27);
    textattr(6);
    printf("    END    ");
    if(current_arrow==0){
        textattr(HighLightPen);
        gotoxy(24,23);
        printf("    BACK    ");
        textattr(NormalPen);
    }
    else if(current_arrow==1){
        textattr(HighLightPen);
        gotoxy(49,23);
        printf("     INFO    ");
        textattr(NormalPen);
    }
    else if(current_arrow==2)
    {
        textattr(HighLightPen);
        gotoxy(74,23);
        printf("     NEXT    ");
        textattr(NormalPen);
    }
    else
    {
        textattr(HighLightPen);
        gotoxy(50,27);
        printf("    END    ");
        textattr(NormalPen);
    }

    textattr(6);
    gotoxy(40,8);
    printf("ID      : ");
    gotoxy(40,12);
    printf("NAME    : ");
    gotoxy(40,16);
    printf("Net Sal : ");
    gotoxy(0,0);
    textattr(NormalPen);
}
void box_build_and_coloe_after_show()
{
    textattr(11);
    print_first_trinagle();
    Print_small_trinagle(45,8);
    Print_small_trinagle(45,12);
    Print_small_trinagle(45,16);
    textattr(NormalPen);
}


int main()
{
    char words[3][14]={"     New     ","     SHOW    ","     Exit    "},ch;
    char Name[20];
    int current=0,lo=1;

    Load_Bar();
    system("cls");


    box_build_and_coloe_after_show();

    do{

        for(int i=0;i<3;i++)
        {
            gotoxy(49,9+(4*i));
            if(i==current)
            {
                textattr(HighLightPen);
            }
            else
            {
                textattr(NormalPen);
            }
            printf("%s\n",words[i]);

        }
        gotoxy(0,23);
        ch=getch();
        switch(ch)
        {
        case 13:    //Enter
            {
                switch(current)
                {
                    case 0:                         //New Enter NAme
                        {
                            system("cls");
                            Enter_Data();
                            system("cls");
                            box_build_and_coloe_after_show();
                            break;

                        }
                    case 1:
                        {
                            system("cls");
                            Show_Data();
                            system("cls");
                            box_build_and_coloe_after_show();
                            break;
                        }
                    case 2:
                        {
                            textattr(NormalPen);
                            system("cls");
                            exit(0);
                            break;
                        }
                }
                break;
            }
        case 27:   // Exit
            {
                lo=0;
                system("cls");
                exit(0);
                break;
            }
        case -32:
            {
                gotoxy(0,23);
                ch=getch();
                switch(ch)
                {
                case 72:                            //UP
                    {
                        current=(current+2)%3;
                        break;

                    }
                case 80:                            //down
                    {
                        current=(current+1)%3;
                        break;

                    }
                case 71:                            //home
                    {
                        current=0;
                        break;

                    }
                case 79:                             //End
                    {
                        current=2;
                        break;
                    }

                }
            }
        }
        textattr(NormalPen);

    }while(lo);
    return 0;
}
