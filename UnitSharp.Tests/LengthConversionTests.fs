namespace UnitSharp.Tests

module LengthConversionTests =

    open System
    open Xunit
    open UnitSharp
    
    [<Fact>]
    let ``FromMeter1`` () =
        let conv x t = 
            let v1 = UnitSharp.Unit Units.Length.Meter
            let v2 = UnitSharp.Unit t
            UnitSharp.ConvertLength x v1 v2
        Assert.Equal(39.37007874015748, conv 1. Units.Inch, 10)
        Assert.Equal(3.2808398950131235, conv 1. Units.Foot, 10)
        Assert.Equal(1.0936132983377078, conv 1. Units.Yard, 10)
        Assert.Equal(0.00062137119223733397, conv 1. Units.Mile, 10)
        
    [<Fact>]
    let ``FromMeter.5`` () =
        let conv x t = 
            let v1 = UnitSharp.Unit Units.Length.Meter
            let v2 = UnitSharp.Unit t
            UnitSharp.ConvertLength x v1 v2
        Assert.Equal(19.68503937007874015748, conv 0.5 Units.Inch, 10)
        Assert.Equal(1.64041994750656167979, conv 0.5 Units.Foot, 10)
        Assert.Equal(0.54680664916885389326, conv 0.5 Units.Yard, 10)
        Assert.Equal(0.00031068559611866698, conv 0.5 Units.Mile, 10)
        
    [<Fact>]
    let ``FromMeterQualified`` () =
        let conv x t = 
            let v1 = UnitSharp.PUnit Modifiers.Kilo Units.Length.Meter
            let v2 = UnitSharp.Unit t
            UnitSharp.ConvertLength x v1 v2
        Assert.Equal(196850.39370078740157480315, conv 5. Units.Inch, 10)
        Assert.Equal(16404.19947506561679790026, conv 5. Units.Foot, 10)
        Assert.Equal(5468.06649168853893263342, conv 5. Units.Yard, 10)
        Assert.Equal(3.10685596118666984809, conv 5. Units.Mile, 10)
