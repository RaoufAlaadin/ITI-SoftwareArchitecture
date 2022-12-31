


var numArr = []; 


for(var i = 0 ; i < 5; i++)
numArr[i] = prompt(`Enter Element ${i+1} out of 5:`,"5"); 




var c = prompt("Enter display color r for red, g for green, b for blue default is blue","b");
var color;

switch (c) {
    case 'r': color = 'red'; break;
    case 'g': color = 'green'; break;
    case 'b': color = 'blue'; break;
    default: color = 'blue';
}


document.write(`<p style="color : ${color};"> Sorting  <\p>`);
document.write(`<br> <hr> `);

document.write(`<p style="color : ${color};"> Original Array is:  <span style="color : black;"> ${numArr.join()} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Sorted Desencding is:  <span style="color : black;"> ${numArr.sort(function(a, b){return a - b}).reverse().join()} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Sorted Ascending is: <span style="color : black;"> ${numArr.sort(function(a, b){return a - b}).join()} <\span> <\p>`);
document.write(`<br>`);


 