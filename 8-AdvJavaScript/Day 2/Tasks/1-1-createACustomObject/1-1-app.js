/* A.1. Create your own custom object that has 
getSetGen as a function value, 
this function should generate
setters and getters for the properties of the caller object


This object may have a description property of string value if
needed

Let any other created object can use this function property to
generate getters and setters for its own properties.


Avoid generating getters or setters for any property of function
value

Hint:
if getSetGen() is applied on any other object it should generate
getters and setters for all of the applied object properties
i.e. if you have the following object

obj = {id:”SD-10”,location:”SV”, addr:”123 st.”, getSetGen:
function(){/*should be implemented*-/ }}  note: I added that - so the block comment can work  

using of getSetGen() will generate the following getId(), setId(),
getLocation(), setLocation(), getAddr(), setAddr().
If you created the following object
var user = { name: ”Ali”, age:10}
When applying getSetGen() on the user object (you can use call
or bind or apply), it will result in creating the following:
getName(), getAge(),setName(),setAge() 

*/


var obj = {
    id: "SD- 10",
    location: "SV",
    addr: "123 st.",
    getSetGen:
    function () {
        var self = this; 
        for ( var i in this)
        {       // note how we have () around the fn for it to excute
                // and we insert the i to it to prevent it from changing. 

            /* lesson: 1- we have () around the annoynmous function for it to excute. 
                       2- we used the annoynmous function and input (i) in the first place
                            becuase of the IFFE design patter
                        if not => the value of (i) used for all the function excutions
                        will be the last value of (i) only 
                        
                        3- check the lecture again, as someoen asked what if we tried without it. 
                        
                        4- object.deefineProperty() gives us more control on the properties 
                            that we assign. 

                        https://www.freecodecamp.org/news/execution-context-how-javascript-works-behind-the-scenes/
                        
                        https://stackoverflow.com/a/111111/19319830
            */
                    
            (function (i) {

                if ( typeof(self[i]) !== "function")
                {   
                    console.log(typeof(i));
                    Object.defineProperty(self,`get${i}`,{
                        value: function ()
                        {
                            return self[i]; 
                        }
                    })
                    Object.defineProperty(self,`set${i}`,{
                        value: function (val)
                        {
                            self[i] = val; 
                        }
                    })
                } 

            }(i))
           
        }
        
    }
}



/* function User(properties) {
    var t = this, i;
    for (i in properties) (function (i) {
        t['get' + i] = function () { return properties[i]; };
        t['set' + i] = function (val) { properties[i] = val; };
    }(i));
}
 */


var user = { 
    name: "Ali", 
    age: 10, 
    father: function () { 
        console.log ( " here is the dad "); 
    }
}

// console.log(obj.getSetGen.call(user) );

/* Object.defineProperty(obj,"wife", {
    value: function nesma ()
    {
        console.log (this.name);
        console.log("make your breakfast");
    }
})

obj.wife.call(user);
 */