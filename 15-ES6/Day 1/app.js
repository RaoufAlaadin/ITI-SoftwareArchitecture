







// 1) Swap the values of x and y using destructuring

console.log(`================ Task 1 - Swap ================`);




// We will use destructing. 
    var x = 5, y = 10;

    console.log(`Value of X: ${x} ,, Value of Y: ${y}`);

// ==> our new assigned variables = array or object the hold the previous values
    var [x, y] = [y, x];  

    console.log(`Value of X: ${x} ,, Value of Y: ${y}`);



// 2) Using rest parameter and spread operator return min and max
// value from any array passed to function call and display each of
// them separately after function call
// note: array length is not fixed



 /* Importnat Notes:
 
 we have to use the rest dots (...param) in the input also.
 Even if we don't have any other exact input parameters beside the param. 
 */

console.log(`================ Task 2 - Max and Min in ES6 ================`);

function myFun (...param)
{
    /* 
    https://medium.com/@vladbezden/how-to-get-min-or-max-of-an-array-in-javascript-1c264ec6e1aa#:~:text=max()%20function%20returns%20the%20largest%20of%20zero%20or%20more%20numbers.&text=of%20Math%20object-,The%20Math.,of%20zero%20or%20more%20numbers.&text=The%20destructuring%20assignment%20syntax%20is,or%20objects%20into%20distinct%20variables.
    Math.min or max doesn't accpet arrays,
        it only takes comma sperated values to compare them
    so by using the spread from ES6 ( those 3 dots ...)
     We will be able to extract the data into this format (1,2,3,4) 
     */
    var max = Math.min(...param);
    var min = Math.max(...param);

    return[ min,max];
}

// using destructing we will separate the values.
var [min,max] = myFun(1,2,3,4,5);


console.log(`min value is: ${min}, max value is: ${max} `);

// 3) Study new array api methods then create the following methods
// and apply it on this array

console.log(`================ Task 3 - ES6 Array methods ================`);

var fruits = ["apple", "strawberry", "banana", "orange",
"mango"];



// a. test that every element in the given array is a string

// it takes a test function, and we usually pass 
// on a lamda expression. 


console.log(fruits.every(ele => (!isFinite(ele))));

// b.test that some of array elements starts with "a"


console.log(fruits.some(ele => (ele.startsWith("a"))));




// c. generate new array filtered from the given array with only
// elements that starts with "b" or "s"

/* filter ==> tests if elements meet a certain conditon. 
    if yes ==> it will add those elements to the new array. 

    map =>  applies something to each element of the array
and create a new array using that and it takes a test fn.  
*/

var fruitsEdited = [];

fruitsEdited = fruits.filter( ele => (ele.startsWith("a") || ele.startsWith("b")))

console.log(fruitsEdited);

// d.generate new array, each element of the new array contains a
// string declaring that you like the give fruit element

var fruitsLover = [];

fruitsLover = fruits.map ( ele => (`I like ${ele}`));

console.log(fruitsLover)

// e.use forEach to display all elements of the new array from
// previouse point

fruitsLover.forEach(element => {
    console.log(element)
});