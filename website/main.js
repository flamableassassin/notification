var socket = io.connect("http://localhost:3000")
let loaded = false;
const { ipcRenderer } = require('electron')
const token = ipcRenderer.sendSync('asynchronous-message',"token");
document.getElementById("title").innerHTML += `<h3>Token: ${token}<br>Your Notifications:</h3>`;


socket.on("connect",() => {
  socket.emit("verify",token)
})
socket.on('connect_error', function(err) {
  //reload page//
  location.reload();
  console.log("client connect_error: ", err);
});

socket.on('connect_timeout', function(err) {
  alert("Unable to connect to server")
});
socket.on("data", (data) => {
  ipcRenderer.send('asynchronous-message', 'token')
  for (var item of data) {
    document.getElementById("nots").innerHTML += `hi<br>`;
  }
})

socket.on("new", (data) => {
  document.getElementById("nots").innerHTML += `hi<br>`;

})
