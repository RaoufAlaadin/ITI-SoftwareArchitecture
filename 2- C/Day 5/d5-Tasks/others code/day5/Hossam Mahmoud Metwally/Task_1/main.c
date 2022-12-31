#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0F
#define HighLightPen 0xc0

struct emp
{
    int id;
    double salary;
    char name[100];
};
struct emp e;

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
    gotoxy(30,5);
    printf("%c",201);
    for(int i=0;i<16;i++)
    {
        gotoxy(30,6+i);
        printf("%c",186);
    }
    gotoxy(30,21);
    printf("%c",200);

    //first row =
    for(int i=0;i<50;i++)
    {
        gotoxy(31+i,5);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<50;i++)
    {
        gotoxy(31+i,21);
        printf("%c",205);
    }


    gotoxy(80,5);
    printf("%c",187);
    for(int i=0;i<16;i++)
    {
        gotoxy(80,6+i);
        printf("%c",186);
    }
    gotoxy(80,21);
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

void Draw_table_data()
{
    system("cls");
    textattr(8);
    print_last_trinagle();
    Print_small_trinagle(55,8);
    Print_small_trinagle(55,12);
    Print_small_trinagle(55,16);
    Print_small_trinagle(46,23);
    gotoxy(54,24);
    textattr(6);

    printf("ENTER");
    gotoxy(40,9);
    printf("ID     : ");
    gotoxy(40,13);
    printf("NAME   : ");
    gotoxy(40,17);
    printf("Salary : ");
    gotoxy(0,0);
    textattr(NormalPen);


}

void Enter_Data()
{
    Draw_table_data();

    textattr(3);
    gotoxy(57,9);
    scanf("%d",&e.id);

    gotoxy(57,13);
    scanf("%s",&e.name);

    gotoxy(57,17);
    scanf("%lf",&e.salary);
    gotoxy(51,24);
    textattr(HighLightPen);
    printf("   ENTER   ");
    textattr(NormalPen);
    gotoxy(0,0);

    char ch = getch();
}
void Show_Data()
{
    textattr(3);
    Draw_table_data();
    gotoxy(56,9);
    printf(" %i",e.id);
    gotoxy(56,13);
    printf(" %s",e.name);
    //fflush(stdout);

    gotoxy(56,17);
    printf(" %lf",e.salary);

    gotoxy(51,24);
    textattr(HighLightPen);
    printf("   ENTER   ");
    textattr(NormalPen);
    gotoxy(0,0);
    char ch=getch();
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
    //Load_Bar();
    char words[3][14]={"     New     ","     SHOW    ","     Exit    "},ch;
    char Name[20];
    int current=0,lo=1;

    //Load_Bar();
    system("cls");
    //Enter_Data();
    //system("cls");

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
