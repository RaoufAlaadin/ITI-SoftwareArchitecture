#include <iostream>
#include "C:\Program Files\CodeBlocks\MinGW\include\graphics.h"

//#include "C:\Program Files\CodeBlocks\MinGW\include\winbgim.h"

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

class Point
{

    int x, y;

public:

    Point()
    {
        x = y = 0;

        cout << "point parameterless ctor \n ";
    }

    Point ( int _x, int _y)
    {

        x = _x;
        y = _y;

//        cout << "Point Ctor02 \n";
    }

    ~Point () { }

    int GetX () {return x;}

    int GetY () {return y;}

    void SetX (int _x) { x = _x;}

    void SetY (int _y) { y = _y; }

    void Show()
    {
        // previews the values of x and y
        cout << "(" << x << "," << y << ") \n" ;

    }



};



class Rect : public ColorSpace
{
    /*this is a composition relation.

        as the point became a necessary part of creating the Rect Class

        Also creating one Rect now takes = 8 + 8 + 4  = 20 bytes  */


    // here we intiliazed 2 Point objects using parameterless ctor
    // so we don't need to add anything about them inside our Rect ctor

    Point UL; //upper left
    Point LR; // lower right




    public:

        Rect ()
        {
//            cout << "Rect parameterless ctor \n ";
        }

        Rect ( int X1, int Y1, int X2, int Y2, int C) : UL(X1,Y1), LR(X2,Y2) , ColorSpace(C)
        {
            // ctor chaining
            /* We cannot write UL.X = X1 as the attributes are private and only accessible directly
                    in the Point class.
            */


//            cout << "Rect  ctor02 \n ";

        }


        void Draw ()
        {
            //NOTE: rectangle only draws. you need another fn. for colors

            // Built-in Function from Graphics.h
            setcolor(GetColor());
            rectangle(UL.GetX(),UL.GetY(),LR.GetX(),LR.GetY());

           /* void rectangle(int x1,int y1,int x2,int y2)
                {
                    BGN.X = (short)x1+movx;
                    BGN.Y = (short)y1+mov;
                    POS.X = (short)x2+movx;
                    POS.Y = (short)y2+mov;
                    PlotRect(hDC, PEN, BGN, POS);
                } */
        }



};

class Line : public ColorSpace
{

    Point P1;
    Point P2;


    public:

        Line (){}

        Line ( int X1, int Y1, int X2, int Y2, int C) : P1(X1,Y1), P2(X2,Y2), ColorSpace(C)
        {}

        void Draw ()
        {

            setcolor(GetColor());
            line(P1.GetX(),P1.GetY(),P2.GetX(),P2.GetY());
        }

};


class Triangle : public ColorSpace
{
    Point P1;
    Point P2;
    Point P3;


    public:

        Triangle (){}

        Triangle ( int X1, int Y1, int X2, int Y2, int X3, int Y3,int C) : P1(X1,Y1), P2(X2,Y2), P3 (X3,Y3) , ColorSpace(C)
        {}

        void Draw ()
        {
            setcolor(GetColor());
            line(P1.GetX(),P1.GetY(),P2.GetX(),P2.GetY());
            line(P2.GetX(),P2.GetY(),P3.GetX(),P3.GetY());
            line(P3.GetX(),P3.GetY(),P1.GetX(),P1.GetY());

        }


};

class Circle : public ColorSpace
{

    Point P1;
    int Radius;


    public:

        Circle (){}

        Circle ( int X1, int Y1, int R, int C): P1(X1,Y1), ColorSpace(C)
        {
            Radius = R;

        }

        void Draw ()
        {
            setcolor(GetColor());
            circle(P1.GetX(),P1.GetY(),Radius);
        }

};






int main()
{

   initgraph();


    Rect R1 (294,340,529,409,4);
    R1.Draw();

    Line L1 (376,340,378,278,4);
    L1.Draw();

    Line L2 (439,341,437,260,4);
    L2.Draw();

    Line L3 (461,232,445,117,5);
    L3.Draw();

    Line L4 (351,233,367,113,5);
    L4.Draw();


    Circle C1(405,117,80,4);
    C1.Draw();

    Circle C2(405,233,120,4);
    C2.Draw();

    Triangle T1(315,391,333,356,348,393,4);
    T1.Draw();




}
