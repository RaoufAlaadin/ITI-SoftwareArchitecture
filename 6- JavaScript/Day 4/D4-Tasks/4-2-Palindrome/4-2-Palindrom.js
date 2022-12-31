


var mySenctence = prompt("Enter a string  ",0);


// pressing ok gives (true) -- makes sesitivty matters 
var CaseSentivity = confirm("Do you want to be CaseSensitve? Ex: 'a' != 'A' ");

var stringLength = mySenctence.length; 
var counter = 0; 

if (CaseSentivity)
    {
        for ( var i = 0; i < stringLength; i++)
        {   
            // the -1 is because the count - for example- goes from 0 to 7 and the length would be 8 
            // so 8-1-0 = 7 .... would give the accurate value for the last index. 

            if (mySenctence.charAt(i) == mySenctence.charAt(stringLength-i-1))
                counter++; 
        }
    }
    else
    {
        for ( var i = 0; i < mySenctence.length; i++)
        {
            if (mySenctence.charAt(i).toUpperCase == mySenctence.charAt(stringLength-i-1).toUpperCase)
                counter++; 
        }
    
    }

    if( counter == stringLength)
    {
        alert(`palindrom found`);
    }
    else{
        alert(`not a palindrom`);
    }


    // Method 2 

    // function isPalindrome(s) {
    //     /* 
    //         1- it will split each char into an element inside an array giving empty qoution will do that "" . 
    //         2- then reverse that array using reverse()
    //         3- then join it back into a string without anything between the letters -- hence the need for "" 
    //         4- after that we compare the original variable to the reversed one
            
    //                         if they match it's a palindrom. 
        
    //     */
    //     return s === s.split("").reverse().join("");
    // }



    