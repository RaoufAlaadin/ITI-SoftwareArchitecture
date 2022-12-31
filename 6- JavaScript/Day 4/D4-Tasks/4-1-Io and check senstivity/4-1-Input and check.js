
/* TODO: 4-1   1- Write a script that accepts a string from user through prompt 

                2- count the number of a specific character (the user willthat the user will define in
                another prompt. 

            3- Ask the user whether to consider difference between
            letter cases or not then display the number of letter appearance
            
            https://stackoverflow.com/questions/2903542/javascript-how-many-times-a-character-occurs-in-a-string

    What I understood is: take a string,
                         then take a single char,
                        then print how many times the char appeared inside that string*/


                // Question: How can I use userInput with regular expersion ? 

    var mySenctence = prompt("Enter a string  ",0);

    var targetCharacter = prompt("Enter a a char ",0);

    // pressing ok gives (true) -- makes sesitivty matters 
    var CaseSentivity = confirm("Do you want to be CaseSensitve? Ex: 'a' != 'A' ");

   
    var counter = 0; 

    if (CaseSentivity)
        {
            for ( var i = 0; i < mySenctence.length; i++)
            {
                if (mySenctence.charAt(i) == targetCharacter)
                    counter++; 
            }
        }
        else
        {
            for ( var i = 0; i < mySenctence.length; i++)
            {
                if (mySenctence.charAt(i).toUpperCase == targetCharacter.toUpperCase)
                    counter++; 
            }
        
        }

        alert(`Number of char: ${targetCharacter} appearance is: ${counter}`);

    


//     //Method 1 

//     if (CaseSentivity)
//     {
//         for ( var i = 0; i < mySenctence.length; i++)
//         {
//             if (mySenctence.charAt(i) == targetCharacter)
//                 counter++; 
//         }
//     }
//     else
//     {
//         for ( var i = 0; i < mySenctence.length; i++)
//         {
//             if (mySenctence.charAt(i).toUpperCase == targetCharacter.toUpperCase)
//                 counter++; 
//         }
    
//     }

//     alert(`Number of char: ${targetCharacter} appearance is: ${counter}`);


//     // Method 2 : using Regular Expression

//     /* 
//         What this basically do, is remove anything that is not the char from the string
//         which leaves a string with nothing but a , then we use the .length and this will count the number of a
//     */

//     if (CaseSentivity)
//     {
//        counter = mySenctence.replace(/[^a]/g, "").length;
//     }
//     else
//     {
//         counter = mySenctence.replace(/[^a]/gi, "").length;
//     }

//     alert(`Number of char: ${targetCharacter} appearance is: ${counter}`);

//      // Method 3 : using Regular Expression


//      if (CaseSentivity)
//     {
//        counter = mySenctence.replace(/[^a]/g, "").length;
//     }
//     else
//     {
//         counter = mySenctence.replace(/[^a]/gi, "").length;
//     }

//                 // OR using match()
//                 /* it returns an array with char we wanted */
//             mySenctence.match(/a/gi).length;


//   // Method 3: using split
  
//   /* it splits the sentence when it finds the char, so for 3 letter, we would get 4 splits
//     so we need to write .length-1 !!!!!!*/


//     str = "A man is as good as his word";
//     alert(str.split('a').length-1);






