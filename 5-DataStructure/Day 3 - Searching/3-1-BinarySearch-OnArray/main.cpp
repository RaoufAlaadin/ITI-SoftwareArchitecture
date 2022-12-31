#include <iostream>

using namespace std;





/*          Low ==> starting index (set as 0 as the default input)
            High ==> Last index ( which is the same as:  size -1)
    */
int BinarySearch (int* Arr, int Low, int High, int Value)
{
    /* iterative is faster than recursive, but Recursion is easier to be written and more clean*/

//    cout<< "BSearch \n";

    if(Low <= High)
    {
        int Mid = (Low + High)/2;

        if (Value == Arr[Mid])
            return Mid;
        else if (Arr[Mid] > Value) // go left
            // for left, Low will always be the same, but the the high will be different.
            return BinarySearch(Arr,Low,Mid-1,Value);

            // could be writen just else... with no conditions.
        else if (Arr[Mid] < Value)// go right
            return BinarySearch(Arr,Mid+1,High,Value);
    }

    return -1;

}


// binary search using ---> Loops


int BinarySearch2(int* Arr, int size, int Value)
{
    int Low = 0 , High = size -1;

    while (High >= Low)
    {
        int Mid = (Low + High)/2;

        if (Arr[Mid] == Value)
            return Mid;

        else if ( Arr[Mid] > Value) // go Left, Low would be always the same.
            High = Mid -1;
        else if (Arr[Mid] < Value) // Go Right --->  High would be always the same
            Low = Mid + 1;
    }

    return -1;

}





int main()
{
//    cout << "Hello world!" << endl;

    int A[] = {6,8,2,1,7,9,10,5};

    int size = sizeof(A)/sizeof(A[0]);


     cout<< "\n=========== Original Array ==============\n" <<endl;
    for (int i =0; i < size; i++)
    {
        cout<< " Element no. ("<<i <<") is : "<< A[i] <<endl;
    }




    cout<< "\n=========== Target Value index is ==============\n" <<endl;


    cout<< "\n=========== Using Recursion ==============\n" <<endl;
    // 1- Recursive

   cout<<" Targeted Number is 9 \n";


    cout<<"index is: "<< BinarySearch(A,0,size-1,9) <<endl;

    cout<< "\n=========== Using For Loops ==============\n" <<endl;

    // 2- For loops

     cout<<" Targeted Number is 60 \n";

    cout<<"index is: "<< BinarySearch2(A,size,60) <<endl;
        // -1 means not found

    cout<<"\n\n\n\n\n";
    return 0;
}
