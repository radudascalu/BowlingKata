module Bowling

open System

type Throw = int
type FirstThrow = Throw
type SecondThrow = Throw
type ThirdThrow = Throw

type Frame = 
    | Strike
    | FinalStrike of SecondThrow * ThirdThrow
    | Spare of FirstThrow
    | FinalSpare of FirstThrow * ThirdThrow
    | Pins of FirstThrow * SecondThrow
  
type BowlingGame = Frame list

let private getFirstThrowValue frame =
    match frame with
    | Strike -> 10
    | FinalStrike _ -> 10
    | Spare first -> first
    | FinalSpare (first, _) -> first
    | Pins (first, second) -> first 

let private getFirst2ThrowsValue frame1 (frame2: Frame option) =
    match frame1 with
    | Strike -> 10 + (getFirstThrowValue frame2.Value)
    | FinalStrike (second, third) -> 10 + second
    | Spare _ -> 10
    | FinalSpare (first, _) -> 10
    | Pins (first, second) -> first + second

let private calculateFrame (frame: Frame, nextFrame: Frame option, secondNextFrame: Frame option) =
    match frame with
    | Strike -> 10 + (getFirst2ThrowsValue nextFrame.Value secondNextFrame)
    | FinalStrike (second, third) -> 10 + second + third
    | Spare _ -> 10 + (getFirstThrowValue nextFrame.Value)
    | FinalSpare (_, thirdThrow) -> 10 + thirdThrow
    | Pins (throw1, throw2) -> throw1 + throw2
    
let calculate (game: BowlingGame) =
    let prepend a b = List.append b a
    game
    |> List.map (fun frame -> Some frame)
    |> prepend [None; None]
    |> List.windowed 3
    |> List.map (fun frames -> (frames.[0], frames.[1], frames.[2]))
    |> List.fold (fun score (frame, nextFrame, secondNextFrame) -> score + (calculateFrame (frame.Value, nextFrame, secondNextFrame))) 0
