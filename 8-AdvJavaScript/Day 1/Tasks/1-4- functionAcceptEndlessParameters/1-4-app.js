/*

1- check data type to be numeric 
2- function must input must not be less than 1 
 */


var adding = function (a,b)
{
    // arguemnt collection
    var sum = 0 ; 
    var numberOfInputs = 2; 

    var err = new Error("No inputs were entered"); 
    var err2 = new Error("a non number value was found in inputs"); 

    if (arguments.length < 1)
    {
        throw err; 
    }
    else
    {

        for( var i = 0; i < arguments.length; i++)
        {
            if (isNaN(arguments[i]))
            {
                throw err2; 
            }
            else{
                
                sum += arguments[i]; 

            }
            
        }

        return sum; 


    }
   
    
}

console.log(adding(1,2,3)); 
console.log(adding()); 
console.log(adding(2,3,4,"xyz")); 