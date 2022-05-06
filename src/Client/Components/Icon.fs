namespace Components

open Feliz

module FA =
  let b name =
    Html.i [
      prop.classes [ "fab"; $"fa-{name}" ]
    ]

  let s name =
    Html.i [
      prop.classes [ "fas"; $"fa-{name}" ]
    ]

  let r name =
    Html.i [
      prop.classes [ "far"; $"fa-{name}" ]
    ]

  let l name =
    Html.i [
      prop.classes [ "fal"; $"fa-{name}" ]
    ]