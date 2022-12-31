#include <iostream>
#include <stdlib.h>
#include <stdio.h>

// this is the one that has --> _getche()
#include <conio.h>

using namespace std;

class complex
{
private:
    int Real;
    int Img;

public:

    // Constructors

     complex (int R, int I)
    {
        cout<<"ctor 01" <<endl;
        cout<< this <<endl<<endl;
        Real = R;
        Img = I ;
    }

    complex (int n)
    {
        cout<<"ctor 02" <<endl;
        cout<< this <<endl<<endl;
        Real = Img = n;
    }

    complex ()
    {
        cout<<"ctor 03" <<endl;
        cout<< this <<endl<<endl;
        Real = Img = 0;
    }

    // destructor

    ~complex()
    {
        cout<<"Destructor" <<endl;
        cout<< this <<endl<<endl;
    }

    void SetReal (int R) { Real = R;}
    void SetImg (int I) {Img = I;}

    int GetReal () { return Real;}
    int GetImg () {return Img;}

    /*  We want a function that prints
            1- R,Img and
            2- i
            3- ( + /-)

        -- Should be a member function or stand-alone.
    */

    void print()
    {
        if ( Img < 0 && Real != 0)
        {
            cout << "The complex number is : "<< Real ;
            cout << Img << "i" << endl;
        }
        else if (Img == 0)
        {
            cout << "The complex number is : " << Real <<endl;
        }
        else if (Real == 0 && Img < 0)
        {

            cout << "The complex number is : " << Img << "i" << endl;
        }
        else if (Real == 0 && Img == 0)
        {
            cout << "The complex number is : " << 0 <<endl;
        }
        else{

            cout << "The complex number is : " << Real << "+" ;
            cout << Img << "i" << endl;
            }

    }


    complex sum(complex C)
        {
            complex Result;

            Result.SetReal(GetReal() + C.GetReal());

            Result.SetImg(GetImg() + C.GetImg());

            return Result;

        }

};




int main()
{
    /* Summary:

        The number of objects are going to be 5 -- ( 3 in main and 2 in fn. )

        We will get 5 constructor calls ( 3 objects in main + 1 as an input to the fn. + 1 inside of the fn. )


        note: the fn. is not showing in the tracing when constructed because it needs a copy constructor which was
        made implicitly by the compiler that's why we only saw it when it called the destructor after the fn. ended.

        and 5 destructor calls.

    */



   complex C1(1,2), C2(5), C3;

   C3 = C1.sum(C2);
   C3.print();



}
