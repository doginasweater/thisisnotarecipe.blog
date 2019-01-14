import React, { lazy, Suspense } from "react";
import { Route, Switch } from "react-router-dom";

const Dashboard = lazy(() => import("./admin/index"));
const Home = lazy(() => import("./app/home"));

export const routes = (
  <Suspense fallback={<div>Loading...</div>}>
    <Switch>
      <Route path="/" component={Home} />
      <Route path="/dashboard" component={Dashboard} />
    </Switch>
  </Suspense>
);
