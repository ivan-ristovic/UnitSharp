module Units 

    type UnitType =
        | Metric
        | Imperial

    type IUnit = 
        abstract Type : UnitType

    type Length =
        | Meter 
        | Inch 
        | Foot
        | Yard
        | Mile 
        interface IUnit with
            member this.Type = 
                match this with
                | Meter -> Metric 
                | _     -> Imperial
        override this.ToString() =
            match this with
            | Meter -> "m" 
            | Inch  -> "in"
            | Foot  -> "ft"
            | Yard  -> "yd"
            | Mile  -> "mi"
            
