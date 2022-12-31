/* 

A.2.2 Create an animation on the page that makes an orange
marble move to the next location in the line every second.

Allow the user to stop the animation by placing the cursor on any
marble. 

The animation will restart again once the user removes
the cursor from that marble. Add your own interesting feature
to the script that tinkers with the speed or location of images 


*/

var index1 , index2; 
var counter; 


function flip(imgObject)
{
    // alert("Something is pressed");
    switch(imgObject.id)
    {
        case 1 :
            imgObject.src = "1.gif";
            break;
        case 2 :
            imgObject.src = "2.gif";
            break;
    }
}