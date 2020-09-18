module TestPoly

open Types
open Poly
open FsCheck

let addInvSimple (p1: Poly) (p2: Poly) =
    if isLegal p1 && isLegal p2 then isLegal (add p1 p2) else true

let addInv (p1: Poly) (p2: Poly) =
    isLegal (add (prune p1) (prune p2))

let _ = Check.Quick addInvSimple;;

// [<Test>]
// let ``When [1;2] is added to [3;4;5;6] expect [4;6;5;6]``() = ()


// Attempt to... Something?
let p1 = Poly.prune [1..3];;
let p2 = Poly.prune [2..2..6];;
let p3 = Poly.prune [3..3..9];;

let zero = Poly.prune [0];;
let one = Poly.prune [1];;

let (.+.) p1 p2 = Poly.add p1 p2;;
let (~-.) p = Poly.mulC -1 p;;
let (.*.) p1 p2 = Poly.mul p1 p2;;

// Properties of a commutative ring
(p1 .+. p2) .+. p3 = p1 .+. (p2 .+. p3);;
p1 .+. p2 = p2 .+. p1;;
p1 .+. zero = p1 && p1 = zero .+. p1;;
p1 .+. (-. p1) = zero;;
(p1 .*. p2) .*. p3 = p1 .*. (p2 .*. p3);;
p1 .*. p2 = p2 .*. p1;;
p1 .*. one = p1 && p1 = one .*. p1;;
p1 .*. (p2 .+. p3) = (p1 .*. p2) .+. (p1 .*. p3);;
(p1 .+. p2) .*. p3 = (p1 .*. p3) .+. (p2 .*. p3);;
