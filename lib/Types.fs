module Types

type Poly = int list

type Degree =
    | MinusInf
    | Fin of int