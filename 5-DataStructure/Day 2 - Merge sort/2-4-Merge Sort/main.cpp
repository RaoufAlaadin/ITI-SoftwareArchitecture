#include <iostream>

using namespace std;

/* 3- merge sort -- the selection sort is nice but it's O(n^2)
                    but if we break the array into small parts using recursion, it becomes n log(n)
                    which is way better....
                    We call that merge sort.
*/

void Merge(int* Arr, int LFirst,int LLast, int RFirst, int RLast)
{
    int size = (RLast - LFirst) +1 ;

//    int size = 10 ;
    int Index = 0;
    int SaveStart = LFirst;

    int* TempArr = new int [size];

    // Case 1- if both array still has elements left (General Case)
    while ( (LFirst <= LLast) && (RFirst <= RLast))
    {
        if (Arr[LFirst] < Arr[RFirst])
        {
            TempArr [Index++] = Arr[LFirst++];
        }
        else
        {
            TempArr [Index++] = Arr[RFirst++];
        }
    }

    // Case 2- Left side still has elements Lfirst != LLast
    while(LFirst <= LLast)
    {
        TempArr[Index++] = Arr[LFirst++];
    }
    // Case 3- Right side still has elements Rfirst != RLast

    while(RFirst <= RLast)
    {
        TempArr[Index++] = Arr[RFirst++];
    }

    // Copying the values to the orginal array

    for ( int i = SaveStart; i <= RLast; i++)
    {
        /* (i-SaveStart) really important part for reducing the size of array created each time.
            it will adjust it's value for any case to start the counter from 0
            Ex:         i = 5  --- 5-5 = 0              i = 0  ---- 0-0 = 0
                        i =6   -- 6-5 = 1               i = 1 ----- 1-0 = 1

        */
        Arr[i] = TempArr[i - SaveStart];
    }

}


                // Main Merge sorting fn.

void MergeSort (int* Arr, int First, int Last)
{
    /*                    if true >> recursion will happen inside the if
                         if False >> it becomes the base case and the recursion is returened
                         as it doesn't have any other path.
                      */
    if (First < Last)
    {
        // using int will return only the whole number, which is useful.
        int Middle = (First + Last)/2;

        MergeSort (Arr,First,Middle); // left side
        MergeSort (Arr,Middle+1,Last); // Right side

        Merge(Arr,First,Middle,Middle+1,Last);





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


   MergeSort(A,0, size-1);

    cout<< "\n=========== Merge Sorted Array  ==============\n" <<endl;
    for (int i =0; i < size; i++)
    {
        cout<< A[i] <<" , " ;
    }

    cout<<"\n\n\n\n\n";



    return 0;
}
