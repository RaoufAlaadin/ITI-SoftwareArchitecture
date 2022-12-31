



document.getElementById("container1").style.cssText = `

display: grid; 
grid-template-columns: 1fr 2fr 1fr; 
grid-template-rows: 0.25fr 1fr 0.25fr; 
gap: 0px 0px; 
grid-template-areas: 
  ". . dv2"
  ". dv3 ."
  "dv1 . ."; 
border: solid;

background-color : #cfa484;
`


document.getElementById("cardContainer").style.cssText =
  `
grid-area: dv3;
// border: solid;
text-align: center;

background-color: #e3c2aa;

`



/* note: 
 this line can be used to have an already intilized value before pressing the file.

  document.getElementById("1").checked = "true" ; 

  */

//functions:  Red border and selection.

// lesson: this is the default intilization, just in case you did not choose anything. 
var selectedCard;
document.getElementById("1").checked = "true" ; 
selectedCard = document.querySelector('input[name="card"]:checked').value;


document.getElementById("picOptions").addEventListener("click", function () {

  //https://www.javatpoint.com/how-to-check-a-radio-button-using-javascript    =========== radio button checker

  document.getElementById("1")

  for (var i = 0; i < document.images.length; i++) {

    document.images[i].style.border = "none";

  }

  //note: only checking for null once is enough here 
  if (document.querySelector('input[name="card"]:checked') == null) {
    console.log("query returned null !!! , nothing is selected");

    return;
  }
  else {

    selectedCard = document.querySelector('input[name="card"]:checked').value;
  }


  document.images[parseInt(selectedCard) - 1].style.cssText = `

          border: solid; 
          border-color: red; 
          `;

})

//functions:  Preview window

document.getElementById("generate").addEventListener("click", function () {

  // selectedCard holds the img no. 


  var win = window.open("", "", "width=500,height=500");

  // create a div and append the copied node inside of it. 

  var pDiv = win.document.createElement("div");
  win.document.body.prepend(pDiv);

  /* align items -- aligns vertically 

      ...
      a..
      ...

    justify content --- aligns horizontally
    
      ...
      .a.
      ...
      */

  // note: text-align: is the one that actually care about the img
  win.document.body.style.cssText =
    `
  display: flex;
  align-items: center;
  justify-content: center;
  border: solid;
  background-color :#82ccd9;
  
  `

  pDiv.style.textAlign = "center";

  var img = win.document.createElement("img");


  img.src = `http://127.0.0.1:5500/8-3-cardGenerator/${selectedCard}.jpg `;
  img.style.width = "200px";
  img.style.height = "200px";

  pDiv.prepend(img);

  img.style.textAlign = "center";





  ///////////////////////////////////


  var pElem = win.document.createElement("h3");
  var text = document.getElementById("box1").value; 
  var textElem = win.document.createTextNode(text);

  pElem.append(textElem);
  pDiv.append(pElem);

  var pClose = win.document.createElement("input");
  pDiv.append(pClose);

  pClose.type = "button";
  pClose.id = "closeX"; 
  pClose.value = "Close the preview"; 
  
  win.document.getElementById("closeX").addEventListener("click", function (){

    win.close();

  })









})