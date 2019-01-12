import React, { lazy, Suspense } from "react";
import { Link, Route, Switch } from "react-router-dom";
import { Col, Container, Row } from "reactstrap";

const Dashboard = lazy(() => import("./admin/index"));
const Home = lazy(() => import("./app/home"));

export const routes = (
  <Container fluid={true}>
    <Row className="light-gray">
      <Col>
        <nav className="p-2">
          <Row>
            <Col md={10}>
              <h1>THIS IS NOT A RECIPE BLOG</h1>
            </Col>
            <Col>
              <input type="text" className="form-control" placeholder="Search for a recipe" />
            </Col>
          </Row>
        </nav>
      </Col>
    </Row>
    <Row>
      <Col md={2} className="light-gray pl-4">
        <Link to="/">Home</Link><br />
        <Link to="/dashboard">Admin</Link>
      </Col>
      <Col>
        <main className="p-3">
          <Suspense fallback={<div>Loading...</div>}>
            <Switch>
              <Route path="/" exact={true} component={Home} />
              <Route path="/dashboard" exact={true} component={Dashboard} />
            </Switch>
          </Suspense>
        </main>
      </Col>
    </Row>
  </Container>
);
