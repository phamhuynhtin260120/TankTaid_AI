# Networking Notes

- Transport: WebSocket
- Message naming: `C2S_*` and `S2C_*`
- Recommended flow:
  1. connect
  2. join room
  3. send periodic input ticks
  4. receive state snapshots
  5. interpolate on client side
