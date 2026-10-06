import React, {useState} from "react";
import { useNavigate } from 'react-router-dom';

function AboutMe(){
  const [updateState, setState] = useState(false);
  const navigate = useNavigate();
function handleClick(){
    navigate("/");
}
function handleMouse(){
    setState((prevValue)=> !prevValue);
}

return (
    <div className="AboutMe">
        
        <p className="Paragraph">
            {<br/>}Hello! My name is Γιώργος Ναβροζίδης.
             I'm a passionate software developer who enjoys 
             building projects that combine creativity with functionality.
              Over time, I’ve worked on various applications — from backend
               systems and full-stack web apps to interactive VR experiences.

            This project is part of my personal journey to improve my skills,
             explore new technologies, and share useful tools with others. I believe 
             in continuous learning and always aim to write clean, efficient code that makes a difference.
        </p>
        <button onMouseOver={handleMouse} onMouseOut={handleMouse} 
        className={updateState? "BackToGenerator animate" : "BackToGenerator"} 
        onClick={handleClick}>Back to Generate Tests</button>
    </div>
)
}

export default AboutMe;