// creating a collection 
//db.students.insert()

/* The benfit of using createCollection, is setting up a validation schema*/

/* Bson , was a new type of saving objects when using javaScript.*/
db.createCollection("students", {
    validator:{
        $jsonSchema:{
            bsonType:"object",
            properties:{
                firstName:{ bsonType: "string"}, // I can give it a regular expression instead.
                lastName:{ bsonType: "string"},
                age:{bsonType:"number",maximum:20},
                
            }
        }//json schema
    }// validator
})

// wrong, takes a string
//note: nulls are allowed, we didn't set it as requrired.
db.students.insertOne({firstName:55}) 

// wrong, We sat max age to `20`
db.students.insertOne({firstName:"sara",age:40}) 

// Correct schema rules.
db.students.insertOne({firstName:"sara",age:15}) 

// This will give me data about the schema, to know what is allowed.
db.students.getCollectionInfos({name:"students"})

// If we try to add a new column it will be allowed !! 

// What if we want to add a `new restrication` on the schema we made

// We have it inside the collection, to apply commands on it. 
// Note: this will override !!, so we need to take the same schema and write with it.
// using db.students.getCollectionInfos({name:"students"})

// Note:  as long the `key` doesn't have extra spaces, then "key" is same as key 

db.runCommand({
  collMod: "students",
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["firstName", "lastName", "_id"], // We added id and fname and lname as required.
      properties: {
        firstName: {
          bsonType: "string"
        },
        lastName: {
          bsonType: "string"
        },
        age: {
          bsonType: "number",
          maximum: 20.0
        }
      }
    }
  }
});


db.getCollectionInfos({ name: "students" })


db.students.insertOne({firstName:"tamer"}) 

db.students.find()

db.students.insertOne({}) 



db.runCommand({
  collMod: "students",
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["firstName", "lastName", "_id"], 
      properties: {
        firstName: {
          bsonType: "string"
        },
        lastName: {
          bsonType: "string"
        },
        age: {
          bsonType: "number",
          maximum: 20.0
        }
      }
    }
  },
  validationAction: "error" // This is the second option after `validator`
                              // default is error, we can set it to `warn`
                              
        // Important: `warn` will allow the insert, but it will just warn you !!!    
      
                                   
});


db.students.find()

/* We had to enter all the other columns, because this record is before we added
the restrictions. 
*/
db.students.updateOne({_id:ObjectId("641ea0c4c77c2bf8368c376c")},
{$set:{age:15,firstName:"aya",lastName:"ayman"}})



// Addding moderate 

/* This way we won't mind older data when deleting annd updating. */

db.runCommand({
  collMod: "students",
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["firstName", "lastName", "_id"], 
      properties: {
        firstName: {
          bsonType: "string"
        },
        lastName: {
          bsonType: "string"
        },
        age: {
          bsonType: "number",
          maximum: 20.0
        }
      }
    }
  },
  validationAction: "error" ,

   validationLevel: "strict"   //  strict(default) vs moderate 
                            
});



db.students.find()


// This will give an error while => validationLevel: "strict"
// Because we don't have a lastname for it added before.   
db.students.updateOne({_id:ObjectId("641ea254c77c2bf8368c3771")},
{$set:{firstName:"mona"}})

// This is allowed in => validationLevel: "moderate" 
db.students.updateOne({_id:ObjectId("641ea254c77c2bf8368c3771")},
{$set:{firstName:"norhan"}})




/* using _id to specify an id , but id without `_` is the default id generated
by the engine.. => _id is a must in update or delete. 
*/

/* The syntax of your query is almost correct, but you need to use ObjectId() 
function to create an ObjectId value for the _id field since
 _id field uses ObjectId as its data type in MongoDB. Here's the correct query:
 
*/
db.students.deleteOne({ _id: ObjectId("641ea262c77c2bf8368c3774") })
