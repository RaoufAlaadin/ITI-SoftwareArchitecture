#include <iostream>

using namespace std;

    /* D2-OOP- Topics:
            1- Revision on Complex numbers task.
            2-
            */



class complex
{
    int Real, Img;

public:

       // Constructors

     complex (int R, int I)
    {
        cout<<"ctor 01" <<endl;
        Real = R;
        Img = I ;
    }

    complex (int n)
    {
        cout<<"ctor 02" <<endl;
        Real = Img = n;
    }

    // destructor

    ~complex()
    {
        cout<<"Destructor";
    }

    int GetReal() {return Real;}

    int GetImg() {return Img;}

    /* for the compiler the methods only exist once
        and it's in this form  -----    void SetReal( complex *this , int R )
                                            {    this -> real = R;        }
                                */
    void SetReal (int R)
    {
        Real = R;

        /* by printing out the this, we get different address for each call.
           because it's a different object.

            this is really helpful in tracing :) !

        */

        cout<< this <<endl;
    }
    void SetImg(int I) { Img = I;}

    complex sum (complex C )
    {
        complex Result(2) ;

         Result.Real = Real + C.Real;
         Result.Img = Img + C.Img;

         return Result;

    }


};

// last in ... first out.


class MyStack
{
   int *Stk; // 8 bytes for a pointer on 64bit machines
   int Tos;    // 4 bytes
                // total is ----> 12 bytes for each object.

    int size; // created to store the value of (L), to be available to the rest of the functions.


public:

    MyStack(int L)
    {

        cout<<"Stack ctor \n";
        Tos = 0;
        size = L;
        // this how you dynamically allocate memory for an array in c++

        Stk = new int[size]; // memory in heap will be (int * size) byte

        /* int *p_scalar = new int(5); //allocates an integer, set to 5. (same syntax as constructors)
            int *p_array = new int[5];  //allocates an array of 5 adjacent integers. (undefined values)*/

    }

    ~MyStack()
    {
        cout<<"destructor"<<endl;

        /*  destuctor is the best place to write a clean-up code.
        that's why we use it to free a dynamically allocated memory at the end of a program .
         */
        delete [] Stk; // we have to add the [] to show that it's an array.
                        // for single element we would have written ----- delete Stk;
    }

    int IsFull()  { return (Tos == size) ;}

    /* I could just return the evaluation on the statement

         if (Tos == 5)
            return 1;
        else
            return 0;

         */

    IsEmpty() { return Tos ==0;}

    void Push(int n)
    {
        if (!IsFull()) //  this is the same is Isfull() == false
        {
            /* NOTE: Tos counting starts from 1 unlike array index starts from 0
                    so note that this mean tos is always pointing at the next empty space
                        so we store at the current tos and then increases it to point to the next empty space. */
            Stk[Tos++] = n;

            //This line has post-increament, so it will use the old value for this line
            // then increase the Tos.
        }
        else{cout<<"Stack is full !! " <<endl; }

    }

    // pop should give us the top value in the stack.
    // last added
    int Pop()
    {
        if (!IsEmpty())
        {
            /* Here we decrease the Tos first, to point to a spot that has value.
                We use that value, and consider that spot empty in our eyes to store a new value.

                Despite it still has the value we took, but we will just override it with whatever
                push() gives us.
            */
            return Stk[--Tos];

        }
        else{
                cout<<"Stack is Empty" << endl;
                // we have to put a return statement for the else, as it's considered a path.
                return 1;

        }
    }



};




int main()
{

    complex CA(1,2), CB (3,4);

    CA.SetReal(5);
    CB.SetReal(4);

/* complex c1(1,2);

 complex c2(5);

 complex c3(5);*/


/* MyStack S1(4);

 S1.Push(7);
 S1.Push(8);
 S1.Push(9);

cout << S1.Pop() << endl;
 S1.Push(13);
cout << S1.Pop() << endl;*/

}
