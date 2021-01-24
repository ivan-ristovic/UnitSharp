module Modifiers
    
    type Prefix = 
        | Nano 
        | Micro 
        | Milli 
        | Centi 
        | Deci 
        | Deca 
        | Hecto 
        | Kilo 
        | Mega 
        | Giga 
        | Tera 
        
        member this.ToShortString = 
            match this with
            | Nano -> "n"
            | Micro -> "µ"
            | Milli -> "m"
            | Centi -> "c"
            | Deci -> "d"
            | Deca -> "da"
            | Hecto -> "h"
            | Kilo -> "k"
            | Mega -> "M"
            | Giga -> "G"
            | Tera -> "T"

        member this.Multiplier = 
            match this with
            | Nano -> 1e-9
            | Micro -> 1e-6
            | Milli -> 1e-3
            | Centi -> 1e-2
            | Deci -> 1e-1
            | Deca -> 1e1
            | Hecto -> 1e2
            | Kilo -> 1e3
            | Mega -> 1e6
            | Giga -> 1e9
            | Tera -> 1e12

