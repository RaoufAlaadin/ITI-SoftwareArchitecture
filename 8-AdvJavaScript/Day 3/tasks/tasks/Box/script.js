var Book = function (
    _title,
    _numOfChapters,
    _author,
    _numOfPages,
    _publisher,
    _numOfCopies
) {
    Object.defineProperties(this, {
        title: {
            value: _title,
            enumerable: true,






        },
        numOfChapters: {
            value: _numOfChapters,
            enumerable: true,
        },
        author: {
            value: _author,
            enumerable: true,
        },
        numOfPages: {
            value: _numOfPages,
            enumerable: true,
        },
        publisher: {
            value: _publisher,
            enumerable: true,
        },
        numOfCopies: {
            value: _numOfCopies,
            enumerable: true,
            writable: true,
        },
    });
    Book.count++;
};

Book.count = 0;
Book.getCount = function () {
    return this.count;
};

var Box = function (_height, _width, _length, _material) {
    Object.defineProperties(this, {
        height: {
            value: _height,
        },
        width: {
            value: _width,
        },
        length: {
            value: _length,
        },
        material: {
            value: _material,
        },
        content: {
            value: [],
        },
    });
};

Box.prototype.createBook = function (
    _title,
    _numOfChapters,
    _author,
    _numOfPages,
    _publisher,
    _numOfCopies
) {
    var index = this.findIndex(_title);
    if (index === -1) {
        var newBook = new Book(
            _title,
            _numOfChapters,
            _author,
            _numOfPages,
            _publisher,
            _numOfCopies
        );

        this.content.push(newBook);
    } else {
        this.content[index].numOfCopies += _numOfCopies;
    }
};

Box.prototype.deleteBook = function (_title) {
    var index = this.findIndex(_title);

    if (index !== -1) {
        this.content[index].numOfCopies--;
        if (this.content[index].numOfCopies === 0) this.content.splice(index, 1);
    } else throw new Error("Cant find book");
};

Box.prototype.findIndex = function (_title) {
    for (var i = 0; i < this.content.length; i++) {
        if (this.content[i].title === _title) {
            return i;
        }
    }
    return -1;
};

Box.prototype.toString = function () {
    var str = `Box Dimensions: ${this.height}x${this.width}x${this.length}, made of ${this.material}
`;
    for (var i = 0; i < this.content.length; i++) {
        str += `${this.content[i].title}: ${this.content[i].numOfCopies} 
`;
    }

    str += `Total Boxes: ` + this;
    return str;
};

Box.prototype.valueOf = function () {
    var sum = 0;
    for (var i = 0; i < this.content.length; i++) {
        sum += this.content[i].numOfCopies;
    }
    return sum;
};

var box1 = new Box(5, 5, 5, "wood");
console.log(box1.toString());

box1.createBook("book1", 5, "au1", 100, "pu1", 2);
console.log(box1.toString());
box1.createBook("book2", 10, "au2", 50, "pu3", 3);
console.log(box1.toString());
box1.deleteBook("book1");
console.log(box1.toString());
box1.deleteBook("book1");
console.log(box1.toString());
box1.createBook("book2", 10, "au2", 50, "pu3", 3);
console.log(box1.toString());

var box2 = new Box(6, 6, 6, "Metal");
box2.createBook("Book5", 6, "au5", 50, "pu5", 3);
console.log(box2.toString());

console.log(`Box1 + Box2 = ${box1 + box2}`);
