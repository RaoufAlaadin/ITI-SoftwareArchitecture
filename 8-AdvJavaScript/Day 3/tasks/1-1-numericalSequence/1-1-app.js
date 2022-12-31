/* Note: Make your own interface for the following tasks.


1. Create your own object that contains 
                            a list of numerical sequence,
 with the following details:


1- Your constructor takes 3 parameters to define start, end of
list and step

2- The list should be private and filled with private method

•You can create getter and setter for the list if needed

•Allow the user to apply the following functionality to his
created sequence

        1- Append or prepend a new value

        2- Dequeue or pop a value,

        3- you have to ensure that you are pushing sequential value
            otherwise through exception

        4- you have to ensure that there is no duplicated value
            otherwise through exception.
            

            note: 
            // I think there is no chance for something to be duplicated
            // this would need us to be inserting something in a specfic place.



3- all of the properties should be defined using
 accessor and/or data descriptor,
prevent them from being deleted, iterated or being modified. 
note: prevent deletion ---- configrable = false
        prevent iteration --- enumerable = false 
        prevent value modification -- writable = false 

        
4- Override .toString() function to display a message with all of
the list content.

5- you can add any property you need. 

*/

var err1 = new Error("the value doesn't match the numerical sequance");
var err2 = new Error("The List is Empty !!");

var list = function (st = 0, en = 5, sep = 1) {

    this.start = st;
    this.end = en;
    this.step = sep;

    // 1- the list is private 
    var numericalList = [];


    // 2- we created a private method to fill the array.
    /* it's hard binded to connect to the caller object. */

    var fillArray = (function () {
        var i = this.start;
        for (i; i <= this.end; i += this.step) {
            numericalList.push(i);
            console.log(i); // for testing 
        }

    }).bind(this)

    // 3- we called the private method from inside of the object. 
    // so it start filling the new object as soon as it's created. 
    fillArray();
    console.log("array is filled");

    //4- we created this (Privileged Method) to be able to see the 
    // values of the private list (can be considred a getter)
    this.getList = function () {
        return numericalList;
    }

    


    //lesson: I think i should be accesing the list using the getter
    // as it's private so to ensure encapsulation ?!  

    Object.defineProperties(this, {
        append: {
            value: function (val) {

                // checking that the new value matches the step sequence 
                var size = numericalList.length;
                if (numericalList[size - 1] + this.step !== val) {
                    throw err1;
                }
                else {
                    numericalList.push(val);

                }
            },
            writable: false,
            configurable: false,
            enumerable: false
        }
        ,
        prepend: {
            value: function (val) {

                // checking that the new value matches the step sequence 
                var size = numericalList.length;
                if (numericalList[0] - this.step !== val) {
                    throw err1;
                }
                else {
                    numericalList.unshift(val);

                }
            },
            writable: false,
            configurable: false,
            enumerable: false
        }
        ,
        pop: {
            value: function () {


                // checking if the list is empty 

                if (numericalList.length === 0) {
                    throw err2;
                }
                else {
                    console.log(`The value ${numericalList.pop()} has been removed from end`);

                }

            },
            writable: false,
            configurable: false,
            enumerable: false
        }
        ,
        deQ: {
            value: function () {
                // checking if the list is empty 
                if (numericalList.length === 0) {
                    throw err2;
                }
                else {
                    // we could have used (shift) also  ..... and (unshift) is used for adding at the start -- we used that at the (prepend) property 
                    console.log(`The value ${numericalList.splice(0, 1)} has been removed from start`);
        
                }
        
        
            },
            writable: false,
            configurable: false,
            enumerable: false
        }
        // ,
        // toString: {
        //     value: function () {
        //         return this.getList();
        //     },
        //     writable: false,
        //     configurable: false,
        //     enumerable: false
        // }
    });

   /* note:  this is incorrect syntax , we can't use the prototype keyword
    inside the function here, search more !!! 
   
    using (prototype) is like creating a property with that name
    because the object instance will be already made 
    so the inheritance will be done !! 

    https://stackoverflow.com/a/16174070/19319830

   this.prototype.toString = function () {
        return this.getList();
    }
 */
}

// this is a correct way of overrriding. 
list.prototype.toString = function () {
    return this.getList();

}



var list1 = new list(0, 10, 2);
var list2 = new list(1, 9, 3); 