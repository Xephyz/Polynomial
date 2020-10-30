module Poly

open Types

val isLegal:    int list -> bool
val prune:      int list -> Poly

val add:        Poly -> Poly -> Poly
val mulC:       int -> Poly -> Poly
val sub:        Poly -> Poly -> Poly
val mulX:       Poly -> Poly
val mul:        Poly -> Poly -> Poly
val eval:       int -> Poly -> int

val toString:   Poly -> string
val derivative: Poly -> Poly
val compose:    Poly -> Poly -> Poly
