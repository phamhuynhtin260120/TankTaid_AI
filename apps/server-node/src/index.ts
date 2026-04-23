import { RawData, WebSocket, WebSocketServer } from "ws";

const port = Number(process.env.PORT ?? 3001);
const wss = new WebSocketServer({ port });

wss.on("connection", (socket: WebSocket) => {
  socket.send(
    JSON.stringify({
      type: "S2C_CONNECTED",
      payload: { message: "Connected to TankTaid server." }
    })
  );

  socket.on("message", (raw: RawData) => {
    socket.send(
      JSON.stringify({
        type: "S2C_ECHO",
        payload: { received: raw.toString() }
      })
    );
  });
});

console.log(`[server-node] WebSocket listening on :${port}`);
