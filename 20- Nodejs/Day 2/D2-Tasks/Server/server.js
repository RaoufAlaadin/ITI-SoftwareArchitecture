/** require("http") */

const http = require("http");
const fs = require('fs');
/* 
try {
  const data = fs.readFileSync("./Client/HTML/main.html").toString();
  console.log(data);
} catch (err) {
  console.error(err);
} */


/*  We have to write one dot `.` not `..` before the path, 

I don't know how it worked with the instructor*/
let mainHtml = fs.readFileSync("./Client/HTML/main.html").toString();
let profileHtml = fs.readFileSync("./Client/HTML/profile.html").toString();
let styleCSS = fs.readFileSync("./Client/Style/style.css").toString();
let scriptJS = fs.readFileSync("./Client/JS/script.js").toString();

let jsonData = fs.readFileSync("./data.json").toString();
let img = fs.readFileSync("./Client/Images/2.jpg");
let favIcon = fs.readFileSync("./Client/Icons/favicon.ico");

let UserData = {};






http.createServer((req, res) => {

    console.log("----Request analysis----")
    console.log(req.method);
    console.log(req.url);

    console.log("----analysis Ending ....----")





    //#region GET
    if (req.method == "GET") {
        switch (req.url) {
            case '/':
            case '/main.html':
            case '/client/main.html':
                // res.writeHead(200,"Hiiii",{"content-type":"text/html"})//MIME Type
                // res.writeHead(200,"Hiiii",{"set-cookie":"name=Ahmed"})//MIME Type
                // res.writeHead(200,"Hiiii",{"Access-Control-Allow-Origin":"*"})//MIME Type ==> third party module [install] ==> cors ==>
                // res.setHeader("content-type","text/html");
                // // res.setHeader("set-cookie","name=ahmed");
                // res.setHeader("Access-Control-Allow-Origin","*")
                res.write(mainHtml);
                break;
            case '/':
            case '/profile.html':
            case '/client/profile.html':
                res.write(profileHtml);
                break;
            case '/style.css':
            case '/client/style.css':
                res.write(styleCSS);
                break;
            case '/script.js':
            case '/client/script.js':
            case '/JS/script.js':
                
                res.write(scriptJS);
                console.log("JavaScript File loaded 👍")
                break;
            case '/2.jpg':
            case '/client/2.jpg':
            case '/client/Images/2.jpg':
                res.write(img);
                break;
            case '/favicon.ico':
            case '/client/favicon.ico':
            case '/client/Icons/favicon.ico':
                res.write(favIcon);
                break;


                /* VERY IMPORTANT,
                So the server understands the GET Request
                Sent by the fetch API */
            case '/data.json':
                res.write(jsonData);
                break;
            default:
                if (req.url.includes("?userName")) {
                    res.write(mainHtml);
                }
                break;
        }
        res.end();
    }
    //#endregion

    //#region POST
    else if (req.method == "POST") {
        req.on("data", (data) => {

            /* Querystring before : 
            
            name=Raouf+Alaadin&mobile=01255667790&address=Alexandria%2CEgypt&email=Raouf%40gmail.com
            
            1- Separate each data pair using `&`
            2- seperate key from value by `=`
            3- we replace any `+` by space ` ` and assign that value to a key in the new object. 
            */

            const queryString = data.toString();

            const pairs = queryString.split("&");
            // const data = {};

            for (let pair of pairs) {
                const [key, value] = pair.split("=");
                UserData[key] = decodeURIComponent(value.replace("+", " "));
            }

            console.log(UserData); // { name: 'Raouf Alaadin', mobile: '01255667790', address: 'Alexandria,Egypt', email: 'Raouf@gmail.com' }


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


              
        })
        req.on("end", () => {

            // *************** ASK Eng/ Mostafa !!!! ***********************



            /* This is wrong because it keeps editing the original `profilehtml`
             But why is the printed result is the first line ?? 
             
             shouldn't it be the last line, as It would override everything that came before it. 
             */
            // res.write(profileHtml.replace("{userName}", UserData.name));

            // res.write(profileHtml.replace("{MobileNumber}", UserData.name));
            // res.write(profileHtml.replace("{Address}", UserData.address));
            // res.write(profileHtml.replace("{Email}", UserData.email));

            const profileHtmlWithValues = profileHtml
                .replace("{userName}", UserData.name)
                .replace("{MobileNumber}", UserData.mobile)
                .replace("{Address}", UserData.address)
                .replace("{Email}", UserData.email);

            res.write(profileHtmlWithValues);

            res.end();
        })
    }
    //#endregion

    //#region PUT
    else if (req.method == "PUT") {

    }
    //#endregion

    //#region PATCH
    else if (req.method == "PATCH") {

    }
    //#endregion

    //#region DELETE
    else if (req.method == "DELETE") {

    }
    //#endregion

    //#region Default
    else {
        res.end("Please Select Common Method");
    }
    //#endregion
}).listen(7000, () => { console.log("Listining on Port 7000") })


/* We have to read the json file first before writing in it, 
if we just write, we will overwrite all the data inside of it. 

The following resouces helps us understand how to read and write from a json file 


- How to read and write a JSON object to a file in Node.js
- Reading and writing JSON files in Node.js: A complete tutorial
- How to read and write JSON file using Node.js
- How to read and write JSON files in Node.js - Atta-Ur-Rehman Shah
- NodeJS how to write JSON data to a file tutorial | sebhastian


*/


/*  We can't use fs to just write to the webpage as it's a nodejs (server) feature, 
    That is not understood by the browser.
    
    This is why we need to use a ajax request to request the data from the server we created
    and used to store the data in the json in the first place 
    
    
    Summary:
    
    1- We created a server on our PC, made a post request to our server from the browser form
        this transfers the data to us so we could store it in a json file.

    2- now to show the data again on a webpage, We need to send it again using a request to the client
        this is usally done by the client making an Ajax GET Requet to obtain the json file data.

    */

