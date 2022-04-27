namespace Components

open Feliz

module ThemePicker =
  let themePicker =
    Html.select [
      prop.classes [
        "select"
        "select-bordered"
      ]
      prop.custom ("data-choose-theme", true)
      prop.children [
        Html.option [
          prop.value "dark"
          prop.text "Dark"
        ]
        Html.option [
          prop.value "synthwave"
          prop.text "Synthwave"
        ]
        Html.option [
          prop.value "night"
          prop.text "Night"
        ]
        Html.option [
          prop.value "cupcake"
          prop.text "Cupcake"
        ]
      ]
    ]