namespace UnitSharp.Tests

module StringTests =

    open System
    open Xunit
    open UnitSharp
    
    [<Fact>]
    let ``PrefixedUnitToString`` () =
        Assert.Equal("m", (UnitSharp.Unit Units.Meter).ToString())
        Assert.Equal("s", (UnitSharp.Unit Units.Second).ToString())
        Assert.Equal("yd", (UnitSharp.Unit Units.Yard).ToString())
        Assert.Equal("km", (UnitSharp.PUnit Modifiers.Kilo Units.Meter).ToString())
        Assert.Equal("mm", (UnitSharp.PUnit Modifiers.Milli Units.Meter).ToString())
        
    [<Fact>]
    let ``ParseUnits`` () =
        let assertPart s pref unit = 
            let p = UnitSharp.ParseUnit(s)
            Assert.Equal(pref, p.Prefix)
            Assert.Equal(unit, p.Unit)
        assertPart "mm" (Some Modifiers.Milli) Units.Meter
        assertPart "km" (Some Modifiers.Kilo) Units.Meter
        assertPart "ms" (Some Modifiers.Milli) Units.Second
