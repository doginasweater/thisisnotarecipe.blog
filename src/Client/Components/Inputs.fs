namespace Components

open Feliz

[<RequireQualifiedAccess>]
module Inputs =
  let text (labelText: string) (props: IReactProperty list) =
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
        Html.input [
          yield! props
          prop.type'.text
          prop.classes [
            "input"
            "input-bordered"
            "w-full"
            "max-w-xs"
          ]
        ]
      ]
    ]