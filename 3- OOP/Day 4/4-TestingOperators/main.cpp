#include <bits/stdc++.h>

using namespace std;

class Complex{
private:
    int real;
    int imaginary;
    static int i;

public:
    /**/

    Complex()
    {
        real=0;
        imaginary=0;
    }

    Complex(Complex &temp)
    {
        real=temp.real;
        imaginary=temp.imaginary;
    }

    int get_real()
    {
        return real;
    }
    int get_ima()
    {
        return imaginary;
    }
    void set_real(int _real)
    {
        real = _real;
    }
    void set_imaginary(int _imaginary)
    {
        imaginary = _imaginary;
    }
    void print()
    {
        if(real!=0 && imaginary>0  )
        cout<<real<<"+"<<imaginary<<"i"<<endl;
        else if(real!=0 && imaginary<0)
        cout<<real<<imaginary<<"i"<<endl;
        else if(real==0 && imaginary!=0)
        cout<<imaginary<<"i"<<endl;
        else if(real!=0 && imaginary==0)
        cout<<real<<endl;
        else
        cout<<"0"<<endl;
    }


    Complex operator-(Complex c1)                   //c3=c1-c2
    {
        Complex result;
        result.real = real - c1.real;
        result.imaginary = imaginary - c1.imaginary;
        return result;
    }

    Complex& operator-=(const Complex &c1)                   //c1-=c2
    {
        real -= c1.real;
        return *this;
    }

    Complex& operator-=(const int &c1)                   //c1-=7
    {
        real -= c1;
        return *this;
    }

    Complex operator-(int a)                             //c3=c1-2
    {
        Complex result;
        result.imaginary=2;
        result.real = real - a;
        return result;
    }

    Complex& operator--()                             //pre
    {
        real--;
        return *this;
    }

    Complex operator--(int)                             //post
    {
        Complex result;
        result.real = real;
        real--;
        return result;
    }

    bool operator==(const Complex &c1)                   //c1==c2
    {
        return (real == c1.real);
    }

    bool operator!=(const Complex &c1)                   //c1!=c2
    {
        return (real != c1.real);
    }

    bool operator>(const Complex &c1)                   //c1>c2
    {
        if(real==c1.real)
        {
            return (imaginary > c1.imaginary);
        }
        return (real > c1.real);
    }

    bool operator>=(const Complex &c1)                   //c1>=c2
    {
        return (real >= c1.real);
    }

    bool operator<(const Complex &c1)                   //c1<c2
    {
        if(real==c1.real)
        {
            return (imaginary < c1.imaginary);
        }
        return (real < c1.real);
    }

    bool operator<=(const Complex &c1)                   //c1<=c2
    {
        return (real <= c1.real);
    }

    operator int()                                       //()c1
    {
        return (real);
    }

    operator char*()                                       //(string)c1
    {
        string s=to_string(real);
        s+= "+"+ to_string(imaginary)+'i';

//        string s= to_string(real) + " " to_string

        int s_size=s.size();


        char *arr=new char[s_size+1];
        for(int i=0;i<s_size;i++)
        {
            arr[i]=s[i];
        }
        arr[s_size]='\0';
        return arr;
    }

    ~Complex()
    {
        //cout<<"\n"<<this<<endl;
        //cout<<"\nNubmer :"<<++i<<endl;
    }
};

Complex operator-(int a,Complex c1)                  //c3=7-c1
{
    Complex result;
    result.set_imaginary(2);

    result.set_real(a - c1.get_real());
    return result;
}


operator-=(int a,Complex c1)                   //7-=c1
{
    return (a-c1.get_real());
}

int Complex::i = 0;

int main()
{
    Complex c1,c2,c3;
    c1.set_real(6);
    c1.set_imaginary(5);
    c2.set_real(4);
    c2.set_imaginary(3);
    c3.set_imaginary(3);

    cout<<"---------------"<<endl;
    cout<<"C3=C1-C2"<<endl;
    c3=c1-c2;
    c3.print();
    cout<<"---------------"<<endl;
    cout<<"c3=7-c2"<<endl;
    c3=7-c2;
    c3.print();

    cout<<"---------------"<<endl;
    cout<<"c3=c2-7"<<endl;
    c3=c2-7;
    c3.print();

    cout<<"---------------"<<endl;
    cout<<"c1-=c2"<<endl;
    c1-=c2;
    c1.print();

    cout<<"---------------"<<endl;
    cout<<"c1-=7"<<endl;
    c1-=7;
    c1.print();

    cout<<"---------------"<<endl;
    cout<<"7-=c1"<<endl;
    cout<<(7-=c1)<<endl;


    cout<<"---------------"<<endl;
    cout<<"c1--"<<endl;
    c1--;
    c1.print();

    cout<<"---------------"<<endl;
    cout<<"c1==c2"<<endl;
    cout<<(c1==c2)<<endl;

    cout<<"---------------"<<endl;
    cout<<"c1!=c2"<<endl;
    cout<<(c1!=c2)<<endl;

    cout<<"---------------"<<endl;
    cout<<"c1>c2"<<endl;
    cout<<(c1>c2)<<endl;

    cout<<"---------------"<<endl;
    cout<<"c1>=c2"<<endl;
    cout<<(c1>=c2)<<endl;


    cout<<"---------------"<<endl;
    cout<<"c1<c2"<<endl;
    cout<<(c1<c2)<<endl;

    cout<<"---------------"<<endl;
    cout<<"c1<=c2"<<endl;
    cout<<(c1<=c2)<<endl;

    cout<<"---------------"<<endl;
    cout<<"(int)c1"<<endl;
    cout<<(int)c1<<endl;

    cout<<"---------------"<<endl;
    cout<<"(char*)c1"<<endl;
    cout<<(char*)c1<<endl;



    return 0;
}
