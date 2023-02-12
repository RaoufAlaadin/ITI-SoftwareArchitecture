





/* 1) Using ES6 new Syntax & features:


 Write a script to create different shapes (rectangle, square,
circle, triangle) make all of them inherits from polygon.


 Display the area 
and each object parameter in your console
by overriding toString()
 Draw your created shapes to a canvas element. 

*/


/* for calling the canavas the draw on it  */
const canvas = document.getElementById('canvas');
const ctx = canvas.getContext('2d');



class polygon
{
  constructor(length = 5)
  {
    this.length = length
  }


}

// 1- rectangle
class rectangle extends polygon
{
  constructor(length,height)
  {
    super(length)
    this.height = height
  }

  // now we can call it as a property. 
  get area()
  {
    return this.length*this.height; 
  }

  toString() {
    return `rectanlge -- width: ${this.length}, height: ${this.height} 
            Rect area is : ${this.area}`;
  }

  draw(ctx) {
    ctx.fillStyle = 'red';
    ctx.fillRect(30, 30, this.length, this.height);
  }
}

// 2- square

class square extends polygon
{
  constructor(length)
  {
    super(length)
  }

  get area()
  {
    return Math.pow(this.length,2); 
  }
  toString() {
    return `Square -- length: ${this.length}
            square area is : ${this.area}`;
  }

  draw(ctx) {
    ctx.fillStyle = 'blue';
    ctx.fillRect(350, 0, this.length, this.length);
  }

}

// 3- circle

class circle extends polygon
{
  constructor(length)
  {
    super(length)
  }

  get area()
  {
    return Math.PI*Math.pow(this.length,2); 
  }


  toString() {
    return `Circle -- radius: ${this.length}
            circle area is : ${this.area.toFixed(3)}`;
  }

  draw(ctx) {

    ctx.fillStyle = 'green';
    ctx.beginPath();
    ctx.arc(150, 300, this.length, 0, 2 * Math.PI);
    ctx.fill();
  }


}

// 4- triangle

class triangle extends polygon
{
  constructor(length,height)
  {
    super(length)
    this.height = height
  }

  get area()
  {
    return 0.5*this.length*this.height; 
  }

  toString() {
    return `Triangle -- base: ${this.length},  height: ${this.height}
            triangle area is : ${this.area}`;
  }


  draw(ctx) {
    ctx.beginPath();
    ctx.fillStyle = 'purple';


    // this is center point for the base 
    ctx.moveTo(400, 350);
    // 1- W move back and draw first outer side and
    // connect it to the top 
    ctx.lineTo(400 - this.length / 2, 350 + this.height);
    // 2- We go forward from the center point and draw the otherside
    // connecting to the same point on top 
    ctx.lineTo(400 + this.length / 2, 350 + this.height);
    // 3- When fill is used it will automatically draw the 3rd side
    // to connect our shape. 
    ctx.fill();
    
  }



}



let rect = new rectangle(200,50);
rect.draw(ctx);
console.log(rect.toString());



let sq = new square(200);
sq.draw(ctx);
console.log(sq.toString());

let cir = new circle(100);
cir.draw(ctx);
console.log(cir.toString());


let tri = new triangle(250,250);
tri.draw(ctx);
console.log(tri.toString());

