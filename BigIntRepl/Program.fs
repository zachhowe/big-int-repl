open System
open System.Numerics

module Program =
  [<EntryPoint>]
  let main _argv =
    let mutable stack: bigint list = []
    let mutable isRunning = true
    
    while isRunning do
      printf "> "
      let cmdParts = Console.ReadLine().Split(' ')
      
      match cmdParts with
      | [| "stop" |] | [| "exit" |] -> // close repl
        isRunning <- false
      | [| "push"; "+" |] -> // push result of add last 2
        let stackLength = (List.length stack)
        let last1 = List.item (stackLength - 1) stack
        let last2 = List.item (stackLength - 2) stack
        stack <- List.removeAt (stackLength - 1) stack
        stack <- List.removeAt (stackLength - 2) stack
        let result = (last1 + last2)
        stack <- List.append stack [result]
      | [| "push"; "*" |] -> // push result of multiply last 2
        let stackLength = (List.length stack)
        let last1 = List.item (stackLength - 1) stack
        let last2 = List.item (stackLength - 2) stack
        stack <- List.removeAt (stackLength - 1) stack
        stack <- List.removeAt (stackLength - 2) stack
        let result = (last1 * last2)
        stack <- List.append stack [result]
      | [| "push"; "++" |] -> // push result of add all
        let result = List.reduce ( + ) stack
        printfn $"%A{result}"
        stack <- [result]
      | [| "push"; "**" |] -> // push result of multiply all
        let result = List.reduce ( * ) stack
        printfn $"%A{result}"
        stack <- [result]
      | [| "push"; value |] -> // push new item in stack
        stack <- List.append stack [BigInteger.Parse value]
      | [| "pop" |]  -> // pop last item in stack
        stack <- List.removeAt ((List.length stack) - 1) stack
      | [| "stack" |] -> // print stack
        printfn $"%A{stack}"
      | [| "+" |] -> // add last 2
        let stackLength = (List.length stack)
        let last1 = List.item (stackLength - 1) stack
        let last2 = List.item (stackLength - 2) stack
        stack <- List.removeAt (stackLength - 1) stack
        stack <- List.removeAt (stackLength - 2) stack
        let result = (last1 + last2)
        printfn $"%A{result}"
      | [| "*" |] -> // multiply last 2
        let stackLength = (List.length stack)
        let last1 = List.item (stackLength - 1) stack
        let last2 = List.item (stackLength - 2) stack
        stack <- List.removeAt (stackLength - 1) stack
        stack <- List.removeAt (stackLength - 2) stack
        let result = (last1 * last2)
        printfn $"%A{result}"
      | [| "++" |] -> // add all
        let result = List.reduce ( + ) stack
        printfn $"%A{result}"
        stack <- []
      | [| "**" |] -> // multiply all
        let result = List.reduce ( * ) stack
        printfn $"%A{result}"
        stack <- []
      | _ -> // default
        printfn "?"
    
    0
