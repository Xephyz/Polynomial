module Tests

open System
open Xunit
open Types
open Poly
open FsCheck
open FsCheck.Xunit

let one: Poly = [1]
let zero: Poly = []


[<Property>]
let ``Legal property`` p = isLegal (prune p)


let associative op (p1: Poly) (p2: Poly) (p3: Poly) =
    op (op p1 p2) p3 = op p1 (op p2 p3)

let commutative op (p1: Poly) (p2: Poly) =
    op p1 p2 = op p2 p1

let identity op (idenP: Poly) (p: Poly) =
    let p = prune p
    op p idenP = p && commutative op idenP p

let invAdditive (p: Poly) =
    add p (mulC -1 p) = zero

let distributive1 (p1: Poly) (p2: Poly) (p3: Poly) =
    mul p1 (add p2 p3) = add (mul p1 p2) (mul p1 p3)

let distributive2 (p1: Poly) (p2: Poly) (p3: Poly) =
    mul (add p1 p2) p3 = add (mul p1 p3) (mul p2 p3)

[<Property>]
let ``+ (Add) is associative`` () = associative add

[<Property>]
let ``+ (Add) is commutative`` () = commutative add

[<Property>]
let ``zero ([]) is the additive identity`` () = identity add zero

[<Property>]
let ``-p is the additive inverse of p`` () = invAdditive

[<Property>]
let ``* (mul) is associative`` () = associative mul

[<Property>]
let ``* (mul) is commutative`` () = commutative mul

[<Property>]
let ``one ([1]) is the multiplicative identity`` () = identity mul one

[<Property>]
let ``multiplication is distributive with respect to addition 1`` () = distributive1

[<Property>]
let ``multiplication is distributive with respect to addition 2`` () = distributive2