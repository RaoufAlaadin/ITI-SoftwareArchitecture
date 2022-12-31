/* A.1. 

Make your own custom Object that simulates the linked list
that accepts objects with a 
    1-single numeric property value in
    2- ascending order. 
    
    Let your object has the following functionalities
    Todo:
    1- Enqueue a value as long as the value is in the sequence
    otherwise through an exception (push an item at the end of
    the list with the passed value).


    2-Insert an item in a specific place
     as long as the (value) is missing from the sequence otherwise through an exception.

    3- Pop a value (remove an item from the end of the list).

    4-Remove an item from a specific place with the required
        value, if the value is not added return a message with “data
        not found”.
    5- Dequeue a value (remove an item from the beginning of the
        list).
    6-  Display the content of the list.
    
    
    Note: Ensure that there is no duplication in your entered values.
    • You can add any property you need.
Note: Use Array Object methods and there is no need to use
sort() function.
 */

/* var obj = {
    newProp: "val",
    age: 15,
    propObj: {
        color: "green",
        model: "abc"
    },
    disp: function () {
        console.log(this.objName); //caller object
    },
    show: show
}; 


see how propObj 


// this tutorial is helpful 
https://www.freecodecamp.org/news/javascript-array-of-objects-tutorial-how-to-create-update-and-loop-through-objects-using-js-array-methods/


*/

var err1 = new Error("the value doesn't match the Ascending sequance");
var err2 = new Error("The value is repeated");
var err3 = new Error("The LinkedList is Empty !!");
var err4 = new Error("data was not found");
var err5 = new Error("your index is out of range");








var linkedListObj = {

    data: [],
    //note:1
    pushVal: function (obj) {
        /* push at the end of the list, 
            as long as it meets the sequence !!
            if not then throw alert */
        // this.data.push(5); 

        if (this.data.length == 0) {
            this.data.push(obj);
        }
        else {
            /* lesson:
               I think there is an array method that can find the last array element
               in a cleaner way */

            if (obj.val < this.data[this.data.length - 1].val) {
                throw err1;
            }
            else {
                this.data.push(obj);

            }

        }


    },

    //note:2
    insertVal: function (obj, index) {
        //insert in a specific place , as long it's not duplicated


        var arrLength = this.data.length;

        //1- for the first value 
        if (arrLength == 0) {



            this.data.splice(index, 0, obj);

        }

        // 2- for adding a value at the end ( the empty spot)
        else if (arrLength == index) {
            if (this.isDuplicate(obj)) {
                throw err2;
            }
            // we compare the new value with the old ending 
            if ((this.data[index - 1].val) < (obj.val)) {
                this.data.splice(index, 0, obj);

            }
            else {
                throw err1;
            }


        }

        // 3-  if the index is in the middle 
        else {
            // out of range check 
            // we only used it here as the previous condition already had an index check. 
            if (index > arrLength || index < 0) {
                throw err5;
            }


            if (this.isDuplicate(obj)) {
                throw err2;
            }
            else {


                if ((this.data[index].val) > (obj.val)) {
                    this.data.splice(index, 0, obj);
                }
                else {
                    throw err1;
                }


            }



        }


    },
    //note:3
    popVal: function () {

        //remove a value from the end of the list  
        // throw an error if it's empty. data.length



        if (this.isEmpty()) {
            throw err3;
        }
        else {

            console.log(this.data.pop());

        }

    },
    //note:4
    removeVal: function (obj,index) {
        // remove from a specific place, if no value is find give an error
        // error 4 
        if (this.isDuplicate(obj))
        {
            this.data.splice(index,1);
        }
        else{
            throw err4;
        }
        
    },

    //note:5
    dVal: function () {

        // if (this.isEmpty)
        // {
        //     throw err3; 
        // }
        // else{
            
        // }
        this.data.splice(0,1);
        
            

    },

     //note:6
     display: function () {
        
        // if (this.isEmpty)
        // {
        //     throw err3; 
        // }
        // else{
           
        // }

        for ( var i = 0; i < this.data.length; i++)
        {
            console.log(this.data[i]);
        }

     },

    //functions: Extra functions for checks
    isDuplicate: function (obj) {
        return (this.data.some(function (e) {
            return e.val === obj.val;
        }))

    },
    isEmpty: function () {
        return (this.data.length === 0)
    },





}


var v1 = {
    val: 1
};

var v2 = {
    val: 2
};
var v3 = {
    val: 3
};
var v4 = {
    val: 4
};
var v5 = {
    val: 5
};


var v6 = {
    val: 6
};









/* var my_object = {key1: "value1", key2: "value2"};
console.log(my_object.key1);

var my_array = ["value1", "value2"];
console.log(my_array[0]);

var my_compound = {a: [{b: "c", d: [0, 1, 2]},
                       {b: "e", d: [3, 4, 5]}]};
console.log(my_compound.a[1].d[0]);  // => 3
console.log(my_compound["a"][1]["d"][0]);  // same thing, perhaps more readable? */