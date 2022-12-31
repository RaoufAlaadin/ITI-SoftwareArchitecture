$(function () {



    /* When using $.each ,,, it can works if you have an 
            1-array with index 
        or  2- object with properties ..


        https://stackoverflow.com/questions/1096924/iterating-a-javascript-objects-properties-using-jquery
        https://api.jquery.com/jquery.each/
        
        here we start with an object that has proeperties !! ... and each property has an array 
        
        their callback functions are 
        in case of array =>   ,function (indexInArray, element value) 
        in case of object =>   ,function(propertyName, valueOfProperty) 

        */

    var rockBands;

/*    lesson: Bussiness Logic 


                    retriveRockBandsInfo() 

                    checkForSelectionOfBandName()

                    updateArtistList()
                    
                    redirectToArtistWebsite() 
*/




    $.ajax({
        type: "GET",
        url: "../DATA/rockbands.json",
        success: function (_rockBands) {
            rockBands = _rockBands;

            //note: for our case.. the json file returns an object with properties, each property has an array. 
            $.each(rockBands, function (bandName, BandMembersInfo) {
                $("#_rockBand").append(`<option value="${bandName}">${bandName}</option>`);
            });

            console.log("testing", rockBands.beatles[0].name);

        },

        error: function () {
            alert("Failed to retrive data.");
        }
    });

    $('#_rockBand').change(function () {


        var currentBandSelection = $(this).val();

        console.log(currentBandSelection);


        /*  lesson:   remove() ===> removes the matched element itself....  
                     empty() ==> removes the child elements of our node. (it does not only clear the value as written in the slides.) 
                     
                     */

        $("#_atrist").empty();


        $.each(rockBands, function (bandName, BandMembersInfo) {


            if (bandName === currentBandSelection) {
                for (var i = 0; i < BandMembersInfo.length; i++) {
                    $("#_atrist").append(`<option value="${BandMembersInfo[i].name}">${BandMembersInfo[i].name}</option>`);
                }
            }
        });


    });



    $('#_atrist').change(function () {


        var currentArtistSelection = $(this).val();

        console.log(currentArtistSelection);


        $("#_atrist").empty();


        $.each(rockBands, function (bandName, BandMembersInfo) {


            for (var i = 0; i < BandMembersInfo.length; i++) {
                if (currentArtistSelection === BandMembersInfo[i].name) {
                    location.assign(`${BandMembersInfo[i].value}`);
                }

            }

        });


    });


    $("#btnAjax").click(function () {



        // console.log("geetingValues", rockBands);



    });






})





//ajax testing


// $.ajax({
//     type: "GET",
//     url: "../DATA/rockbands.json",
//     success: function (_rockBands) {
//         rockBands = _rockBands;

//         //note: for our case.. the json file returns an object with properties, each property has an array.
//         $.each(rockBands, function (bandName, BandMembersInfo) {



//             $("#_rockBand").append(`<option value="${bandName}">${bandName}</option>`);


//             // $("#showData").append(`<p> Band Name: ${bandName} , artist detail ${BandMembersInfo[0].name}</p>`);


//           /*   https://stackoverflow.com/questions/11922383/how-can-i-access-and-process-nested-objects-arrays-or-json */

//             //research:
//             // var artists = []
//             // for (var i = 0; i < BandMembersInfo.length; i++){
//             //     artists[i] = BandMembersInfo[i].name + BandMembersInfo[i].value;
//             // }

//             // $("#showData").append(`<p> Band Name: ${bandName} , artist detail ${ artists
//             // }</p>`);


//         });

//         /* lesson: to go into an object proerty, we use (.) ,, to access one of it's array's element, we use [i] */

//         console.log("testing", rockBands.beatles[0].name);




//     },

//     error: function () {
//         alert("Failed to retrive data.");
//     }
// });
