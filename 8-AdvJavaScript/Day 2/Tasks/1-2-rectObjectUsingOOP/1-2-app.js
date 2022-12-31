/* Using the constructor method for creating Objects, 

write a script that allows you to create a rectangle object that
• Should have width and height properties.
• Implement a method for calculating its area
• Implement a method for calculating its perimeter.
• Implement displayInfo() function to display a message
declaring the width, height, area, and perimeter of the
created object. */


var rect = function (w,h)
{
    this.width = w; 
    this.height = h; 
    this.area = function ()
    {
        return (w*h); 
    }

    this.perimeter = function ()
    {
        return (2*(w+h));
    }

    this.displayInfo = function ()
    {
        console.log(`w = ${w}, h = ${h}, area= ${this.area()} , perimeter = ${this.perimeter()}`);
    }

}

var rect1 = new rect(2,3);