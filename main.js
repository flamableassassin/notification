const {
  app,
  BrowserWindow,
  Notification
} = require('electron')

//server stuff//
const body_parser = require('body-parser');
const server = require('express')();
const http = require('http').Server(server);
let socket = require('socket.io')(http);
server.use(body_parser.json())

let open = false;
let already_opened = false;
let win;
let notification_list = [];
app.on('ready', function() {
  //server online
  let token;
  http.listen(3000, function() {
    token = "asda";
    notification_list.push({
      token: token
    })
    return;
    send_not("App online", `Token: ${token}`, 10)
  })
  //----------------------------------------------------------//
  server.post("/", (req, res) => {
    socket.emit("new", req.body)
    //adding the current time
    Object.assign(req.body, {
      time: Date.now()
    })
    notification_list.push(req.body)
    res.send("ok")
    if (open) return;
    //sending notification
    let not = send_not(req.body.title, req.body.msg, req.body.type);
    //responding to client//
    //opening window when the notification is opened
    not.on("click", () => {
      open = true;
      if (already_opened) win.show();
      else {
        already_opened = true;
        win = new BrowserWindow({
          webPreferences:{
            nodeIntegration:true
          },
          width: 1000,
          height: 1000,
          resizeable: false,
          frame: false
        })

        win.loadURL("file:" + __dirname + "/html/message.html")
        win.once('ready-to-show', () => {
          win.show()
        })
      }
      socket.on("close", (socket) => {
        console.log("ok");
        win.hide();
        open = false;
      })
    });
  })
})

socket.on("connection", (socket) => {
  socket.emit("data", notification_list)
})

socket.on("close", (socket) => {
  console.log("ok");
})

function send_not(title, msg, type) {
  let types = {
    1: __dirname + "/img/msg.png", //message
    2: __dirname + "/img/battery.png", // battery
    3: __dirname + "/img/phone.png",
    10: __dirname + "/img/server.png" // server msg
  }
  let not = new Notification({
    title: title,
    body: msg,
    icon: types[type],
    silent: true
  })
  not.show()
  return not;
}
