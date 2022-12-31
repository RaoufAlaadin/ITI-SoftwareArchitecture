#include <iostream>
//#include <bits/stdc++.h>
#include <string>
#include <cstring>


using namespace std;

    // 4-1 - Complex numbers Operator overloading.



class complex
{
private:
    int Real;
    int Img;



public:

    // Constructors

     complex (int R, int I)
    {
//        cout<<"ctor 01" <<endl;
//        cout<< this <<endl<<endl;
        Real = R;
        Img = I ;


    }

    complex (int n)
    {
//        cout<<"ctor 02" <<endl;
//        cout<< this <<endl<<endl;
        Real = Img = n;
    }

    complex ()
    {
//        cout<<"ctor 03" <<endl;
//        cout<< this <<endl<<endl;
        Real = Img = 0;
    }

    // destructor

    ~complex()
    {
//        cout<<"Destructor" <<endl;
//        cout<< this <<endl<<endl;
    }

    void SetReal (int R) { Real = R;}
    void SetImg (int I) {Img = I;}

    int GetReal () const { return Real;}
    int GetImg () const {return Img;}

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

    /* 1-  (-) operator */

    complex operator - (const complex &C)
        {
            // C3 = C1 (this)-- the fn. is member + C2 (C)--input
            complex Result;

            Result.Real = Real - C.Real;
            Result.Img = Img - C.Img ;

            return Result;

        }

    /* 2- (-) operator while calling an int  */

        // int - object

        // this - input
        complex operator - (int R)
        {
            // C3 = C1 (this)-- the fn. is member + C2 (C)--input
            complex Result;

            Result.Real = Real - R;
            Result.Img = Img ;

            return Result;

        }

        /* 4- (-=) input as object */

        // C1 -= C2 is same as C1 = C1 - C2;

        complex& operator -= (const complex &C)
        {
            Real = Real - C.Real; // same as --->  Real -= C.Real ;
            Img = Img - C.Img;

            /* NOTE:  1) this ---- address of complex C1 , so the compiler finds it as int.
                        *this  --- is the complex object itself.

                    2) We only return by reference ----> to save on memory from the (temp object) that was going
                        to be returend then equaled to C1 by the complier.
                    */
            return *this;
        }

        /* 5- (-=) input as integer */

        complex& operator -= (int R)
        {
            Real = Real - R;
            Img = Img ;

            /* NOTE:  1) this ---- address of complex C1 , so the compiler finds it as int.
                        *this  --- is the complex object itself.

                    2) We only return by reference ----> to save on memory from the (temp object) that was going
                        to be returend then equaled to C1 by the complier.
                    */
            return *this;
        }


        /* 6-  (-=) input an integer as previously but ..
                    it's going to be a variable.
                    as we will store the result of subtracting C1 real part from it.
                    */

        /* 7- (--) Pre-increament */

         complex operator -- ()
        {
            Real --;
            return *this;
        }

        /* 8- (--) Post-increament */

         complex operator -- (int)
        {
            complex temp (Real,Img);

            Real --;
            return temp;
        }

        /* NOW ------- We go into comparison operators............*/

        /* 9- 10 - (==) (!=) */

        bool operator == (const complex &C)
        {
            return ((Real == C.Real)&& (Img == C.Img));
        }

        bool operator != (const complex &C)
        {
            return ((Real != C.Real) || (Img != C.Img));
        }


        /* 11- 12-   C1 >C2 ,,,,, C1 >= C2     ---- C < C2 ,,,,C1 <= C2 */

        bool operator > (const complex &C)
        {
            if ( Real == C.Real)
            {
               return  ( (Img > C.Img));
            }
            else {
               return( Real > C.Real);
            }
        }

         bool operator >= (const complex &C)
       {
            if ( Real == C.Real)
            {
               return  ( (Img >= C.Img));
            }
            else {
                return( Real >= C.Real);
            }
        }

         bool operator < (const complex &C)
       {
            if ( Real == C.Real)
            {
               return  ( (Img < C.Img));
            }
            else {
                return( Real < C.Real);
            }
        }

         bool operator <= (const complex &C)
        {
           {
            if ( Real == C.Real)
            {
               return  ( (Img <= C.Img));
            }
            else {
                return( Real <= C.Real);
            }
        }
        }

        /* 13- (int) C1 */

         operator int ()
        {
            // it acts as a member of the complex object between ()
            // takes it's real value and returns it.

            return Real;
        }


//          14- (char*) C1

          operator char* ()
        {
            // it acts as a member of the complex object between ()
            // takes it's real value and returns it.

        string s=to_string(Real);
        s+= ""+ to_string(Img)+'i';

/*      Writing it like that doesn't work... to_string says that it wants ; after it's written.

        string s=to_string(Real) ""+ to_string(Img)+'i';
*/

        int n = s.length();


        char *arr = new char [n+1];  // +1 for null char '\0'

        /* .c_str()  returns a pointer to a null terminated sequance of char

                https://cplusplus.com/reference/string/string/c_str/

            it basically transforms our string into an  array char..
            but why can't we return that? because it's on the stack and it will get deallocated as soon as
            the fn. ends

            so we need to copy them to (arr), but strcpy only accepts pointer to an array or char

            that's why we used .c_str().
        */

               strcpy(arr,s.c_str());


               return arr;


               /* Method (2) for getting a char array from a string.

               there is many ways here.

               https://www.geeksforgeeks.org/convert-string-char-array-cpp/


               for (int i = 0; i < n; i++)
               {
                  arr[i] = s[i];
               }
                arr[n] = '\0';

                */


        }


};


// we have to use a stand alone for C3 = 7 - C3;
// you  can't be-friend this fn. to the class, so we use getters and setters.

// as the left side cannot be used, we will put it's values as an input also.
complex operator - (int number, const complex &R)
{

    /* NOTE !!! :  I had to put const after GetReal and GetImg to be able to put const when refrencing R

            because the compiler thinks the functions are going to shift our data somehow ?!

            the reason is still not clear to me.... Check the StackoverFlow Post

            https://stackoverflow.com/questions/5973427/error-passing-xxx-as-this-argument-of-xxx-discards-qualifiers
    */
    complex Result (number - R.GetReal() , R.GetImg());

    return Result;
}



int operator -= (int a, const complex &R)    // (int a, const complex &R)   (const complex &R, int a)
{
    a = a - R.GetReal() ;

    return a;

}

int main()
{
    complex C1(5,2), C2(3,4), C3;

    cout<<" values in Object C1" <<endl;

    C1.print();

    cout<<" \n values in Object C2" <<endl;

    C2.print();

    cout<< "--------------------------" <<endl;

    /* 1-  (-) operator */

    cout<<" \n  1- (-) operator   C3 = C1 - C2 " <<endl;
    C3 = C1 - C2 ;
    C3.print();


    cout<< "--------------------------" <<endl;

    //////////////////////////////////////////////


     /* 2- (-) operator while calling an int  */

         // this - input

    cout<<" \n  2- (-) operator  C3 = 7 - C2 " <<endl;

    C3 = 7 - C2;

    C3.print();

    cout<< "--------------------------" <<endl;

    ///////////////////////////////////////

    cout<<" \n  3- (-) operator  C3 = C2 - 7 " <<endl;

    C3 = C2 - 7;

    C3.print();

    cout<< "--------------------------" <<endl;

    /////////////////////////////////////////

    cout<<" \n  4- (-=) operator  C1 -= C2 " <<endl;

    C1 -= C2;

    C1.print();

    cout<< "--------------------------" <<endl;

    ///////////////////////////////////////////////////

    cout<<" Note: **always check the latest value for C1, as it gets modified by each calculation" <<endl;

    cout<<" \n  5- (-=) operator  C1 -= 7 " <<endl;

    C1 -= 7;

    C1.print();

    cout<< "--------------------------" <<endl;

    //////////////////////////////////////////////////

    cout<<" \n  6- (-=) operator  7 -= C1 " <<endl;

    cout<<" Note: This time we input an  int variable and store the result in that int variable again. " <<endl;

    cout<<"\t \t \t it's created as a standalone fn." <<endl;

    /* IMPORTANT NOTE:
        As we already have used -= with an int once inside the class
        so making it a standalone would require us more inputs,
        therefore we get a different signture

    */

    cout << "The variable Result equals:  "<< (7 -= C1) <<endl;

    cout<< "--------------------------" <<endl;

   //////////////////////////////////////////////////

    cout<<" \n  7- (--) operator PRE --C1 " <<endl;

    --C1;

    C1.print();

    cout<< "--------------------------" <<endl;

    ////////////////////////////////////////////////////

     cout<<" \n  8- (--) operator  POST C1-- " <<endl;

     cout<<" \n  Value is holded while on the same line " <<endl;

    (C1--).print();

    cout<<" \n  gets increased if C1 is called later on  " <<endl;

    C1.print();

    cout<< "--------------------------" <<endl;


    /////////////////////////////////////

     cout<<" \n  9-  -10  (==) (!=)  (C1 == C2)  --- (C1 != C2)  " <<endl;


        complex C4 (20,3) ,C5 (5,6);

     cout<<" \n values in Object C4" <<endl;

    C4.print();

    cout<<" \n values in Object C5" <<endl;

    C5.print();



    if (C4 == C5)
    {
        cout << " \n EQ" << endl;
    }
    if( C4 != C5)
    {
        cout << "\n                     NEQ" << endl;
    }

    cout<< "--------------------------" <<endl;

     /////////////////////////////////////

     cout<<" \n  11-  -12  (<) (>) (>=) (<=)  " <<endl;

     cout<<" \n values in Object C4" <<endl;

    C4.print();

    cout<<" \n values in Object C5" <<endl;

    C5.print();


    if ( C4 > C5 )
    {
        cout << "\n C4  is Greater than C5" << endl;
    }
   else
    {

        cout << "\n C4 is smaller than C5" <<endl;
    }




    cout<< "--------------------------" <<endl;


    cout<<" \n 13-   (int) C1 \n " <<endl;



    cout << "Type Casting (int) is :  "<< (int) C1 << endl;


    cout<< "--------------------------" <<endl;


    cout<<" \n 14-   (char*) C1 \n " <<endl;


       cout << "our char array is: " << (char*)C1 << endl;

}
