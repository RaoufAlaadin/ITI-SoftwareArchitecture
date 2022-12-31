#include <iostream>
#include "C:\Program Files\CodeBlocks\MinGW\include\graphics.h"

using namespace std;

class ShapeColor
{
    int color;
public:
    ShapeColor(int c = 0)
    {
        color = c;
    }

    void setColor(int c)
    {
        color = c;
    }

    int getColor()
    {
        return color;
    }
};

class Point
{
    int x, y;
public:
    Point(int c1 = 0, int c2 = 0)
    {
        x = c1;
        y = c2;
    }
    int getX()
    {
        return x;
    }
    int getY()
    {
        return y;
    }
    void setX(int c)
    {
        x = c;
    }
    void setY(int c)
    {
        y = c;
    }
    void show()
    {
        cout << x << "," << y << endl;
    }
};

class MyRectangle: public ShapeColor
{
    Point ul, lr;
public:
    MyRectangle(int p1x, int p1y, int p2x, int p2y, int clr):
        ul(p1x, p1y), lr(p2x, p2y), ShapeColor(clr){}

    void draw()
    {
        // this just gives C as input
        setcolor(getColor());
        rectangle(ul.getX(), ul.getY(), lr.getX(), lr.getY());
    }
};

class Line: public ShapeColor
{
    Point p1, p2;
public:
    Line(int p1x, int p1y, int p2x, int p2y, int clr):
        p1(p1x, p1y), p2(p2x, p2y), ShapeColor(clr){}

    void draw()
    {
        setcolor(getColor());
        line(p1.getX(), p1.getY(), p2.getX(), p2.getY());
    }
};

class Triangle: public ShapeColor
{
    Point p1, p2, p3;
public:
    Triangle(int p1x, int p1y, int p2x, int p2y, int p3x, int p3y, int clr):
        p1(p1x, p1y), p2(p2x, p2y), p3(p3x, p3y), ShapeColor(clr){}

    void draw()
    {
        setcolor(getColor());
        line(p1.getX(), p1.getY(), p2.getX(), p2.getY());
        line(p1.getX(), p1.getY(), p3.getX(), p3.getY());
        line(p2.getX(), p2.getY(), p3.getX(), p3.getY());
    }
};

class Circle: public ShapeColor
{
    Point center;
    int radius;
public:
    Circle(int centerX, int centerY, int r, int clr):
        center(centerX, centerY), ShapeColor(clr)
    {
        radius = r;
    }

    void draw()
    {
        setcolor(getColor());
        circle(center.getX(), center.getY(), radius);
    }
};

int main()
{
    initgraph();

    int yOffset = 100;

    MyRectangle base (300, 145, 620, 300, 4);
    base.draw();

    Triangle button (532, 399+yOffset, 518, 420+yOffset, 546, 419+yOffset, 2);
    button.draw();

    Line column1 (600, 380+yOffset, 600, 300+yOffset, 2);
    column1.draw();

    Line column2 (544, 380+yOffset, 544, 300+yOffset, 2);
    column2.draw();

    Circle lCircle (573, 237+yOffset, 142, 2);
    lCircle.draw();

    Circle uCircle (573, 81+yOffset, 98, 2);
    uCircle.draw();

    Line uLine1 (622, 81+yOffset, 644, 237+yOffset, 2);
    uLine1.draw();

    Line uLine2 (524, 81+yOffset, 502, 237+yOffset, 2);
    uLine2.draw();

    return 0;
}
