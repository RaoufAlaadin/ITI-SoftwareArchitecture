/* In the code you provided, ObjectId is a helper function in MongoDB that converts a string to an ObjectId. 
So ObjectId("641ea0c4c77c2bf8368c376c") is used to convert the string "641ea0c4c77c2bf8368c376c" 
to an ObjectId, which can be used as the value for the _id field in a MongoDB query.
*/

// Embedding Documents ( bad )

/* 3 problems => 

1- 
2-
3- ...with every update
*/

// Referencing Documents 

/* 

remember: each record is called ==> document 


Employee document

{    _id: 1, 
    name: "Eman",
    department_id:3  // referenced another object.
}


Department document
{
    
    _id:3,
    name:"SD"
    phone:"01234",
    email:asdas@gmail.com

}

*/


// is it logical to save all the courses every person takes ? nope
// All SD track students study the same courses !! 
// Here it's better to use referencing instead of Embedding. 


/* 
    1- 
    
    Instructor --- address 
     one ---- one 
     ? ==>  it's better to be embded, it's not something common between Instructors.
     
     What if an Instructor have `many Addresses`??
     
     2-
     
     Instructor -- address 
     one --- many 
     
     inst {id, name ,, addresses:[{},{}] } 
     
     ? ==> Still better to be embded 
     
     3-
     
     Student -- dept
     one -- many
     
     if `Embeded` 
             --> 
             
             1- stud(id,,,dept:{name,phone,,,}}
             // We will have to inset all the department data inside each student
             
             2- dept(id,,,students"[{},{}.......]
             // This is worse as we would have to add all the students with all of their details
             // This is sooo bad ,, case 1 is less bad.
             
             
      if `ref` 
      
      => This is better, but it's not suitable for reading alot.
      
      stud(id,,,dept_id:1)
      dept(id,,,,,)
      
      
      ***** Best choice *****
      
      Ref + Embded 
      
      students(id,,,dept:{name,_id})
      
      1- We embded the data we need the most => name 
      2-included a ref to the original object for further reading `if needed`
      => _id     
      
      /// Summary 
      This using the _id and reading the whole `dept object` 
      if you only needed the name (solved ref problem),
      and at the same time saved us space from including the whole dept object
      inside of each student ( solved embded problem)
     
     

*/


/*  // Creating a non-clustred index 


 title: "c#" 

 - All the data are ordered by the order they are insered in ....
 // based on `title` not _id 
 // The index connects us to the rest of the object.
 
     A,B                 C,D        H
  title: Angular        C#         html ....
 
 
 _id: 1  ... _id: 1001   _id: 2001
 _id:1000    _id:2000   _id: 3000 
 
 
                     title:Angular ====>  this means we go to the path related to C# 
                     /       \
                    /         \
                Angular      Html 
                C# 
               /    \
              /      \
            A,B        C,D
            /            title: C# 
           /
       title: Angular 
       
       // We reached our goal in less steps
       // This is the benfit of indexing.    
                     
 

 

*/

typeof db.students.findOne() // This returns an object. 



use library

db.books.insertMany([
  {
    title: "MongoDB: The Definitive Guide",
    author: "Kristina Chodorow",
    subject: "MongoDB",
    language: "English"
  },
  {
    title: "C# 9 and .NET 5 - Modern Cross-Platform Development",
    author: "Mark J. Price",
    subject: "C#",
    language: "English"
  },
  {
    title: "Angular in Action",
    author: "Jeremy Wilken",
    subject: "Angular",
    language: "English"
  },
  {
    title: "HTML and CSS: Design and Build Websites",
    author: "Jon Duckett",
    subject: "HTML",
    language: "English"
  }
])

db.books.find()

/* Important note:  `background:true` => will allow the creation on index column
                    In the background, without blocking other services that are
                    trying to use our database !! 👍*/
db.books.createIndex({title:1},{name:"TitleName",background:true})


/* using .explain() will show us details on which index was 
   used for our search
*/
db.books.find({title:"MongoDB: The Definitive Guide"}).explain()

/* Note: Index can be also created in MongoDB compass software,

If we have multiple indexes, the engine will choose what is suitable for it. 
*/



/* 
    Rembemr: 
    // We used to do the following in SQL 
    
    select cust_id, sum(amount) as value 
    from orders 
    where status = "A" 
    groupby cust_id 
    
    //// Deprecated !!!!! => do not use mapReduce
    db.orders.mapReduce ( 
        function() { }
        .....
    )
    
    
    /// We currently use Aggregation function,
    // It serves the same purpose by having stages that
    // deliver to each other. 
    */
    
    
    
    /* using Aggregation => 
    1--   
        
    $match
    
        
        {
          subject: "C#"
        }
            
     2--   
       $group 
    
                {
              _id: "$Cat", // key of grouping // Cat category
              // fieldN: {
                // accuexpressionNmulatorN: 
              totalPages:{  
                $sum: "$Pages"
              }
            }
            
       3--
        $project 
        
                {
          // names must be exact
          _id:0,
          "CategoryName":"$_id", // new column based on ID
          "totalPages": 1,
          // fullName: {$concat:[$firstName,"",$lastName]}
          // Would have been useful in D2-task 
}
       4--
       
       {
          categoryName: -1  // or 1 for ascending
       }
          
      5--   
        $out 
        
        'AggCatTotal'


        // By pressing `Run`, It will create a new 
        // collection
        
        /// *Important note* ==> 
            Inserting documents in the new collection that has been created, 
           Will generate id', despite we removed the id's of the original collection.
    
    */

//note:  books I created is missing columns from the lecture one.
db.books.aggregate([{
    $match:{Borrow:true},
    },
    {
        $group:{_id:"Cat",
        PagesAvg:{$avg: "$Pages"}}
    },
    {
        $project: {_id: 0, PagesAvg:1,"CatName":"$_id"}
    },
    {
        $sort:{
            CatName:-1
        }
    },
    {
        $out:"CatAvg"
    }

])

/////////////////////////////////


use ITI

// sum people in the same city and over 21 

db.instructors.aggregate([
{
    $match:{age:{$gt:21}}
    
},
{
    $group:{
        _id:{age:"$age",city: "$address.city"},
        count: {$sum:1} // Can be created in a different stage if needed. 
            }  
},
 
 {
     
     
 }

])


// Lookup is really important

// array from .txt 

db.departments.insertMany(array)

db.students.find()


db.students.aggregate([{
    $lookup:{
        // join betwen it and dept.
        
        from: "departments", // second collection to join. 
        // the field that has the matching primary key
        // same as `join on`
        localField: "department" ,
        foreignField:"_id",
        as:"dept"   // combined data of department in dept column       
    }
}])

// unwind

db.students.find({})


// Atlas


// Remember to save the password


// REDIS (In-memory data Store) 

/* it's a no-sql database but it's still really different 

everything it takes is key,value pair, it's like a huge gaint object.

stores everything on the Ram ===> Really fast 


*/
