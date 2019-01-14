import React from "react";
import { render } from "react-dom";
import { Provider } from "react-redux";
import { BrowserRouter as Router } from "react-router-dom";
import { layout } from "./layout";
import { store } from "./redux/store";
import { routes as r } from "./routes";

import "./styles/app.scss";

import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";

library.add(fas);

const renderApp = (routes: JSX.Element) => {
  render(
    <Provider store={store}>
      <Router>
        {layout({ content: routes })}
      </Router>
    </Provider>,
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
