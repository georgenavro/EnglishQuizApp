import React,{useState} from "react";
import "./../../../public/navigationBar.css";
import { useNavigate } from "react-router-dom";

function navigationBar(){
const [updatedState, setState] = useState({
    StartButton : false,
    GeneratedTest: false,
    TestResults : false,
    AboutMe : false,
    Logout : false,
    Admin_DashBoard: false
});
const navigate = useNavigate();
const role = localStorage.getItem("role");

  function handleAnimation(event){
    const value = event.target.value;
    
    switch (value) {
        case "1":
            setState((prevValue) =>({
                ...prevValue,
                StartButton : !prevValue.StartButton
            }));
            break;
        case "2":
            setState((prevValue) =>({
                ...prevValue,
                GeneratedTest : !prevValue.GeneratedTest
            }));
            break;
        case "3":
            setState((prevValue) =>({
                ...prevValue,
                TestResults : !prevValue.TestResults
            }));
            break;
        case "4":
            setState((prevValue) =>({
                ...prevValue,
                AboutMe: !prevValue.AboutMe
            }));
            break;
         case "5":
            setState((prevValue) =>({
                ...prevValue,
                Admin_DashBoard: !prevValue.Admin_DashBoard
            }));
            break;   
        case "6":
            setState((prevValue) =>({
                ...prevValue,
                Logout: !prevValue.Logout
            }));
            break;        
        default:
            break;
    }
    }
function handleClick(event){
    const value = event.target.value;
    if(value === "1")
        navigate("/");
    else if(value === "2")
        navigate("/GeneratedTest")
    else if(value === "3")
        navigate("/TestResults");
    else if(value === "4")
         navigate("/AboutMe");
    else if(value === "5")
         navigate("/admin_dashboard")
    else {
        localStorage.clear();
        navigate("/login");
    }
}

return (
<div className="navBar">
    <button onMouseOver={handleAnimation} onMouseOut={handleAnimation} value="1"
    className={updatedState.StartButton ? "animationButton" : ""}
    onClick={handleClick}>Start Test</button>
    {role === "Admin" ?
    <button onMouseOver={handleAnimation} onMouseOut={handleAnimation} value="5"
    className={updatedState.Admin_DashBoard ? "animationButton" : ""}
    onClick={handleClick}>Admin_Dashboard</button>
    :""}

    <button onMouseOver={handleAnimation} onMouseOut={handleAnimation} value="2"
    className={updatedState.GeneratedTest ? "animationButton" : ""}
    onClick={handleClick}>GeneratedTest</button>
    
    <button onMouseOver={handleAnimation} onMouseOut={handleAnimation} value="3"
    className={updatedState.TestResults ? "animationButton" : ""}
    onClick={handleClick}>Test Results</button>

    <button onMouseOver={handleAnimation} onMouseOut={handleAnimation} value="4"
    className={updatedState.AboutMe ? "animationButton" : ""}
    onClick={handleClick}>AboutMe</button>

    <button onMouseOver={handleAnimation} onMouseOut={handleAnimation} value="6"
    className={updatedState.Logout ? "animationButton" : ""}
    onClick={handleClick}>Logout</button>

</div>
)
}
export default navigationBar;