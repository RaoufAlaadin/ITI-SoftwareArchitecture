


var mySenctence = prompt("Enter a string  ",0);


// pressing ok gives (true) -- makes sesitivty matters 
alert(`The longest word is:  ${wordChecker(mySenctence)}`);


function wordChecker(s)
{
    
    var wordArr = s.split(" ");
    var longestWord = wordArr[0]; 

    for(var i = 0; i< (wordArr.length)-1; i++)
    {
        if (wordArr[i].length < wordArr[i+1].length)
        {
            longestWord = wordArr[i+1];

        }
    }


    return longestWord;
}