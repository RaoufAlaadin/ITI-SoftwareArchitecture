document.getElementById("sendForm").addEventListener("submit",function(){


   

var responce = confirm("do you want to continue ? "); 

if(!responce)
{
    event.preventDefault();
}


})

// custom Event
var myEvent = new Event ("timeOut"); 

document.getElementById("submit").addEventListener("timeOut",function(){

    event.preventDefault();
    alert("timeout-nothing was confirmed");


})

setTimeout(() => {
document.getElementById("submit").dispatchEvent(myEvent);
   
}, 3000);




//https://daily-dev-tips.com/posts/javascript-stop-form-submit/

//https://javascript.info/default-browser-action


/* 
this is the lecture example that were using return false
it's the Day-6-Demo

<form>
        <input type="text" name="usrnm">
        <input type="submit" value="send" onclick="alert('stop submission');return false;">
        <!-- <input type="submit" value="send" onclick="alert('stop submission')"> -->

</form>
    
    
    
    */