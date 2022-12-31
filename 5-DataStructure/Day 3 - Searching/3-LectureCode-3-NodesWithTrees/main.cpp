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


int BinarySearch (int* Arr, int Low, int High, int Value)
{
    /* iterative is faster than recursive, but Recursion is easier to be written and more clean*/
    if(Low <= High)
    {
        int Mid = (Low + High)/2;

        if (Value == Arr[Mid]) return Mid;
        else if (Arr[Mid] > Value) // go left
            return BinarySearch(Arr,Low,Mid-1,Value);
        else // go right

            return BinarySearch(Arr,Mid+1,High,Value);
    }

}


// binary search using ---> Loops

int BinarySearch2(int* Arr, int size, int Value)
{
    int Low = 0, High = size - 1;

    while (High >= Low )
    {
        int Mid = ( Low + High)/ 2;

        if ( Arr[Mid] == value)
            return Mid;
        else if ()
    }
}




class Node
{
    public:
    int Key; //Data // imagine we have tons of data to search here :)

    Node* pLeft;
    Node* pRight;


};

Node* pTree = NULL; // note ====================================

Node* SearchBTree ( Node* pRoot, int Key)
{
    // go back if value found or root equals null

    if ( PRoot != NULL)
    {
        if (pRoot ->Key == Key)
            return pRoot;
        else if (pRoot -> Key > Key) // Go to Left Sub Tree
            return SearchBTree(pRoot->pLeft,Key);
        else
        return SearchBTree(pRoot->pRight,Key);
    }
}


int CountNodes ( Node *pRoot)
{
    if(pRoot != NULL)
        return CountNodes(pRoot ->pLeft) //////////////////// complete-1
}

void TreeTraverse (Node* pRoot)
{
    // would print from bottom to top

    if (pRoot != NULL)
    {

        //////////////////// complete-2

    }

}

Node* NewNode()
{
    Node* pNew = new Node();

    if(pNew == NULL) exit(0);

    pNew ->pLeft = pNew ->pRight = NULL;

    cout<< "Enter new key" ;
    cin >> pNew ->Key;

    return pNew;
}



int main()
{
    cout << "Hello world!" << endl;

    int Arr[8] = { 4, 2, 8, 3, 6, 7, 1, 5};

    cout<< BinarySearch(Arr,0,7,8) << endl;

    // not sorted -- O(n)
    return 0;
}
