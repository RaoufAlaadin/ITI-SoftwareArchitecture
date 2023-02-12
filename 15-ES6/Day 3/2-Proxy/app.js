


/* 2) Proxy


create a dynamic object using Proxy such that it has only the
following properties


 name property that accepts only string of 7 characters


 address property that accepts only string value


 age property that accepts numerical value between 25 and
60 

*/


/*  Reflect is a built-in object that provides methods  

*/

var myObj = {

}

var handler = {

  set(target,prop,value)
  {
    switch(prop)
    {
      case "name" : 
      if( value.length == 7  && value.match("^[a-zA-Z]+$"))
        target[prop] = value; 
      else
        console.log("Invalid name");
      break;

      case "address":

      if( value.match("^[a-zA-Z]+$"))
        target[prop] =value;
        else
        console.log("Invalid Address");
      break;

      case "age" :
      if( value.match("^[0-9]+$") && parseInt(value) > 25 && parseInt(value) < 60 )
      target[prop] =value;
      else
      console.log("Invalid Age");

      break;


    }

  },
  get(target,prop)
  {
    if( target.hasOwnProperty(prop))
  /*  we are dealing with an object.. 
      so the we used target (object name)
      prop(which is the property key) as an index
      and this will return the value.     
  */    
      return target[prop]; 
      else
      console.log(`Invalid request, property does not exist`);
      return 0; 

  }

}

var myProxy = new Proxy(myObj,handler)


console.log("============ Testing Outup ========= ")

/////////////////////////////////////
console.log("==================== Name  ========= ")

console.log("--------- wrong name - less than 7 -----")

myProxy.name = "helloM";
console.log(myProxy.name);

console.log("-------------correct name ----------")

myProxy.name = "helloMy";
console.log(myProxy.name);

//////////////////////////////////////

console.log("==================== Address  ========= ")

console.log("--------- wrong address - have numbers -----")

myProxy.address = "Alexandria 231";
console.log(myProxy.address);

console.log("-------------correct address ----------")

myProxy.address = "Alexandria";
console.log(myProxy.address);

////////////////////////////////

console.log("==================== Age   =============== ")

console.log("--------- wrong age - over 60 -----")

myProxy.age = "80";
console.log(myProxy.age);

console.log("--------- wrong age - less than 25 -----")

myProxy.age = "15";
console.log(myProxy.age);


console.log("-------------correct age ----------")

myProxy.age = "40";
console.log(myProxy.age);