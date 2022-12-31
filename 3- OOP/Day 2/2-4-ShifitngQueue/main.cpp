#include <iostream>
#include <conio.h>

using namespace std;





        // task 2-4- Shifting Queue

class Queue
{
   int *Q; // 8 bytes for a pointer on 64bit machines
   int Tail;    // 4 bytes
                // total is ----> 12 bytes for each object.

    int size; // created to store the value of (L), to be available to the rest of the functions.


public:

    Queue(int L)
    {

        cout<<"Queue ctor \n";
        Tail = -1;

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


    return (Tail == (size -1)) ;

    }

    /* I could just return the evaluation on the statement

         if (Tail == 5)
            return 1;
        else
            return 0;

         */

    int IsEmpty() { return (Tail == -1);}

    void EnQ(int n)
    {
        // Always EnQ from the Back !!!!!!

        if (!IsFull())
        {
            Q[++Tail] = n;
            cout<<"The number ( "<< n <<" ) got registered in the Q"<<endl;
        }
        else{
            cout<<"The Q is full !! " << endl;
        }



    }

    // EnQ should give us the top value in the Queue.
    // last added
    void DeQ()
    {
        // Always DeQ from the Front !!!!

        if(!IsEmpty())
        {
            cout<<"The number in-front is:" << Q[0] << endl;

             // now we need to shift everything.

             for(int i = 0; i < size -1; i++)
             {

                 Q[i] = Q[i+1];
             }

             // note:the Tail should be also moved once.
             // to keep pointing at the last element.
             Tail--;

        }
        else{
            cout<<"Q is Empty" <<endl;
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
    int i = 0;
    int count  = 0 ;
     if (  Tail == -1)
        {
           cout<<"  Q is empty" <<endl;

        }

        else
        {
            while (i != (Tail+1))
            {
                cout<< Q[i] <<endl;
                count++;
                i++;
            }

//            cout<< Q[i] <<endl;

            // Tail +1 to let it print the value at Tail

            cout <<" The number of elements are : " << count << endl << endl;
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
