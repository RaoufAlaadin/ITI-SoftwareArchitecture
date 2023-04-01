/**
 * Server ==> Port & http ===> require("http")
 */

const http = require("http");
const fs = require("fs");
http.createServer((req, res) => {
    //logic

    /* By default chrome sends a GET request with each refresh
     for the `favicon.ico` ... So we have to run our logic when the url
     does not match the `favicon.ico` request. 
     
     We want to work on only the GET request by the URL 
     */


    if (req.url != "/favicon.ico") {

        /* We always expect 3 main parts from a request
            1- url => path to guide us 
            2- method => type of operation wanted
            3- body => needed only in case of POST and PUT 
            
            NOTE:  body here is undefined because we sent `no body` 😁
                We are only dealing with a  GET request here. 
         */

        // console.log(req.url);
        // console.log(req.method);
        // console.log(req.body);

        let reqArr = req.url.split("/");
        console.log(reqArr);
        let result = 0;
        let calculationType = reqArr[1].toLowerCase();

        switch (calculationType) {
            case "add":
                for (let i = 2; i < reqArr.length; i++) {
                    result += parseInt(reqArr[i]);
                }

                break;

            case "subtract":
                result = parseInt(reqArr[2]);
                for (let i = 3; i < reqArr.length; i++) {
                    result -= parseInt(reqArr[i]);
                }
                break;
            case "multiply":
                result = 1;
                for (let i = 2; i < reqArr.length; i++) {
                    result *= parseInt(reqArr[i]);
                }
                break;
            case "divide":
                result = parseInt(reqArr[2]);
                for (let i = 3; i < reqArr.length; i++) {
                    result /= parseInt(reqArr[i]);
                }
                break;

            default:
                res.writeHead(404, "Not Found", { "content-type": "text/plain"});
                res.end("Invalid calculation type");
                return;


        }

        // for(let i = 1; i < reqArr.length; i++)
        // {
        //     reuslt += parseInt(reqArr[i]) ;
        // }



        res.writeHead(200, "ok", { "content-type": "text/plain" })
        res.write(`<h1>Our calc sum is => ${result} </h1>`)

        fs.appendFile("file.txt", `Our calc sum is => ${result}\n`, function (err) {
            if (err) throw err;
            console.log("Result appended to file");
        });

        res.end();
    }
}).listen(7000)




/*  Refactored ===> 


const http = require("http");
const fs = require("fs");

http.createServer((req, res) => {
  // Ignore favicon.ico requests
  if (req.url === "/favicon.ico") {
    res.writeHead(204);
    res.end();
    return;
  }

  // Parse the URL and make sure it has at least 2 parts
  const [operation, ...numbers] = req.url.split("/").filter(Boolean);
  if (!operation || numbers.length < 2) {
    res.writeHead(400, { "content-type": "text/plain" });
    res.end("Invalid request");
    return;
  }

  // Parse the numbers and perform the operation
  const parsedNumbers = numbers.map(Number);
  let result;
  switch (operation) {
    case "add":
      result = parsedNumbers.reduce((sum, n) => sum + n, 0);
      break;
    case "subtract":
      result = parsedNumbers.reduce((diff, n) => diff - n);
      break;
    case "multiply":
      result = parsedNumbers.reduce((product, n) => product * n, 1);
      break;
    case "divide":
      result = parsedNumbers.reduce((quotient, n) => quotient / n);
      break;
    default:
      res.writeHead(404, { "content-type": "text/plain" });
      res.end("Invalid operation");
      return;
  }

  // Write the result and append it to the file
  const message = `Our ${operation} result is => ${result}\n`;
  res.writeHead(200, { "content-type": "text/html" });
  res.write(`<h1>${message}</h1>`);
  fs.appendFile("file.txt", message, (err) => {
    if (err) throw err;
    console.log("Result appended to file");
  });
  res.end();
}).listen(7000, () => {
  console.log("Server is running on port 7000");
});


*/