#include <iostream>

using namespace std;

class Parent {

protected:

int X;
int Y;

public:

    Parent ()
    {
        X = Y = 0 ;
        cout << "Parent parameterless ctor \n" ;

    }

    Parent(int _X, int _Y)
    {

        X = _X; ;
        Y = _Y ;

        cout << "Parent ctor01 \n" ;
    }
    ~Parent ()
    { cout << "Parent dest. \n" ; }


    int GetX () { return X;}
    int GetY () { return Y;}

    void SetX(int _X) { X = _X; }
    void SetY (int _Y) { Y = _Y;}

//    int SumXY()

    int Sum()
    {
        return X  + Y;
    }

};

class Child : public Parent
{
    int Z;

public:

    Child ()
    {
        int Z = 0;
        cout << " Child Parameterless Ctor \n" ;
    }

    // constructors.

    Child(int _X, int _Y , int _Z):Parent(_X , _Y)
    {
        // Ctor chaining , Child choose wich base Ctor to use to intiliaze Base members in Derived  Object

        // I input 3 parameters to child ctor and 2 of them goes as an input to Parent ctor


        Z = _Z;
        cout << "Child ctor02 \n" ;

    }
    ~Child () { cout << "Child dest. \n"; }

    int GetZ () { return Z;}

    void SetZ (int _Z) { Z = _Z;}

//    int SumXYZ()

// fn. over-riding
    int Sum ()
    {
        // this -> GetX is same as GetX

        // while using (protected) we can use X and Y normally.


//        return (GetX()  + GetY() + Z) ;

        return (Parent::Sum() + Z) ;
    }

};

int main()
{

    Parent P (1,2) ;

    P.SetX(3);
    P.SetY(4);


    Child C (5,6,7) ;

    C.SetX(8);

    C.SetY(9);

    C.SetZ(10);



//    cout << C.SumXYZ() << endl;
//    cout << C.SumXY() << endl;

        // same fn. getting overrided for each class.
    cout << C.Sum() << endl;
    cout << P.Sum() << endl;
}
