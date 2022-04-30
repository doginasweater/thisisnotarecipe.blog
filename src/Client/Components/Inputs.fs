namespace Components

open Feliz

[<RequireQualifiedAccess>]
module Inputs =
  let text (labelText: string) (props: IReactProperty list) =
    Html.div [
      prop.classes [ "form-control" ]
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
          ]
        ]
      ]
    ]

  let textarea (labelText: string) (props: IReactProperty list) =
    Html.div [
      prop.classes [ "form-control" ]
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
        Html.textarea [
          yield! props
          prop.classes [
            "textarea"
            "textarea-bordered"
            "h-24"
          ]
        ]
      ]
    ]