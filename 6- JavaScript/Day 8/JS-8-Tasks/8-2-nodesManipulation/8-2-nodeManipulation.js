

/* 
    a Good CSS layout generator.

    https://grid.layoutit.com/
    
*/  

//1- first we change the style of the bullet points into empty cricles. 
document.getElementById("nav").style.cssText = `

    list-style-type:circle;
    list-style-position: inside;
    
`;


/* 
lesson: 2- we called the first div element by using the class name , notice the specfic format. 
            note when we tried using .style on bigDiv it didn't autocompelete... but it still worked. 
 */
var bigDiv = document.getElementsByClassName("center")[0];
bigDiv.style.cssText = `


display: grid; 
grid-template-columns: 1fr 1fr 1fr; 
grid-template-rows: 1fr 1fr 1fr; 
gap: 0px 0px; 
grid-template-areas: 
  ". . dv2"
  ". dv3 ."
  "dv1 . ."; 
//   border: solid;

`

// lesson: 3- now we put style on the image we already have and the menu
document.getElementById("header1").style.cssText = 
`
grid-area: dv1;
// border: solid;
text-align: left;

`


document.getElementById("navigation").style.cssText = 
`
grid-area: dv3;
// border: solid;
text-align: center;

`



/* lesson: 4- we gave the <img> an  id using the setAttribute( , ) method.
            as we wanted to use it with the "load" eventListener.... but at the end it worked without using it? 

            it was just all matter of writing the code in the correct order!!! 😁

            note the format !!! ==>   div1.setAttribute("id", "panda"); 

            as w3schools have a wrong format for setAttribute.. where you only enter one input !! 
 */

var div1 = document.getElementById("header1").firstElementChild; 
div1.setAttribute("id", "panda");




/* lesson: 5- Here we started cloning the "header1" div element as it has the image inside of it
        
            note: for it to also copy the <img> you have to agree to the "deep copy" by writing (true) 
            
        
        After creating the clone, we changed the (clone ID) immediatly to avoid future conflict 
        we also changed the image id for future use. 
       */

console.log("Starting cloning");
var node = document.getElementById("header1").cloneNode(true);
node.id = "header2";
node.firstElementChild.setAttribute("id","bear");

//fixme: we append the node to decide it's placemenet in the document. 
document.getElementsByClassName("center")[0].append(node);

console.log("Cloning is done");

//fixme: now the clone is (on top) of the original.... so we need to change it's style . 

document.getElementById("header2").style.cssText = 
`
grid-area: dv2;
// border: solid;
text-align: right;

`;

console.log(node);


/* lesson: todo://Note: we gave the clone image the id (bear) not get away from the id conflict when calling it. 
// and we had to do that as the header 2 was the one on top !!!!! 


// it can also work by writing header2 for the element !!!! 
// the problem all along was that the clone and the orginal element were on the same location !!!! 

document.getElementById("bear").addEventListener( "mouseover", function(){


                document.getElementById("header2").style.cssText = 
            `
            grid-area: dv2;
            border: solid;
            text-align: right;

            `;

})
*/














// document.getElementsByTagName("div")[0].classList.toggle("center")
// document.getElementsByTagName("div")[0].classList.add("center")
// document.getElementsByTagName("div")[0].classList.remove("center")
