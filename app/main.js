var socket = io.connect("http://localhost:3000")
const {
  ipcRenderer
} = require('electron')
document.getElementById("title").innerHTML += `<h3>Token: <u>${token}</u><br>Your Notifications:</h3>`;

socket.on("connect", () => {
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
    document.getElementById("nots").innerHTML += `
    <div class="not">
      ${item.msg}<br>
    </div>
    `;
  }
})

socket.on("new", (data) => {
  document.getElementById("nots").innerHTML += `
  <div class="not">
    ${data.msg}<br>
  </div>
  `;
})
