import React from "react";

export function handleMouseOverOut(event, setState) {
  const name = event.target.value;
  setState(prev => ({
    ...prev,
    [name]: !prev[name],
  }));
}
export default handleMouseOverOut;