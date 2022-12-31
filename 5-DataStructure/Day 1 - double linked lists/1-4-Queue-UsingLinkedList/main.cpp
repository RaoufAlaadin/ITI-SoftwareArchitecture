#include <iostream>
#include <conio.h>

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

class Queue
{

   int Tail;    // 4 bytes
                // total is ----> 12 bytes for each object.

    int size; // created to store the value of (L), to be available to the rest of the functions.


     EmpNode* PStart = NULL;
    EmpNode* PLast = NULL;


public:


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

    Queue(int L)
    {

        cout<<"Queue ctor \n";
        Tail = -1;

        size = L;
        // this how you dynamically allocate memory for an array in c++

         for (int i = 0; i < size; i++)
        {
            // this will create a linked list of employees
            // will intilize all id to -1
            AddNode(i);
        }

    }

    ~Queue(){}

    int IsFull()
    {return (Tail == (size -1)) ;}



    int IsEmpty() { return (Tail == -1);}

    void EnQ(EmpNode E)
    {
        // Always EnQ from the Back !!!!!!

        if (!IsFull())
        {
            EmpNode* pCurrent = SearchList(++Tail);

            if (pCurrent == NULL)


                 {
                    cout<<"==============================" <<endl;
                    cout<< "the Specific employee was Not found" << endl;
                    cout<<"==============================" <<endl;
                }
            else
                {
                    pCurrent->id = E.id;
                     cout<<"The number ( "<< pCurrent->id <<" ) got registered in the Q"<<endl;

                }

        }
        else{
            cout<<"The Q is full !! " << endl;
        }

    }

    // EnQ should give us the top value in the Queue.
    // last added
    void DeQ()
    {
        // Always DeQ from the Front !!!!

        if(!IsEmpty())
        {
            cout<<"The number in-front is:" << PStart << endl;

             // now we need to shift everything.

             EmpNode* pCurrent = PStart;
             PStart = PStart->PNext;


              if (pCurrent == NULL)

                 {
                    cout<<"==============================" <<endl;
//                    cout<< "the Specific employee was Not found" << endl;
//                    cout<<"==============================" <<endl;
                }
            else
                {
                  for(int i = 0; i < size -1; i++)
                     {
                        pCurrent->id = pCurrent->PNext -> id;

                        pCurrent = pCurrent->PNext;

                        //     Q[i] = Q[i+1];


                     }

                     // note:the Tail should be also moved once.
                    // to keep pointing at the last element.
                    Tail--;
                }




        }
        else{
            cout<<"Q is Empty" <<endl;
        }




    }


  void viewContent ()
        {
        EmpNode* pDisplay = PStart;
        for(int i = 0; i < Tail; i++)
        {

            cout << "number" << i << " : " << pDisplay->id <<endl;
            pDisplay = pDisplay ->PNext;
        }


}

};



int main()
{
     // stack of 4 employees with random id
     Queue Q1(4);

    EmpNode Temp;
    Temp.id = 2015;
    Q1.EnQ(Temp);


    Temp.id = 2016;
    Q1.EnQ(Temp);


    Temp.id = 2020;
    Q1.EnQ(Temp);

    cout<<"Trying view content" <<endl;
    cout<<"==================" <<endl;


    Q1.viewContent();

    Q1.DeQ();

    cout<<"Trying view content" <<endl;
    cout<<"==================" <<endl;


    Q1.viewContent();





    return 0;

}
