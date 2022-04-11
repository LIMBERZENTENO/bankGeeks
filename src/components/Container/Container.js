import React from "react";
import "./Container.css";

const Container = ({ children }) => {
  return <div className="wrapper">{children}</div>;
};

export default Container;
