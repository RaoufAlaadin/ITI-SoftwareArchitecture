#include <iostream>
#include <conio.h>

using namespace std;





        // task 2-3- Circular Queue

class Queue
{
   int *Q; // 8 bytes for a pointer on 64bit machines
   int Tail, Head;    // 4 bytes
                // total is ----> 12 bytes for each object.

    int size; // created to store the value of (L), to be available to the rest of the functions.


public:

    Queue(int L)
    {

        cout<<"Queue ctor \n";
        Tail = -1;
        Head = -1;
        size = L;
        // this how you dynamically allocate memory for an array in c++

        Q = new int[size]; // memory in heap will be (int * size) byte

        /* int *p_scalar = new int(5); //allocates an integer, set to 5. (same syntax as constructors)
            int *p_array = new int[5];  //allocates an array of 5 adjacent integers. (undefined values)*/

    }

    ~Queue()
    {
        cout<<"destructor"<<endl;

        /*  destuctor is the best place to write a clean-up code.
        that's why we use it to free a dynamically allocated memory at the end of a program .
         */
        delete [] Q; // we have to add the [] to show that it's an array.
                        // for single element we would have written ----- delete Q;
    }

    int IsFull()
    {


    return (((Tail + 1) % size == Head)) ;

    }

    /* I could just return the evaluation on the statement

         if (Tail == 5)
            return 1;
        else
            return 0;

         */

    IsEmpty() { return Tail == Head;}

    void EnQ(int n)
    {
        // Always EnQ from the Back !!!!!!

        /* We aklways put the special cases in the if's
            and then the general case in the else statement */
        if ( Head == -1 && Tail == -1)
        {
            Head = Tail = 0;
            Q[Tail] = n;
        }
        else if( IsFull())
        {
            cout<< "Queue is full" << endl;
        }
        else{

            // We can't use ++T , because We want it to loop !!

            // we are pushing the tail to an empty space .... to then add a value to that space using the next line !!!!!
            Tail = (Tail+1) % size ;
            // this will increase T, but it reaches the T = 4 which is size = 5  .. then  ...
            // Ex.   T = 4+1 % 5 --- gives T = 0 ---> which will return the pointer to the start again.

            Q[Tail] = n;
        }

    }

    // EnQ should give us the top value in the Queue.
    // last added
    void DeQ()
    {
        // Always DeQ from the Front !!!!



         if ( Head == -1 && Tail == -1)
        {
           cout<<"  Q is empty" <<endl;

        }
        else if (IsEmpty())
            {
                // it will become empty after taking that last one element

            /* We Have the case of Having only one element
                so both head and tail point to it.

                but after DeQ using Head .. the Queue will be empty

                So we reset the pointers back to -1
                */

                cout<< "The element in-front is: " << Q[Head]<< endl;

                // After taking the value, We reset them both.
                Head = Tail = -1;


        }
        else{
             // we are not adding anything, we just the element in-front

             cout<< "The element in-front is: " << Q[Head]<< endl;

             // but then We need to put the Head on the next element in-line
             // Taking in-care that we can't use Head++ because of the circular concept.

             Head = (Head +1) % size ;

             // the modulus part is only useful when u are at the end of the array
             // else you could say we have (Head = Head +1 ) most of the time.
             // which is the same as Head++

        }
    }


//int Peak()
//{
//     if (!IsEmpty())
//        {
//            /* Here we decrease the Tail first, to point to a spot that has value.
//                We use that value, and consider that spot empty in our eyes to store a new value.
//
//                Despite it still has the value we took, but we will just override it with whatever
//                EnQ() gives us.
//            */
//            return Q[Tail-1];
//
//        }
//        else{
//                cout<<"Queue is Empty" << endl;
//                // we have to put a return statement for the else, as it's considered a path.
//                return 1;
//
//        }
//
//}

void GetCount()
{
    int i  = Head;
    int count  = 0 ;
     if ( Head == -1 && Tail == -1)
        {
           cout<<"  Q is empty" <<endl;

        }

        else
        {
            while (i != Tail)
            {
                cout<< Q[i] <<endl;
                count++;

                i = (i+1) % size;
            }

            cout<< Q[i] <<endl;

            // Tail +1 to let it print the value at Tail

            cout <<" The number of elements are : " << count+1 << endl << endl;
        }

}

};



int main()
{
    int x, k = 0;
    char ch;
    int ExitFlag = 0;
    cout<< "Enter the size of the Q: " ;
    cin>> x;

     Queue Q1(x);



     do {
            cout<<  " Press Q to EnQ ---- Press D to DeQ --- Press C to to display the Queue -- e to exit" << endl ;
            cin >> ch;

            switch(ch)
                {
                case 'q':
                    Q1.EnQ(k);
            // note that: k is increased even if the Q is full
            // that's why you get weird numbers.
                    k++;
                    break;
                case 'd':
                    Q1.DeQ();
                    break;
                case 'c':
                    Q1.GetCount();
                    break;

                case 'e' :
                    exit(1);
                    break;
                }



     }while (ExitFlag != 1);










    return 0;
}
