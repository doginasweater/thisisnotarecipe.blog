namespace Components

open Feliz

[<AutoOpen>]
module Button =
  type ButtonType =
    | None
    | Primary
    | Secondary
    | Accent
    | Info
    | Success
    | Warning
    | Error
    | Ghost

  type ButtonSize =
    | Large
    | Normal
    | Small
    | Tiny

  type ButtonVariant =
    | Regular
    | Link
    | Outline
    | Active

  let mapBtnClass type' =
    match type' with
    | None -> ""
    | Primary -> "btn-primary"
    | Secondary -> "btn-secondary"
    | Accent -> "btn-accent"
    | Info -> "btn-info"
    | Success -> "btn-success"
    | Warning -> "btn-warning"
    | Error -> "btn-warning"
    | Ghost -> "btn-ghost"

  let mapBtnSize size =
    match size with
    | Large -> "btn-lg"
    | Normal -> "btn-md"
    | Small -> "btn-sm"
    | Tiny -> "btn-xs"

  let mapBtnVariant variant =
    match variant with
    | Regular -> ""
    | Link -> "btn-link"
    | Outline -> "btn-outline"
    | Active -> "btn-active"

  type ButtonProps =
    { btnType: ButtonType
      size: ButtonSize
      variant: ButtonVariant
      isDisabled: bool
      isGlass: bool
      text: string
      classes: string list
      onClick: (Browser.Types.MouseEvent -> unit) option
      extraProps: IReactProperty list }

  let private makeButton (props: ButtonProps) =
    Html.button [
      prop.classes [
        "btn"
        mapBtnClass props.btnType
        mapBtnVariant props.variant
        mapBtnSize props.size
        yield! props.classes
      ]
      yield! props.extraProps
      prop.text props.text
      if props.onClick.IsSome then
        prop.onClick props.onClick.Value
    ]

  type ButtonBuilder() =
    let defaultButton =
      { btnType = None
        size = Normal
        variant = Regular
        isDisabled = false
        isGlass = false
        text = ""
        classes = []
        onClick = Option.None
        extraProps = [] }

    member _.Yield _ = defaultButton

    [<CustomOperation("btnType", MaintainsVariableSpace = true)>]
    member _.btnType(props, btnType) = { props with btnType = btnType }

    [<CustomOperation("size", MaintainsVariableSpace = true)>]
    member _.size(props, size) = { props with size = size }

    [<CustomOperation("variant", MaintainsVariableSpace = true)>]
    member _.variant(props, variant) = { props with variant = variant }

    [<CustomOperation("disabled", MaintainsVariableSpace = true)>]
    member _.disabled(props, disabled) = { props with isDisabled = disabled }

    [<CustomOperation("glass", MaintainsVariableSpace = true)>]
    member _.glass(props, glass) = { props with isGlass = glass }

    [<CustomOperation("props", MaintainsVariableSpace = true)>]
    member _.extraProps(props, extra) = { props with extraProps = extra }

    [<CustomOperation("classes", MaintainsVariableSpace = true)>]
    member _.classes(props, classes) = { props with classes = classes }

    [<CustomOperation("text", MaintainsVariableSpace = true)>]
    member _.text(props, text) = { props with text = text }

    [<CustomOperation("onClick", MaintainsVariableSpace = true)>]
    member _.onClick(props, onClick) = { props with onClick = Some onClick }

    member _.Run props = makeButton props

  let button = new ButtonBuilder()