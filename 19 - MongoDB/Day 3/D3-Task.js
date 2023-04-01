use FacultySystemV2


/* Bson ( Binary Json ) 

    serilized data type like json, but it's used with mongoDB  
*/ 



//1. Create new database named: FacultySystemV2.
//• Create student collection that has (FirstName, lastName,
//IsFired, FacultyID, array of objects, each object has
//CourseID, grade).



db.createCollection("student", {
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["_id", "FirstName", "LastName", "IsFired", "FacultyID", "Courses"], // Required
      properties: {
        _id: { bsonType: "int" },
        FirstName: { bsonType: "string" },
        LastName: { bsonType: "string" },
        IsFired: { bsonType: "bool" },
        FacultyID: { bsonType: "int" },
        Courses: {
          bsonType: "array",
          items: {
            bsonType: "object", // Object inside an object. 
            required: ["CourseID", "Grade"], // Required
            properties: {
              CourseID: { bsonType: "int" },
              Grade: { bsonType: "int", minimum: 0, maximum: 100 }
            }
          }
        }
      }
    }
  }
});

//db.runCommand({
//  collMod: "student",
//  validator: {
//    $jsonSchema: {
//      bsonType: "object",
//      required: ["FirstName", "LastName", "IsFired", "FacultyID", "Courses"], // Required
//      properties: {
//            FirstName: { bsonType: "string" },
//            LastName: { bsonType: "string" },
//            IsFired: { bsonType: "bool" },
//            FacultyID: { bsonType: "objectId" },
//            Courses: {
//              bsonType: "array",
//              items: {
//                bsonType: "object", // Object inside an object. 
//                required: ["CourseID", "Grade"], // Required
//                properties: {
//                  CourseID: { bsonType: "int" },
//                  Grade: { bsonType: "int", minimum: 0, maximum: 100 }
//                }
//          }
//        }
//      }
//    }
//  }
//})





db.student.find()

//• Create Faculty collection that has (Faculty Name,
//Address).

db.createCollection("faculty", {
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["_id", "FacultyName", "Address"],
      properties: {
        _id: { bsonType: "int" },
        FacultyName: { bsonType: "string" },
        Address: { bsonType: "string" }
      }
    }
  }
});

//• Create Course collection, which has (Course Name, Final
//Mark).

db.createCollection("course", {
  validator: {
    $jsonSchema: {
      bsonType: "object",
      required: ["_id", "CourseName", "FinalMark"],
      properties: {
        _id: { bsonType: "int" },
        CourseName: { bsonType: "string" },
        FinalMark: { bsonType: "int", minimum: 0, maximum: 100 }
      }
    }
  }
});
/////////////////////////////////////////
//• Insert some data in previous collections.

db.faculty.find()

db.faculty.deleteMany({})

db.faculty.insertMany([
  {
    _id: 101,
    FacultyName: "Faculty of Science",
    Address: "123 Main St"
  },
  {
    _id: 102,
    FacultyName: "Faculty of Arts",
    Address: "456 Broadway"
  }
]);

//////

db.course.find()

db.course.insertMany([
  {
    _id: 1,
    CourseName: "Math",
    FinalMark: 85
  },
  {
    _id: 2,
    CourseName: "Science",
    FinalMark: 92
  },
  {
    _id: 3,
    CourseName: "English",
    FinalMark: 78
  },
  {
    _id: 4,
    CourseName: "History",
    FinalMark: 91
  }
]);


db.student.deleteMany({})

db.student.find()

db.student.insertMany([
  {
      _id:1,
    FirstName: "Ahmed",
    LastName: "Hesham",
    IsFired: false,
    FacultyID: 101, //science
    Courses: [
      { CourseID: 1, Grade: 85 },
      { CourseID: 2, Grade: 92 }
    ]
  },
  {
       _id:2,
    FirstName: "Mona",
    LastName: "Fahmy",
    IsFired: false,
    FacultyID: 101, //science 
    Courses: [
      { CourseID: 1, Grade: 92 },
      { CourseID: 2, Grade: 88 }
    ]
  },
  {
      _id:3,
    FirstName: "Shady",
    LastName: "Dorgham",
    IsFired: true,
    FacultyID: 102, // arts
    Courses: [
      
      { CourseID: 3, Grade: 83 },
      { CourseID: 4, Grade: 80 }
    ]
  }
]);






//2. Display each student Full Name along with his average
//grade in all courses. $concat

db.student.aggregate([
  {
    $project: {
      FullName: { $concat: ["$FirstName", " ", "$LastName"] },
      AverageGrade: { $avg: "$Courses.Grade" }
    }
  }
])


//3. Using aggregation display the sum of final mark for all
//courses in Course collection.


db.course.aggregate([
  { // we have to use group
    $group: {
      _id: null,
      totalFinalMark: { $sum: "$FinalMark" }
    }
  }
])

//4. Implement (one to many) relation between Student and
//Course, by adding array of Courses IDs in the student object.
//• Select specific student with his name, and then display
//his courses.


db.student.aggregate([
  
  {
    $lookup: {
      from: "course",
      localField: "Courses.CourseID",
      foreignField: "_id",
      as: "newCourses"
    }
    
  },
  { $match: { FirstName: "Ahmed", LastName: "Hesham" } },
  { $project: { _id: 1, FirstName: 1, LastName: 1, newCourses: 1 } }
]);






//4.Implement relation between Student and faculty by adding
//the faculty object in the student using _id Relation using
//$Lookup.
//• Select specific student with his name, and then display
//his faculty



db.student.aggregate([

   
  
  {
    $lookup: {
      from: "faculty",
      localField: "FacultyID",
      foreignField: "_id",
      as: "Faculty"
    }
  },
  {
    $match: {
      FirstName: "Ahmed",
      LastName: "Hesham"
    }
  },
  {
    $project: {
      FirstName: 1,
      LastName: 1,
      Faculty: 1
    }
  }
]);