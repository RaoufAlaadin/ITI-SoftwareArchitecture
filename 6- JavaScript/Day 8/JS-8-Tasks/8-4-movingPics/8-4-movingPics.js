document.getElementById("box1").style.cssText = 
`
border: solid; 
border-color: red;
height: 600px; 
width: 600px;

`

document.getElementById("icon1").style.cssText = 
`
position: absolute; 
top: 300px; 
left: 20px; 

`
document.getElementById("icon2").style.cssText = 
`
position: absolute; 
top: 300px; 
left: 560px; 

`
document.getElementById("top").style.cssText = 
`
position: absolute; 
top: 580px; 
left: 300px; 

`

var timer; 

//start
var x = 25 , y = 560 , z = 580 ; 
var m1 = 10, m2 = -10, m3 =-10 ; 
var limit1 = 560, limit2 = 20, limit3 = 20;


function checkEnd (currentPos,start,end,m)
{
    if (currentPos  <= start || currentPos >= end)
        return -m ;

    else
        return m ; 
}

function flyingFun()
{

    timer = setInterval(() => {
        var pic1 = document.getElementById("icon1");
        var pic2 = document.getElementById("icon2");
        var pic3 = document.getElementById("top");

       

        m1 = checkEnd(x,20,560,m1);
        pic1.style.left = `${x+m1}px`;

        m2 = checkEnd(y,20,570,m2);
        pic2.style.left = `${y+m2}px`;

        m3 = checkEnd(z,20,590,m3); 
        pic3.style.top = `${z+m3}px`;


        x = parseInt(getComputedStyle(pic1).left); 
        y = parseInt(getComputedStyle(pic2).left); 
        z = parseInt(getComputedStyle(pic3).top); 

        console.log(`x  ${x} y   ${y}  z  ${z} `) ;

        document.getElementById("data1").innerHTML = `icon1 --> left: ${x}`;
        document.getElementById("data2").innerHTML = `icon2 --> left: ${y}`;
        
    }, 50);



}

document.getElementById("moveStop").addEventListener("click" , function(){

    if ( this.value == "move")
    {
        this.value = "stop";
        clearInterval(timer);
        flyingFun();
    }
    else{
        this.value = "move";
        clearInterval(timer);

    }
   
})


document.getElementById("reset").addEventListener("click", function(){

     x = 25 , y = 560 , z = 580 ; 
     m1 = 10, m2 = -10, m3 =-10 ; 

     clearInterval(timer);
     flyingFun();


})




