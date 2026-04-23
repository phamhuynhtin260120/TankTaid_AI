# TankTaid AI - Monorepo Scaffold

This repository now includes a multiplayer game scaffold for:
- Unity client
- Node.js backend
- Shared protocol/config packages

## Current status

- Existing Unity project remains at repository root for safety.
- New monorepo folders are added for server-side and shared code.
- You can migrate Unity project into `apps/client-unity` later when ready.

## Top-level layout

- `apps/client-unity`: future Unity project location
- `apps/server-node`: Node.js networking backend
- `shared/shared-protocol`: shared message/event contracts
- `shared/shared-config`: shared constants and balance defaults
- `shared/shared-utils`: shared utility functions
- `infra`: local/runtime infrastructure files
- `tools`: scripts and helpers
- `docs`: architecture and networking docs
