document.addEventListener("contextmenu", function(){

    //  ascii code,   alt , ctrl , shift 

    // osama-elZero --- >  https://www.youtube.com/watch?v=JXNbnm3WBVo&ab_channel=ElzeroWebSchool
    // preventDefault stops the event itself from happening 
    // we applied it to the document itself ,,,,, not the body on any other tag 

    // we might need this when preventing users from using the defualt one
    // or even creating our own context menu. 
    event.preventDefault(); 
    console.log(" you clicked right click");
   
})