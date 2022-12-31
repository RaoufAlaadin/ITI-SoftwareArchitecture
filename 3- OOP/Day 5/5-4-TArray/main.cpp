#include <iostream>

using namespace std;

template <class MyType >

class intArray
{

private:

    MyType *Arr;

    int size;

    // constructor

public:


    intArray (int s = 3)
    {
//         cout<<"intArray ctor \n";
        size = s;
        Arr = new MyType [size] ;
    }


    // copy constructor --- why ?! -- I think because we will have many objects return
    //                              and not everything is going to be return by reference.

    intArray (const intArray &A)
    {

        size = A.size;
        Arr = new MyType [size];

        // after dynamically allocating a new space with a new address.
        // we copy the values from old to new object.
        for ( int i = 0; i < size; i++)
            Arr[i] = A.Arr[i];

//        cout<< "copy cons." <<endl;
    }

    // destructor

    ~intArray()
    {

//        cout<<"destructor"<<endl;

        for (int i= 0; i < size; i++)
        {
            Arr[i] = -1;
        }
        delete [] Arr;
    }


    // you can return by reference here because we are modifying an object that has
    // a scope outside this fn.
    intArray & operator = (const intArray  &A)
    {
        /* our input is the right side.
                A = B --- A.operator = (B)

                http://www.java2s.com/ref/cpp/cpp-operator-overload-array-class-overloads-assignment-operator-and-c.html
        */
        // we are freeing the reciver memory as it's data gonna get over-rided by the right side anyway.
        // and allocating new memory and new size based on the right side to be able to take in
        // all the data stored on the right side and store it in the left side.

        size = A.size;

        delete [] Arr;


        Arr = new MyType [size] ;
        for( int i = 0; i < size; i++)
        {
            Arr[i] = A.Arr[i];
        }

        return *this;
    }

    /* making it return by reference is important to be able to
            1- take the cell value
            2- assign new value to the cell
        we do all of this without needing the getters and setters

    */

   MyType&  operator [] (int index)
   {

       if ( (index >= 0) && (index < size) )
        return Arr[index];
   }


    // DO NOT USE RETURN  BY REF !!! THE C SCOPE IS ONLY INSIDE THE FN.


    // WE NEED TO USE THE COPY CTOR. ... WHICH WILL EXTEND THE LIFE OF THE DATA
    // UNTIL WE MOVE ON ONE LINE AHEAD FROM THE REAL CODE !!!!!!!
    intArray operator + (const intArray &B)
    {
         int new_size = 0;

        if (size > B.size)
            new_size = size;
        else
            new_size = B.size;

//        cout << "size is : " << size << endl;
        intArray C(new_size);

        for (int i = 0; i < size; i++)
               C.Arr[i] = Arr[i] + B.Arr[i];

        return C;

    }

    void SetArrayValue (int index,int value)
    {
        if ( (index >= 0) && (index < size) )
                Arr[index] = value;

    }

    int GetSize()
    {
        return size;
    }

};

int main()
{
    intArray <int> MyA(5);

    // Array A

    cout <<"A Array : " <<endl;

    for(int i = 0; i < MyA.GetSize(); i++)
    {
        MyA[i] = 3 * i;

        cout<< "  " << MyA[i] << endl;

    }

    // Array B

    cout <<"B Array : " <<endl;

    intArray <char> MyB(5);

    for(int i = 0; i < MyB.GetSize(); i++)
    {
        MyB[i] = 65 + i;

        cout<< "  " << MyB[i] << endl;

    }


    // Array C

//   MyC = MyA + MyB ;
//
//     cout <<"C Array : " <<endl;
//
//    for(int i = 0; i < MyC.GetSize(); i++)
//    {
//
//
//        cout<< "  " << MyC[i] << endl;
//
//    }




}
