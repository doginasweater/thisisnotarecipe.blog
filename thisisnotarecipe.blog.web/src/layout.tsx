import React, { lazy, Suspense } from "react";
import { Link, Route, Switch } from "react-router-dom";
import { Col, Container, Row } from "reactstrap";

export const layout = (routes: JSX.Element, appName: string = "") => (
  <>
    <nav className="navbar navbar-dark fixed-top flex-md-nowrap p-2 shadow light-gray">
      <h1>
        This Is Not a Recipe Blog
        {appName && `- ${appName}`}
      </h1>
      <div>
        <input
          type="text"
          className="form-control"
          placeholder="Search for a recipe"
        />
      </div>
    </nav>
    <Container fluid={true}>
      <Row>
        <nav className="col-md-2 d-none d-md-block sidebar light-gray">
          <div className="sidebar-sticky pl-2">
            <Link to="/">Home</Link>
            <br />
            <Link to="/dashboard">Admin</Link>
          </div>
        </nav>
        <main className="col-md-9 col-lg-10 ml-sm-auto px-4">
          {routes}
        </main>
      </Row>
    </Container>
    <footer className="footer mt-auto py-3 text-right">
      <Container fluid={true}>
        &copy; - <a href="https://github.com/myopicmage/thisisnotarecipe.blog" target="_blank">dog in a sweater</a>
      </Container>
    </footer>
  </>
);
