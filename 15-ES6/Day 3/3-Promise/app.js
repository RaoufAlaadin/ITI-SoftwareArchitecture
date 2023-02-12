function parsingData(url) {
  return fetch(url)
    .then(response => {
      if (!response.ok) {
        // we throw an error and have a catch to handle it. 
        throw new Error(response.statusText);
      }
      // this is the full response
      console.log(response); 

      //this line returns the json data from the responce 
      return response.json();
    })
    .catch(error => {
      console.error(error);
    });
}

parsingData("https://jsonplaceholder.typicode.com/users")
  .then(data => {


    /* The parsingData method we made returns the responce.json() directly
     that's why we just started working with the data. */
    
    let table = `<table class="table table-bordered">
                  <thead>
                    <tr>
                      <th>ID</th>
                      <th>Name</th>
                      <th>Username</th>
                      <th>Email</th>
                    </tr>
                  </thead>
                  <tbody>`;

                 
    data.forEach(user => {
      table += `<tr>
                  <td>${user.id}</td>
                  <td>${user.name}</td>
                  <td>${user.username}</td>
                  <td>${user.email}</td>
                </tr>`;
    });

    table += `</tbody></table>`;

    document.getElementById("table").innerHTML = table;
  })
  .catch(error => {
    console.error(error);
  });

  // console.log("nothing started")
