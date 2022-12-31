#include <stdio.h>
#include <stdlib.h>

#include <string.h>


        /* task 5-1:  1- We have a single employee ( we do not need an array )

                      2- take his data from the user-input (reading data)
            ** we will input all of his data despite not needing everything for output**

                      3- print out --- Employee ID , name , net
        */

typedef struct employee
{
    // we have (8) data info about the employee.
    int id,age;
    char gender, name[100],city[200];
    double salary, overtime, deduct;

    // net = (salary + overtime ) - deduct.
    // we will use this formula everytime we want the net. salary !!

}employee;

int main()
{
    employee e1 ;

    /* this is how we can give (multiple inputs) using scanf()

    printf("Enter employee id and age : \n ");
    scanf("%i%i",&e1.id,&e1.age);

    printf("id = %i , age = %i ", e1.id, e1.age);*/

    printf("Enter  id: ");
    scanf("%i",&e1.id);

    printf("Enter  age: ");
    scanf("%i",&e1.age);

    // it's important to use _flushall

    _flushall();
    printf("Enter gender: ");
    scanf("%c",&e1.gender);

    _flushall();

    printf("Enter  Name: ");
    gets(e1.name);


    printf("Enter city: ");
    gets(e1.city);

    printf("Enter  Salary: ");
    scanf("%lf",&e1.salary);

    printf("Enter  overtime: ");
    scanf("%lf",&e1.overtime);

    printf("Enter  deduct: ");
    scanf("%lf",&e1.deduct);

    printf(" **************************** \n ");
    printf (" Employee's data is : \n ");

    double net = e1.salary + e1.overtime - e1.deduct;

    printf(" ID: %i , Name: %s , Net.Salary : %0.02lf ",e1.id, e1.name, net);










}
