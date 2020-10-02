module Tests

open System
open Xunit
open Types
open Poly
open FsCheck
open FsCheck.Xunit


// Preserving an invariant
// The invariant being that all functions on polynomials should give legal polynomials if given legal polynomials

[<Property>]
let ``prune produces legal polynomials property`` p = isLegal (prune p)

let invarianceTwoPolys op (p1: Poly) (p2: Poly) =
    isLegal (op (prune p1) (prune p2))

let invarianceOnePoly op (p: Poly) = isLegal (op (prune p))

// Part 1 function tests
[<Property>]
let ``add preserves the invariant`` () = invarianceTwoPolys add

[<Property>]
let ``mulC preserves the invariant`` n (p: Poly) = isLegal (mulC n (prune p))

[<Property>]
let ``sub preserves the invariant`` () = invarianceTwoPolys sub

[<Property>]
let ``mulX preserves the invariant`` (p: Poly) = invarianceOnePoly mulX

[<Property>]
let ``mul preserves the invariant`` () = invarianceTwoPolys mul

// Part 2 function tests
[<Property>]
let ``derivative preserves the invariant`` () = invarianceOnePoly derivative


// Properties of a commutative ring
let one: Poly = [1]
let zero: Poly = []

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