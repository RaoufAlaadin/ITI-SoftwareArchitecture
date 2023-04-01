// let myMod = require("../Modules/myModule");//{} ==> exports
// // console.log(myMod);//{ AddItem:()=>{}, TotalPrice:()=>{}  }

// myMod.AddItem("Labtop", 20000);
// myMod.AddItem("SmartWatch", 7000);
// myMod.AddItem("HeadPhone", 3000);


// console.log(myMod.TotalPrice());


// let myMod2 = require("../Modules/myModule");

// myMod2.AddItem("Labtop", 20000);
// myMod2.AddItem("SmartWatch", 7000);
// myMod2.AddItem("HeadPhone", 3000);


// console.log(myMod2.TotalPrice());


//import {myClass} from '../Modules/myModule'

const flightTicket = require('../Modules/myModule');//{} ==> exports
// console.log(myClass);//{ myClass: class{} }// 
/**
 * let user1 = new myMod.myClass();
 * let user1 = new myClass();
 */

let alexTicket = new flightTicket('C7', 'MS915', 'CAI', 'HRG', '2023-04-15');

// 1- Display all the info 

console.log("---------------1- Display Info ---------------")
alexTicket.displayInfo();



// 2- Send an object to update all the details. 

console.log("---------------2 - Update info ---------------")

alexTicket.updateInfo({
  seatNum: 'B2',
  flightNum: 'AA456',
  departureAirport: 'JFK',
  arrivalAirport: 'LAX',
  travellingDate: '2023-04-02',
});




/* https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Destructuring_assignment
 

const obj = { a: 1, b: 2 };
const { a, b } = obj;
// is equivalent to:
// const a = obj.a;
// const b = obj.b;

Binding happens when the `property name` have the same `variable name`

even having the same order won't help when using properties I guess...

The variable `MUST` have the same name. 

*/
// The porperty n
alexTicket.updateInfo({departureAirport: "JohnCenaAirport"});



alexTicket.displayInfo();


// 3- Get specfic attrbiute from the data,



//  getInfo() returns an object containing properties,
//  each property holds the value of that attribute in the current instance.
const updatedInfo = alexTicket.getInfo();

// test cases

console.log("---------------3 - Get Specific Info ---------------")

console.log(updatedInfo.departureAirport);


