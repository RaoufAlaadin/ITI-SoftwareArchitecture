#include <iostream>

using namespace std;


class MyStack
{

//    public:
   int *Stk; // 8 bytes for a pointer on 64bit machines
   int Tos;    // 4 bytes
                // total is ----> 12 bytes for each object.

    int size; // created to store the value of (L), to be available to the rest of the functions.


public:

    // copy constructor

    MyStack (MyStack &S)
    {

        Tos = S.Tos;
        size = S.size ;

        // doesn't copy the address of pointer.. and instead allocates a new space.
        Stk = new int [size];

        for (int i = 0; i < Tos; i++)
        {
            Stk[i] = S.Stk[i];
        }

//        cout<< "copy cons." <<endl;
    }

    //Constructors

    MyStack(int L = 5 )
    {

//        cout<<"Stack ctor \n";
        Tos = 0;
        size = L;

        Stk = new int[size]; // memory in heap will be (int * size) byte


    }

    ~MyStack()
    {
//        cout<<"destructor"<<endl;

        for (int i= 0; i < Tos; i++)
        {
            Stk[i] = -1;
        }

        delete [] Stk; // we have to add the [] to show that it's an array.
                        // for single element we would have written ----- delete Stk;


    }

    int IsFull()  { return (Tos == size) ;}

    IsEmpty() { return Tos ==0;}

    void Push(int n)
    {
        if (!IsFull()) //  this is the same is Isfull() == false
        {
            Stk[Tos++] = n;

        }
        else{cout<<"Stack is full !! " <<endl; }

    }


    int Pop()
    {
        if (!IsEmpty())
        {

            return Stk[--Tos];

        }
        else{
                cout<<"Stack is Empty" << endl;

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

////////////////////////////////////////////////////////////////////

// operator overloading.

        // 1- []
      int & operator [] (int index)
        {

               if ( (index >= 0) && (index < size) )
                return Stk[index];
        }


        // 2- (+)
    MyStack operator + (const MyStack &B)
        {
            int i = 0 ;

             MyStack C ( size + B.size );

             C.Tos = Tos + B.Tos;

            for ( i = 0; i < Tos; i++)
                {
                   C.Stk[i] = Stk[i];

                }

            for (int k = 0; k < B.Tos; k++)

                   {
                       C.Stk[i] = B.Stk[k];
                       i++;
                   }

            return C;

        }

        // 3-  (=)
     MyStack & operator = (const MyStack  &A)
        {
        /* our input is the right side.
                A = B --- A.operator = (B)

                http://www.java2s.com/ref/cpp/cpp-operator-overload-Stkay-class-overloads-assignment-operator-and-c.html
        */
        // we are freeing the reciver memory as it's data gonna get over-rided by the right side anyway.
        // and allocating new memory and new size based on the right side to be able to take in
        // all the data stored on the right side and store it in the left side.

            delete [] Stk;
            size = A.size;
            Tos = A.Tos;

            Stk = new int [size] ;
            for( int i = 0; i < size; i++)
            {
                Stk[i] = A.Stk[i];
            }

            return *this;
        }





friend void viewContent ( MyStack &S);

};


// stand alone fn. that has been friended.
void viewContent (MyStack &S)
{
    for(int i = 0; i < S.Tos; i++)
    {
        cout << "number" << i << " : " << S.Stk[i] <<endl;
    }
}



int main()
{
       MyStack S1(4), S2(3), S3;

cout<<"S1 Values " <<endl;

 S1.Push(1);
 S1.Push(2);
 S1.Push(3);



viewContent(S1);


cout << "-----------------------------" <<endl;

 cout<<"S2 Values " <<endl;
    S2.Push(4);
    S2.Push(5);


viewContent(S2);

cout << "-----------------------------" <<endl;

cout<<"S3 Values " <<endl;

    S3 = S1 + S2;


    viewContent(S3);


    return 0;
}
