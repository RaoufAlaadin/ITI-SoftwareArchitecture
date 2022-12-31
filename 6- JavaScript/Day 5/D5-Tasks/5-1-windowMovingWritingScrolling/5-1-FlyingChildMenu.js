/* 1.BOM
1.1. Window Object

1.1.1. Create a parent window that opens a flying child window. Hint:

1- Start by creating a parent window that opens a child window.
2- Child window should always be on top view and moves up and down
   within boundaries of user screen.
3- Parent window should contain a button that stops child window
    movement.


1.1.2. Write a script that shows a “typing message” appearing in a
new child window. The new window should close after few seconds of
displaying your message.


1.1.3. Create a parent a window that opens a scrollable advertising
child window.

 */
    //Lesson: A- Flying Window !! 
       
        var flyID;
        var win; 
        var current = 1;  // go down = 1 ,, go up = -1
        var up = -1; 
        var down = 1; 
        var a , b ; 
        

        // 1- Open window

        function openWin(){
            win = open("5-1-childWin.html", "", "width=400 , height=87, top=200");
        }


        // 2- Start Moving 


        function flyingParameters(shift,directionFactor){
            win.moveBy(shift, shift);
            win.focus();
            //change direction-- 
            if ( directionFactor === 0)
            current = 1;
            if ( directionFactor === 865 )
            current = -1;  

        }
    
        function moveWin() {
            //NOTE:  Starting the setInterval 

                flyID = setInterval(() => {
                        a = win.screenTop;
                        b = win.screenLeft;
                        console.log(`Current Location ---- x = ${a}, y = ${b} `);

                        switch(current)
                        {
                            case up: 
                                  flyingParameters(-1,a);
                            break; 

                            case down:
                                   flyingParameters(1,a);
                                break;
                        }
                
            }, 0); 

        }


        // 3- Stop Moving 

        function stopWin()
           {
               
               clearInterval(flyID);
               // win.close();
           }

         // 4- Close window 
   
        function closeWin()
           {
               win.close();
           }


    //Lesson: B - Typing Window !!!! 

           var text = "The Flying Dutchman was a sea captain who once found himself struggling to round the Cape of Good Hope during a ferocious storm. He swore that he would succeed even if he had to sail until Judgment Day...... Will close after 3 seconds";
           var i = 0;
   
           
           
           function typeWriter() {
               if (i < text.length) {
                   typWin.document.write(text.charAt(i)); 
                   i++;
                   setTimeout(typeWriter, 25);
               }
               else 
               {
                    i = 0 ; 
                   setTimeout(() => {
                       typWin.close(); 
                   }, 3000);
               }
           }
   
           function typingWindow()
           {
   
               typWin = open("5-2-TypingText.html", "", "height=300, width=600");
               typWin.focus();
   
               typeWriter();
               
           }

        //Lesson: C - Scrolling Window

           function scrollWindow ()
           {    
            var scrollWin = open("5-3-Scrolling.html", "", "height=300, width=600");

            scrollWin.focus(); 

            setInterval(() => {
                scrollWin.scrollBy(0,30);
                
            }, 500);


           }

     
        

        