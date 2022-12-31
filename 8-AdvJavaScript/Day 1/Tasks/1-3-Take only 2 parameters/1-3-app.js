var adding = function (a,b)
{
    // arguemnt collection
    var sum = 0 ; 
    var numberOfInputs = 2; 

    var err = new Error("You must enter 2 inputs"); 

    if (arguments.length != numberOfInputs)
    {
        throw err; 
    }
    else
    {

        for( var i = 0; i < arguments.length; i++)
        {
            sum += arguments[i]; 
        }

        return sum; 


    }
   
    
}

console.log(adding(2,3)); 
console.log(adding(2)); 
console.log(adding(2,3,4)); 