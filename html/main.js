var socket = io.connect("http://localhost:3000")
let loaded = false;


socket.on('connect_error', function(err) {
  console.log("client connect_error: ", err);
});

socket.on('connect_timeout', function(err) {
  console.log("client connect_timeout: ", err);
});


socket.on("data", (data) => {
  console.log("getting data");
  for (var item of data) {
    if (item.token !== undefined) document.getElementById("title").innerHTML += `<h3>Token: ${item.token}<br>Your Notifications:</h3>`;
    else document.getElementById("nots").innerHTML += `<br>hi`;
  }
})

socket.on("new", (data) => {
  document.getElementById("nots").innerHTML += `<br>hi`;

})

function close() {
  console.log("ok");
  socket.emit("close",function () {

  })
  console.log("ok");
}
