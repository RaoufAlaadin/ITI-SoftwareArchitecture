

var colorTester = document.getElementById("colorTester");

/* note:  We can use (for-of) or other (forloops) on className or tag name to put an eventListener on any of them
    as they all call the same function.  

    https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/for...of
     
    (for-in)only works on object properties, that's why we used for-of
    
    document.getElementsByClassName("changeColor") =====> returns an array of the elements that has that class. 
    */

for (var element of document.getElementsByClassName("changeColor"))
{
    element.addEventListener("click",updateColors);
}



function updateColors() { colorTester.style.color = `rgb(${redControl.value},${greenControl.value},${blueControl.value})`};




/*   ---- bad and long method. ---

var redControl = document.getElementById("redColor");
var greenControl = document.getElementById("greenColor");
var blueControl = document.getElementById("blueColor");

 redControl.addEventListener("click",updateColors);
 greenControl.addEventListener("click",updateColors);
blueControl.addEventListener("click",updateColors);

*/