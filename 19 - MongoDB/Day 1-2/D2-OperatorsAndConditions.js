
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


db.instructors.insertOne({_id:10,firstName:"mazen",lastName:"ahmed",
                age:21,salary:7040,
                address:{city:"Ismailia",street:10,building:8},
                courses:["asp.net","mvc","EF"]})






use ITI

//1- run following queries on instructors collection:
//a- Display all documents in instructors collection ==> use query filters

db.instructors.find();

//b- Display all instructors with salaries greater than 4000 (only show
//firstName and salary)

db.instructors.find({salary:{$gt:4000}},{firstName:1 , salary:1});



//c- Display all instructors with ages less than or equal 25.
// lte => lower than or equal 
db.instructors.find({age: {$lte: 25}})
//d- Display all instructors with city mansoura and sreet number 10 or 14
//only display (firstname,address,salary).

db.instructors.find({$and: [{"address.city": "Mansoura"}, 
    {$or: [{"address.street": 10}, {"address.street": 14}]}]}
    , {firstName: 1, address: 1, salary: 1})
//e- Display all instructors who have js and jquery in their courses (both of
//them not one of them).

db.instructors.find({courses: {$all:["js", "jquery"]}}) // we don't have these courses

//f- Display number of courses for each instructor and display first name
//with number of courses.


// method-1

// note: important to use exists, to avoid using length on undefined. 

db.instructors.find({courses:{$exists:true}}).forEach(ins=>{
    print(`${ins.firstName} , courses: ${ins.courses.length}`)
})

// method-2 => inside the table 

// using aggregate allows multiple query filters, project columns and inside of it is $size.
db.instructors.aggregate([{
    $project:{
    firstName :1 , numberOfCourses :{$size:"$courses"}}
    }])

//g- Write mongodb query to get all instructors that have firstName and
//lastName properties , sort them by firstName ascending then by
//lastName descending and finally display their data FullName and age
//Note: use mongoDb sort method not javascript array method

// note that =>  it's case sensitive so `A = 65 `.. is smaller than `a =97` 
// which will show when sorting asc => A ~ a .... desc => a ~ A 
db.instructors.find({
    firstName :{$exists:true},lastName :{$exists:true}  // exist check
    }).sort({firstName :1 , lastName :-1}). // sorting => asc 1 // desec -1
    forEach(doc => {
    print("FullName:"+doc.firstName+" "+doc.lastName+", Age:"+doc.age);
    
    });
    
    
//BONUS: create new collection with step g values data and name it
//instructorsData


//h- Find all instructors that have fullName that contains “mohammed”.


db.instructors.find();

db.instructors.find({$or:[{firstName:"mohammed"},{lastName:"mohammed"}]})

//i- Delete instructor with first name “ebtesam” and has only 5 courses in
//courses array

db.instructors.find();

db.instructors.deleteOne({firstName :"ebtesam",courses :{$size:5}});


//j- Add active property to all instructors and set its value to true.

db.instructors.find();
db.instructors.updateMany({},{$set:{active:true}});
//
//k- Change “EF” course to “jquery” for “mazen mohammed” instructor
//(without knowing EF Index)

// using the positional operator => $ 

db.instructors.find();
db.instructors.updateOne(
    { firstName: "mazen", lastName: "mohammed", courses: "EF" },
    { $set: { "courses.$": "jquery" } }
)

//l- Add jquery course for “noha hesham”.

db.instructors.find();
db.instructors.updateOne(
   { firstName:"noha",lastName:"hesham" },
   { $push:{courses:"jquery"}} // add to the array
);

//m- Remove courses property for “ahmed mohammed ” instructor

db.instructors.updateOne(
   { firstName:"ahmed",lastName:"mohammed" },
   { $unset:{courses:""}}
);

//n- Decrease salary by 500 for all instructors that has only 3 courses in their
//list ($inc)

// $inc can be used as increament or decremeant based on the sign used. 

db.instructors.updateMany({courses: {$size: 3}}, {$inc: {salary: -500}});

//o- Rename address field for all instructors to fullAddress.

db.instructors.find();
db.instructors.updateMany({}, {$rename: {"address": "fullAddress"}})

//p- Change street number for noha hesham to 20

// beware of this trick =>  we had to use fulladress instead of adress because we re-named it 
db.instructors.updateOne({firstName: "noha", lastName: "hesham"}, {$set: {"fullAddress.street": 20}})

