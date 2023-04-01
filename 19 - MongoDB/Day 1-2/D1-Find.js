
let instructorsArray=[{_id:6,firstName:"noha",lastName:"hesham",
                age:21,salary:3500,
                address:{city:"cairo",street:10,building:8},
                courses:["js","mvc","signalR","expressjs"]},
                
                {_id:7,firstName:"mona",lastName:"ahmed",
                age:21,salary:3600,
                address:{city:"cairo",street:20,building:8},
                courses:["es6","mvc","signalR","expressjs"]},
                
                {_id:8,firstName:"mazen",lastName:"mohammed",
                age:21,salary:7040,
                address:{city:"Ismailia",street:10,building:8},
                courses:["asp.net","mvc","EF"]},
                
                {_id:9,firstName:"ebtesam",lastName:"hesham",
                age:21,salary:7500,
                address:{city:"mansoura",street:14,building:3},
                courses:["js","html5","signalR","expressjs","bootstrap"]}
               
		
		];



db.createCollection("instructors");
db.instructors.insertMany(instructorsArray);
db.instructors.find()

db.instructors.drop()
show dbs

show collections

db.instructors.deleteOne({ _id: 6 });

//6- start create new collection named instructors following with inserts
//a- Insert your own data


//b- Insert instructor without firstName and LastName (mongo will raise an
//error or not ?)

// No Error , mongo db is scheme-less , no specific structure. 
db.instructors.find()
db.instructors.insertOne({
  _id: 1,
  age: 50,
  salary: 10000,
  address: {
    city: "Luxor",
    street: 50,
    building: 12
  },
  courses: ["MongoDB", "ExpressJS"]
});


//c- Using array contained with lab folder instructors.txt file.
//d- BONUS Include data contained in json file (instructors.json) in your lab
//folder using administration mongoimport command
//In Windows Shell

//mongoimport --db ITI --collection instrcutors --file filename.json --jsonArray


//7- Try the following queries: (all queries should be run using find or findOne)


//a- Display all documents for instructors collection ( records are called documents)

db.instructors.find()

//b- Display all instructors with fields firstName, lastName and address

// `1` means to include the specificed field in the returned document 

db.instructors.find({}, { firstName: 1, lastName: 1, address: 1 });


//c- Display firstName and city(not full address) for instructors with age 21.


db.instructors.find({ age: 21 }, { firstName: 1, "address.city": 1 });

//d- Display firstName and age for instructors live in Mansoura city.

db.instructors.find({"address.city": "mansoura"}, {firstName: 1, age: 1})

//e- Try to run these commands
//1-

db.instructors.find()

// 
db.instructors.find({firstName:"mona"},{lastName:"ahmed"},{firstName:
1,lastName:1})

//Explain the output!!


// wrong as we only allowed 2 input paramters (query condition, projection ) 

// it will ignore the 3rd parameter, and prints lastName: "ahmed" even if it's not there
// as we broke the logic I guess 

// correct form is => someone with that first and last name and display on f and l names.
db.instructors.find({firstName:"mona", lastName:"ahmed"}, {firstName:1, lastName:1})


//2- 
//Explain the output!

db.instructors.find()

// looks for who have the course mvc and shows their name and courses 
db.instructors.find({courses:"mvc"},{firstName:1,courses:1})


