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
let io = require('socket.io')(http);
server.use(body_parser.json())

//
let open = false;
let already_opened = false;
let win, app_id;
let notification_list = [];
const web_token = Math.random().toString(36).substring(2, 6);

app.on('ready', function() {
  //server online
  http.listen(2659, function() {
    return;
    send_not("App online", `IP: ${ip.address()}`, 10)
  })
  //----------------------------------------------------------//
  server.post("/", (req, res) => {
    io.to("verified").emit("new", req.body)
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
          resizeable: true,
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

io.on("connection", (socket) => {
  if (ip.isPrivate(socket.handshake.address)) {
    app_id = socket.id;
    socket.join("verified")
      .join("app")
      .emit("data", notification_list)
  }
  console.log(io.sockets);
  //sending to client asking if they want to verify new device connecting//
  if (open) {
    io.to("app").emit("verify", socket.handshake.address, (data) => {
      console.log(data);
    })
  } else {
    let not = send_not(`New connecting from ${socket.handshake.address}`, "Would you like to verify please open the notification if so", 10)
    not.on("click", () => {

    })
  }

  socket.on("verify", (socket_id) => {
    if (socket.rooms["test"] === undefined) socket.close();

  })
})

function send_not(title, msg, type) {
  let types = {
    1: __dirname + "/img/msg.png", // message
    2: __dirname + "/img/battery.png", // battery
    3: __dirname + "/img/phone.png", // phone call
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
