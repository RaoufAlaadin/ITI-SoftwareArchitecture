#include <iostream>

using namespace std;

class Base
{
public:
    int X;
public:
    Base(int _X) { X = _X;}
    int GetX() {return X;}
    void SetX(int _X) { X = _X;}

    void Show ()
    {
        cout<< "I am Base \n";
    }
    ///1. Public virtual Method
     virtual void DynShow() { cout << "Base  Dynamic \n";}
};
///2. Derived use Public Inheritance
class Derived : public Base
{
protected :
    int Y;
public:
    Derived(int _x , int _y):Base(_x) { Y = _y;}
    int GetY() { return Y;}
    void SetY(int _Y) { Y = _Y;}
    void Show()
    {
        cout <<"I am Derived \n";
    }
    ///3.in Derived , override on Virtual Function , using Public Function
    void DynShow()  {cout <<"Derived Dynamic \n";}
};

class Derived02 : public Derived
{
protected:
    int Z;
public:
    Derived02(int a, int b , int c) : Derived(a , b)
    {
        Z = c;
    }

     void Show()
    {
        cout <<"I am Derived 02  \n";
    }

    void DynShow()
    {
        cout <<"Derived 02 Dynamic :"<<Z<<","<<Y<<","<<X<<endl;
    }
};



int main()
{
    /*    ///  2-trying refrences


    Derived02 DD(4,5,6);

    Base& BaseRef = DD , *BPtr = &DD ;

    BaseRef.DynShow(); ///Derived02
    BPtr->DynShow(); ///Derived02

    Derived* DPtr = &DD;
    DPtr->DynShow(); ///Derived02

    BPtr = new Derived(7,8);
    BPtr->DynShow(); ///Derived*/



    //////////////////////////////////////

   cout << "Static: BPtr to base  " <<endl;
    Base B(1),*BPtr ;
    BPtr = new Base(2);

    B.Show(); ///Base
    BPtr->Show(); ///Base

    B.DynShow(); ///Base
    BPtr->DynShow(); ///Base

 cout << "=========================" <<endl;

 cout << "Static: DPTR to derived  " <<endl;
    Derived D(3,4) , *DPtr ;
    DPtr = new Derived(5,6);

    D.Show(); ///Derived
    DPtr->Show(); ///Derived

    D.DynShow(); ///Derived
    DPtr->DynShow(); ///Derived


    //Pointer \ Reference to Base = Derived Object
 //Valid , implicit

   //4. Pointer to Base = Object from Derived
    //Generalize , Develop against Base(Abstract) not Against Derived (Concrete Implementation)

     cout << "=========================" <<endl;

    cout << "interesting Case: BPtr to Derived  " <<endl;
    BPtr = new Derived(7,8);
    //BPtr = DPtr;
    //BPtr = &D;


    BPtr->Show();///Base
    //Statically Binded Methods , Early Binded Methods
    //Binding : Resolving Function , to Function Body
    //Compiler Bind Function call to Function Body as early as Compilation Type
    //Statically based in Pointer (Caller) Type not based on object Type


    BPtr->DynShow(); ///Derived
    //Dynamic Binding , Late Binding
    //Functions labeled as Dynamically Binded Methods
    //Binding will happen as late as Runtime by OS (Runtime )
    //Dynamically based on Object Type not Pointer \ reference Type



//    BPtr = new Derived02(5,3,2);
//
//    BPtr ->DynShow();
//
//
//    cout<< "==================" << endl;
//
//    cout<<"what if we creat DPtr and try pointing at base ? " <<endl;



//   DPtr = new Base(5); // child cannot point at parent






    return 0;
}
