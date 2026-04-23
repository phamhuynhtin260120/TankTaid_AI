export const PROTOCOL_VERSION = "v1";

export const C2S = {
  ROOM_JOIN: "C2S_ROOM_JOIN",
  INPUT_TICK: "C2S_INPUT_TICK"
} as const;

export const S2C = {
  CONNECTED: "S2C_CONNECTED",
  STATE_SNAPSHOT: "S2C_STATE_SNAPSHOT"
} as const;
