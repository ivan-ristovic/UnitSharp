namespace UnitSharp

module Units =

    open System.Collections.Generic
    
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
            
    type Time =
        | Second 
        | Minute
        | Hour
        | Day 
        | Week
        | Month
        | Year 
        | Decade 
        | Century 
        | Millenium 
        interface IUnit with
            member this.Type = 
                match this with
                | _ -> Metric 
            
    let UnitFromString : IReadOnlyDictionary<string, IUnit> = 
        readOnlyDict [ 
            ("m", Meter :> IUnit);
            ("in", Inch :> IUnit);
            ("ft", Foot :> IUnit);
            ("yd", Yard :> IUnit);
            ("mi", Mile :> IUnit);
            ("s", Second :> IUnit);
        ]

    let UnitToString : IReadOnlyDictionary<IUnit, string> = 
        readOnlyDict [ 
            ( Meter :> IUnit, "m");
            ( Inch :> IUnit, "in");
            ( Foot :> IUnit, "ft");
            ( Yard :> IUnit, "yd");
            ( Mile :> IUnit, "mi");
            ( Second :> IUnit, "s");
        ]
