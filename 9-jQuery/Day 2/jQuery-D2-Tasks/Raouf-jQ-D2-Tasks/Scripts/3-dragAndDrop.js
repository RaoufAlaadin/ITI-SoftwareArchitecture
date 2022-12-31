$(function (){
    

    $( "#rabbit" ).draggable();



    $( "#blackHole" ).droppable({
      drop: function( event, ui ) {
        $( "#rabbit" ).hide("explode",3000);
      }
    });




  })