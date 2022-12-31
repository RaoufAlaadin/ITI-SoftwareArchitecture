// instead of using onload we will use this method.

$(function () {
  // $("#header1").click(function () {

  //     this.innerHTML = "Why did you click here?"
  // })
  // $("#div1").css({
  //     "color": "blue",
  //     "backgroundColor": "yellow",
  //     "border": "solid",
  //     "height": "100px",
  //     "width": "200px",

  //     'text-align': 'center',

  // });


 
  console.log("test");

  var showOnlyCurrentDiv = function (currentDiv) {
    // lesson: i had to make it look in div inside div's to overlook the .container div
    $("div")
      .filter(function () {
        return ( $(this).attr("class") != "container" && $(this).attr("id") != "btnDiv" && 
        $(this).attr("class") != "listContainer"  && $(this).attr("class") != "list")

      })
      .hide();
    $(currentDiv).show();
  };

  // note: this is the first case where we have nothing clicked yet.
  showOnlyCurrentDiv(0);

  //#region About

  $("#btnAbout").click(function () {
    showOnlyCurrentDiv("#div1");
  });

  //#endregion

  $("#btnGallery").click(function () {
    showOnlyCurrentDiv("#div2");
    $("#img1").hide(3000); //fast|normal|slow || duration
  });

  //#region Gallery

  var picCounter = 1;

  $("#btnBack").click(function () {
    if (picCounter == 1) {
      picCounter = 8;
      $("#snowMan").attr("src", `../Images/${picCounter}.jpg`);
    } else {
      $("#snowMan").attr("src", `../Images/${--picCounter}.jpg`);
    }
    console.log(`currentPicIs ${picCounter}`);
  });

  $("#btnNext").click(function () {
    if (picCounter == 8) {
      picCounter = 1;
      $("#snowMan").attr("src", `../Images/${picCounter}.jpg`);
    } else {
      $("#snowMan").attr("src", `../Images/${++picCounter}.jpg`);
    }
    console.log(`currentPicIs ${picCounter}`);
  });

  //#endregion

  $("#btnServices").click(function () {
    showOnlyCurrentDiv("#div3");
    $(".menuBtn").slideToggle();
    // $(".menuBtn").fadeToggle();
    
    

    
  });


  $("#btnComplain").click(function () {
    showOnlyCurrentDiv("#div4");
   
  });

  /*research:  getting the value of an input in both native javaScript or jQuery
  https://www.geeksforgeeks.org/how-to-get-the-value-in-an-input-text-box-using-jquery/
  
  https://www.ceos3c.com/javascript/store-user-input-in-a-variable-with-javascript/
  
  */

  $("#btnSend").click(function () {
    showOnlyCurrentDiv("#div5");

   
        var userName = $("#name").val();
        var email= $("#email").val();
        var phone = $("#phone").val();
        var review = $("#review").val();


        $("#info1").text(userName);
        $("#info2").text(email);
        $("#info3").text(phone);
        $("#info4").text(review);


        

   
  });

  $("#btnBacktoEdit").click(function () {
    showOnlyCurrentDiv("#div4");
   
  });





});
