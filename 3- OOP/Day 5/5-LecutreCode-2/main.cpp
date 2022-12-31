#include <iostream>

using namespace std;



//class complex
//{
//
//};

// Template Method


template <class T>

void Swap ( T& x, T& y)
{
    T Temp = x;

    x = y;

    y = Temp;

}

// non - Template ( called non- Generic in .NET )

void Swap (int &x, int &y)
{
    double Temp = x;

    x = y;

    y = Temp;

}

//void Swap (double &x, double &y)
//{
//    double Temp = x;
//
//    x = y;
//
//    y = Temp;
//
//}

//void Swap (double &x, double &y)
//{
//    double Temp = x;
//
//    x = y;
//
//    y = Temp;
//
//}

int main()
{
    int A = 7 , B = 3;

//    Swap (A,B);

    Swap <int> (A,B); // explicitly specify T : int

    // you can also not specify the type and the compiler will try to figure it out
    // and replace each (T) to a Data type based on the inputs

    cout << " A = " << A <<endl;
    cout << " B = " << B << endl;
    //////////////////////////////
    double D1 = 1234.5 , D2 = 1.2345 ;

    Swap(D1, D2);

    cout << " D1 = " << D1 << endl;
     cout << " D1 = " << D2 << endl;
     ////////////////////////////

    char ch01 =  'a', ch02 = 'z';

    Swap(ch01, ch02);

    cout << "ch01 = " << ch01 << endl;

    cout << "ch02 = " << ch02 << endl;







}
