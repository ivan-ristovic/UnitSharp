namespace UnitSharp

module UnitSharp =

    open System.Linq

    type PrefixedUnit<'T when 'T :> Units.IUnit>(prefix: Modifiers.Prefix option, unit: 'T) =
        member this.Prefix = prefix
        member this.Unit = unit
        member this.Multiplier : double = (if this.Prefix.IsNone then 1. else this.Prefix.Value.Multiplier)
        override this.ToString() = 
            let pstr = if this.Prefix.IsNone then "" else Modifiers.PrefixToString.[this.Prefix.Value]
            $"{pstr}{Units.UnitToString.[this.Unit]}"
        

    let Unit<'T when 'T :> Units.IUnit> (u : 'T) : PrefixedUnit<'T> =
        new PrefixedUnit<'T>(None, u)

    let PUnit<'T when 'T :> Units.IUnit> (p : Modifiers.Prefix) (u : 'T) : PrefixedUnit<'T> =
        new PrefixedUnit<'T>(Some p, u)

    let ParseUnit(s: string) : PrefixedUnit<Units.IUnit> =
        let prefix = Modifiers.PrefixFromString.Keys.FirstOrDefault(fun k -> s.StartsWith(k))
        let unprefixed = 
            let prefixLength = if isNull prefix then 0 else prefix.Length
            s.Substring(prefixLength)
        let unit = Units.UnitFromString.[unprefixed]
        if isNull prefix then Unit unit else PUnit Modifiers.PrefixFromString.[prefix] unit

    let Convert<'TUnit, 'TConv when 'TConv :> Converters.IConverter<'TUnit>> (v: double) (u1: PrefixedUnit<'TUnit>) (u2: PrefixedUnit<'TUnit>) : double =
        let converter = System.Activator.CreateInstance typedefof<'TConv> :?> Converters.IConverter<'TUnit>
        let v2f = v * u1.Multiplier |> converter.ToSi u1.Unit |> converter.FromSi u2.Unit 
        v2f * u2.Multiplier

    let ConvertLength = Convert<Units.Length, Converters.LengthConverter>
