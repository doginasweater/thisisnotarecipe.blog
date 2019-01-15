import React from "react";
import { Link } from "react-router-dom";
import { Col, Row } from "reactstrap";
import { DropdownItem, DropdownMenu, DropdownToggle, UncontrolledButtonDropdown } from "reactstrap";
import Icon from "../common/Icon";
import Reference from "../common/Reference";

import "./Recipe.scss";

export default () => (
  <>
    <h2 className="mb-2 recipe-title">
      Pressure Cooker Sesame Chicken
    </h2>
    <Row>
      <Col>
        As cooked by <Link to="#">Kevin</Link> & <Link to="#">Steven</Link>
        {" "}- Last made 1 week ago
      </Col>
      <Col className="text-right">
        <a href="https://www.pressurecookingtoday.com/pressure-cooker-honey-sesame-chicken/">
          Original Source
        </a>
      </Col>
    </Row>
    <Row className="mt-4">
      <Col sm={8}>
        <div className="d-flex justify-content-between align-items-center">
          <h4>Ingredients</h4>
        </div>
      </Col>
    </Row>
    <Row className="mb-3">
      <Col>
        <span className="smaller">
          Sort by: <a href="#" className="selected">Order Used</a> | <a href="#">Type</a>
        </span>
      </Col>
    </Row>
    <Row>
      <Col>
        <ul>
          <li>
            4 large boneless skinless chicken breasts, diced (about 2 lbs.)
          </li>
          <li>Freshly ground pepper and salt</li>
          <li>1 tablespoon vegetable oil</li>
          <li>1/2 cup diced onion</li>
          <li>2 <Reference text="cloves garlic" />, minced</li>
          <li>1/2 cup soy sauce*</li>
          <li>1/4 cup ketchup</li>
        </ul>
      </Col>
      <Col>
        <ul>
          <li>
            1/2 cup honey {" "}<a href="#"><Icon name="chevron-down" /></a>
          </li>
          <li>1/4 teaspoon red pepper flakes</li>
          <li>2 tablespoons cornstarch</li>
          <li>3 tablespoons water</li>
          <li>2 green onions, chopped</li>
          <li>Sesame seeds, toasted</li>
        </ul>
      </Col>
      <Col>
        <img src="https://placekitten.com/400/300" /><br />
        <span style={{fontSize: ".8em"}}>Image credit: placekitten</span>
      </Col>
    </Row>
    <h4 className="mb-2">Instructions</h4>
    <Row>
      <Col>
        <ol>
          <li>Season chicken with freshly ground pepper.</li>
          <li>
            Preheat <Reference text="pressure cooking pot" /> using the saute setting.
            {" "}<a href="#"><Icon name="chevron-up" /></a>
            <p>
              <strong>Note from Kevin</strong>: you don't need the lid on when using the sautee setting
            </p>
          </li>
          <li>
            Add oil, onion, garlic, and chicken to the pot and saute stirring
            occasionally until onion is softened, about 3 minutes.
            {" "}<a href="#"><Icon name="chevron-down" /></a>
          </li>
        </ol>
      </Col>
    </Row>
  </>
);
