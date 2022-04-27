module Components

open Feliz

[<RequireQualifiedAccess>]
module Components =
    let textInput (labelText: string) (props: IReactProperty list) =
        let inputProps =
            props
            @ [ prop.type'.text
                prop.classes [
                    "input"
                    "input-bordered"
                    "w-full"
                    "max-w-xs"
                ] ]

        Html.div [
            prop.classes [
                "form-control"
                "w-full"
                "max-w-xs"
            ]
            prop.children [
                Html.label [
                    prop.classes [ "label" ]
                    prop.children [
                        Html.span [
                            prop.classes [ "label-text" ]
                            prop.text labelText
                        ]
                    ]
                ]
                Html.input inputProps
            ]
        ]