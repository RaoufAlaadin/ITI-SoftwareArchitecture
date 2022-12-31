#include <iostream>

using namespace std;


// Abstract class => includes atleast one pure virtual method.
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


    // made it into PURE VIRTUAL METHOD
   virtual double  CArea () = 0 ;
};


// 1- Rectangle

class Rect : public GeoShape
{

    public:

    Rect (double W, double H): GeoShape(W,H) {}
//
//    ~Rect () {cout << "Rect Dest. \n"; }

    double CArea () override { return Dim1 * Dim2 ;}
};

// 2- Square

class Square : public GeoShape  // instead of inhertining from Rect, I can't remember why we did that.
{

    public:


    Square (double L): GeoShape(L,L) {}

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

double SumAreaDynamic( GeoShape** X, int C)
{
    double Result = 0;
    int i = 0;
//    GeoShape** X;

    for (i = 0; i < C; i++)
    {
        Result += X[i] ->CArea();
        /*
                Explaining how it works without the the []

                                        cout<<(**X).CArea()<<endl;
                                        cout<<(**(X+7)).CArea()<<endl; // X is like &X[0]
         */


    }


    return Result;
}

int  main()
{

    // Can't use this line because we didn't create a parameter-less constructor for it to use.
//    Rect* RectArr = new Rect[3];


    Rect RectArr[3] = {  Rect(10,10), Rect(10,10),Rect(10,10) } ; //300

    Square SqArr[3] = {  Square(10), Square(10),Square(10) } ;  // 300

    Circle CArr[3] = {  Circle(10),Circle(10),Circle(10) } ; // 942

    Triangle TArr[3] = {  Triangle (10,10) , Triangle (10,10) , Triangle (10,10) } ; // 150

    // only one (*) is used here because the name of the array is already a pointer.
    GeoShape* Arr[12] = {  RectArr,&RectArr[1],&RectArr[2],
                            SqArr, &SqArr[1], &SqArr[2],
                            CArr, &CArr[1] , &CArr[2],
                            TArr, &TArr[1], &TArr[2]           };



cout << " \n The Sum of Area is ====> " << SumAreaDynamic(Arr,12) <<endl;  // 1692


}
