# Architecture

High-level architecture:
- Unity client sends player inputs via WebSocket.
- Node.js server validates and simulates room state.
- Server broadcasts state snapshots or deltas.
- Shared protocol package keeps client/server message contracts aligned.
