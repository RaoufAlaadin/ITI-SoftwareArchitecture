
var input = prompt("Enter the header value",0);

document.write("The headers are: "); 

for(var i = 1; i <= 6; i++)
{
    document.write("<h" + i + ">" + input + "</h"+ i + ">")
}

