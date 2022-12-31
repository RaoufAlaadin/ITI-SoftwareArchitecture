#include <iostream>

using namespace std;


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


int Peak()
{
     if (!IsEmpty())
        {
            /* Here we decrease the Tos first, to point to a spot that has value.
                We use that value, and consider that spot empty in our eyes to store a new value.

                Despite it still has the value we took, but we will just override it with whatever
                push() gives us.
            */
            return Stk[Tos-1];

        }
        else{
                cout<<"Stack is Empty" << endl;
                // we have to put a return statement for the else, as it's considered a path.
                return 1;

        }

}

void GetCount()
{
    cout<<"Number of elements we have is :" << Tos << endl;

    // if we had it Return type as int We would have needed to
    // set a return statement or else it would return garbage.

}

};



int main()
{
     MyStack S1(4);

 S1.Push(7);
 S1.Push(8);
 S1.Push(9);

//cout << S1.Peak() << endl;
//S1.GetCount();
//
//cout << S1.Pop() << endl;
//cout << S1.Peak() << endl;
//
// S1.GetCount();
// S1.Push(13);

S1.Pop();
//S1.Pop();

cout << S1.Pop() << endl;


cout << S1.Peak() << endl;




    return 0;
}
