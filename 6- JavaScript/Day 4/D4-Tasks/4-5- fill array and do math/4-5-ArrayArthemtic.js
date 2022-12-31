


var numArr = []; 
var sum = 0; 

for(var i = 0 ; i < 3; i++)
numArr[i] = prompt(`Enter Element ${i+1} out of 3:`,"5"); 


var multiplication = numArr[0], division = numArr[0];

for(var i = 0 ; i < 3; i++)
sum += parseInt(numArr[i]);

for(var i = 1 ; i < 3; i++)
multiplication *= parseInt(numArr[i]);


for(var i = 1 ; i < 3; i++)
division /= parseInt(numArr[i]);


var c = prompt("Enter display color r for red, g for green, b for blue default is blue","b");
var color;

switch (c) {
    case 'r': color = 'red'; break;
    case 'g': color = 'green'; break;
    case 'b': color = 'blue'; break;
    default: color = 'blue';
}


document.write(`<p style="color : ${color};"> ADDIN --- MULTIPLYING -- DIVISION  <\p>`);
document.write(`<br> <hr> `);

document.write(`<p style="color : ${color};"> Sum of 3 values is:  <span style="color : black;"> ${sum} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Multiplication of 3 values is:  <span style="color : black;"> ${multiplication} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Division of 3 values is: <span style="color : black;"> ${division} <\span> <\p>`);
document.write(`<br>`);


