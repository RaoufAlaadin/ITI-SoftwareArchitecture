#include <iostream>

using namespace std;


/* General notes on Second half of the Lecutre:

        1- inserting a Node using
                a- Recursive Case
                    3:21 -- yousef's case

                b- 2 pointers

        2- searching

        3- deleting a node
                a-  last child
                b-  deleting a root ? the problem here is which to choose.
                */

int SearchArray ( int* Arr,int size, int Value)
{
   /* for(int i = 0; i < size && (Arr[i] < Value) , i++)
    {
        // (Arr[i] < Value) this to reduce time as it won't loop if the value is bigger ?
        if (Arr[i] == value)
            return i;
    }

        return -1;*/


}

/*          Low ==> starting index (set as 0 as the default input)
            High ==> Last index ( which is the same as:  size -1)
    */
int BinarySearch (int* Arr, int Low, int High, int Value)
{
    /* iterative is faster than recursive, but Recursion is easier to be written and more clean*/

    cout<< "BSearch \n";

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

    // 1- Recursive
    cout<< BinarySearch(A,0,size-1,9) <<endl;

    // 2- For loops

    cout<< BinarySearch2(A,size,6000) <<endl;


    cout<<"\n\n\n\n\n";
    return 0;
}
