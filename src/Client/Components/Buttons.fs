namespace Components

open Feliz

[<AutoOpen>]
module Button =
  type ButtonType =
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
    | Link
    | Outline
    | Active

  let mapBtnClass type' =
    match type' with
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
    | Link -> "btn-link"
    | Outline -> "btn-outline"
    | Active -> "btn-active"

  type ButtonProps =
    { btnType: ButtonType option
      size: ButtonSize option
      variant: ButtonVariant option
      isDisabled: bool
      isGlass: bool
      isLoading: bool
      text: string
      classes: string list
      onClick: (Browser.Types.MouseEvent -> unit) option
      extraProps: IReactProperty list }

  let private makeButton (props: ButtonProps) =
    Html.button [
      prop.classes [
        "btn"
        if props.btnType.IsSome then
          mapBtnClass props.btnType.Value
        if props.variant.IsSome then
          mapBtnVariant props.variant.Value
        if props.size.IsSome then
          mapBtnSize props.size.Value
        if props.isDisabled then "btn-disabled"
        if props.isGlass then "glass"
        if props.isLoading then "loading"
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
        size = None
        variant = None
        isDisabled = false
        isGlass = false
        isLoading = false
        text = ""
        classes = []
        onClick = None
        extraProps = [] }

    member _.Yield _ = defaultButton

    [<CustomOperation("btnType", MaintainsVariableSpace = true)>]
    member _.btnType(props, btnType) = { props with btnType = Some btnType }

    [<CustomOperation("size", MaintainsVariableSpace = true)>]
    member _.size(props, size) = { props with size = Some size }

    [<CustomOperation("variant", MaintainsVariableSpace = true)>]
    member _.variant(props, variant) = { props with variant = Some variant }

    [<CustomOperation("disabled", MaintainsVariableSpace = true)>]
    member _.disabled(props, disabled) = { props with isDisabled = disabled }

    [<CustomOperation("glass", MaintainsVariableSpace = true)>]
    member _.glass(props, glass) = { props with isGlass = glass }

    [<CustomOperation("loading", MaintainsVariableSpace = true)>]
    member _.loading(props, loading) = { props with isLoading = loading }

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