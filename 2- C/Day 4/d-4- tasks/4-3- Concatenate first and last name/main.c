#include <stdio.h>
#include <stdlib.h>

// this is important to use strcat or strncat
#include <string.h>

int main()
{
    /* Task 4-3: 1- Receive first name and last name,
                 2- and concatenate them in one name
                 3- and display on screen.

    */

    char fname[30], lname[30];

    printf("Enter the first name: ");
    gets(fname);

    printf("Enter the last name: ");
    gets(lname);

    /*
    we are using strncat() instead of strcat()
    because it allows us to set the limit of added lname to fname

    this will prevent any overflow that might put us at security risks !!!!
    As any un-wanted entries to our system can be used bad

    */


    strncat(fname," ",30 - strlen(fname) - 1);
    strncat(fname,lname,30 - strlen(fname) - 1);

    //    puts(&fname[0]);
    //we can also use this, as just the name is a pointer to the first element.
    // so we can instead put the first element and add (&) to get it's address !! .

    puts(fname);

}
