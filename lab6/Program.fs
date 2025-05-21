open System

module MathOps =

    let sum a b = a + b
    let diff a b = a - b
    let prod a b = a * b
    let divide a b = if b = 0.0 then Double.NaN else a / b
    let exponent a b = a ** b
    let root a = if a < 0.0 then Double.NaN else Math.Sqrt a
    let private degToRad x = x * Math.PI / 180.0
    let sine x = Math.Sin(degToRad x)
    let cosine x = Math.Cos(degToRad x)
    let tangent x = Math.Tan(degToRad x)

    let makePower p = fun x -> exponent x p
    let square = makePower 2.0
    let cube = makePower 3.0

module CLI =

    open MathOps

    let showBanner () =
        printfn "\nWelcome to Functional Calculator ヾ(＾ ∇ ＾)"
        printfn "[1] Add        [2] Subtract"
        printfn "[3] Multiply   [4] Divide"
        printfn "[5] Power      [6] Square Root"
        printfn "[7] Sine       [8] Cosine"
        printfn "[9] Tangent    [0] Quit"
        printf  "Choose option (0–9): "

    let inputNumber label =
        printf "%s: " label
        match Double.TryParse(Console.ReadLine()) with
        | true, v -> v
        | _ ->
            printfn "Invalid input, defaulting to 0.0"
            0.0

    let execute choice =
        let displayResult value =
            if Double.IsNaN value then
                printfn "Math error or invalid input!"
            else
                printfn "=> Result: %.4f" value

        match choice with
        | 1 ->
            let x = inputNumber "Enter A"
            let y = inputNumber "Enter B"
            sum x y |> displayResult
        | 2 ->
            let x = inputNumber "Enter A"
            let y = inputNumber "Enter B"
            diff x y |> displayResult
        | 3 ->
            let x = inputNumber "Enter A"
            let y = inputNumber "Enter B"
            prod x y |> displayResult
        | 4 ->
            let x = inputNumber "Enter A"
            let y = inputNumber "Enter B"
            divide x y |> displayResult
        | 5 ->
            let x = inputNumber "Base"
            let y = inputNumber "Exponent"
            exponent x y |> displayResult
        | 6 ->
            let x = inputNumber "Number"
            root x |> displayResult
        | 7 ->
            let x = inputNumber "Angle (°)"
            sine x |> displayResult
        | 8 ->
            let x = inputNumber "Angle (°)"
            cosine x |> displayResult
        | 9 ->
            let x = inputNumber "Angle (°)"
            tangent x |> displayResult
        | 0 ->
            printfn "Goodbye!"
        | _ ->
            printfn "Invalid selection. Try again."

    let rec mainLoop () =
        showBanner ()
        match Int32.TryParse(Console.ReadLine()) with
        | true, 0 -> ()
        | true, opt ->
            execute opt
            mainLoop ()
        | _ ->
            printfn "Invalid input. Please enter a digit."
            mainLoop ()

[<EntryPoint>]
let main _ =
    CLI.mainLoop ()
    0
