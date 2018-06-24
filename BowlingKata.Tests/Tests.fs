module Tests

open System
open Xunit
open Bowling

[<Fact>]
let ``strike on every frame`` () =
    let score = 
        [   
            Strike
            Strike
            Strike
            Strike
            Strike
            Strike
            Strike
            Strike
            Strike
            FinalStrike (10, 10)
        ]
    let result = calculate score
    Assert.Equal (300, result)

[<Fact>]
let ``9 and 0 on every frame`` () =
    let game = 
        [   
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
            Pins (9, 0)
        ]
    let score = calculate game
    Assert.Equal (90, score)
   
[<Fact>]
let ``spare on every frame`` () =
    let game = 
        [   
            Spare 5
            Spare 5
            Spare 5
            Spare 5
            Spare 5
            Spare 5
            Spare 5
            Spare 5
            Spare 5
            FinalSpare (5, 5)
        ]
    let score = calculate game
    Assert.Equal (150, score)
