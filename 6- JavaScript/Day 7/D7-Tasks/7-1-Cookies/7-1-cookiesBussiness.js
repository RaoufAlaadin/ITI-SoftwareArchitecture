/* 
        We will write what will happen if the button is pressed,
        it' going to be like we are calling a fn. 
*/

function intial () { 

    document.getElementById("register").addEventListener("click",

    function()
    {
        // 1- name 
        var usrnameValue = document.getElementById("usrname").value; 
        setCookie("usrname",usrnameValue);
    
        // 2- Radio: Male or Female

        var genderValue; 
    
        if(document.getElementById("male").checked)
        {
            genderValue = document.getElementById("male").value; 
            
            
        }
        else{
            genderValue = document.getElementById("female").value;
        }

        setCookie("gender",genderValue);

        // 3 - age 

        var age = document.getElementById("age").value; 

        setCookie("age",age);

        // 4 - color 

        var colorObj = document.getElementById("favColor");

        var color = colorObj.options[colorObj.selectedIndex].text; 

        setCookie("favColor",color);
    
        // var usrnameValue = document.getElementById("usrname").value;
        // setCookie("usrname",usrnameValue);
    
        // var usrnameValue = document.getElementById("usrname").value;
        // setCookie("usrname",usrnameValue);
    
     console.log("CookieCreateeddd !!!");
    
    
     location.assign("7-1-welcomePage.html"); 
    
    // visitCounter();

    // if you want to set a cookie for each new user, then we need arrays 

    if(hasCookie("counter"))
    {
        deleteCookie("counter");

    }
    
    }
    ) 

}


function shape ()
{
    if (getCookie("gender") === "male")
    document.getElementById("picture").innerHTML = `<img src="1.jpg" width="120" height="200">`;
    else
    document.getElementById("picture").innerHTML = `<img src="2.jpg" width="120" height="200">`;

}


//Note: We still need to add something for the visitCounter to be called for each time the html is loaded


function visitCounter(){

    shape();    



        // how to track it per usrname instead of client? 
        var visits;  

        var color = getCookie("favColor");
    
        if (hasCookie("counter"))
        {
            visits = getCookie("counter");
            visits = parseInt(visits) + 1;
        
            document.getElementById("welcome").innerHTML = 
            `<span style="color: ${color};">${getCookie("usrname")} </span> visited 
            <span style="color: ${color};">${visits} </span> times`
    
             // this part is for updating the cookies by the new numbers of visits
            // for later calls 
            setCookie("counter", visits);
        }
        else
        {   // if visits was 0 
    
            visits = 1;
            setCookie("counter", visits);
        document.getElementById("welcome").innerHTML = 
        `By the way,<span style="color: ${color};"> ${getCookie("usrname")} </span> this is your first time here.`
        }
        


}







// document.querySelector("#welcomeBody").onload = visitCounter; 

// function visitCounter(){

//     // how to track it per usrname instead of client? 
//     var visits; 
    
//     if (hasCookie("counter"))
//     {
//         visits = GetCookie("counter");
//         visits = parseInt(visits) + 1;
    
//         document.querySelector("#welcome").innerHTML = `${getCookie("usrname")} visited ${visits} times`

//          // this part is for updating the cookies by the new numbers of visits
//         // for later calls 
//         setCookie("counter", visits);
//     }
//     else
//     {   // if visits was 0 

//         visits = 1;
//         setCookie("counter", visits,expdate);
//     document.querySelector("#welcome").innerHTML = `By the way, ${getCookie("usrname")} this is your first time here.`
//     }
    
//     }
    
   
    
