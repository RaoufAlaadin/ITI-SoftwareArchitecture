/* 2. 

I think box ==> parent 
        book ==> child 

Create your box object that contains books objects, ensure that
you can

a. Create book object and add it to box object content
property.

b. Count # of books inside box

c. Delete any of these books in box according to book title.
Note: You should delete a single copy of the books with the
same title.

d. Create Class Property that counts numbers of created books
objects and Class method to retrieve it.


e. Use .toString() to display the box instance’s dimensions and
how books are stored in it.


f. Implement .valueof() so that if there is more than one box
object we can get total number of books in these boxes by
adding them
                i.e. if box1 has 5 books and box2 has 2 books,
                then box1 + box2 should return 7
Note:
• There is no inheritance
• Using of global variables, Class methods and properties isn’t
allowed.
• Box object has the following properties:
height, width, length, material, content.
o The content property contains an array books
• Book object has the following properties:
title, numofChapters, author, numofPages, publisher,
numofCopies

• You should use accessor and/or data descriptor for defining
properties, and if needed, prevent them from being deleted,
iterated or being modified.

note: same as previoues task 

• you can define any function needed for both box and book
objects */

var box = function (h = 100, w = 200, l = 300, m = "comics") {
  this.height = h;
  this.width = w;
  this.length = l;
  this.material = m;

  // array of books
  // here we will store all the book objects we created.
  this.content = [];

  //research: this is something like a static variable to count
  // the number of object creation

  // 1- static variable inside an IIFE to count objects
  var someFunc1 = (function () {
    var staticVar = 0;

    /* lesson: I am sending a flag to increase or decrease the book objects
        number based on creation or deletion...
        note: we might delete a book copy, but we would still have it's object because 
        we have multiple copies. */
    return function (flag) {






      if (flag === 1)



        console.log(++staticVar);
      if (flag === -1) console.log(--staticVar);
      return staticVar;
    };
  })();

  // 2- variable store the number of created book object itself (copies doesn't matter)
  var countBooks;
  Object.defineProperties(this, {
    // 3- creating an new book object ( if the book already exist, it will add a copy.)
    addBook: {
      value: function (
        t = "The sun",
        n = 5,
        auth = "TamerMorsy",
        num = 200,
        pup = "Ahram",
        noc = 2
      ) {
        /* note: We have to check if the book already exist and we might need to just increase it's copies.
                    this is the point about preventing dublicates. 
                    
                    */

        var flag = 1;
        for (var i = 0; i < this.content.length; i++) {
          if (this.content[i].title == t) {
            this.content[i].numOfCopies += noc;
            flag = -1;
          }
        }

        if (flag === 1) {
          var temp = new book(t, n, auth, num, pup, noc);
          this.content.push(temp);
          countBooks = someFunc1(1);
        }
      },
      writable: false,
      configurable: false,
      enumerable: false,
    },

    // 4- counting number of book objects.
    countBooksObject: {
      value: function () {
        return countBooks;
      },
      writable: false,
      configurable: false,
      enumerable: false,
    },


    // 5- counting all the copies for each book
    countCopies: {
      value: function () {
        var numberOfBooks = 0;
        // var that = this;
        for (var i = 0; i < this.content.length; i++) {
          numberOfBooks += this.content[i].numOfCopies;
          // console.log(`testing the no. ${numberOfBooks}`);
        }

        console.log(`number of books: ${this.content.length}`);
        console.log(`number of books (including copies): ${numberOfBooks}`);

        return numberOfBooks;
      },
      writable: false,
      configurable: false,
      enumerable: false,
    },

    // 6- deleting a copy if found. if not, it will remove the whole object. 
    delete: {
      value: function (bookTitle) {
        for (var i = 0; i < this.content.length; i++) {
          if (this.content[i].title == bookTitle) {
            if (this.content[i].numOfCopies > 1) {
              // removes only one copy.
              this.content[i].numOfCopies--;
              console.log("book [copy] has been deleted");
            } else {
              this.content.splice(i, 1);
              console.log("book deleted");
              countBooks = someFunc1(-1);
            }
          } else {
            console.log("book was not found");
          }
        }
      },
      writable: false,
      configurable: false,
      enumerable: false,
    },
  });
};

//functions: prototypes overriding
//1- toString
box.prototype.toString = function () {
  console.log(
    `Box width: ${this.width}, Height:${this.height},length: ${this.length}`
  );
  console.log(`The book material stored in the box are:  ${this.material}`);
};

//2- valueOf
box.prototype.valueOf = function () {
  return this.countCopies();
};

var box1 = new box();
var box2 = new box(500, 100, 800, "toons");

//note: the default book have numberOfcopies of 2
var book = function (
  t = "The sun",
  n = 5,
  auth = "TamerMorsy",
  num = 200,
  pup = "Ahram",
  noc = 2
) {
  this.title = t;
  this.numOfChapters = n;
  this.author = auth;
  this.numOfPages = num;
  this.puplisher = pup;
  this.numOfCopies = noc;
};

var book1 = new book();
