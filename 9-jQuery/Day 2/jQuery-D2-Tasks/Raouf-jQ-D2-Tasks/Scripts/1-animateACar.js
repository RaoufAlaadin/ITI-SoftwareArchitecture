$(function () {



    var timer;
    $("#btnMove").click(function () {

        // $("#raceCar").css("left", "10px");




        // note: I had to chain the hide() animation for it to work after the animate()
        timer = setInterval(() => {

            $("#d1").append($("#data"));
            $("#raceCar").animate({ left: "1000px" }, 5000, "easeOutBounce").hide("explode", 2000);
            var pic1 = document.getElementById("raceCar");
            x = parseInt(getComputedStyle(pic1).left);
            console.log(`x  ${x} `);
            document.getElementById("data").innerHTML = `icon1 --> left: ${x}`;


        }, 30);


        setTimeout(function () {

            clearInterval(timer);
            console.log("hide the car");
        }, 5000);




    });




    // timer = setInterval(() => {
    //     var pic1 = document.getElementById("icon1");
    //     var pic2 = document.getElementById("icon2");
    //     var pic3 = document.getElementById("top");



    //     m1 = checkEnd(x,20,560,m1);
    //     pic1.style.left = `${x+m1}px`;

    //     m2 = checkEnd(y,20,570,m2);
    //     pic2.style.left = `${y+m2}px`;

    //     m3 = checkEnd(z,20,590,m3); 
    //     pic3.style.top = `${z+m3}px`;


    //     x = parseInt(getComputedStyle(pic1).left); 
    //     y = parseInt(getComputedStyle(pic2).left); 
    //     z = parseInt(getComputedStyle(pic3).top); 

    //     console.log(`x  ${x} y   ${y}  z  ${z} `) ;

    //     document.getElementById("data1").innerHTML = `icon1 --> left: ${x}`;
    //     document.getElementById("data2").innerHTML = `icon2 --> left: ${y}`;

    // }, 50);



})