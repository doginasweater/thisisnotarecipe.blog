namespace Shared

open System

type ImageId = ImageId of Guid

[<CLIMutable>]
type Image =
  { Id: ImageId
    Source: string
    Alt: string }