#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <string.h>
#include<windows.h>
#define NormalPen 0x0F
#define HighLightPen 0XF0
#define Enter 0x0d
#define ESC 27
#include <windows.h>

// created it to make an array of structs to input different data, why did we not make it separate data?
// ya3ny n3mlo data mtfrata, l2n mfesh mantek y5len a3mel kda, talma enta 3ndak 7aga lazem tsheel aktar mn field, n3mlha struct aw class b3d kda fe el c++
struct Employee
{
    int id;
    char name[100];
    double salary;
};
// De el array elly bnfsheel feha el data bta3t kol mwazf, ya3ny kol ma el user y create new employee bn7oto f el array de, de btmsel el database
struct Employee employeesData[10];

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

// de el function elly btrsem el main menu, (add, display, exit);
// bt3mel check 3la el key elly el user d5alo fe 7alet eno ashom arrows ya3ny bnt7arak lfo2 w lta7t, w mtnsash fkret en el sahm da extended key
// f lazem t3mel getch marteen,
void drawMenu(int current)
{

    char menu[3][8]= {"new","display","exit"};
    textattr(NormalPen);
    system("cls");
    for(int i=0; i<3; i++)
    {
        if(i == current)
        {
            textattr(HighLightPen);
        }
        else
        {
            textattr(NormalPen);
        }
        gotoxy(5,10+(3*i));
        printf("%s",menu[i]);  //string make it 1D array not 2D
    }
}

// de el function elly btrsem menu lel user 3shan yda5al el data bta3t el mwazf w b3d ma yda5al el data, a5er satr f el function bymsek el mwzaf elly
// e7na 3mlnah elly hoa mn no3 struct employee, y5azeno f el array elly e7na m3rfenha fo2
void drawEmployeeMenu(int index)
{
    system("cls");
    printf("please enter the data of employee %d \n", index+1);
    // create object of employee elly han5zen fe el data
    struct Employee E;
    gotoxy(5,10);
    printf("ID:\n");

    gotoxy(5,13);
    printf("Name:\n");

    gotoxy(5,16);
    printf("Salary\n");



    gotoxy(12,10);
    scanf("%d",&E.id);

    gotoxy(12,13);
    scanf("%s",E.name);

    gotoxy(12,16);
    scanf("%d",&E.salary);


    // 5azen el object elly createnah fe el array
    employeesData[index] = E;


}

// de function bt3rd el data bta3t el mwzaf, ezzay? ba5od el index adwar 3leh f el array law mawgood, a3rdeo law mesh mawgood tala3 error

void displayEmployee(int index)
{
    system("cls");
    // hena n3ml check 3la el index elly el ragel b3to e7na etf2na law el mawzaf mesh mawgood hayb2a el data bta3to garbage, f el garabage bta3 el id
    // hyb2a b zero, f el check hena enk tshoof el id law b zero etba3 error w e5rog men el function
    // fe else ro7 hat el data bta3t el mawzaf men el array w e3rdha
    if (employeesData[index].id==0)
    {
        printf("the data of the employee does not exist \n press ant key to continue");
        if(getch())
            drawMenu(0);

    }
    else
    {

        gotoxy(5,10);
        printf("ID:\n");
        gotoxy(8, 10);
        printf("%d", employeesData[index].id);
        gotoxy(5,13);
        printf("Name:\n");
        gotoxy(10,13);
        printf("%s",employeesData[index].name);
        gotoxy(5,16);
        printf("Salary\n");
        gotoxy(12,16);
        printf("%d",employeesData[index].salary);
        gotoxy(20,20);
        printf("press any key to continue\n");
        if(getch())
            drawMenu(0);
    }

}



int main()
{


    int current =0;
    char ch;




    drawMenu(current);
    int index;
    do
    {
        ch=getch();     // non extended keys
        switch(ch)
        {
        case Enter:
            switch(current)
            {
            case 0:
                system("cls");

                printf("please enter the index of the employee\n");
                scanf("%d",&index);
                if (index>9)
                {
                    printf("the employee index is not exist, press any key to continue\n");
                    if(getch())
                        drawMenu(current);
                }
                else
                {


                    drawEmployeeMenu(index) ;
                    drawMenu(current);
                }

                break;
            case 1:
                system("cls");
                printf("plz enter the index of the employee\n");
                scanf("%d",&index);
                if (index>9)
                {
                    printf("the employee index is not exist, press any key to continue\n");
                    if(getch())
                        drawMenu(current);
                }
                else
                {


                    displayEmployee(index);

                    drawMenu(current);
                }

                break;
            case 2:
                ch=ESC;

                break;
            }



            break;
        case -32:   // extended keys
            ch=getch();

            switch(ch)
            {
            case 72:  //up
                if(current==0)
                {
                    current=2;
                    drawMenu(current);
                }
                else
                {
                    current--;
                    drawMenu(current);
                }
                break;
            case 80:    //down
                if(current==2)
                {
                    current=0;
                    drawMenu(current);
                }
                else
                {
                    current++;
                    drawMenu(current);
                }
                break;
            case 79:      //end
                current=3;
                drawMenu(current);
                break;


            }
            break;



        }
    }
    while(ch!=ESC);


    return 0;
}
