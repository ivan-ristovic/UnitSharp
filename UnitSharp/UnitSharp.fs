module UnitSharp

    type PrefixedUnit<'T when 'T :> Units.IUnit>(prefix: Modifiers.Prefix option, unit: 'T) =
        member this.Prefix = prefix
        member this.Unit = unit
        member this.Multiplier : double = (if this.Prefix.IsNone then 1. else this.Prefix.Value.Multiplier)
        override this.ToString() = 
            let pstr = if this.Prefix.IsNone then "" else this.Prefix.Value.ToString()
            $"{pstr} {this.Unit.ToString()}"
        

    let unit<'T when 'T :> Units.IUnit> (u : 'T) : PrefixedUnit<'T> =
        new PrefixedUnit<'T>(None, u)

    let punit<'T when 'T :> Units.IUnit> (p : Modifiers.Prefix) (u : 'T) : PrefixedUnit<'T> =
        new PrefixedUnit<'T>(Some p, u)


    let convert<'TUnit, 'TConv when 'TConv :> Converters.IConverter<'TUnit>> (v: double) (u1: PrefixedUnit<'TUnit>) (u2: PrefixedUnit<'TUnit>) : double =
        let converter = System.Activator.CreateInstance typedefof<'TConv> :?> Converters.IConverter<'TUnit>
        let v2f = v * u1.Multiplier |> converter.ToSi u1.Unit |> converter.FromSi u2.Unit 
        v2f * u2.Multiplier

    let convertLength = convert<Units.Length, Converters.LengthConverter>