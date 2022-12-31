

var i = 1; 
var timer; 
function nextPic()
{
    if ( i != 6)
    document.getElementById("baby").src= `${++i}.jpg`;
    
}

function prevPic()
{
    if ( i != 1)
    document.getElementById("baby").src= `${--i}.jpg`;
    
}

function slideStart()
{
   timer =  setInterval(function () {

    if ( i != 6)
    document.getElementById("baby").src= `${++i}.jpg`;
    else
    {
        i = 1; 
        document.getElementById("baby").src= `${i}.jpg`;

    }
    

   },1000);
  
    
}


function slideStop()
{
   clearInterval(timer);
    
}




/* var i = 1; 
function nextPic()
{
    if ( i != 6)
    document.getElementById("baby").src= `${++i}.jpg`;
    else
    {
        i = 1; 
        document.getElementById("baby").src= `${i}.jpg`;

    }
} */