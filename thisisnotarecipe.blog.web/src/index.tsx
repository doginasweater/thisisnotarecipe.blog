import React from "react";
import { render } from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import { layout } from "./layout";
import { routes as r } from "./routes";

import "./styles/app.scss";

const renderApp = (routes: JSX.Element) => {
  render(
    <Router>
      {layout(routes)}
    </Router>,
    document.getElementById("root"),
  );
};

renderApp(r);

if (module.hot) {
  module.hot.accept("./routes", () => {
    const { routes } = require("./routes");

    renderApp(routes);
  });
}
