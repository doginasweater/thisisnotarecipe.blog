import React, { lazy, Suspense } from "react";
import { Link, Route, Switch } from "react-router-dom";
import "./routes.scss";

const Dashboard = lazy(() => import("./admin/index"));
const Home = lazy(() => import("./app/home"));

export const routes = (
  <div>
    <nav>
      <Link to="/">Home</Link> | <Link to="/dashboard">Admin</Link>
    </nav>
    <main>
      <Suspense fallback={<div>Loading...</div>}>
        <Switch>
          <Route path="/" exact={true} component={Home} />
          <Route path="/dashboard" exact={true} component={Dashboard} />
        </Switch>
      </Suspense>
    </main>
  </div>
);
