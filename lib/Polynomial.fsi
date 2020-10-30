module Poly

open Types

// Part 3 functions that were moved to beginning
val isLegal:    int list -> bool
val prune:      int list -> Poly

// Part 1 functions
val add:        Poly -> Poly -> Poly
val mulC:       int -> Poly -> Poly
val sub:        Poly -> Poly -> Poly
val mulX:       Poly -> Poly
val mul:        Poly -> Poly -> Poly
val eval:       int -> Poly -> int

// Part 3 functions
val toString:   Poly -> string
val derivative: Poly -> Poly
val compose:    Poly -> Poly -> Poly

// Part 4 functions
val deg:        Poly -> Degree
val addD:       Degree -> Degree -> Degree
