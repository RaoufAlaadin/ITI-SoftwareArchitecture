#include <iostream>
#include "C:\Program Files\CodeBlocks\MinGW\include\graphics.h"


using namespace std;



class ColorSpace
{
    int Color;

public:

    ColorSpace ()
    {
        Color = 4;
    }

    ColorSpace(int c)
    {
        Color = c;
    }


    SetColor(int c) {Color = c;}

    int GetColor(){return Color;}




};

class point
{
    int x, y;
public:
    point()
    {
        x=y=0;
        //cout<<"Point Parameterless ctor is excuted"<<endl;
    }
    point(int _x, int _y)
    {
        x=_x;
        y=_y;
        //  cout<<"point(int _x ,int _y) ctor is excuted"<<endl;
    }
    ~point()
    {

        // cout<<"point Destctor is excuted"<<endl;
    }
    void setX(int _x)
    {
        x=_x;
    };
    void setY(int _y)
    {
        y=_y;
    };
    int GetX()
    {
        return x;
    };
    int GetY()
    {
        return y;
    };
    void show()
    {
        //cout<<"("<<x<<","<<y<<")"<<endl;
    }
};


class Rect : public ColorSpace
{
    point UL;
    point LR;

public:
    Rect()
    {
        int color=0;
        // cout<<"Rect Parameterless ctor is excuted"<<endl;
    }
    Rect(int x1, int y1, int x2, int y2,int c):UL(x1,y1), LR(x2,y2), ColorSpace(c)
    {

        // cout<<"Rect  ctor is excuted"<<endl;
    }
    ~Rect() {};
    void Draw()
    {
        setcolor(GetColor());
        rectangle(UL.GetX(),UL.GetY(),LR.GetX(),LR.GetY());
    }
};


class Circle : public ColorSpace
{
    point center  ;
    int  radius;
public:
    Circle()
    {
        int radius=0;
        // cout<<"LINE Parameterless ctor is excuted"<<endl;
    }
    Circle(int x1, int y1,int r, int c):center(x1,y1) , ColorSpace(c)
    {

        radius=r;
        // cout<<"LINE  ctor is excuted"<<endl;
    }
    ~Circle() {};
    void Draw()
    {
        setcolor(GetColor());
        circle(center.GetX(),center.GetY(),radius);
    }

};
class Line : public ColorSpace
{
    point UL, UR ;

public:
    Line()
    {

        // cout<<"LINE Parameterless ctor is excuted"<<endl;
    }
    Line(int x1, int y1, int x2, int y2,int c):UL(x1,y1), UR(x2,y2) , ColorSpace(c)
    {

    }
    ~Line() {};
    void Draw()
    {
        setcolor(GetColor());
        line(UL.GetX(),UL.GetY(),UR.GetX(),UR.GetY());

    }

};
class Triangle : public ColorSpace
{
    point UC, LR ;

public:
    Triangle()
    {
        // cout<<"Triangle Parameterless ctor is excuted"<<endl;
    }
    Triangle(int x1, int y1, int x2, int y2 ):UC(x1,y1), LR(x2,y2) , ColorSpace(c)
    {

        // cout<<"Triangle  ctor is excuted"<<endl;
    }
    ~Triangle() {};
    void Draw()
    {
        setcolor(GetColor());
        line(UC.GetX(),UC.GetY(),LR.GetX(),LR.GetY());
    }

};


int main()
{

    clrscr();
    initgraph();



    //point p1(10,10);
    // p1.show();

    Rect R1(50,295,357,340,90);

    SetBkColor(hDC,9);

    R1.Draw();
    Line L1(185,291,153,219,230);
    Line L2(185,293,222,222,230);
    Line L3(149,180,160,60,230);
    Line L4(225,180,197,62,230);
    Line L5 (111,310,97,330,230);
    Line L6 (97,330,130,330,230);
    Line L7 (130,330,111,310,230);
    SetBkColor(hDC,9);

    L1.Draw();
    L2.Draw();
    L5.Draw();
    L6.Draw();
    L7.Draw();

    SetBkColor(hDC,9);

    L3.Draw();
    L4.Draw();
    Circle C1(190,190,100,60);
    Circle C2(181,50,50,70);
    SetBkColor(hDC,9);

    C1.Draw();
    SetBkColor(hDC,9);

    C2.Draw();

// Triangle T1(600,150,900,150);
// T1.Draw();
    // Triangle T2(600,600,650,300);
//T2.Draw();
//  Triangle T3(900,150,90,300);
//T3.Draw();
//    _getch();


    //rectangle(130,210,450,210);


   

}
