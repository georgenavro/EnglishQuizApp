import React,{useState} from "react";
import "./../../../public/admin_NavBar.css";
import { useNavigate } from "react-router-dom";

function admin_navigationBar(){

const navigate = useNavigate();

function handleClick(event){
    const value = event.target.value;
    if(value === "1")
        navigate("/");
    else if(value === "2")
        navigate("/admin_dashboard")
    else if(value === "3")
        navigate("/add_data");
    else {
        localStorage.clear();
        navigate("/login");
    }
}

return (
<div className="navBar">
    <button  value="1" className="admin_NavBar"
    onClick={handleClick}>Start Test</button>

    <button value="2" className="admin_NavBar"
    onClick={handleClick}>Admin Dashboard</button>
    
    <button value="3" className="admin_NavBar"
    onClick={handleClick}>Add-Remove Data</button>

    <button value="4" className="admin_NavBar"
    onClick={handleClick}>Logout</button>

</div>
)
}
export default admin_navigationBar;