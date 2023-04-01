

/* Important Note: 

By the way we are assigning the class to exports,
We are making it the one and only object that is going to be exported
from the current module.

*/
module.exports = class FlightTicket {
    // The constructor method
    constructor(seatNum, flightNum, departureAirport, arrivalAirport,travellingDate) {
      // Assign the parameters to the properties
      this.seatNum = seatNum;
      this.flightNum = flightNum;
      this.departureAirport = departureAirport;
      this.arrivalAirport = arrivalAirport;
      this.travellingDate = travellingDate;
    }
  
    // The displayInfo method
    // It prints the information of the ticket to the console
    displayInfo() {
      // Use template literals to format the output
      console.log(`Seat number: ${this.seatNum}`);
      console.log(`Flight number: ${this.flightNum}`);
      console.log(`Departure airport: ${this.departureAirport}`);
      console.log(`Arrival airport: ${this.arrivalAirport}`);
      console.log(`Travelling date: ${this.travellingDate}`);
    }
  
    // The getInfo method
    // It returns an object containing the information of the ticket
    getInfo() {
      // Use object literal shorthand to create the object
      return {
        seatNum: this.seatNum,
        flightNum: this.flightNum,
        departureAirport: this.departureAirport,
        arrivalAirport: this.arrivalAirport,
        travellingDate: this.travellingDate,
      };
    }
  
    // The updateInfo method
    // It takes an object as a parameter and updates the properties of the ticket accordingly
    updateInfo(newInfo) {
      // Use object destructuring to get the properties from the parameter
      const {
        seatNum,
        flightNum,
        departureAirport,
        arrivalAirport,
        travellingDate,
      } = newInfo;
      // Use conditional statements to check if the properties are defined and valid
      // If yes, assign them to the corresponding properties of the ticket
      if (seatNum && typeof seatNum === "string") {
        this.seatNum = seatNum;
      }
      if (flightNum && typeof flightNum === "string") {
        this.flightNum = flightNum;
      }
      if (departureAirport && typeof departureAirport === "string") {
        this.departureAirport = departureAirport;
      }
      if (arrivalAirport && typeof arrivalAirport === "string") {
        this.arrivalAirport = arrivalAirport;
      }
      if (travellingDate && typeof travellingDate === "string") {
        this.travellingDate = travellingDate;
      }
    }
  };

//   console.log ( module.exports)
//   console.log ( exports)
//   console.log("hello")
