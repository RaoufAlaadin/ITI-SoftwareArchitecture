#include <stdio.h>
#include <stdlib.h>

#define size 5

int main()
{
/*     // if we only set 3 values, (C) will set the rest to zero !!
    // this is only in C !!
    int a[5] = {1,2,3,4,5};


    // this will set every cell to 0 because we did not set them !!
    int a [100] = {0};



// Ex 2 :
    for(int i = 0; i < 5; i++)
        printf("%i\n",a[i]);
*/


/*// Ex 3 - get the average grade for the students marks

int marks[size] , i, sum = 0 ;
    for( i = 0; size>i ; i++)
    {
        printf("Enter Subject %i grade",i+1);
        scanf("%i", &marks[i]);
        sum += marks[i];

    }

    printf("sum = %i ", sum );


    // how does the complier moves to the right index in an array ?

    // a[5] = memory address + 5 * sizeof(data type) ;
    // 5* sizeof(data type) will give the number of bytes needed to move from point to point*/


/*// Ex 4 - 2D array

// the cells that are not intialiazed, Will be put to zero's

int marks [3][5] = {{1,2,3,4,5},{6,7,8},{9,10}} ;

// i -- rows , j-- columns.

//int i, j;
//
//for ( i = 0; i < 3; i++ )
//{
//    for(j = 0; j < 5; j++)
//    {
//        printf(" %i ,", marks[i][j]);
//    }
//
//    printf(" \n");
//}


 // Ex: 5  Can we do it with only one for loop ?

 int c;

 // size is 3*5 = 15 ;

 for ( c = 0; c < 15; c++ )
    {
        printf("%i , ",marks[c / 5][c % 5]);
    }
    */

/*// Ex 6 : I want to sum every row alone


// Ex 7 : Enter a name


    // and put every sum in a cell inside a column


    int marks[3][5] , sum [3] = {0} , avg[5] = {0};

    int i , j;
    for (i = 0; i < ; i++)
    {
        for (j = 0; j < ; j++)
        {
            printf("Enter student %i , subject %i Grade : \n", i+1 , j+1 );
            scanf("%i", &marks [][]);
            sum [i] += marks [i][j];
            avg[j] += marks [i][j];


        }

        for { i = 0; i < 5; i++}
        {
            avg[i] /= 3;
        }*/


 // Ex 7 :

 char name [10],ch , i;

    printf("Enter your name: \n");

    //getch()  -- read single char, returns char
    //getche()  -- read single char , return char ?? but they are not the same i think

    for(  i = 0; i < 10; i++ )
    {
        ch = getche();
        if (ch ==13)
        {
            name[i] = '0';
            break;
        }
        name [i] = ch;
    }



    printf("Hello ");


//    for( int i = 0; i < 10; i++)
//   {
//       printf("%c", name[i]);
//   }

    i = 0 ;
    while( name[i] != '\0' )
    {
        printf("%c", name[i++]);
    }
}
