import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";

export type IconProps = {
  name: string;
  size?: "small" | "regular"
};

export default ({ name, size }: IconProps) =>
  <FontAwesomeIcon icon={name} size={size === "small" ? "xs" : "1x"} />;
