







/* 1) Create your own function that accepts multiple parameters to
generate course information and display it. 

Assume that the function accepts course information as object that contains
courseName, courseDuation, courseOwner.
if any of required field is not set in function call it should have
default values as follows: 
courseName=”ES6” ,
courseDuration=”3days”,
 courseOwner=”JavaScript”.
Bonus: through exception if passed object includes properties
other than those described above
Note: user is allowed not to pass all of these properties, he can
pass needed properties only */



function generateCourseInfo(obj) {


    /* So we decalred a default object inside the function, 
        now we need to declare object.assign, to let it create a mix 
        of what is given and what is needs to be used from the default. 
        
        also note that: it will also handle other inputs that we didn't want
        but we need to give a warning if the input was like that. 
        */
    // assign(target,source) works on enumrable , which is objects.

    //and source is like a param where we can enter as much as we like.


    var defaultObj = {
        courseName: "ES6",
        courseDuration: "3days",
        courseOwner: "JavaScript"


    }


    /* Note: 
    
    We have to enclose our whole code with the try, 
    to prevent it from continuing when an Error is thrown. 
    
    if we only enclose the (for..in) then we would get the error.msg 
    but the return string will still be displayed.  
    */
    try {

        for (const key in obj) {

            /* sending a key from the obj 
                if it works with the defaultObj and return true for having
                the property.
            the both of them have the same property. 

            It's like using the same key for 2 doors, 
            It doesn't matter what is behind the doors(values)
            what matter is the key. */
            if (!defaultObj.hasOwnProperty(key)) {
                // const element = object[key];
                throw new Error("Object had extra properties,Be caraeful!");
            }
        }

        var result = Object.assign({}, defaultObj, obj)
        return `
                courseName: ${result.courseName}, 
                courseDuration: ${result.courseDuration},
                courseOwner: ${result.courseOwner}
    
            `

    } catch (error) {

        /* using console.error, will display it in red as an error msg.
            I don't know why autocomplete wasn't working for this one. */
        console.error(error.message);

        /* we wrote this return 0, as every function needs a return path.
        if we do not write it, the function will return undefined 
        on it's own.
        it's just better visually to return something you 
        about.  */


        return 0;
    }


}


console.log(" ============== Task1: Pass an Object, Test Defaults. ============")
// test-1- normal object
var obj = {
    courseName: "StoredProcedures",
    courseDuration: "7days",
    courseOwner: "Database",
}

console.log(generateCourseInfo(obj));
// test-2 - object missing an input 
var obj = {
    courseName: "StoredProcedures",
    courseDuration: "7days",

}

console.log(generateCourseInfo(obj));
// test-3 - object that has extra parameter => throw exception. 
var obj = {
    courseName: "StoredProcedures",
    courseDuration: "7days",
    courseOwner: "Database",
    studentAge: "5"
}

console.log(generateCourseInfo(obj));




/* 
2) Create a generator that returns fibonacci series that takes only
one parameter. Make two different implementations as
described below:

a.the parameter passed determines the number of elements
displayed from the series.
b.the parameter passed determines the max number of the
displayed series should not exceed its value. */



function* fibonacci(x,flag) {


    let [prev, curr] = [0, 1];
    let i = 0; 

    switch (flag)
    {

        case 1:

        console.log(`number of elements will be: ${x}`);
        while (i < x) {
                yield curr;
                [prev, curr] = [curr, prev + curr];
                i++;
        }
        break;


        case 2: 

        console.log(`Max value that we should not pass is: ${x}`);
        let max = x; 
        i = 0; 
        while (curr < max) {
                yield curr;
                [prev, curr] = [curr, prev + curr];
                i++;
        }
        break;

    }  

    
}

console.log(" ============== Task2-1: number of elements ============")

  // 1- number of elements displayed from the series 
  let sequence1 = fibonacci(10,1);

  for (const iterator of sequence1) {
    console.log(iterator);
  }

console.log(" ============== Task2-1: Max value ============")


  // 2- Max value that we should not pass. 

  let sequence2 = fibonacci(20,2);

  for (const iterator of sequence2) {
    console.log(iterator);
  }

  //note: using the spread operator will call .Next() implicitly
  // which remove the need for using the (for..of)
//   console.log([...sequence1]);
//   console.log([...sequence2]);

//   console.log(sequence.next().value); // 1
//   console.log(sequence.next().value); // 1
//   console.log(sequence.next().value); // 2
//   console.log(sequence.next().value); // 3








// 3) create your own object that has [Symbol.replace] method so
// that if any long string (e.g. its length exceed 15 characters )called
// replace and pass your object as replace method parameter it will
// display only 15 character of string with terminating “…”


// 1- override the main sterin


/* https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp/@@replace */

console.log(" ============== Task 3: override the .replace() ============")

const TruncateString = {
    [Symbol.replace](string) {
      return string.length > 15 ? string.substring(0, 15) + "..." : string;
    }
  };

  /* 
  
  TruncateString will hold an override for the .replacMethod
  if I pass it's object, then the .replace will be have like the function
  Inside the object. 
  
  if u pass RegEx like usual, then the method will act normally. 
  
  this way you didn't lose the original functionalty of the method.
  
  it's like delegates, the method will behave based on the object sent 
  to it. 
  
  */
  
  let longString = "Hello from the vip room of the iti";
  let shortString = "Hello there";
  
  console.log(longString.replace(TruncateString));  
  console.log(shortString.replace(TruncateString));  





// 4) Create an iterable object by implementing @@iterator method
// i.e. Symbol.iterator, so that you can use for..of and retrieve its
// properties.
// Bonus: make proper updates to retrieve the object’s properties
// and its values.

console.log(" ============== Task4- iterater over an object ============")


console.log(" ============== using Generator function ============")

// using a genrator function
let iterableObj1 = {
    
    prop1: 'Welcome',
    prop2: 'To',
    prop3: 'Morocoooo',

    genFun: function* () {
        // we point at our current object using this
        // and using for..in will get us his keys
        // passing the key to the object's index brackets 
        // will return the values. 
        for (let key in this) {
            if ( key != "genFun") // this prevent us from printing the fn. itself.
           yield this[key];
        }
     }
 };
 

 // passing a refernce to a gen function to a for..off
 // will automatically call .next() until it ends 
 for (let value of iterableObj1.genFun()) {
    console.log(value);
 }










 console.log(" ============== using symbol.iterate ============")



let iterableObject2 = {

    name: "FAVA BEANS ",
    age: "500",
    location: "Egypt",
    [Symbol.iterator]: function() {
      let i = 0;
      let properties = Object.keys(this);
      return {
        next: () => {

          if (i < properties.length) {
            return {

              // we have to increas the counter in the second parameter not the first
              // else a weird shifting happens. 
              value: [properties[i], this[properties[i++]]],
              done: false
            };
          }
          return {
            done: true
          };

        }
      };
    }
   
  };
  
  for (const [key, value] of iterableObject2) {
    console.log(`${key}: ${value}`);
  }




