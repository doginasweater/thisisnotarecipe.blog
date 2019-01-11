import React from "react";
import { Link, Route } from "react-router-dom";
import { Home } from "./app/home";

const Admin = () => <h1>admin</h1>;

export const routes = (
  <div>
    <nav>
      <Link to="/">Home</Link> | <Link to="/dashboard">Admin</Link>
    </nav>
    <main>
      <Route path="/" exact={true} component={Home} />
      <Route path="/dashboard" exact={true} component={Admin} />
    </main>
  </div>
);
