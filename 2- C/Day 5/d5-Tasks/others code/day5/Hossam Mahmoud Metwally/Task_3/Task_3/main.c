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
struct emp e[101],temp;
int emp_counter;
void Itialize_ID(){
    for(int i=0;i<=100;i++)
    {
        e[i].id=-1;
    }
}

int check_for_id(int id)
{
    for(int i=0;i<=100;i++)
    {
        if(e[i].id==id)
            return i+1;
    }
    return 0;
}


void set_data_in_array(struct emp temp)
{
    for(int i=0;i<=100;i++)
    {
        if(e[i].id==-1)
        {
            e[i].id=temp.id;
            e[i].age=temp.age;
            //=;
            strcpy(e[i].address,temp.address);
            e[i].Gen=temp.Gen;
            strcpy(e[i].name,temp.name);
            e[i].over_tm=temp.over_tm;
            e[i].tax=temp.tax;
            e[i].salary=temp.salary;
            break;
        }
    }
}

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

void print_main_trinagle(){
    //first col =
    gotoxy(40,2);
    printf("%c",201);
    for(int i=0;i<23;i++)
    {
        gotoxy(40,3+i);
        printf("%c",186);
    }
    gotoxy(40,26);
    printf("%c",200);

    //first row =
    for(int i=0;i<30;i++)
    {
        gotoxy(41+i,2);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<30;i++)
    {
        gotoxy(41+i,26);
        printf("%c",205);
    }


    gotoxy(70,2);
    printf("%c",187);
    for(int i=0;i<23;i++)
    {
        gotoxy(70,3+i);
        printf("%c",186);
    }
    gotoxy(70,26);
    printf("%c",188);
    gotoxy(0,0);

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
void print_number_of_emplyee(int i,int pi){

    gotoxy(pi+1,2);
    textattr(HighLightPen);
    printf(" Employee Data ");
    textattr(NormalPen);
    /*
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
    */
}
void Draw_table_data(int i,int option){
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

    Print_small_trinagle(50,26);               //Back   or ok
    gotoxy(55,27);
    if(option==1)
    {
        printf("   Back    ");
    }
    else
    {
        printf("    OK     ");
        //char ch=getch();
    }
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

void error_rectanle(){
//first col =
    gotoxy(40,10);
    printf("%c",201);
    for(int i=0;i<1;i++)
    {
        gotoxy(40,11+i);
        printf("%c",186);
    }
    gotoxy(40,12);
    printf("%c",200);

    //first row =
    for(int i=0;i<40;i++)
    {
        gotoxy(41+i,10);
        printf("%c",205);
    }
    //last row =
    for(int i=0;i<40;i++)
    {
        gotoxy(41+i,12);
        printf("%c",205);
    }


    gotoxy(80,10);
    printf("%c",187);
    for(int i=0;i<1;i++)
    {
        gotoxy(80,11+i);
        printf("%c",186);
    }
    gotoxy(80,12);
    printf("%c",188);
    gotoxy(0,0);
}

void display_error_table_all_alements(){
    system("cls");
    textattr(8);
    error_rectanle();
    gotoxy(53,8);
    textattr(HighLightPen);
    printf("   WARNNING   ");
    textattr(NormalPen);

    gotoxy(47,11);
    textattr(6);
    printf(" **THIS ID ALREADY EXIST** ");
    textattr(NormalPen);

    gotoxy(28,14);
    textattr(8);
    printf("   RE-ENTER  ");

    gotoxy(53,14);
    printf("     BACK    ");

    gotoxy(78,14);
    printf("    CHANGE   ");

    textattr(NormalPen);

    textattr(8);
    Print_small_trinagle(50,7);    //WARNNING
    Print_small_trinagle(25,13);
    Print_small_trinagle(50,13);
    Print_small_trinagle(75,13);

}

void scan_all_data()
{
    system("cls");
    Draw_table_data(0,0); //////////////////
    textattr(3);
    gotoxy(37,9);
    scanf("%d",&temp.id);
    gotoxy(37,13);
    scanf("%s",&temp.name);

    gotoxy(37,17);
    scanf("%lf",&temp.salary);

    gotoxy(37,21);
    scanf("%s",&temp.address);

    gotoxy(77,9);
    scanf("%d",&temp.age);

    gotoxy(77,13);
    scanf("\n");
    scanf("%c",&temp.Gen);

    gotoxy(77,17);
    scanf("%lf",&temp.tax);

    gotoxy(77,21);
    scanf("%lf",&temp.over_tm);
}

void Enter_Data()
{
    char ch,names[3][14]={"   RE-ENTER  ","     BACK    ","    CHANGE   "};
    int current_arrow=0,ex=1,f=1;
    do{
        ex=0;
        scan_all_data();
        gotoxy(55,27);
        textattr(HighLightPen);
        printf("    OK     ");
        textattr(NormalPen);
        gotoxy(0,0);
        if(check_for_id(temp.id))
        {
            f=0;
            getch();
            display_error_table_all_alements();
            do{

                for(int i=0;i<3;i++)
                {
                    if(current_arrow==i)
                    {
                        textattr(HighLightPen);
                        gotoxy(28+(25*i),14);
                        printf("%s",names[i]);
                    }
                    else
                    {
                        textattr(8);
                        gotoxy(28+(25*i),14);
                        printf("%s",names[i]);
                    }
                }
                //textattr(NormalPen);

                gotoxy(0,0);
                ch=getch();
                switch(ch)
                {
                case 13:    //Enter
                    {
                        switch(current_arrow)
                        {
                            case 0:                         //New Enter DATA
                                {
                                    f=1;
                                    system("cls");
                                    ex=1;
                                    break;
                                }
                            case 1:                        //BACK
                                {
                                    system("cls");
                                    break;
                                }
                            case 2:                       //CHANGE
                                {

                                    textattr(NormalPen);
                                    system("cls");
                                    set_data_in_array(temp);
                                    break;
                                }

                        }
                        break;
                    }
                case -32:
                    {
                        gotoxy(0,0);
                        ch=getch();
                        gotoxy(0,0);
                        switch(ch)
                        {

                            case 77:                            //right
                                {
                                    current_arrow=(current_arrow+1)%3;
                                    //print_small_content_info(current_arrow);
                                    break;
                                }
                            case 75:                             //left
                                {
                                    current_arrow=(current_arrow+2)%3;;
                                    //print_small_content_info(current);
                                    break;
                                }

                        }
                        break;
                    }
                }
            }while(ch!=13);

        }
        else
        {
            set_data_in_array(temp);
        }
    }while(ex);
    gotoxy(0,0);
    if(f)
        ch = getch();

}


void diplay_data_of_i_emplyee_small_info(int i)
{


    textattr(3);

    gotoxy(57,8);
    printf("    ");
    gotoxy(57,8);
    printf("%i",e[i].id);

    gotoxy(57,12);
    printf("              ");
    gotoxy(57,12);
    printf("%s",e[i].name);

    gotoxy(57,16);
    printf("        ");
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

void print_small_structure_info(int option){


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
    Print_small_trinagle(45,26);         //END

    if(option==1){
    Print_small_trinagle(70,22);         //NEXT
    Print_small_trinagle(20,22);         //BACK
    }
}
void print_small_content_info(int current_arrow,int option){
    char names[4][14]={"     BACK    ","     INFO    ","     NEXT    ","     END     "};
    int X[4]={24,49,74,50};
    int Y[4]={23,23,23,27};

    textattr(6);
    if(option==1)
    {
        gotoxy(74,23);
        printf("     NEXT    ");

        gotoxy(24,23);
        printf("     BACK    ");
    }
    gotoxy(49,23);
    printf("     INFO    ");

    gotoxy(50,27);
    printf("     END     ");
    if(option==1){
        for(int i=0;i<4;i++)
        {
            if(current_arrow==i)
            {
                textattr(HighLightPen);
                gotoxy(X[i],Y[i]);
                printf("%s",names[i]);
                textattr(NormalPen);
            }
            else
            {
                textattr(NormalPen);
                gotoxy(X[i],Y[i]);
                printf("%s",names[i]);
            }
        }
    }
    else
    {

        if(current_arrow==0)
        {
            textattr(HighLightPen);
            gotoxy(X[1],Y[1]);
            printf("%s",names[1]);
            textattr(NormalPen);
            gotoxy(X[3],Y[3]);
            printf("%s",names[3]);
        }
        else
        {
            textattr(HighLightPen);
            gotoxy(X[3],Y[3]);
            printf("%s",names[3]);
            textattr(NormalPen);
            gotoxy(X[1],Y[1]);
            printf("%s",names[1]);
        }
    }
/*
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
    }
*/
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

void Show_Data_of_all_employee(){
    char ch,current=0,ex=1,i=0;
    for(int j=0;j<100;j++)                        //for first show after delete
    {
        if(e[j].id!=-1)
        {
            i=j;
            break;
        }
    }
    diplay_data_of_i_emplyee_small_info(i);
    print_small_structure_info(1);
    print_small_content_info(current,1);
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

                        int found=0;
                        for(int k=i-1;k>=0;k--)
                        {
                            if(e[k].id!=-1)
                            {
                                i=k;
                                found=1;
                                break;
                            }
                        }
                        if(!found){
                        for(int k=100;k>=i;k--)
                        {
                            if(e[k].id!=-1)
                            {
                                i=k;
                                break;
                            }
                        }
                        }
                        diplay_data_of_i_emplyee_small_info(i);
                        break;
                    }
                case 1:
                    {
                        display_full_info(i);
                        ch=getch();
                        system("cls");
                        diplay_data_of_i_emplyee_small_info(i);
                        print_small_structure_info(1);
                        print_small_content_info(current,1);
                        break;
                    }
                case 2:
                    {
                        int found=0;
                        for(int k=i+1;k<=100;k++)
                        {
                            if(e[k].id!=-1)
                            {
                                i=k;
                                found=1;
                                break;
                            }
                        }
                        if(!found){
                        for(int k=0;k<i;k++)
                        {
                            if(e[k].id!=-1)
                            {
                                i=k;
                                break;
                            }
                        }
                        }


                        diplay_data_of_i_emplyee_small_info(i);
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
                        print_small_content_info(current,1);
                        break;
                    }
                case 80:                            //down
                    {
                        current=3;
                        print_small_content_info(current,1);
                        break;
                    }
                case 77:                            //right
                    {
                        current=(current+1)%4;
                        print_small_content_info(current,1);
                        break;
                    }
                case 75:                             //left
                    {
                        current=(current+3)%4;;
                        print_small_content_info(current,1);
                        break;
                    }
                }
                break;
            }

        }

    }while(ex);

}

void main_build_and_coloe_after_show()
{
    textattr(11);
    print_main_trinagle();
    Print_small_trinagle(45,3);
    Print_small_trinagle(45,7);
    Print_small_trinagle(45,11);
    Print_small_trinagle(45,15);
    Print_small_trinagle(45,19);
    Print_small_trinagle(45,23);

    textattr(NormalPen);
}

void not_found_data(int option)
{
    textattr(8);
    error_rectanle();
    Print_small_trinagle(50,7);
    gotoxy(53,8);
    textattr(HighLightPen);
    printf("   WARNNING   ");
    textattr(NormalPen);

    gotoxy(47,11);
    textattr(6);
    if(option==0)
    {
        printf(" **Please enter Data** ");
    }
    else
    {
        printf(" **    NOT FOUND    ** ");
    }
    textattr(NormalPen);
    gotoxy(0,0);
    getch();
}

void delete_by_id()
{
    int id;
    system("cls");
    textattr(8);
    Print_small_trinagle(54,4);               //for input id
    textattr(6);
    gotoxy(40,5);
    printf("Enter ID : ");
    textattr(11);
    gotoxy(56,5);
    scanf("%d",&id);
    system("cls");
    int i=check_for_id(id);
    if(i!=0)
        e[i-1].id=-1;
}

void delete_by_name()
{
    char name[100];
    system("cls");
    textattr(8);
    Print_small_trinagle(54,4);               //for input id
    textattr(6);
    gotoxy(38,5);
    printf("Enter Name : ");
    textattr(11);
    gotoxy(56,5);
    scanf("%s",&name);
    system("cls");

    for(int i=0;i<=100;i++)
    {
        if(!strcmp(e[i].name,name))
        {
            e[i].id=-1;
        }
    }
}

void Show_Data_by_id(){
    char ch;
    int current=0,ex=1,i=0,tem;

    system("cls");
    textattr(8);
    Print_small_trinagle(54,4);               //for input id
    textattr(6);
    gotoxy(40,5);
    printf("Enter ID : ");
    textattr(11);
    gotoxy(56,5);
    scanf("%d",&tem);
    system("cls");

    i=check_for_id(tem);
    if(!i)
    {
        not_found_data(1);
    }
    else{
    i--;
    diplay_data_of_i_emplyee_small_info(i);
    print_small_structure_info(0);
    print_small_content_info(current,0);
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
                        display_full_info(i);
                        ch=getch();
                        system("cls");
                        diplay_data_of_i_emplyee_small_info(i);
                        print_small_structure_info(0);
                        print_small_content_info(current,0);
                        break;
                    }
                case 1:
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
                        current=(current+1)%2;
                        print_small_content_info(current,0);
                        break;
                    }
                case 80:                            //down
                    {
                        current=(current+1)%2;
                        print_small_content_info(current,0);
                        break;
                    }
                case 77:                            //right
                    {
                        current=(current+1)%2;
                        print_small_content_info(current,0);
                        break;
                    }
                case 75:                             //left
                    {
                        current=(current+1)%2;
                        print_small_content_info(current,0);
                        break;
                    }
                }
                break;
            }

        }

    }while(ex);

}
}

int main()
{
    char words[7][14]={"     New     ","  SHOW BY ID ","   SHOW ALL  "," Delete BY ID"," Delete BY NM","     Exit    "},ch;
    int current=0,lo=1;
    Itialize_ID();
    //Load_Bar();
    system("cls");


    main_build_and_coloe_after_show();

    do{

        for(int i=0;i<6;i++)
        {
            gotoxy(49,4+(4*i));
            if(i==current)
            {
                textattr(HighLightPen);
            }
            else
            {
                textattr(8);
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
                            emp_counter++;
                            system("cls");
                            Enter_Data();
                            system("cls");
                            main_build_and_coloe_after_show();
                            break;

                        }
                    case 1:                        //Show BY ID if EXIST
                        {
                            system("cls");
                            Show_Data_by_id();
                            system("cls");
                            main_build_and_coloe_after_show();
                            break;
                        }
                    case 2:                       //Show ALL
                        {
                            system("cls");
                            if(emp_counter>0)
                                Show_Data_of_all_employee();
                            else
                                not_found_data(0);
                            system("cls");
                            main_build_and_coloe_after_show();
                            textattr(NormalPen);
                            break;
                        }

                    case 3:                         //Delete BY ID
                        {
                            emp_counter--;
                            system("cls");
                            delete_by_id();
                            system("cls");
                            main_build_and_coloe_after_show();
                            break;

                        }
                    case 4:                       //Delete BY NAme
                        {
                            emp_counter--;
                            system("cls");
                            delete_by_name();
                            system("cls");
                            main_build_and_coloe_after_show();
                            break;
                        }
                    case 5:                       //ExIT
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
                        current=(current+5)%6;
                        break;

                    }
                case 80:                            //down
                    {
                        current=(current+1)%6;
                        break;

                    }
                case 71:                            //home
                    {
                        current=0;
                        break;

                    }
                case 79:                             //End
                    {
                        current=5;
                        break;
                    }

                }
            }
        }
        textattr(NormalPen);

    }while(lo);
    return 0;
}
