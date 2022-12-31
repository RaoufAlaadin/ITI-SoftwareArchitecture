/*

A.1.1. Make your own welcoming page of a registration form to
• display a greeting message for the user by his name and
title, then
• show a display of his info (address, gender, email, mobile)
and

• display a recommendation to use chrome browser if he is
using another browser (Bonus)


Hints:
• You should build a registration form to send the entire
required info from the user and let the action is getting the
welcoming page.
i.e. The welcoming page is the page that should be
displayed after registration.
• The registration form should contain fields for 
        1-name, 
        2-email,
        3-password
        4- job title
        5-, mobile,
        6- gender, 
        7- address.
• Read the required info from the query string. */


/// the backslash (\) makes us able to write the special character like + , that has a use in RegularExpresions
/// [&=] gives multiple option for the split ,, so split happens if any of them are found.
var infoArr = location.search.substring(1).replace(/\+/g, " ").split(/[&=]/);


document.getElementById("welcome").innerHTML = `<h2>Welcome To our Website -- <span style="color: blue;"> ${infoArr[1]} </span> , our <span style="color: blue;"> ${infoArr[7]} </span> <h2> `;

document.getElementById("address").innerHTML = `<h3>Your Address is: <span style="color: blue;"> ${infoArr[13].replace("%2C",",")} </span> <h3>`; 
document.getElementById("gender").innerHTML = `<h3>Your Gender is: <span style="color: blue;"> ${infoArr[11]} </span> <h3>`; 


document.getElementById("email").innerHTML = `<h3>Your Email is: <span style="color: blue;"> ${infoArr[3].replace("%40","@")} </span> <h3>`; 
document.getElementById("mobile").innerHTML = `<h3>Your Mobile Number is: <span style="color: blue;"> ${infoArr[9]} </span> <h3>`; 

browserCheck();



function browserCheck() { 

    if(navigator.userAgent.indexOf("Chrome") != -1 )
   {
       alert('You are using Chrome !!');
   }
   else 
   {
       alert('You not using Chrome, Please switch to it');
   }
  
   }


 /*   function browserCheck() { 
    if(navigator.userAgent.indexOf("Opera") != -1 || navigator.userAgent.indexOf('OPR') != -1 )
   {
       alert('Opera');
   }
   else if(navigator.userAgent.indexOf("Edg") != -1 )
   {
       alert('Edge');
   }
   else if(navigator.userAgent.indexOf("Chrome") != -1 )
   {
       alert('You are using Chrome !!');
   }
   else if(navigator.userAgent.indexOf("Safari") != -1)
   {
       alert('Safari');
   }
   else if(navigator.userAgent.indexOf("Firefox") != -1 ) 
   {
        alert('Firefox');
   }
   else if((navigator.userAgent.indexOf("MSIE") != -1 ) || (!!document.documentMode == true )) //IF IE > 10
   {
     alert('IE'); 
   }  
   else 
   {
      alert('unknown');
   }
   }
 */


