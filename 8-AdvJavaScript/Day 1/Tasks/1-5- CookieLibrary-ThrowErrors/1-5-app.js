/* Make your own .js file that should have the following functions:

        • getCookie(cookieName):
                 o Retrieves a cookie value based on a cookie name.
        • setCookie(cookieName,cookieValue[,expiryDate]):
             o Sets a cookie based on a cookie name, cookie value,
                and expiration date.
        • deleteCookie(cookieName):
                 o Deletes a cookie based on a cookie name.
        • allCookieList():
             o returns a list of all stored cookies
        • hasCookie(cookieName):
                  o Check whether a cookie exists or not
1- Use your functions to create the required cookies
2- display a greeting message to your visitor with displaying an image as his
profile pic referring to his gender
3-inform him with his number of visits to the site. 
4- Display user name and number of visits 
            with font color according to his choices.
Note:
• Do not use <form> tag in the registration page.
• Replace the registration page with the profile page using
location object */

var err = new Error("Invalid parameters count"); 


function getCookie(cookieName)
{

     if (arguments.length != 1)
     { 
          throw err; 
     }

     var nameEQ = `${cookieName}=`; 
     var cArray = document.cookie.split(";");

     for (var i = 0; i < cArray.length; i++)
     {
          var  c = cArray[i];
          // first we remove the spaces
          while(c.charAt(0) == " ")
               c = c.substring(1,c.length);
          // the char of the name we are looking for is 
          //supposed to be at the begaining as we removed all the spaces.
          if (c.indexOf(nameEQ) == 0)
          {
               c = c.substring(nameEQ.length,c.length);

               return decodeURIComponent(c); 
          }
     }

     return null; 
}


function setCookie(cookieName,cookieValue,months)
{

     if (arguments.length > 3 || arguments.length <= 0)
     { 
          throw err; 
     }
     // we first check if we have an expiryDate to be entered.
     var expiries ; 

     if (months)
     {
          var date = new Date();
          date.setMonth(date.getMonth() + months);
          expiries  = date.toUTCString();
     }

     document.cookie = `${cookieName} = ${encodeURIComponent(cookieValue)}; expires=${expiries}` ; 

}



function deleteCookie(cookieName)
{

     if (arguments.length != 1)
     { 
          throw err; 
     }
     // this removes the cookies value and set it to an older date.
     // so it turns into a session and gets removed when u close the browser. 
     setCookie(cookieName,"",-1);    
}
function allCookieList()
{

     
     // we first run all the fields throught decodeURIComponents
     // just to make sure everything is back to plain text again. 
     var cArray = document.cookie.split(";");
     for(var i = 0; i < cArray.length; i++)
     {
          cArray[i] = decodeURIComponent(cArray[i]); 
     }

     return cArray; 

}

function hasCookie(cookieName)
{

     if (arguments.length != 1)
     { 
          throw err; 
     }

     var nameEQ = `${cookieName}=`; 
     var cArray = document.cookie.split(";");

     for (var i = 0; i < cArray.length; i++)
     {
          var  c = cArray[i];
          // first we remove the spaces
          while(c.charAt(0) == " ")
               c = c.substring(1,c.length);
          // the char of the name we are looking for is 
          //supposed to be at the begaining as we removed all the spaces.
          if (c.indexOf(nameEQ) == 0)
          {
               c = c.substring(nameEQ.length,c.length);

               // alert(`cookieName: ${cookieName} was found`);
               return true; 
          }
     }

     // alert(`cookieName: ${cookieName} was NOT found, try again`);

     return false; 

}



// function setCookie(name,value,days) {
//      var expires = "";
//      if (days) {
//          var date = new Date();
//          date.setTime(date.getTime() + (days*24*60*60*1000));
//          expires = "; expires=" + date.toUTCString();
//      }
//      document.cookie = name + "=" + (value || "")  + expires + "; path=/";
//  }