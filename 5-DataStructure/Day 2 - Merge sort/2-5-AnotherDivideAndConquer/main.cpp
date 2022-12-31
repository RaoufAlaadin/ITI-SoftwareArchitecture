#include <iostream>

using namespace std;

/* 4- Quick sort --  it's like the merge sort in their time complexity

                    BestCase- Randomized numbers. O(n log(n))


                    WorstCase  O(n^2) and this hapens
                    (1) - when the array is already sorted.We would be just wasting our time.

                    (2) - when the partitioning algorithm picks the largest or smallest element
                    as the pivot element every time,

                    So it's best practice to :
                                (a) pick the pivot randomly
                                (b) shuffle the array before sorting.



                    Why Quick sort over Merge?

                    it continusly does the swapping directly to the main Array, so We don't have
                    to create TempArr and use (memory space) like we did in Merge.


*/


 void Swap(int& a , int& b )
        {
            // passing by reference to be editing the array's values directly, less work.
            int Temp;

            Temp = a;
            a = b;
            b = Temp;
        }


int Partition (int Arr [], int Start, int End)
{
    int Pivot = Arr[End];
    int i = Start -1;

    for(int j = Start; j <= (End -1); j++)
    {
        // Case 1- if the value at (j) is smaller than the value at the pivot.
        //          then we increase (i) and swap
        if(Arr[j] < Pivot)
        {

            Swap(Arr[++i],Arr[j]);
        }
    }

    // Final Case :  this will swap the pivot to it's resting place.
    Swap(Arr[++i],Arr[End]);


    // At last---> We will retrun the location of the latest pivot
    // so we can divide around it.
    return i;

}

void QuickSort( int Arr [], int Start, int End)
{
    // base case
    // it means our pointer reached
    if (End <= Start) return;

        // pivot postion change by each partition ,
        //that's why we need to re-calculate it first
        // before inserting it into the QuickSort

    int pivot = Partition(Arr,Start,End);

    // we create a quick sort around our pivot, because it reached it's resting place
    // that's why the left side ends before our pivot
    // and the right side starts after our pivot to the end of the array
    QuickSort(Arr,Start,pivot-1);
    QuickSort(Arr,pivot+1,End);
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


   QuickSort(A,0, size-1);

    cout<< "\n=========== Quick Sorted Array  ==============\n" <<endl;
    for (int i =0; i < size; i++)
    {
        cout<< A[i] <<" , " ;
    }

    cout<<"\n\n\n\n\n";



    return 0;
}
