import React from "react";
import { Col, Row } from "reactstrap";

export default () => (
  <>
    <h2 className="mb-4">Pressure Cooker Sesame Chicken</h2>
    <h3 className="mb-2">Ingredients</h3>
    <Row>
      <Col>
        <ul>
          <li>
            4 large boneless skinless chicken breasts, diced (about 2 lbs.)
          </li>
          <li>Freshly ground pepper and salt</li>
          <li>1 tablespoon vegetable oil</li>
          <li>1/2 cup diced onion</li>
          <li>2 cloves garlic, minced</li>
          <li>1/2 cup soy sauce*</li>
          <li>1/4 cup ketchup</li>
        </ul>
      </Col>
      <Col>
        <ul>
          <li>1/2 cup honey*</li>
          <li>1/4 teaspoon red pepper flakes</li>
          <li>2 tablespoons cornstarch</li>
          <li>3 tablespoons water</li>
          <li>2 green onions, chopped</li>
          <li>Sesame seeds, toasted</li>
        </ul>
      </Col>
    </Row>
    <h3 className="mb-2">Instructions</h3>
    <Row>
      <Col>
        <ol>
          <li>Season chicken with freshly ground pepper.</li>
          <li>Preheat pressure cooking pot using the saute setting.</li>
          <li>
            Add oil, onion, garlic, and chicken to the pot and saute stirring
            occasionally until onion is softened, about 3 minutes.
          </li>
        </ol>
      </Col>
    </Row>
  </>
);
