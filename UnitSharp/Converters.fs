namespace UnitSharp

module Converters =

    type IConverter<'T when 'T :> Units.IUnit> =
        abstract Si : 'T
        abstract ToSi : 'T -> double -> double 
        abstract FromSi : 'T -> double -> double

    type LengthConverter() =
        interface IConverter<Units.Length> with
            member this.Si: Units.Length = Units.Length.Meter
            member this.FromSi(unit: Units.Length) (value: double): double = 
                let factor = 
                    match unit with
                    | Units.Length.Meter -> 1.
                    | Units.Length.Mile  -> 0.00062137119223733397
                    | Units.Length.Inch  -> 39.37007874015748031496
                    | Units.Length.Foot  -> 3.28083989501312335958
                    | Units.Length.Yard  -> 1.09361329833770778653
                value * factor
            member this.ToSi(unit: Units.Length) (value: double): double = 
                let factor = 
                    match unit with
                    | Units.Length.Meter -> 1.
                    | Units.Length.Mile  -> 1609.344
                    | Units.Length.Inch  -> 0.0254
                    | Units.Length.Foot  -> 0.3048
                    | Units.Length.Yard  -> 0.9144
                value * factor
            
