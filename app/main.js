var socket = io.connect("http://localhost:2659")
const {
  ipcRenderer
} = require('electron')

let disconnted = false;
socket.on("connect", () => {
  if (disconnted) alert("Connected to server again")
})
socket.on('connect_error', function(err) {
  //reload page//
  let disconnted = true;
  location.reload();
  console.log("client connect_error: ", err);
});

socket.on('connect_timeout', function(err) {
  alert("Unable to connect to server")
});

socket.on("verify", (data, fn) => {
  let choice = confirm(`New connection from ${data}\nWould you like to verify them?`)
  fn(choice ? "t" : "f")
})

socket.on("data", (data) => {
  ipcRenderer.send('asynchronous-message', 'token')
  for (var item of data) {
    document.getElementById("nots").innerHTML += `
    <div class="not">
      <b>${item.title}</b>
      <hr>
      ${item.msg}
    </div>
    `;
  }
})

socket.on("verify",(data,fn) => {
    fn("hi")
})

socket.on("new", (item) => {
  document.getElementById("nots").innerHTML += `
  <div class="not">
    <b>${item.title}</b>
    <hr>
    ${item.msg}
  </div>
  `;
})


//sticky nav//
var navbar = document.getElementById("title");
var sticky = navbar.offsetTop;
window.onscroll = function() {
  if (window.pageYOffset >= sticky) navbar.classList.add("sticky")
  else navbar.classList.remove("sticky");
}
