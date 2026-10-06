import React, {useState} from "react";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import "./../../../public/login.css";
import { FaUserAlt } from "react-icons/fa";
import { FaLock } from "react-icons/fa";
import { useAuth } from "../Auth/AuthContext";
import { jwtDecode } from "jwt-decode";

function login(){
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
    const [error, setError] = useState("");
    const [updateState, setState] = useState({
      loginInputUser: false,
      loginInputPassword: false,
      loginButtonContinue: false,
      loginButtonSign: false
    });
    const [removeTitle, setTitle] = useState(false);
    const { setIsAuthenticated } = useAuth(); 

    function handleUsername(event){
      const value = event.target.value;
      setUsername(value);
    }

    function handlePassword(event){
      const value = event.target.value;
      setPassword(value);
    }

    function handleMouseStatus(event){
      const name = event.currentTarget.getAttribute("name");
      
      switch (name) {
        case "User":
          setState(prevValue => ({
            ...prevValue,
            loginInputUser: !prevValue.loginInputUser
          }));
          break;
        case "Password":
          setState(prevValue => ({
            ...prevValue,
            loginInputPassword: !prevValue.loginInputPassword
          }));
          break;
        case "BtnContinue":
          setState(prevValue => ({
            ...prevValue,
            loginButtonContinue: !prevValue.loginButtonContinue
          }));
          break;
        case "BtnSignUp":
          setState(prevValue => ({
            ...prevValue,
            loginButtonSign: !prevValue.loginButtonSign
          }));
          break;
              
        default:
          break;
      }
    }

    async function handleSubmit(event){
      event.preventDefault();
      setTitle(true);
      
       try{
        const loginData = {
          Username: username,
          Password: password
         };
          const response = await axios.post("http://localhost:8095/Users/Login", loginData, {
            headers: {
              "Content-Type": "application/json",  // Ensure JSON content type is set
            }});
          console.log("Data submitted:", response.data);
            localStorage.setItem("token", response.data.jwtToken);
            localStorage.setItem("userID", response.data.id);
            const decode = jwtDecode(response.data.jwtToken);
            const roleclaim = Object.keys(decode).find(key=>key.includes("role"));
            const role = decode[roleclaim];
            localStorage.setItem("role", role);
            console.log(role);
            setIsAuthenticated(true);
            console.log("Y");
            navigate("/");
            if(role === "Admin")
              navigate("/admin_dashboard");
        } catch (error) {
          setError("The username or password you entered is incorrect. Please try again.");
         
        }

    }
    function SignUp(){
      navigate("/register");
    }

  return <div className="loginForm">
    <p>{error}</p>
    <h1 className={removeTitle ? "removeTitles" : ""}>Welcome to my English QA</h1>
    <h2 className={removeTitle ? "removeTitles" : ""}>Please login to access the questions or create an account</h2>
    <form >
    <div onMouseOver={handleMouseStatus} onMouseOut={handleMouseStatus} name="User" 
    className={updateState.loginInputUser ? "loginInputs setColor-animation" : "loginInputs"}>
    <span className="icon"><FaUserAlt /></span>
    <input type="text" onChange={handleUsername} placeholder="User Name"/></div>

    <br/>

    <div onMouseOver={handleMouseStatus} onMouseOut={handleMouseStatus} name="Password" 
    className={updateState.loginInputPassword ? "loginInputs setColor-animation" : "loginInputs"}>
    <span className="icon"><FaLock /></span>
    <input type="password" onChange={handlePassword} placeholder="Password"/></div>

    <br/>
    <button onMouseOver={handleMouseStatus} onMouseOut={handleMouseStatus} name="BtnContinue" 
    className={updateState.loginButtonContinue ? "loginInputs typeBut setColor-animation" :"loginInputs typeBut"}
     onClick={handleSubmit}>Continue</button>

    <button onMouseOver={handleMouseStatus} onMouseOut={handleMouseStatus} name="BtnSignUp" 
    className={updateState.loginButtonSign ? "loginInputs typeBut setColor-animation" :"loginInputs typeBut"}
     onClick={SignUp}>Sign Up</button>

    </form>
    <br/>
    
  </div>  

}

export default login;