#include <iostream>

using namespace std;



class TypeOne
{


};

class TypeTwo : public TypeOne
{
protected:
    int B;
public:

    TypeTwo (int a, int b): TypeOne(a) {B = b;}

    void ShowData() override { cout }
};

int main()
{
    cout << "Hello world!" << endl;
    return 0;
}
