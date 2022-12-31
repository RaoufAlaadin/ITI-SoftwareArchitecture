#include <iostream>

using namespace std;

// 1- double linked list (structure programming)

typedef struct EmpNode
{
    // this part is all considered data
    int id,age;
    char gender, name[100],city[200];
    double salary, overtime, deduct;

    // we have to type struct here, as the typedef was not yet declared for it.
   struct EmpNode* PNext;
   struct EmpNode* PPrev;

}EmpNode;


// global pointers assigned automatically to NULL
// Note: global variables gets assigned to 0

EmpNode* PStart;
EmpNode* PLast;

// I might need another Global pointer for the current node.


// -0

// we input an object that contain the data, that is going to used later
// in the already made data adding fn inside the menu.
EmpNode* NewNode(int D )
{
    // this dynamically allocates new space for a single node
    // and assigns the values and
    EmpNode* PNew = new EmpNode();
    if ( PNew == NULL) exit(0);

    // we only set the id for this node, there is still other data.
    PNew ->id = D;
    cout<< "\n Employee Name  ";
    cin >> PNew->name;

//    cout<< "Employee Gender" <<endl;
//    cin >> PNew->gender;

    // we intilize both of the node's side to NULL , until we decied where to put it.
    PNew ->PNext = NULL;
    PNew ->PPrev = NULL;


    return PNew;

}

// -1
void AddNode(int key)
{
    // here we are just calling the fn we created, that will do the dynamic allocation.
    EmpNode* PNew = NewNode(key);

    // if this check is true, then we do not have any nodes in our list
    // and it sets the Pnew as our first and only node.. that's why PLast and PStart point to it.

    if (PLast == NULL)
        PLast = PStart = PNew;
    else
    {
        // we are going to keep adding to the end of the list....
        /*              so... the steps are:
                                    1- change the next address of the last node into the address of the new node.
                                    2- change the prev of the new node to the *previously* end opf list node.
                                    3- we already sat next of the new node to NULL, so we won't to do that.
                                    */

       PLast->PNext = PNew;
       PNew->PPrev = PLast;

       // set the last pointer on the new end.
       PLast = PNew;
    }
}

// -2
EmpNode* SearchList(int key)

{
    // gets the Psearch to point to the node at the start of the linked list.
    EmpNode* Psearch = PStart;

    while(Psearch != NULL)
    {
        if (Psearch ->id == key)
        {
            cout<< "Founded the Employee !!! Great Dude !! \n";
            // gets us out of the while loop.
            break;
        }

        // moves us to the next node.
        Psearch = Psearch ->PNext;
    }

    return Psearch;
}



// -3

void Display(int key)
{
    // searchlist returns a pointer to the wanted node.
    // so we get our pDisplay pointer to point at the same place.

    EmpNode* pDisplay = SearchList(key);

    if (pDisplay == NULL)

        cout<< "the Specific employee was Not found" << endl;
    else
        cout<< pDisplay->id <<endl ;
        cout<< pDisplay->name <<endl ;
        // here we should be displaying all the data of that object
        // can we just call the already made menu fn.


}


// -4

void DisplayAll()
{
    EmpNode* pDisplay = PStart;

    while( pDisplay != NULL)
    {
        cout<< pDisplay->id <<endl ;
        cout<< pDisplay->name <<endl ;
        // then we move the pointer to the next node.

        pDisplay = pDisplay ->PNext;

    }
}

// -5

void DeleteNode( int key)
{
    /* searchList() should return us a pointer to the requested employee id if found.
        and then after pointing to it, we decide how to delete it.*/
    EmpNode* pDelete = SearchList(key);

    // Case 1- if pDelete points to nothing, then the SearchList didn't find our object.
    if ( pDelete == NULL)
    {
        cout << "Employee was not found, Try again." << endl;
    }
    else
    {  /* Case 2 - We have only one node in the list.
                    this means that Pstart and Plast point at the same node( or value)
                    note: they also do that when the list is empty!! pstart = plast  = null
                    but the pdelete == Null check , ensures that we will get atleast one node.*/


        if (PStart == PLast)
        {
            // we will just reset the pointers to NULL, which makes pDelete the only pointer
            // that is pointing at them, so it can free that memory.

            PStart = PLast = NULL;

        }
        // Case 3- if the node at the start of the linked list
        else if ( pDelete == PStart)
        {
            // point to the 2nd node
            PStart = PStart->PNext;
            // set the PPrev for the 2nd node to be null, As we are going to delete the 1st node.
            PStart->PPrev = NULL;
        }
        // Case 4- node at the end
        else if(pDelete == PLast)
        {
            // same as case 2, but doing it at the end.
            PLast = PLast->PPrev;
            PLast ->PNext = NULL;
        }
        else
        {   // Case 5 - (General Case) - a node in the middle of a big list

           pDelete->PPrev->PNext = pDelete->PNext;
           pDelete ->PNext->PPrev = pDelete->PPrev;
        }

        // we are inside the else where pDelete was able to find the node it wants.
        // so now after removing the node from the chain.
        // we free it :)

        // Note: delete is used with new instead of free(), because delete also calls the destructor.
        // which is useful when destorying objects created from a class.

        delete pDelete;

    }

}



// -6

void DeleteAll()
{
    // You can either delete from the start to end or the opposite direction.

    /* Logical steps ---->   1- point to a node
                            2- make sure to save the adresss of the next node ( then we need an extra pointer)
                                    -- the pDelete we created here could be also called Temp pointer.
                            3- delete the node you are standing on
                            4- repeat.... until what?....
                                    until the next address we have stored equals NULL
                                    which means we are deleting our last node. */

    EmpNode* pDelete;

    while (PStart != NULL)
    {
        pDelete = PStart;
        // this will set Pstart = NUll at the last node.
        PStart = PStart ->PNext;
        delete  pDelete;
    }

    // Remember that Pstart is reset to NULL already, but you will have to do Plast manually.

    PLast = NULL;

    cout<<"Everything was deleted" <<endl;

}



int main()
{
    cout << "Hello world!" << endl;

    AddNode(1);
    AddNode(2);
    AddNode(3);



    cout << " ========================" <<endl;

    int x = 5 ;

//    while (x > 0)
//    {
//         cout << "Enter the ID number" << endl;
//        cin >> x;
//        Display(x);
//    }

DisplayAll();

cout << " ========================" <<endl;

DeleteNode(2);

cout << " ========================" <<endl;

DisplayAll();

cout << " ========================" <<endl;

DeleteAll();

DisplayAll();




    return 0;
}
