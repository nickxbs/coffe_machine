module internal CoffeeMachine.Core
open System
open System.Text.RegularExpressions
open CoffeeMachine.Maker
open DrinkMaker.Data
open CoffeeMachine.DrinkRepository

let showMessage display message =
  let pattern  = "^M:(.*)$"
  let matches = Regex.Match(message, pattern)
  display matches.Groups.[1].Value

let display message =
  printfn "%s" message

let make'' maker display (orderStr: string) =
  if orderStr.StartsWith("M")
  then showMessage display orderStr
       None
  else match makeBeverage orderStr with
       | Message m -> display m
                      None                      
       | Drink drink -> match drink with
                        | Some beverage -> let save, _ = drinkRepo
                                           save beverage |> Some
                         
                        | None -> failwith "Error"

let make' display orderStr =
  make'' makeBeverage display orderStr
