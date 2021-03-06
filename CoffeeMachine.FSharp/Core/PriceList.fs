module CoffeeMachine.PriceList

open System.Collections.Generic
open DrinkMaker.Data

let private prices = dict[Tea, 0.4; Coffee, 0.6; Chocolate, 0.5; Orange, 0.6]

let priceList beverageTYpe =
  prices.Item beverageTYpe
