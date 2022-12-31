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

        // you handle the zeros and the (-)

        /* this means:
            1) R: 4  I:3 --> 4 + 3i
            2) R: 4  I:-3 --> 4 - 3i
            3) R: 4  I: 0 --> 4
            4) R: 0  I: 3 --> 3i
            5) R: 0  I: 0 --> 0



            */

            // numbers for testing the print are ( 3 , -4 , 3 , 5)


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

    // add or subtract them by doing the img alike and real alike

    // function signture ?

        complex sum(complex C2)
        {
            complex C3;

            C3.SetReal(GetReal() + C2.GetReal());

            C3.SetImg(GetImg() + C2.GetImg());

            return C3;

        }

};

complex sub(complex L, complex R)
{
    complex C3;

    C3.SetReal(L.GetReal() - R.GetReal());
    C3.SetImg(L.GetImg() - R.GetImg());

   return C3;

}

int main()
{
   complex C1, C2, C3;

   // because I am using _getch() , which takes a character.
   char ExitFlag = '0';
   int x, y;

   do{
        // C1 values
        cout<<"Enter C1 (real): " ;
        cin >> x;
        C1.SetReal(x);

        cout<<"Enter C1 (Imag): " ;
        cin >> y;
        C1.SetImg(y);

        cout<<"\n \n";

        // C2 values
        cout<<"Enter C2 (real): " ;
        cin >> x;
        C2.SetReal(x);

        cout<<"Enter C2 (Img): ";
        cin >> y;
        C2.SetImg(y);

        C1.print();
        C2.print();

        cout<<"---------------------------------" <<endl;

        C3 = C1.sum(C2);

        C3.print();

        cout<<"---------------------------------" <<endl;

        C3 = sub(C1,C2);

        C3.print();

        cout<<"---------------------------------" <<endl;

        cout<<"Exit? press (1) else press any key" <<endl;

        ExitFlag = _getch();

        cout<<"---------------------------------" <<endl;

   }while(ExitFlag != '1');

 /*
 C1.SetReal(3);
   C1.SetImg(-4);

   C2.SetReal(1);
   C2.SetImg(-22);

   C1.print();
   C2.print();

   // sum will add C1 and C2

   /* sum is a member function,
        so it have all the data inside C1

        I should tell it how to handle getting an object as input

        I should also tell it to store the result in C3 values ?

        operator overloading ?


   C3 = C1.sum(C2);

   C3.print();
   // the stand alone function will take 2 parameters
   C3 = sub(C1,C2);

   C3.print();
*/


}
