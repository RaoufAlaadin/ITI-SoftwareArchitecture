
var numArray = []; 
var sum = 0; 
var ans; 
var txt; 
var op1 , op2; 

function printScreen(generalValue)
{
    ans = document.getElementById("Answer") ;
    ans.value += generalValue;
}

function  EnterEqual ()
{

    
}
function  EnterNumber(numValue)
{
    printScreen(numValue);
    sum = parseInt(numValue) ; 

}
function  EnterOperator (operatorValue)
{
    op1 = parseInt(ans.value) ; 
    ans.value = operatorValue; 


}
function  EnterClear ()
{


}
