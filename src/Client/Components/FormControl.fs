namespace Components

open Feliz

module FormControl =
  let formControl (children: ReactElement seq) =
    Html.div [
      prop.classes [ "form-control" ]
      prop.children children
    ]