#include <iostream>

using namespace std;

/* 2- Bubble sort (Asc), We make an iteration for each element we have
                        and in Each iteration we compare all the adjacent elements
                        moving the smaller elements to the left side
                        and moving forward with the bigger element until reaching the end of the array
                        when starting again we exclude the last element as it will be sorted.

                        if it gets a sorted array, it takes way less time because of the
                                                bool sorted;


*/

  void Swap(int& a , int& b )
        {
            // passing by reference to be editing the array's values directly, less work.
            int Temp;

            Temp = a;
            a = b;
            b = Temp;
        }

void BubbleSort(int* Arr, int size)
{
    bool Sorted = true ;

    // size - i - 1    ===>   -i to remove the number of sorted elements by that iteration
    //                        -1 Because we are comparing with j+1 , so th (-1) will prevent us from exceeding the array.

    for (int i = 0; i < size; i++ )
    {
        Sorted = true;

        for( int j = 0; j < size- i - 1; j++ )
        {
            // if it finds my current is bigger than the next, the swap
            // this will push the biggest number to the end.
            if ( Arr[j] > Arr[j+1])
            {
                Swap(Arr[j], Arr[j+1]);

                /* if we get into this if condition.
                 this means the array is still not sorted.
                we check that for every iteration to reduce the calcualtion time

                        This is one of the benfits over Merge sort.
                */

                Sorted = false;
            }

        }

        if (Sorted) return; // gets us out of the main for loop, no more iterations.
                            // our job is done.
    }
}
int main()
{
//    cout << "Hello world!" << endl;

 int A[] = {6,8,2,1,7,9,10,5};

    int size = sizeof(A)/sizeof(A[0]);


     cout<< "\n=========== Original Array ==============\n" <<endl;
    for (int i =0; i < size; i++)
    {
        cout<< A[i] <<" , ";
    }


    BubbleSort(A,size);

    cout<< "\n=========== Bubble Sorted Array Ascending ==============\n" <<endl;
    for (int i =0; i < size; i++)
    {
        cout<< A[i] <<" , " ;
    }

    cout<<"\n\n\n\n\n";



    return 0;
}
