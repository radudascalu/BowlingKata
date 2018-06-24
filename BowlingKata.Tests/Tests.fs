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

[<Fact>]
let ``strike on first 9 frames and then spare`` () =
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
            FinalSpare (5, 5)
        ]
    let result = calculate score
    Assert.Equal (270, result)
    
[<Fact>]
let ``spare on 9th frame and strike on the 10th`` () =
    let score = 
        [   
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Spare 9
            FinalStrike (0, 0)
        ]
    let result = calculate score
    Assert.Equal (30, result)

[<Fact>]
let ``strike followed by a spare and then 5pins`` () =
    let score = 
        [   
            Strike
            Spare 5
            Pins (5, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
        ]
    let result = calculate score
    Assert.Equal (40, result)

[<Fact>]
let ``strike followed by 4pins and 5pins`` () =
    let score = 
        [   
            Strike
            Pins (4, 5)
            Pins (5, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
            Pins (0, 0)
        ]
    let result = calculate score
    Assert.Equal (33, result)
