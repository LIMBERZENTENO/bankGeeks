import React, { useState, useEffect } from "react";

import Container from "./components/Container/Container";
import OutputScreen from "./components/OutputScreen/OutputScreen";
import ButtonBox from "./components/ButtonBox/ButtonBox";
import Button from "./components/Button/Button";

const btnValues = [
  [1, 2, 3, "*"],
  [4, 5, 6, "-"],
  [6, 7, 8, "+"],
  [0, ".", "=","/"],
  ["C"]
];

const App = () => {
  let [calc, setCalc] = useState({
    sign: "",
    num: 0,
    res: 0,
  });

  const numEvent = (e) => {
    e.preventDefault();
    const value = e.target.innerHTML;

      setCalc({
        ...calc,
        num:
          calc.num === 0 && value === "0"
            ? "0"
            : calc.num % 1 === 0
            ? Number(calc.num + value)
            : calc.num + value,
        res: !calc.sign ? 0 : calc.res,
      });
  };

  const sign = (e) => {
    setCalc({
      ...calc,
      sign: e.target.innerHTML,
      res: !calc.res && calc.num ? calc.num : calc.res,
      num: 0,
    });
  };

  const equals = () => {
    if (calc.sign && calc.num) {
      const math = (a, b, sign) =>
        sign === "+"
          ? a + b
          : sign === "-"
          ? a - b
          : sign === "*"
          ? a * b
          : a / b;

      setCalc({
        ...calc,
        res:
                math(
                  Number(calc.res),
                  Number(calc.num),
                  calc.sign
               ),
        sign: "",
        num: 0,
      });
    }
    //
    const formData = new FormData();
    formData.append('first_value', Number(calc.res));
    formData.append('second_value', Number(calc.num));
    formData.append('operation', calc.sign);
    const requestOptions = {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json',

        'Accept': 'application/json'
      },
      mode: 'no-cors',
      body: formData
    };
    fetch('https://localhost:7121/api/Calculators', requestOptions)
        .then(response => response.json())
        .then(data => this.setState({ postId: data.id }));
  };

  const clear = () => {
    setCalc({
      ...calc,
      sign: "",
      num: 0,
      res: 0,
    });
  };

  return (
    <Container>
      <h2 align="center">Calculadora</h2>
      <OutputScreen value={calc.num ? calc.num : calc.res} />
      <ButtonBox>
        {btnValues.flat().map((button, i) => {
          return (
            <Button
              key={i}
              value={button}
              onClick={
                button === "C"
                  ? clear
                  : button === "="
                  ? equals
                  : button === "/" || button === "*" || button === "-" || button === "+"
                  ? sign
                  : numEvent
              }
            />
          );
        })}
      </ButtonBox>
    </Container>
  );
};

export default App;
