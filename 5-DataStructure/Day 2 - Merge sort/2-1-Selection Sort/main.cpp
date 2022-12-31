#include <iostream>

using namespace std;

/* 1- Selection sort, Basically you find the smallest number in the array on the right side of your current element
                        and you put it in your current element and then move forward */
int IndexOfMinValue(int Arr[], int StartIndex, int EndIndex)
{
    // I think using int Arr[], Creates an array and equats the values? instead of us having
    // to do extra work inside the fn ? test it.

    // Note : using int* Arr does the exact same thing.

    int Index = StartIndex;

    // starting from the index next to THAT element to see if ---> StartIndex+1 < StartIndex ?
    for ( int i = StartIndex+1; i < EndIndex; i++)
    {
        if (Arr[i] < Arr[Index])
        {
            Index = i;
        }
    }

    return Index;
}

void Swap(int& a , int& b )
{
    // passing by reference to be editing the array's values directly, less work.
    int Temp;

    Temp = a;
    a = b;
    b = Temp;
}


void SelectionSort (int Arr[], int size)
{
    int Index; // this stores the index value coming from  IndexOfMinValue

    for (int i = 0; i < size; i++)
    {
        Index = IndexOfMinValue(Arr,i,size);

        Swap(Arr[i],Arr[Index]);
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


    SelectionSort(A,size);

    cout<< "\n=========== Selection Sorted Array ==============\n" <<endl;
    for (int i =0; i < size; i++)
    {
        cout<< A[i] <<" , " ;
    }

    cout<<"\n\n\n\n\n";
    return 0;
}
