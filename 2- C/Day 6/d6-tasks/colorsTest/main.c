#include <stdio.h>
#include <stdlib.h>
#include <windows.h>


int main()
{
// for (int i = 0; i < 256; ++i)
// {
//  SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), i);
//  printf("text color in use : %i  and in hexa %x \n", i);
// }

/*SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);
  printf("text color in use : %i  and in hexa %x \n", 15);

 SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 176);
  printf("text color in use : %i  and in hexa %x \n", 176);

   SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 96);
  printf("text color in use : %i  and in hexa %x \n", 96);

   SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 95);
  printf("text color in use : %i  and in hexa %x \n", 95);

   SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 224);
  printf("text color in use : %i  and in hexa %x \n", 224);

   SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 240);
  printf("text color in use : %i  and in hexa %x \n", 240);

   SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 192);
  printf("text color in use : %i  and in hexa %x \n", 192);*/
 char ch;

do{

   ch = getch();

printf("%i \n ", ch);

}while ( ch != 0);

}
