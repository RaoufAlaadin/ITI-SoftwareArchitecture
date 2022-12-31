#include <iostream>

using namespace std;

class EmpNode
{
    public:
    // this part is all considered data
    int id,age;
    char gender, name[100],city[200];
    double salary, overtime, deduct;

    // we have to type struct here, as the typedef was not yet declared for it.
   EmpNode* PNext;
   EmpNode* PPrev;



};




class MyStack
{

   int Tos;
   int size;

    EmpNode* PStart = NULL;
    EmpNode* PLast = NULL;



public:

    //////////////

    EmpNode* NewNode(int D )
    {
        EmpNode* PNew = new EmpNode();
        if ( PNew == NULL) exit(0);

        PNew ->id = D;

        PNew ->PNext = NULL;
        PNew ->PPrev = NULL;


        return PNew;

    }

        /////////////
    void AddNode(int key)
        {

            EmpNode* PNew = NewNode(key);

            if (PLast == NULL)
                PLast = PStart = PNew;
            else
            {

               PLast->PNext = PNew;
               PNew->PPrev = PLast;


               PLast = PNew;
            }
        }

        //////////////////

        EmpNode* SearchList(int key)

            {
                // gets the Psearch to point to the node at the start of the linked list.
                EmpNode* Psearch = PStart;

                while(Psearch != NULL)
                {
                    if (Psearch ->id == key)
                    {
//                        cout<< "Founded the Employee !!! \n";
                        // gets us out of the while loop.
                        break;
                    }

                    // moves us to the next node.
                    Psearch = Psearch ->PNext;
                }

                return Psearch;
            }


//////////////////
    MyStack(int L)
    {

        cout<<"Stack ctor \n";
        Tos = 0;
        size = L;
        // this how you dynamically allocate memory for an array in c++

    for (int i = 0; i < size; i++)
        {
            // this will create a linked list of employees
            // will intilize all id to -1
            AddNode(i);
        }

    }

    ~MyStack(){}

    // 1- IsFull() , Is Empty() conditions which are important for later fn
    int IsFull()  { return (Tos == size) ;}

        IsEmpty() { return Tos ==0;}

    // 2- main functions

        // a- Push

    void Push(EmpNode E)
    {
        if (!IsFull()) //  this is the same is Isfull() == false
        {

//            Stk[Tos++] = n;

            // this points to empty space in top of stack then increase Tos
            EmpNode* pCurrent = SearchList(Tos++);

            if (pCurrent == NULL)

                 {
                    cout<<"==============================" <<endl;
                    cout<< "the Specific employee was Not found" << endl;
                    cout<<"==============================" <<endl;
                }
            else
                {
                   pCurrent->id = E.id;
                }

            // stores the emp id


        }
        else{cout<<"Stack is full !! " <<endl; }

    }


        // b- POP

    int Pop()
    {
        if (!IsEmpty())
        {

               EmpNode* pCurrent = SearchList(--Tos);

            if (pCurrent == NULL)

                 {
                    cout<<"==============================" <<endl;
//                    cout<< "the Specific employee was Not found" << endl;
//                    cout<<"==============================" <<endl;
                }
            else
                {
                    return pCurrent->id;
                }




        }
        else{
                cout<<"Stack is Empty" << endl;
                // we have to put a return statement for the else, as it's considered a path.
                return 1;

        }
    }


    // c- Peak
int Peak()
{
     if (!IsEmpty())
        {


              EmpNode* pCurrent = SearchList(Tos-1);

            if (pCurrent == NULL)

                 {
                    cout<<"==============================" <<endl;
//                    cout<< "the Specific employee was Not found" << endl;
//                    cout<<"==============================" <<endl;
                }
            else
                {
                    return pCurrent->id;
                }




        }
        else{
                cout<<"Stack is Empty" << endl;
                // we have to put a return statement for the else, as it's considered a path.
                return 1;

        }

}



    void viewContent ()
    {
        EmpNode* pDisplay = PStart;
        for(int i = 0; i < Tos; i++)
        {

            cout << "number" << i << " : " << pDisplay->id <<endl;
            pDisplay = pDisplay ->PNext;
        }



    }

};


// stand alone fn. that has been friended.




int main()
{
    // stack of 4 employees with random id
     MyStack S1(4);

    EmpNode Temp;
    Temp.id = 2015;
    S1.Push(Temp);


    Temp.id = 2016;
    S1.Push(Temp);


    Temp.id = 2020;
    S1.Push(Temp);

    cout<<"Trying view content" <<endl;
    cout<<"==================" <<endl;


    S1.viewContent();

    S1.Pop();

    cout<<"Trying view content" <<endl;
    cout<<"==================" <<endl;


    S1.viewContent();















//    EmpNode E2(8);
//    S1.Push(E2);
//
//    EmpNode E3(9);
//    S1.Push(E3);


// S1.Push(8);
// S1.Push(9);








    return 0;
}
