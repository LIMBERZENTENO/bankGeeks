import React from "react";
import { Textfit } from "react-textfit";
import "./OutputScreen.css";

const OutputScreen = ({ value }) => {
  return (
    <input className="screen" type="number" value={value}></input>
  );
};

export default OutputScreen;
