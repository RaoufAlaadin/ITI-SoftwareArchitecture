/* alert("Hello world");
console.log("Hello World");
console.error("This is an error"); */

// strings , Numbers, boolean , null , undefined

const name = "Raouf";
const age = 30; 
const rating = 4.5;
const isCool = true; 
const x = null; 
const y = undefined; 
let z; 


console.log(typeof x);

// concatenation

    // old bad way 
    console.log("My name is " + name + " and I am " + age)

    // new way (Template literals) used to be called Template strings. 

    const hello = `my name is ${name} and I use Template literals.`;
    console.log(hello);


// string properties. 

// properties don't have (), if it has one.. then it's a method !!!. 
// length is a property. 
// toUpperCase() is a method. 

const s = "Hello world"; 

/*  Everything below is working because the interperter figured out (s) type
    as a string. 
    And so it started using properties and methods of the string */
console.log(s.length);
console.log(s.toUpperCase());
console.log(s.toLowerCase());

// substring(,) === gets us a subString from the full string, 
//from the starting to ending indecies that we choose.   
console.log(s.substring(0,4).toUpperCase());
document.write(s.bold()+"<br>");

document.write(`endpicks ${s.sup()} <br>`)
document.write(s.strike()); 





    


