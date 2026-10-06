import React,{useState} from "react";


function Header(props) {

  return (
    <header>
     <h1 className={props.className}>{props.icon}{props.title}</h1>
    </header>
  );
}

export default Header;
