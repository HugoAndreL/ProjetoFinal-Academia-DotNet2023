import { Cargo } from "./cargo";

export interface Usuario {
  id?: number,
  nome: string,
  email: string,
  senha?: string,
  cargoId?: number,
  cargo?: Cargo,
}
