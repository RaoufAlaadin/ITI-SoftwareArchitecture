#include <iostream>

using namespace std;

class GeoShape
{

protected:

    int Dim1, Dim2;

public:

    GeoShape (int d1 = 0, int d2 = 0)
    {
        Dim1 = d1;
        Dim2 = d2;
    }

    ~GeoShape () {cout << "Geoshape Dest. \n"; }

    int GetDim1() {return Dim1;}
    int GetDim2() {return Dim2;}

    void SetDim1(int D) {Dim1 = D;}
    void SetDim2(int D) {Dim2 = D;}
};


// 1- Rectangle

class Rect : public GeoShape
{

public:

    Rect (int W, int H): GeoShape(W,H) {cout << " Rectangle ctor \n"; }

    ~Rect () {cout << "Rect Dest. \n"; }

    int CArea () { return Dim1 * Dim2 ;}
};

// 2- Square

class Square : protected Rect
{
    // we didn't need any new dimensions over what we have from Rect.
    // Because a Square is similar to it.

public:

    // both of the dimensions take the same input value
    // to create a square.
    Square (int L): Rect(L,L)  {cout << " Square ctor \n"; }

    // we didn't write CArea agian as it's the same as the Rect

    // new functions, because we inherited protected from rect/

    void SetDim1 (int D) { Dim1 = Dim2 = D;}
    void SetDim2 (int D) { Dim1 = Dim2 = D;}

    int CArea()
    {
        /* I can still use Rect::CArea    ONLY from inside of the class*/
        return Rect::CArea();
    }
};

// 3- Circle


class Circle : public GeoShape
{
 public:

    Circle (int R): GeoShape(R,R) {cout << " Circle ctor \n"; }

    ~Circle () {cout << "Circle Dest. \n"; }

    int CArea () { return 3.14* Dim1 * Dim2 ;}

};

// 4- Triangle

class Triangle : public GeoShape
{

  public:

    Triangle (int d1, int d2): GeoShape(d1,d2) {cout << " Triangle ctor \n"; }

    ~Triangle () {cout << "Triangle Dest. \n"; }

    int CArea () { return 0.5* Dim1 * Dim2 ;}

};

int main()
{   Rect R (10,15);

    R.SetDim1 (11);
    R.SetDim2 (16);

    cout << R.CArea() <<endl;
}
