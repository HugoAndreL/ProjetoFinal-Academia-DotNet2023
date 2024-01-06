import { Funcionalidade } from "./funcionalidade";

export interface Cargo {
  id?: number,
  nome: string,
  funcs?: Funcionalidade[]
}
