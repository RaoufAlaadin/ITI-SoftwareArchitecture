/* A.1. Apply different styles over a paragraph according to
checked radio button.
Implement the required functions in an external .js file to let
TextStyle.html works properly */


function ChangeFont(value)
{
    document.getElementById("PAR").style.fontFamily = value; 
}

function ChangeAlign(value)
{
    document.getElementById("PAR").style.textAlign = value; 
}


function ChangeHeight(value)
{
    document.getElementById("PAR").style.lineHeight = value; 
}


function ChangeLSpace(value)
{
    document.getElementById("PAR").style.letterSpacing = value; 
}


function ChangeIndent(value)
{
    document.getElementById("PAR").style.textIndent = value; 
}

function ChangeTransform(value)
{
    document.getElementById("PAR").style.textTransform = value; 
}


function ChangeDecorate(value)
{
    document.getElementById("PAR").style.textDecoration = value; 

}

function ChangeBorder(value)
{
    document.getElementById("PAR").style.border = value; 
}
function ChangeBorderColor(value)
{
    document.getElementById("PAR").style.borderColor = value; 
}