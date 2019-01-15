import React from "react";
import { Link, withRouter } from "react-router-dom";
import { Container, Row } from "reactstrap";
import Nav, { NavProps } from "./common/Nav";

type Props = {
  content: JSX.Element;
  appName?: string;
};

const date = new Date();

const navbar = [
  {
    heading: "Search",
    icon: "search",
    links: [
      {
        path: "/",
        label: "Recipe",
        icon: "search",
      },
    ],
  },
  {
    heading: "Categories",
    links: [
      {
        path: "/",
        label: "Breakfast",
        icon: "home",
      },
      {
        path: "dashboard",
        label: "Admin",
        icon: "tools",
      },
    ],
  },
  {
    heading: "Recipes By Cook",
    icon: "users",
    links: [
      {
        path: "/",
        label: "Kevin",
        icon: "user",
      },
      {
        path: "/",
        label: "Steven",
        icon: "user",
      },
      {
        path: "/",
        label: "Chris",
        icon: "user",
      },
      {
        path: "/",
        label: "Aki",
        icon: "user",
      },
      {
        path: "/",
        label: "Danielle",
        icon: "user",
      },
    ],
  },
];

const markup = (props: Props) => {
  const { content, appName } = props;

  return (
    <>
      <nav className="navbar navbar-dark fixed-top flex-md-nowrap shadow light-gray pl-3">
        <Link to="/" className="unstyled-link navbar-brand">
          This Is Not a Recipe Blog
          {appName && `- ${appName}`}
        </Link>
      </nav>
      <Container fluid={true}>
        <Row>
          <nav className="col-md-2 d-none d-md-block sidebar light-gray pl-2">
            <div className="sidebar-sticky p-4">
              {Nav({ headings: navbar })}
            </div>
          </nav>
          <main className="col-md-9 col-lg-10 ml-sm-auto px-5">{content}</main>
        </Row>
      </Container>
      <footer className="footer mt-auto py-3 text-right">
        <Container fluid={true}>
          &copy; {date.getFullYear()} -{" "}
          <a
            href="https://github.com/myopicmage/thisisnotarecipe.blog"
            target="_blank"
          >
            dog in a sweater
          </a>
        </Container>
      </footer>
    </>
  );
};

export const layout = withRouter(markup);
