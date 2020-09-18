// Learn more about F# at http://fsharp.org

open System
open Types
open Poly

[<EntryPoint>]
let main argv =
    // printfn "Hello World from F#!"
    printfn "Testing the poly things\n"

    printfn "Part 1 funcs:"
    printfn "add [1;2] [3;4;5;6] = [4;6;5;6]: %s" (string (Poly.add [1;2] [3;4;5;6] = [4;6;5;6]))
    printfn "mulC 2 [2;0;0;1] = [4;0;0;2]: %s" (string (Poly.mulC 2 [2;0;0;1] = [4;0;0;2]))
    printfn "sub [1;2] [3;4;5;6] = [-2;-2;-5;-6]: %s" (string (Poly.sub [1;2] [3;4;5;6] = [-2;-2;-5;-6]))
    printfn "mulX [2;0;0;1] = [0;2;0;0;1]: %s" (string (Poly.mulX [2;0;0;1]=[0;2;0;0;1]))
    printfn "mul [2;3;0;1] [1;2;3] = [2;7;12;10;2;3]: %s" (string (Poly.mul [2;3;0;1] [1;2;3] = [2;7;12;10;2;3]))
    printfn "eval 2 [2;3;0;1] = 16: %s\n" (string (Poly.eval 2 [2;3;0;1] = 16))

    printfn "Part 2 funcs:"
    printfn "isLegal [2;5;0] = False: %s" (string (Poly.isLegal [2;5;0] = false))
    printfn "isLegal [2;5;0;2] = True: %s" (string (Poly.isLegal [2;5;0;2]))
    printfn "prune [2;5;0] = [2;5]: %s" (string (Poly.prune [2;5;0] = [2;5]))
    printfn "prune [2;5;0;2] = [2;5;0;2]: %s" (string (Poly.prune [2;5;0;2] = [2;5;0;2]))
    printfn "toString [2;5;0;3] = 2 + 5x + 3x^3: %s" (string (Poly.toString [2;5;0;3] = "2 + 5x + 3x^3"))
    printfn "derivative [1;2;3] = [2;6]: %s" (string (Poly.derivative [1;2;3] = [2;6]))
    printfn "compose [2;0;0;4] [0;3;2] = [2;0;0;108;216;144;32]: %s\n" (string (Poly.compose [2;0;0;4] [0;3;2] = [2;0;0;108;216;144;32]))

    printfn "Part 3 funcs:"
    printfn "deg [] = MinusInf: %s" (string (Poly.deg [] = MinusInf))
    printfn "deg [2;0;0;1] = Fin 3: %s" (string (Poly.deg [2;0;0;1] = Fin 3))
    printfn "addD (deg []) (deg [2;3]) = MinusInf: %s" (string (Poly.addD (deg []) (deg [2;3]) = MinusInf))
    printfn "addD (deg [1..5]) (deg [1;2]) = Fin 5: %s" (string (Poly.addD (deg [1..5]) (deg [1;2]) = Fin 5))

    0 // return an integer exit code
