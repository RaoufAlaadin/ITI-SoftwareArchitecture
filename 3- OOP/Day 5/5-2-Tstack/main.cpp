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
        delete [] Stk;


//        SNum--;
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


    // to deal with a static attribute.... you need a static fn. :)
    static int GetSNum () {return SNum;}


void View ();


};


template <class MyType>

// for intializing private or public static memebers.

int MyStack <MyType> :: SNum = 0;  // SNum should be redefined , that's why we put int
                            // and we pust MyStack to tell that it's related to that class

template <class MyType>

// Declared in class, but doing the implementation outside of the class
// just to test it.
void MyStack <MyType>::View ()
    {

        for ( int i = 0; i < Tos; i++)
            cout << " \t \t"<< Stk[i] <<endl;

            cout<<endl;

    }




int main()
{

    cout << "The <int> Stack is:" <<endl;

   MyStack <int> S1(7);

   S1.push(5);

   S1.push(3);

   S1.push(8);

   S1.push(15);

   S1.View();




    cout << "The <Char> Stack is:" <<endl;

   MyStack <char> S2(5);

   S2.push('A');
   S2.push('B');
   S2.push('C');
   S2.push('D');

   S2.View();

//MyStack <int> S3, S4;


   // We put it into the public section to be able to call it using the scope operator

//   cout << " Number of objects: "<< MyStack <int>:: GetSNum() <<endl;






}
