module Components

open Feliz

type ButtonType =
    | Success
    | Danger
    | Info
    | Warning
    | Primary
    | Secondary

[<RequireQualifiedAccess>]
module Components =
    let button (buttonType: ButtonType) (text: string) (props: IReactProperty list) =
        let color =
            match buttonType with
            | Primary -> [ "bg-cyan-400" ]
            | Danger ->
                [ "bg-red-700"
                  "text-white"
                  "dark:text-white"
                  "border-red-500" ]
            | Success -> [ "" ]
            | Info -> [ "" ]
            | Warning -> [ "" ]
            | Secondary -> [ "" ]

        let finalProps =
            props
            @ [ prop.type' "button"
                prop.classes (
                    [ "px-4"
                      "py-2"
                      "rounded"
                      "dark:text-slate-800" ]
                    @ color
                )
                prop.text text ]

        Html.button finalProps

    let primaryButton = button Primary
    let dangerButton = button Danger
    let successButton = button Success
    let infoButton = button Info
    let warningButton = button Warning
    let secondaryButton = button Secondary