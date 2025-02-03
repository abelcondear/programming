open System.IO
open System

let inline (+=) (x : byref<_>) y = x <- x + y

//------------------------------
//Task: converting this string into new one where the parenthesis are balanced
//------------------------------

let input = ")()()()("
let start_position = 1

let lookup_open str start_from: int32 =
    //function body
    let mutable retval = 0
    let mutable count = 0
    let mutable flag = false

    for chr in str do
        &count += 1

        if count = start_from then (
            flag <- true
        )

        if chr = '(' && flag then (
            flag <- false
            retval <- count            
        )

    retval

let lookup_close str start_from: int32 =
    //function body
    let mutable retval = 0
    let mutable count = 0
    let mutable flag = false

    for chr in str do
        &count += 1

        if count = start_from then (
            flag <- true
        )

        if chr = ')' && flag = true then (
            flag <- false
            retval <- count                       
        )

    retval

let mutable pos_open = lookup_open input start_position

let mutable while_continue = true
while while_continue do
    pos_open <- lookup_open input pos_open
    if pos_open = 0 then ( while_continue <- false )
    else ( printf "openings parentheses counter=%d\n" pos_open )

    if while_continue && pos_open < input.Length then ( 
        &pos_open += 1 //move next position

        let key = System.Console.ReadKey(true)
        if key.KeyChar.Equals(ConsoleKey.Enter) then ( while_continue <- false )    
    )
    else ( 
        while_continue <- false 
    )

printf "\n"
let mutable pos_close = lookup_close input start_position

while_continue <- true
while while_continue do
    pos_close <- lookup_close input pos_close
    if pos_close = 0 then ( while_continue <- false )
    else ( printf "closings parentheses counter=%d\n" pos_close )
        
    if while_continue && pos_close < input.Length then ( 
        &pos_close += 1 //move next position

        let key = System.Console.ReadKey(true)
        if key.KeyChar.Equals(ConsoleKey.Enter) then ( while_continue <- false )        
    )
    else ( 
        while_continue <- false 
    )

printf "Ending program ..."
System.Console.ReadKey(true) |> ignore 

exit(0)
