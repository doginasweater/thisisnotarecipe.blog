namespace Components

open Feliz

[<RequireQualifiedAccess>]
module Navbar =
  let navbar =
    Html.div [
      prop.classes [
        "navbar"
        "bg-base-300"
        "p-4"
        "border-b"
        "border-gray-400"
      ]
      prop.children [
        Html.div [
          prop.className "flex-1"
          prop.children [
            Html.a [
              prop.classes [
                "btn"
                "btn-ghost"
                "normal-case"
                "text-xl"
              ]
              prop.href "/"
              prop.text "This Is Not a Recipe Blog"
            ]
          ]
        ]
        Html.div [
          prop.classes [ "flex-none"; "gap-2" ]
          prop.children [
            Html.div ThemePicker.themePicker
            Html.div [
              prop.className "form-control"
              prop.children [
                Html.input [
                  prop.type'.text
                  prop.placeholder "Search"
                  prop.classes [
                    "input"
                    "input-bordered"
                  ]
                ]
              ]
            ]
            Html.div [
              prop.classes [
                "dropdown"
                "dropdown-end"
              ]
              prop.children [
                Html.label [
                  prop.tabIndex 0
                  prop.classes [
                    "btn"
                    "btn-ghost"
                    "btn-circle"
                    "avatar"
                  ]
                  prop.children [
                    Html.div [
                      prop.classes [ "w-10"; "rounded-full" ]
                      prop.children [
                        Html.img [
                          prop.src "https://api.lorem.space/image/face?hash=33791"
                        ]
                      ]
                    ]
                  ]
                ]
                Html.ul [
                  prop.tabIndex 0
                  prop.classes [
                    "mt-3"
                    "p-2"
                    "shadow"
                    "menu"
                    "menu-compact"
                    "dropdown-content"
                    "bg-base-300"
                    "rounded-box"
                    "w-52"
                  ]
                  prop.children [
                    Html.li [
                      Html.a [
                        prop.className "justify-between"
                        prop.children [
                          Html.text "Profile"
                          Html.span [
                            prop.className "badge"
                            prop.text "New"
                          ]
                        ]
                      ]
                    ]
                    Html.li [
                      Html.a [ prop.text "Pick theme" ]
                    ]
                  ]
                ]
              ]
            ]
          ]
        ]
      ]
    ]