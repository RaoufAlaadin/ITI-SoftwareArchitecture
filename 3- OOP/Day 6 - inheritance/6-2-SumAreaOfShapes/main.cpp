#include <iostream>

using namespace std;

class GeoShape
{

protected:

    double Dim1, Dim2;

public:

    GeoShape (double d1 = 0, double d2 = 0)
    {
        Dim1 = d1;
        Dim2 = d2;
    }

//    ~GeoShape () {cout << "Geoshape Dest. \n"; }

    double GetDim1() {return Dim1;}
    double GetDim2() {return Dim2;}

    void SetDim1(double D) {Dim1 = D;}
    void SetDim2(double D) {Dim2 = D;}
};


// 1- Rectangle

class Rect : public GeoShape
{

    public:

    Rect (double W, double H): GeoShape(W,H) {}
//
//    ~Rect () {cout << "Rect Dest. \n"; }

    double CArea () { return Dim1 * Dim2 ;}
};

// 2- Square

class Square : protected Rect
{

    public:


    Square (double L): Rect(L,L) {}

        // either of them will set our square ready.

    void SetDim1 (double D) { Dim1 = Dim2 = D;}
    void SetDim2 (double D) { Dim1 = Dim2 = D;}

    double CArea()
    { return Dim1 * Dim2; }

};

// 3- Circle


class Circle : public GeoShape
{
 public:

    Circle (double R): GeoShape(R,R) {}

    ~Circle (){}

        // Circle Area =  pi * r^2

    double CArea () { return 3.14* Dim1 * Dim2 ;}

};

// 4- Triangle

class Triangle : public GeoShape
{

  public:

    Triangle (double d1, double d2): GeoShape(d1,d2) {}

    ~Triangle (){}
    // Triangle = 0.5 * base *
    double CArea () { return 0.5* Dim1 * Dim2 ;}

};

// we have 8 inputs -- > 4 objects array and their respective sizes.
//Standalone fn.

double SumArea(Rect *RectArr, Square *SqArr, Circle *CArr, Triangle *TArr, int Rsize, int Ssize, int Csize, int Tsize)
{
    double Result = 0;
    int i = 0;

    for (i = 0; i < Rsize; i++)
    {
        Result += RectArr[i].CArea();
    }
    for (i = 0; i < Ssize; i++)
    {
        Result += SqArr[i].CArea();
    }
    for (i = 0; i < Csize; i++)
    {
        Result += CArr[i].CArea();
    }
    for (i = 0; i < Tsize; i++)
    {
        Result += TArr[i].CArea();
    }

    return Result;
}

int  main()
{
    cout << " Testing the Area of all the shapes. \n";

    cout<< "============================================== \n" ;
    Rect R (10,15);
    cout << "  Rectangle --> " << R.CArea() <<endl;

    Square S(20);
    cout << "  Square --> " << S.CArea() <<endl;

    Circle C (10);
    cout << "  Circle --> " << C.CArea() <<endl;

    Triangle T (5,6);
    cout << "  Triangle --> " << T.CArea() <<endl;

    cout<< "============================================== \n" ;

    /* NOTE: if we  want to use variable sizes, then we have to use Dynmicallly allocated array of objects
            https://www.youtube.com/watch?v=GeZiIDyJdYc&ab_channel=AdelNasim
    */
//    int Rsize = 1, Ssize = 1 , Csize = 1 , Tsize = 1 ;

    Rect RectArr[3] = {  Rect(10,10), Rect(10,10),Rect(10,10) } ; //300

    Square SqArr[3] = {  Square(10), Square(10),Square(10) } ;  // 300

    Circle CArr[3] = {  Circle(10),Circle(10),Circle(10) } ; // 942

    Triangle TArr[3] = {  Triangle (10,10) , Triangle (10,10) , Triangle (10,10) } ; // 150



cout << " \n The Sum of Area is ====> " << SumArea(RectArr, SqArr, CArr, TArr, 3, 3, 3, 3) <<endl;  // 1692


}
