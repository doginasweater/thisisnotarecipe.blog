module App

open Elmish
open Elmish.React
open Elmish.UrlParser

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram Main.init Main.update Main.view
|> Program.toNavigable (parsePath Router.routeParser) Main.setRoute
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactSynchronous "root"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run