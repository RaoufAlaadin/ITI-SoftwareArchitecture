// Get the button element by id
let button = document.getElementById("getData");

// Add a click event listener to the button
button.addEventListener("click", function() {
  // Use fetch to get the JSON file
  fetch("../data.json")
    .then((response) => response.json()) // Convert the response to JSON
    .then((data) => {

      // Get the table body element by id

      console.log(data);
      let tableBody = document.getElementById("tableBody");

      // Loop through the data array
      for (let item of data) {
        // Create a new table row element
        let row = document.createElement("tr");

        // Create four table cell elements for each property
        let nameCell = document.createElement("td");
        let mobileCell = document.createElement("td");
        let addressCell = document.createElement("td");
        let emailCell = document.createElement("td");

        // Set the text content of each cell to the corresponding property value
        nameCell.textContent = item.name;
        mobileCell.textContent = item.mobile;
        addressCell.textContent = item.address;
        emailCell.textContent = item.email;

        // Append the cells to the row
        row.appendChild(nameCell);
        row.appendChild(mobileCell);
        row.appendChild(addressCell);
        row.appendChild(emailCell);

        // Append the row to the table body
        tableBody.appendChild(row);
      }
    })
    .catch((error) => console.error(error)); // Handle any errors
});














// (function () {
// 'use strict'
// const forms = document.querySelectorAll('.requires-validation')
// Array.from(forms)
//   .forEach(function (form) {
//     form.addEventListener('submit', function (event) {
//       if (!form.checkValidity()) {
//         event.preventDefault()
//         event.stopPropagation()
//       }

//       form.classList.add('was-validated')
//     }, false)
//   })
// })()


