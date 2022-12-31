var input = 0 , sum = 0;



do{


    input = prompt("Enter the number ",0);
    
    if (isNaN(input))
    {
        alert("Not a number"); 
    }
    else{   
        sum += parseInt(input);
    }
    

}
while(input != '0' && sum <= 100 );


document.write("Sum is:" + sum);
