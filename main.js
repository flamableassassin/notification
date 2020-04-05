const {
  app,
  BrowserWindow,
  Notification,
  ipcMain
} = require('electron')
const ip = require('ip');
//server stuff//
const body_parser = require('body-parser');
const server = require('express')();
const http = require('http').Server(server);
let socket = require('socket.io')(http);
server.use(body_parser.json())

//
let open = false;
let already_opened = false;
let win;
let notification_list = [];
const web_token = Math.random().toString(36).substring(2, 6);

app.on('ready', function() {
  //server online
  http.listen(3000, function() {
    return;
    send_not("App online", `👍`, 10)
  })
  //----------------------------------------------------------//
  server.post("/", (req, res) => {
    socket.to("verified").emit("new", req.body)
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
          webPreferences: {
            nodeIntegration: true
          },
          width: 1000,
          height: 1000,
          resizeable: false,
          frame: false
        })

        win.loadURL("file:" + __dirname + "/app/message.html")
        win.once('ready-to-show', () => {
          win.show()
        })
      }
    });
  })
})

ipcMain.on('asynchronous-message', (event, arg) => {
  if (arg === "close") {
    if (open) win.hide();
    open = false
  }
})
socket.on("connection", (socket) => {
  if (ip.isPrivate(socket.handshake.address)) {
    socket.join("verified")
    socket.emit("data", notification_list)
  }
  socket.on("verify", (test_token) => {
    if (test_token !== token) return;
    socket.join("verified")
    socket.emit("data", notification_list)
    send_not("Verified New Connection", `Socket id: ${socket.id}`, 10)
    console.log("verified " + socket.id);
  })
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
