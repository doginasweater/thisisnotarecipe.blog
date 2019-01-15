import React from "react";
import { Link } from "react-router-dom";
import Icon from "./Icon";

type ReferenceProps = {
  text: string;
};

export default ({ text }: ReferenceProps) => (
  <Link to="#">
    <span>{text}</span> <Icon name="info" size="small" />
  </Link>
);
