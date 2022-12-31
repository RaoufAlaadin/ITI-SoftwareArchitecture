#include <iostream>

using namespace std;


/* We will declare cArea inside GeoShape as virtual and then using ptr to objects
    we will be able to use the latest version of the fn. when needed */

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

    // we don't have a specific implemention for it
    // we just made the decleration and
    virtual double CArea ()  {return 0;}

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

class Square : public Rect
{

    public:


    Square (double L): Rect(L,L) {}

        // either of them will set our square ready.

    void SetDim1 (double D) { Dim1 = Dim2 = D;}
    void SetDim2 (double D) { Dim1 = Dim2 = D;}

//    double CArea()
//    { return Dim1 * Dim2; }

};

// 3- Circle


class Circle : public GeoShape
{
 public:

    Circle (double R): GeoShape(R,R) {}

    ~Circle (){}

        // Circle Area =  pi * r^2

    double CArea () override { return 3.14* Dim1 * Dim2 ;}

};

// 4- Triangle

class Triangle : public GeoShape
{

  public:

    Triangle (double d1, double d2): GeoShape(d1,d2) {}

    ~Triangle (){}
    // Triangle = 0.5 * base *
    double CArea () override { return 0.5* Dim1 * Dim2 ;}

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


double SumOfAreas(GeoShape** GArr, int C)
{
    double Sum = 0;

    for (int i = 0; i < C; i++)
    {
        /* GArr is pointer that points at array of pointers
            GArr[i] is the address stored in the first pointer from the array and it points at an object
            to access the object we write :    *GArr[i]  to dereference the address
                                                                and to get to it's fn.    (*GArr[i]).CArea();

                                Which is the same as GArr[i] -> CArea();

                                                                                                            */
        Sum += GArr[i] -> CArea();
    }

    return Sum;
}



int  main()
{

    Rect Arr1[3] = {  Rect(10,10), Rect(10,10),Rect(10,10) } ; //

    Square Arr2[2] = {  Square(10), Square(10) } ;  //

    Triangle Arr3[2] = {  Triangle (10,10) , Triangle (10,10)  } ; //

    // note : Arr1 is the same as &Arr1[0]

    GeoShape* Arr[7] = { Arr1 , &Arr1[1] , &Arr1[2], Arr2, &Arr2[1] , Arr3, &Arr3[1] };




    cout << SumOfAreas(Arr,7) << endl;


    GeoShape G (10,10) ; Square S (20);
    G = S; // it will only take the part it knows from Square and will not look back.

    // [important note]  this will print zero. As we didn't satisfy the 4th rule by using pointers not variables.
    cout << G.CArea() <<endl;


  /*
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

    // NOTE: if we  want to use variable sizes, then we have to use Dynmicallly allocated array of objects
          // https://www.youtube.com/watch?v=GeZiIDyJdYc&ab_channel=AdelNasim

//    int Rsize = 1, Ssize = 1 , Csize = 1 , Tsize = 1 ;

    Rect RectArr[3] = {  Rect(10,10), Rect(10,10),Rect(10,10) } ; //300

    Square SqArr[3] = {  Square(10), Square(10),Square(10) } ;  // 300

    Circle CArr[3] = {  Circle(10),Circle(10),Circle(10) } ; // 942

    Triangle TArr[3] = {  Triangle (10,10) , Triangle (10,10) , Triangle (10,10) } ; // 150



cout << " \n The Sum of Area is ====> " << SumArea(RectArr, SqArr, CArr, TArr, 3, 3, 3, 3) <<endl;  // 1692*/


/*GeoShape* Ptr = new Square(20);

cout << Ptr -> CArea(); // gives 400 as we have dynamic binding.*/


}
