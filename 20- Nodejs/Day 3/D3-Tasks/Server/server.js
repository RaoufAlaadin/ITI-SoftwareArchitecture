



const express = require('express');
const app = express();

const path = require("path");

const fs = require('fs');
// const port = 3000;

let PORT = process.env.PORT || 7008;
const bodyParser = require("body-parser");

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: true }))

// This Will identify the root folder for static files
// Now all of them are loaded and can be accessed normally
// this is better than writing them a million time.
app.use(express.static('Client'));




let UserData = {};

let profileHtml = fs.readFileSync("./Client/HTML/profile.html").toString();

app.get(['/', '/main.html', '/client/main.html'], (req, res) => {
    // res.send(mainHtml);
    res.sendFile(path.join(__dirname, "./Client/HTML/main.html"))

});

app.get(['/profile.html', '/client/profile.html'], (req, res) => {
    // res.send(profileHtml);
    res.sendFile(path.join(__dirname, "./Client/HTML/profile.html"))

});

app.get(['/style.css', '/client/style.css'], (req, res) => {
    res.sendFile(path.join(__dirname, "./Client/Style/style.css"))


    // res.send(styleCSS);
});

app.get(['/script.js', '/client/script.js', '/JS/script.js'], (req, res) => {
    // res.send(scriptJS);
    // console.log("JavaScript File loaded 👍")

    res.sendFile(path.join(__dirname, "./Client/JS/script.js"))

});

app.get(['/2.jpg', '/client/2.jpg', '/client/Images/2.jpg'], (req, res) => {
    res.send(img);

    res.sendFile(path.join(__dirname, "./Client/Images/2.jpg"))

});

app.get(['/favicon.ico', '/client/favicon.ico', '/client/Icons/favicon.ico'], (req, res) => {
    // res.send(favIcon);

    res.sendFile(path.join(__dirname, "./Client/Icons/favicon.ico"))

});

app.get('/data.json', (req, res) => {
    // res.send(jsonData);

    res.sendFile(path.join(__dirname, "./data.json"));

});

app.post('/profile.html', (req, res) => {


    fs.readFile("data.json", "utf8", (err, data) => {
        if (err) {
          console.error(err);
          console.log(" omg the reading json failed");

        } else {

            console.log(" we readd the jason correctly 👍");
            /*  Json.Parse ==> from json string to a json object in javascript ( from file to program)
                Json.Stringfy => from program to file 
            https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/JSON/parse */


          const jsonArray = JSON.parse(data);
          console.log(jsonArray);


          // push the new data object to the array
          jsonArray.push(UserData);
          // stringify the array and write it back to the file
          fs.writeFile("data.json", JSON.stringify(jsonArray), "utf8", (err) => {
            if (err) {
              console.error(err);
            } else {
              console.log("Data appended successfully");
            }
          });
        }
      });


    
   

    console.log(req.body)
    let data = req.body;
    

    let profileHtmlWithValues = profileHtml
            .replace("{userName}", data.name)
            .replace("{MobileNumber}", data.mobile)
            .replace("{Address}", data.address)
            .replace("{Email}", data.email);

    res.send(profileHtmlWithValues);
    // res.send("Post Called")

})

app.listen(PORT, () => { console.log("http://www.localhost:" + PORT) });








/*

Summary 
-----


1- bodyparser does the parsing job for you so you don't need a separate event to handle the parsing first
2- that's why we don't user req.on("data") and req.on("end") as they may lead to conflict and errors
    We just access the data directly using req.body 

    
The req.on("data") and end events are used to handle incoming data from a request stream 
in Node.js. However, they are not recommended to be used inside 
app.post express code, because express already provides a middleware 
function called bodyParser that can parse the request body and make it 
available as req.body. Using req.on("data") and end inside app.post express 
code can cause conflicts and errors, as well as make the code less readable 
and maintainable. Therefore, it is better to use bodyParser middleware and access req.body directly in app.post express code. 

*/
