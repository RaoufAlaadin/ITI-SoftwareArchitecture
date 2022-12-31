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

    if ( pRoot != NULL)
    {
        if (pRoot ->Key == Key) // checking if we are at the value.
            return pRoot;
        else if (pRoot -> Key > Key) // Go to Left Sub Tree
            // so we change the value of pRoot to go to the left node.
            return SearchBTree(pRoot->pLeft,Key);
        else
        return SearchBTree(pRoot->pRight,Key);
    }

    return NULL; // Empty Tree
}


int CountNodes ( Node *pRoot)
{
    if(pRoot != NULL)
        return CountNodes(pRoot ->pLeft) + 1 + CountNodes(pRoot ->pRight);
    return 0;

    /* the 1 is the root itself, when in recursion every node will be a root at some point.
       like at one of the leaf , if we consider the leaf a root. it get 0 + 1 + 0 as both direction will point to Null
       So we will be returning this (1) to the pLeft that called us.

       note: when pRoot -> pLeft is the input.. it's implicity the new pRoot..
                when that pRoot faces Null, it returns to the previous state and continues the line
                forr pRoot-> pRight to excute.

            so we don't just immediatly escape the run.. we just take a step back and look on what we have.

            so now we have  1 + 1 + (1) -- the third one came from pRoot->pRight calling the right node then
            trying it's poiners are returning with a null also
            so now we have
                                *
                              *  *   which gave us 3 nodes as a return.
    */
}

void TreeTraverse (Node* pRoot)
        {
            if ( pRoot != NULL)
            {
                TreeTraverse(pRoot ->pLeft);

                cout << pRoot->Key << endl;

                TreeTraverse(pRoot->pRight);

            }


        }
            // would print from bottom to top





Node* NewNode()
{
    Node* pNew = new Node();

    //checking if the node
    if(pNew == NULL) exit(0);


    pNew ->pLeft = pNew ->pRight = NULL;

    // Registering Data in this one Node.

    cout<< "Enter new key:  " ;
    cin >> pNew ->Key;

    // returning the pointer to the node we created.
    return pNew;
}

// we have to pass the poiner address by reference.

void InsertNode (Node* &pRoot, Node* pNew)
{
    if (pRoot == NULL)
        pRoot = pNew;

    else if (pRoot->Key > pNew->Key) // add to the left
        InsertNode(pRoot->pLeft, pNew);
    else // add to the right.
        InsertNode(pRoot->pRight,pNew);

}



// another method for inserting a node by using 2 pointers,
// one is behind the other.

void InsertNode2 (Node* pRoot, Node* pLeaf, Node *pNew)
{
    /* if pLeaf is Null, this means we reached the end of one of the branches
        where we wanted to add the node.

            this is replacing the part ===>  if (pRoot == NULL)
                                                    pRoot = pNew;

                                            from the reference version.

            but here we are more clear.
    */
    if (pLeaf == NULL)
    {

        if (pRoot == NULL)
            pTree = pNew; // if the leaf is NUll and the Root is Null, then we have an empty tree
                          // so We assign the new node to the pTree.
        else
        {
            // for this case pRoot != Null so we are point at at node.
            // and we have also came back from pLeaf = Null but we don't know which.
            // so we do our comparison and assign the new address in one of the partations inside our current root.
            if (pRoot->Key > pNew->Key)
                pRoot->pLeft = pNew;
            else
                pRoot->pRight = pNew;
        }
    }
    else if (pLeaf->Key > pNew->Key )

        InsertNode2(pLeaf, pLeaf->pLeft,pNew);

    else
        InsertNode2(pLeaf, pLeaf->pRight,pNew);


}


// fn. prototypes to declare them for the complier

void DeleteNode(Node* &pRoot);
Node* GetMax (Node* pMax);

void Delete (Node* &pRoot, int key)
{
    //Note:
    //  we use by reference because we want the address, and where it's actually located in the tree.

    //      that's why we won't use the searchBTree() because it only gives the address of the node
    //      but it doesn't give us the path to reach it from the pTree.

    // the first 2 if statements are like a mini SearchBTree()

    if ( key < pRoot->Key)
        Delete(pRoot->pLeft,key);

    else if ( key > pRoot->Key)
        Delete(pRoot->pRight,key);

    else // this means we found that node we want to delete

        DeleteNode(pRoot); // check for the 3 cases of deletion

}


// we take the pRoot by address to keep track of the location of the node inside the tree, beside having it's address.
void DeleteNode(Node* &pRoot)
{
    // saving the address of the node to free it's memory later,
    // after removing it from the tree structure.

    Node* pDelete = pRoot;

    // Case 1 : if Leaf or node have single child

    // we check if it has something that it points at on the Left
    // if found , we get our root to point to it instead of pointing at the node we will delete.
    if (pRoot->pLeft == NULL)
       {
           pRoot = pRoot->pRight;
           delete pDelete;
       }

       // same as the previous, but we look if there is nothing on the Right side.
    else if (pRoot->pRight == NULL)
    {
        pRoot = pRoot->pLeft;
           delete pDelete;
    }

    /* Why didn't we put the condition like this ? ==>  pRoot->pLeft != NULL
            because they way we wrote it allow for the case of the node have no leafs also
            as if it found NULL on the right, so it point to left one,
            in some case the left one might have a child

            But the sometimes it will be also NULL !! :)  so this will get the root to point at null
            which does the porpose we want in case the node to be deleted doesn't have any childs

            if written with != , if both sides equal null, we would never enter any of the if statements. !!!!!

    */

    // now.. what if we want to delete a node that has 2 childs. ( Root node)
    else{

            // Can't directly delete node with 2 Childs
            // 1. Search for Most right on Left Sub Tree ( High from lowest Sub Tree)
            // 2.  Swap pRoot,Node from step 1
            // 3. Apply DeleteNode on Swaped Node.

           Node* Temp = GetMax(pRoot->pLeft); // telling it to find the node with the max value on the left sub-tree

           // we took the data from the max node and we put that data in the root
           // as if we made a swap
           pRoot ->Key = Temp->Key;
           // now we need to delete the max node.

           // this line will look for the node with the max key, but we guide to look only into the left sub tree
           // to prevent it from deleting our current pRoot.
           Delete(pRoot->pLeft,Temp->Key);

    }
}


Node* GetMax (Node* pMax)
{
    while (pMax->pRight != NULL)
        pMax = pMax ->pRight;

    return pMax;
}



int main()
{

    cout<< "\n=========== Inserting Nodes. ==============\n" <<endl;

    for (int i = 0; i < 8; i++)
        //        InsertNode(pTree,NewNode());
        InsertNode2(pTree,pTree,NewNode());


    cout<< "\n=========== Deleting Nodes. ==============\n" <<endl;

        Delete(pTree,3);


        // without  passing by Reference, the Traverse will return nothing.

        cout<< "\n=========== Printing Nodes (Traverse) . ==============\n" <<endl;
        TreeTraverse(pTree);

//        Delete(pTree,2);
//
//        Delete(pTree,5);

    cout<< "\n=========== Number of nodes ==============\n" <<endl;
        cout << "Node Count:" << CountNodes(pTree);


    cout<< "\n=========== Searching for a key. ==============\n" <<endl;
        // the SearchBTree() fn. returns us a pointer to the node that holds our key.
        // so we have to store the value of that pointer in another pointer
        // to be able to use it outside of the fn.

        Node* Psearch = SearchBTree(pTree,10);

        if ( Psearch != NULL)
        {
            cout<< "Found \n";
        }
        else{
            cout<< "not found \n";
        }
        /* Pointer pTree is created under the node class and it points to a NUll
            so due to the first if .. pTree will point to the first allocated node before prograssing downward.

            the fn. NewNode() returns a pointer to the new node. so putting the fn as the input
            is a good shortcut. :)
        */


/*int A[] = {6,8,2,1,7,9,10,5};

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

    cout<< BinarySearch2(A,size,6000) <<endl;*/


    cout<<"\n\n\n\n\n";
    return 0;
}
