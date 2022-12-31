/*

        Note:       1-  you can insert either numbers as a string to any function like .test or isNan for example
                        don't use parseInt for this case or it would give u Random values.
                        use  it ONLY when you need to add numbers. 
                */ 

//1- Name validation

do{
    var userName = prompt("Enter your name  ","Raouf");

    /* ^  -- ensure we start with one of the letters , 
       $ -- ensure we end with a letter from the range,
       + -- that we atleast enter one char atleast or more. 

    */
    var patternMatch = (/^[A-Za-z]+$/).test(userName);

}while((!patternMatch));

// isFinite will give us true if the value is a number
// we could have also used  !isNan() so if it's a  number it gives true


do{
    var phoneNumber = prompt("Enter your phone Number  ","12345678");

    var patternMatch = (/^[0-9]{8}$/).test(phoneNumber);

}while((!patternMatch) );




do{
    var mobileNumber = prompt("Enter your Mobile Number ","01283816201");

    var patternMatch = (/^01[0125][0-9]{8}$/).test(mobileNumber);

}while((!patternMatch));

do{
    var email = prompt("Enter your E-mail  ","RaoufAlaadin97@gmail.com");

    var patternMatch = (/^([a-z]|[A-Z]|[0-9]|_)+@([a-z]|[A-Z])+\.([a-z]|[A-Z])+$/).test(email);

}while((!patternMatch));


var c = prompt("Enter display color r for red, g for green, b for blue default is blue","r");
var color;

switch (c) {
    case 'r': color = 'red'; break;
    case 'g': color = 'green'; break;
    case 'b': color = 'blue'; break;
    default: color = 'red';
}


document.write(`<p style="color : ${color};"> Welcome dear guest <span style="color : black;"> ${userName} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Your phone number is <span style="color : black;"> ${phoneNumber} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Your mobile number is <span style="color : black;"> ${mobileNumber} <\span> <\p>`);
document.write(`<br>`);

document.write(`<p style="color : ${color};"> Your email address is <span style="color : black;"> ${email} <\span> <\p>`);
document.write(`<br>`);




