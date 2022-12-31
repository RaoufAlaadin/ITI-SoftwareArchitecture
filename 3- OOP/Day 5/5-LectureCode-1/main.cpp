#include <iostream>

using namespace std;

template <class MyType >

class MyStack
{
    MyType *Stk; //Object Attribute

    MyType Tos, size; //Object Attribute


  static int SNum; //Class Attribute


public:



    MyStack (int L = 5)
    {

//        this ->SNum = 0;

        Tos = 0;
        size = L;
        Stk = new MyType [size];

        SNum++;
    }

    MyStack ( const MyStack &Olds)
    {
        Tos = Olds.Tos;
        size = Olds.size;
        Stk = new int [size];
        for(int i = 0; i < Tos; i++)
        {
            Stk[i] = Olds.Stk[i];
        }

        SNum++;

    }

    ~MyStack()
    {
        /* I am not sure if the stk we will be taking numbers
            that's why we hide this part for now.   */

//        for(int i = 0; i < Tos; i++)
//            Stk[i] = -1;

        delete [] Stk;
        SNum--;
    }


    MyStack& operator = ( const MyStack &R)
    {
        delete [] Stk;
        Tos = R.Tos;
        size = R.size;

        Stk = new MyType (size);
        for( int i = 0; i < Tos; i++)
            Stk[i] = R.Stk[i];

        return *this;
    }

    bool IsFull () {return Tos == size;}
    bool IsEmpty() { return Tos == 0;}

    MyType pop()
    {
        if ( !IsEmpty())
        {
            return Stk [ --Tos];
        }
    }

    void push(MyType n)
    {
        if (!IsFull())
            Stk[Tos++] = n;
    }

    void View ();


     // does function depend on object state ? We mean the attributes per object.
    // it does does not depend.

    // 1- Then we should make the function STATIC !!!

    // 2- also we need it in case of needing to access class data without creating an object.


    static int GetSNum ()

    {
        // Tos++ ; size --;
        // WE CAN'T Access ***directly*** the Object attributes.
        // as the static function does not have (this.)

        return SNum;

    }


    static void DemoFun (MyStack &S)
    {
        MyStack R(4);

        R.Tos++; // ? ---- it can do this

        S.size = 15; // ? it can do this

        /* as the static fn. can't access data directly like saying Tos = 5
            but it can in-directly by passing the reference like above.

        */
    }

    /* Also due to this we can use The Stand alone fn. inside the class.*/

    /*  static complex sum ( complex L , complex R )

        {           complex Result ;

            Result.Real = L.Real + R.Real;
            Result.Img = L.Img + R.Img;

        }
         */


};


template <class MyType>

// for intializing private or public static memebers.

int MyStack <MyType> :: SNum = 0;  // SNum should be redefined , that's why we put int
                            // and we pust MyStack to tell that it's related to that class

template <class MyType>

void MyStack <MyType>::View ()
    {
        for ( int i = 0; i < Tos; i++)
            cout << Stk[i] << " , ";

            cout<<endl;

    }




int main()
{
    // SNum is the first variable to exist in the code.

     cout << " Number of objects: "<< MyStack <int> :: GetSNum() <<endl;


     // note if we want a char. !!!!!


     MyStack <char> cStack (10);
     cout << "MyStack <char> object number = " << MyStack <char> :: GetSNum() << endl;



   MyStack <int> S1(7);

   S1.push(5);

   S1.push(3);

   S1.push(50);

   S1.View();

   MyStack <int> S2(5);

   S2.push('A');
   S2.push('B');
   S2.push('C');
   S2.push('D');

   S2.View();


   // We put it into the public section to be able to call it using the scope operator

   cout << " Number of objects: "<< MyStack <int>:: GetSNum() <<endl;

   MyStack <int> *Ptr;

   Ptr = new MyStack <int> (8);

   cout << " Number of objects: "<< MyStack <int>:: GetSNum() <<endl;

   delete Ptr;

   cout << " Number of objects: "<< MyStack<int> :: GetSNum() <<endl;


}
