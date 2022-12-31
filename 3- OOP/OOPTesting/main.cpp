// CPP Program to demonstrate Function overloading in
// Default Arguments
#include <iostream>
using namespace std;

// 3- static

class Parent
{ int y;
static int z;
public:
Parent( )
{
z=0; // Linel

cout<<"p less ctor" <<endl;
}
Parent (int a) //Line 2
{
y=a;

cout<<"p lized ctor" <<endl;
}
};

//int Parent::z = 0;


int main( )
{
Parent d(4); //Line 3
Parent m; //Line 4
}







// 2 - composite relation
/*
class Y
{

protected:
 int hi;

private:

    Y()
    {
//        cout<<" Y ctor" <<endl;
    }
     ~Y(){ cout<<" Y DESC" <<endl; }


};

class X : public Y
{

//    Y Y1;

public:

    X()
    {
        cout<<" X ctor" <<endl;
    }

    ~X(){ cout<<" X DESC" <<endl; }


};


int main()
{
    X X1;

//    Y Y1;

//    int a;
//    a=50;
//
////    ::a = 20;
//
//    cout << a;

}*/

// 1- default argument exercies

/*// A function with default arguments, it can be called with
// 2 arguments or 3 arguments or 4 arguments.
int sum(int x= 10, int y)
{
    return (x + y );
}
//int sum(int x, int y, float z = 0, float w = 0)
//{
//    return (x + y + z + w);
//}
// Driver Code
int main()
{
//    cout << sum(10, 15) << endl;
    cout << sum(10) << endl;
//    cout << sum(10, 15, 25, 30) << endl;
    return 0;
}*/
