/* B.1. 
Write two different functions with two different ways of
implementations that 
takes any number of parameters
and returns them as a reversed collection using array’s reverse function.


Note: using of any loop is not allowed 

*/

// apply -- if the borrowed fn needs an input -- the input must be in an array. 


var reverseFn1 = function () {

    console.log("apply"); 
    
    return Array.from([].reverse.apply(arguments)); 

    
}


// call --- if the borrowed fn needs an input, we can insert it using (,)


var reverseFn2 = function () {

    console.log("call"); 
    
    return Array.from([].reverse.call(arguments)); 

    
}

console.log(reverseFn1(1,2,3));
console.log(reverseFn2(4,5,6));



/* array.from ---- calls a method called from that is inside the main array object 
 it's target to transform any object anto an array when you use typeof  */