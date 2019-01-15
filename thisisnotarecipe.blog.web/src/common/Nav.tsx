import React from "react";
import { Link } from "react-router-dom";
import Icon from "./Icon";

import "./nav.scss";

export type NavProps = {
  headings: {
    heading: string;
    icon?: string;
    links: {
      icon: string;
      path: string;
      label: string;
    }[];
  }[];
};

export default ({ headings }: NavProps) =>
  headings.map((heading, hindex) => (
    <div className="nav-group mb-4" key={hindex}>
      <h5>{heading.heading}</h5>
      {heading.links.map((link, lindex) => (
        <Link
          key={lindex}
          to={{ pathname: link.path }}
          className="d-flex align-items-center w-100 pl-2 nav-item text-danger"
        >
          <Icon name={link.icon} /> <div className="ml-2">{link.label}</div>
        </Link>
      ))}
    </div>
  ));
