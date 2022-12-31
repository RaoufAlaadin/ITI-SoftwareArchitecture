/* 

A.2.2 Create an animation on the page that makes an orange
marble move to the next location in the line every second.

Allow the user to stop the animation by placing the cursor on any
marble. 

The animation will restart again once the user removes
the cursor from that marble. Add your own interesting feature
to the script that tinkers with the speed or location of images 


*/

var index = 0 
var timer;
function animation()
{
    
    timer = setInterval(() => {

        index++;
        if ( index  === 0 )
        document.images[index].src = `marble2.jpg`;
        else if ( index < 4)
        {   document.images[index-1].src = `marble1.jpg`;
            document.images[index].src = `marble2.jpg`;
        }
        else{
            document.images[index-1].src = `marble1.jpg`;
            index = 0; 
            document.images[index].src = `marble2.jpg`;
        }
        
    }, 500);

    
}

animation();


function freezeAnimation()
{
    clearInterval(timer)
}

function continueAnimation()
{
    animation();
}