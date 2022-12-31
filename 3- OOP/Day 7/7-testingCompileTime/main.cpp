#include <iostream>

using namespace std;

int main()
{


//    int x = 5;
//    int *y = &x;
//

    int w = 10 ;
    int *x = &w;

    int* y = x ;

    w = 5;
    cout<< *y <<endl;



}
