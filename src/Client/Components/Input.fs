namespace Components

open Feliz

[<AutoOpen>]
module Input =
  type InputType =
    | Text
    | Password

  type InputProps =
    { IsTextArea: bool
      Type: InputType
      Color: ThemeColor option
      Size: Size option
      Placeholder: string option
      Value: string option
      LabelText: string option
      RightLabelText: string option
      HelperText: string option
      RightHelperText: string option
      Disabled: bool
      Bordered: bool
      ExtraProps: IReactProperty seq
      Classes: string seq
      OnChange: (string -> unit) option }

  let private mapInputType inputType =
    match inputType with
    | Text -> prop.type'.text
    | Password -> prop.type'.password

  let private hasTopLabel (props: InputProps) =
    props.LabelText.IsSome
    || props.RightLabelText.IsSome

  let private hasBottomLabel (props: InputProps) =
    props.HelperText.IsSome
    || props.RightHelperText.IsSome

  let private makeInputElement (props: InputProps) =
    Html.input [
      mapInputType props.Type
      if props.Placeholder.IsSome then
        prop.placeholder props.Placeholder.Value
      prop.classes [
        "input"
        if props.Bordered then "input-bordered"
      ]
      if props.OnChange.IsSome then
        prop.onChange props.OnChange.Value
      yield! props.ExtraProps
    ]

  let private makeTextareaElement (props: InputProps) =
    Html.textarea [
      mapInputType props.Type
      if props.Placeholder.IsSome then
        prop.placeholder props.Placeholder.Value
      prop.classes [
        "textarea"
        if props.Bordered then
          "textarea-bordered"
      ]
      if props.OnChange.IsSome then
        prop.onChange props.OnChange.Value
      yield! props.ExtraProps
    ]

  let private makeInput (props: InputProps) =
    Html.div [
      prop.classes [
        "form-control"
        yield! props.Classes
      ]
      prop.children [
        if hasTopLabel props then
          Html.label [
            prop.className "label"
            prop.children [
              if props.LabelText.IsSome then
                Html.span [
                  prop.className "label-text"
                  prop.text props.LabelText.Value
                ]
              if props.RightLabelText.IsSome then
                Html.span [
                  prop.className "label-text-alt"
                  prop.text props.RightLabelText.Value
                ]
            ]
          ]
        match props.IsTextArea with
        | true -> makeTextareaElement props
        | false -> makeInputElement props
        if hasBottomLabel props then
          Html.label [
            prop.className "label"
            prop.children [
              if props.HelperText.IsSome then
                Html.span [
                  prop.className "label-text-alt"
                  prop.text props.HelperText.Value
                ]
              if props.RightHelperText.IsSome then
                Html.span [
                  prop.className "label-text-alt"
                  prop.text props.RightHelperText.Value
                ]
            ]
          ]
      ]
    ]

  type InputBuilder(IsTextArea: bool) =
    let defaultInput =
      { IsTextArea = IsTextArea
        Type = Text
        Color = None
        Size = None
        Placeholder = None
        Value = None
        LabelText = None
        RightLabelText = None
        HelperText = None
        RightHelperText = None
        Disabled = false
        Bordered = true
        ExtraProps = []
        Classes = []
        OnChange = None }

    member _.Yield _ = defaultInput
    member _.Run props = makeInput props

    [<CustomOperation("type", MaintainsVariableSpace = true)>]
    member _.type'(props, type') = { props with Type = type' }

    [<CustomOperation("color", MaintainsVariableSpace = true)>]
    member _.color(props, color) = { props with Color = Some color }

    [<CustomOperation("size", MaintainsVariableSpace = true)>]
    member _.size(props, size) = { props with Size = Some size }

    [<CustomOperation("placeholder", MaintainsVariableSpace = true)>]
    member _.placeholder(props, placeholder) =
      { props with Placeholder = Some placeholder }

    [<CustomOperation("value", MaintainsVariableSpace = true)>]
    member _.value(props, value) = { props with Value = Some value }

    [<CustomOperation("label", MaintainsVariableSpace = true)>]
    member _.label(props, label) = { props with LabelText = Some label }

    [<CustomOperation("rightLabel", MaintainsVariableSpace = true)>]
    member _.rightLabel(props, rightLabel) =
      { props with RightLabelText = Some rightLabel }

    [<CustomOperation("helper", MaintainsVariableSpace = true)>]
    member _.helper(props, helper) = { props with HelperText = Some helper }

    [<CustomOperation("rightHelper", MaintainsVariableSpace = true)>]
    member _.rightHelper(props, rightHelper) =
      { props with RightHelperText = Some rightHelper }

    [<CustomOperation("disabled", MaintainsVariableSpace = true)>]
    member _.disabled(props, disabled) = { props with Disabled = disabled }

    [<CustomOperation("bordered", MaintainsVariableSpace = true)>]
    member _.bordered(props, bordered) = { props with Bordered = bordered }

    [<CustomOperation("extraProps", MaintainsVariableSpace = true)>]
    member _.extraProps(props, extraProps) = { props with ExtraProps = extraProps }

    [<CustomOperation("classes", MaintainsVariableSpace = true)>]
    member _.classes(props, classes) = { props with Classes = classes }

    [<CustomOperation("onChange", MaintainsVariableSpace = true)>]
    member _.onChange(props, onChange) = { props with OnChange = Some onChange }

  let input = new InputBuilder(false)
  let textarea = new InputBuilder(true)